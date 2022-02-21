using Physics2D.Runtime.Colliders.Model.Datas;
using UnityEngine;

namespace Physics2D.Runtime.Colliders.Model.CollisionCheckBehaviours
{
    public class CircleCollisionCheckBehaviour : ICollisionCheckBehaviour
    {
        private readonly Transform _transform;
        private readonly float _radius;
        private Vector3 _worldPosition;

        public CircleCollisionCheckBehaviour(CircleColliderData data, Transform transform)
        {
            _transform = transform;
            _radius = data.Radius;
        }
        
        public void UpdateColliderPosition()
        {
            _worldPosition = _transform.position;
        }
        
        public bool ContainsWorldPoint(Vector3 point)
        {
            var diff = new Vector3(
                point.x - _worldPosition.x,
                point.y - _worldPosition.y,
                0);

            return diff.magnitude <= _radius;
        }
    }
}