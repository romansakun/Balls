using Physics2D.Runtime.Colliders;
using Physics2D.Runtime.Colliders.Model.Datas;
using UnityEngine;

namespace Physics2D.Runtime
{
    public class Physics2DInitializer: MonoBehaviour
    {

        [SerializeField] private Physics2DController _controller;
        [SerializeField] private Transform _collider;
        [SerializeField] private Transform _collider2;
        [SerializeField] private Transform _collider3;
        //[SerializeField] private Transform _rigidbody;
 
        private void Start()
        {
            _controller.AddColliderController(new ColliderController(new FigureColliderData(
                new Vector3[]
                {
                    new Vector3(-.5f, -.5f, 0),
                    new Vector3(-.5f, .5f, 0),
                    new Vector3(.5f, .5f, 0),
                    new Vector3(.5f, -.5f, 0)
                },
                new [] {0, 1, 2, 0, 2, 3}
            ), _collider));         
            
            _controller.AddColliderController(new ColliderController(new FigureColliderData(
                new Vector3[]
                {
                    new Vector3(-.5f, -.5f, 0),
                    new Vector3(-.5f, .5f, 0),
                    new Vector3(.5f, .5f, 0),
                    new Vector3(.5f, -.5f, 0)
                },
                new [] {0, 1, 2, 0, 2, 3}
            ), _collider2));  
            
            _controller.AddColliderController(new ColliderController(new FigureColliderData(
                new Vector3[]
                {
                    new Vector3(-.5f, -.5f, 0),
                    new Vector3(-.5f, .5f, 0),
                    new Vector3(.5f, .5f, 0),
                    new Vector3(.5f, -.5f, 0)
                },
                new [] {0, 1, 2, 0, 2, 3}
            ), _collider3));  
            
            // _controller.AddRigidbodyController(new RigidbodyController(_rigidbody, new List<Vector3>()
            // {
            //     new Vector3(-.1f, 0, 0),
            //     new Vector3(.1f, 0, 0),
            //     new Vector3(0, -.1f, 0),
            //     new Vector3(0, .1f, 0),
            //     new Vector3(.065f, .065f, 0),
            //     new Vector3(-.065f, -.065f, 0),
            //     new Vector3(.065f, -.065f, 0),
            //     new Vector3(-.065f, .065f, 0),
            //     new Vector3(0.05f, 0.0725f, 0),
            //     new Vector3(-0.05f, -0.0725f, 0),
            //     new Vector3(0.05f, -0.0725f, 0),
            //     new Vector3(-0.05f, 0.0725f, 0),
            // }));
        }
    }
}