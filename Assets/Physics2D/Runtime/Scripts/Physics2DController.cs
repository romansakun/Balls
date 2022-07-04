using System.Collections.Generic;
using Physics2D.Runtime.Colliders;
using Physics2D.Runtime.Rigidbodies;
using UnityEngine;

namespace Physics2D.Runtime
{
    public class Physics2DController : MonoBehaviour
    {
        //эти списки можно сделать массивами и инициализировать их нужной длины, а потом просто инкрементить индекс после добавления элементов.
        
        private readonly List<ColliderController> _colliderControllers = new List<ColliderController>(1000);
        private readonly List<RigidbodyController> _rigidbodyControllers = new List<RigidbodyController>(2000);

        
        public void AddRigidbodyController(RigidbodyController rigidbodyController)
        {
            _rigidbodyControllers.Add(rigidbodyController);
        }

        public void AddColliderController(ColliderController colliderController)
        {
            _colliderControllers.Add(colliderController);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
           
            for (int i = 0; i < _colliderControllers.Count; i++)
            {
                var colliderController = _colliderControllers[i];
                colliderController.UpdateColliderPosition();
            
                for (int j = 0; j < _rigidbodyControllers.Count; j++)
                {
                    var rigidbodyController = _rigidbodyControllers[j];
                    rigidbodyController.UpdatePosition();
                    rigidbodyController.ExecuteCollision(colliderController);
                }
            }    
            for (int i = 0; i < _rigidbodyControllers.Count; i++)
            {
                _rigidbodyControllers[i].ExecuteMovement(deltaTime);
            }
        }
    }
}