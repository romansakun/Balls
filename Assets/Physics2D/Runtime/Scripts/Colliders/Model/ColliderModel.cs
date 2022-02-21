using Physics2D.Runtime.Colliders.Model.CollisionCheckBehaviours;
using UnityEngine;

namespace Physics2D.Runtime.Colliders.Model
{
    public class ColliderModel
    {
        private ICollisionCheckBehaviour _collisionCheckBehaviour;

        public ColliderModel(ICollisionCheckBehaviour collisionCheckBehaviour)
        {
            SetCollisionCheckBehaviour(collisionCheckBehaviour);
        }

        public void SetCollisionCheckBehaviour(ICollisionCheckBehaviour collisionCheckBehaviour)
        {
            _collisionCheckBehaviour = collisionCheckBehaviour;
        }

        public void UpdateColliderPosition()
        {
            _collisionCheckBehaviour.UpdateColliderPosition();
        }

        public bool ContainsWorldPoint(Vector3 point)
        {
            return _collisionCheckBehaviour.ContainsWorldPoint(point);
        }

    }
}

