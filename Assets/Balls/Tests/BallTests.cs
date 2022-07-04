using System.Collections;
using System.Collections.Generic;
using Balls.Runtime.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class BallTests
{
    private static Ball GetBall()
    {
        var go = Resources.Load<GameObject>("Prefabs/Ball");
        return GameObject.Instantiate<Ball>(go.GetComponent<Ball>());
    }
    
    // A Test behaves as an ordinary method
    // [Test]
    // public void BallTestsSimplePasses()
    // {
    //     
    // }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    [TestCase(0f, 0f, 0f,.05f, ExpectedResult = null)]
    [TestCase(0f, -1f, 3f,.25f, ExpectedResult = null)]
    [TestCase(0.5f, -.866f, 5f,.15f, ExpectedResult = null)]
    [TestCase(-0.5f, -.866f, 5f,.15f, ExpectedResult = null)]
    [TestCase(-0.375f, -.927f, 5f,.15f, ExpectedResult = null)]
    [TestCase(0.375f, -.927f, 10f,.15f, ExpectedResult = null)]
    public IEnumerator StartFlying_WhenCalled_ExpectedPosAfterTimeInterval(float dirX, float dirY, float speed, float timeInterval)
    {
        Resources.Load<GameObject>("Prefabs/Glassful");
        yield return null;
        
        var ball = GetBall();
        ball.Initialize();
        ball.SetPosition(Vector3.zero);
        ball.SetSpeed(speed);
        ball.StartFlying(new Vector3(dirX, dirY, 0));

        yield return new WaitForSeconds(timeInterval);
       
        var expectedDistance = speed * timeInterval;
        var actualDistance = Vector3.Distance(Vector3.zero, ball.transform.position);
        Assert.AreEqual(expectedDistance, actualDistance, 0.05f);
    }

    private List<int> list;

    [SetUp]
    public void SetUp()
    {
        list = new List<int>(10000);
        for (int i = 0; i < 10000; i++)
        {
            list.Add(i);
        }
    }

    [Test]
    public void TestPerformanceListForeach()
    {
        foreach (var e in list)
        {
            var a = e + 1;
        }
    }

    [Test]
    public void TestPerformanceListFor()
    {
        for (var index = 0; index < list.Count; index++)
        {
            var a = list[index] + 1;
        }
    }
    
}

