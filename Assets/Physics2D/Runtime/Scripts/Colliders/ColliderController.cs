using Physics2D.Runtime.Colliders.Model;
using UnityEngine;

namespace Physics2D.Runtime.Colliders
{
    public class ColliderController
    {
        private readonly ColliderModel _colliderModel;

        public ColliderController(ColliderModel model)
        {
            _colliderModel = model;
        }
        
        public void UpdateColliderPosition()
        {
            _colliderModel.UpdateColliderPosition();
        }

        public bool ContainsWorldPoint(Vector3 point)
        {
            return _colliderModel.ContainsWorldPoint(point);
        }
    }
}