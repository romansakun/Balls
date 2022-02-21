using System.Collections.Generic;
using Physics2D.Runtime.Colliders;
using UnityEngine;

namespace Physics2D.Runtime.Rigidbodies
{
    public class RigidbodyController
    {
        private Context _context;

        public RigidbodyController(Transform transform, List<Vector3> collisionPoints)
        {
            _context = new Context(transform, collisionPoints);
        }
        
        
        public void UpdatePosition()
        {
            _context.currentPosition = _context.transform.position;
            for (var i = 0; i < _context.worldCollisionPoints.Count; i++)
            {
                _context.worldCollisionPoints[i] = _context.transform.TransformPoint(_context.localCollisionPoints[i]);
            }
        }

        public void ExecuteMovement(float deltaTime)
        {
            if (_context.currentReflect.sqrMagnitude > float.Epsilon)
            {
                _context.currentVelocity = _context.currentReflect.normalized * (_context.currentVelocity.magnitude * .5f);
            }
            else
            {
                _context.currentVelocity += new Vector3(0, Constants.GravityConstant * deltaTime, 0);
            }

            _context.transform.position += _context.currentVelocity * deltaTime;
            
            _context.currentReflect = Vector3.zero;
        }

        public void ExecuteCollision(ColliderController colliderController)
        {
            foreach (var collisionPoint in _context.worldCollisionPoints)
            {
                if (!colliderController.ContainsWorldPoint(collisionPoint))
                    continue;

                var reflectVector = _context.currentPosition - collisionPoint;
                _context.currentReflect += reflectVector;
            }
        }
    }
}