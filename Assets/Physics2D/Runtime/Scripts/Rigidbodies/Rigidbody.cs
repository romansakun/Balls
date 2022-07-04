using System.Collections.Generic;
using UnityEngine;

namespace Physics2D.Runtime.Rigidbodies
{
    public class Rigidbody : MonoBehaviour
    {
        [SerializeField] private Physics2DController _controller;

        private void Start()
        {
            _controller.AddRigidbodyController(new RigidbodyController(transform, new List<Vector3>()
            {
                new Vector3(-.1f, 0, 0),
                new Vector3(.1f, 0, 0),
                new Vector3(0, -.1f, 0),
                new Vector3(0, .1f, 0),
                new Vector3(.065f, .065f, 0),
                new Vector3(-.065f, -.065f, 0),
                new Vector3(.065f, -.065f, 0),
                new Vector3(-.065f, .065f, 0),
                new Vector3(0.05f, 0.0725f, 0),
                new Vector3(-0.05f, -0.0725f, 0),
                new Vector3(0.05f, -0.0725f, 0),
                new Vector3(-0.05f, 0.0725f, 0),
                // new Vector3(0.025f, 0.09f, 0),
                // new Vector3(-0.025f, -0.09f, 0),
                // new Vector3(0.025f, -0.09f, 0),
                // new Vector3(-0.025f, 0.09f, 0),
            }));
        }
    }
}