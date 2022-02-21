using UnityEngine;

namespace Physics2D.Runtime.Colliders.Model.CollisionCheckBehaviours
{
    public interface ICollisionCheckBehaviour
    {
        void UpdateColliderPosition();
        bool ContainsWorldPoint(Vector3 point);
    }
}