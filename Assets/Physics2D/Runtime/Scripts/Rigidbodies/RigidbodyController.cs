using System.Collections.Generic;
using Physics2D.Runtime.Colliders;
using UnityEngine;

namespace Physics2D.Runtime.Rigidbodies
{
    public class RigidbodyController
    {
        private readonly Context _context;
        private readonly int _pointsCount;

        public RigidbodyController(Transform transform, List<Vector3> collisionPoints)
        {
            _context = new Context(transform, collisionPoints);
            _pointsCount = _context.worldCollisionPoints.Length;
        }
        
        
        public void UpdatePosition()
        {
            _context.currentPosition = _context.transform.localPosition;
            for (var i = 0; i < _pointsCount; i++)
            {
                _context.worldCollisionPoints[i] = _context.transform.TransformPoint(_context.localCollisionPoints[i]);
            }
        }

        public void ExecuteMovement(float deltaTime)
        {
            if (_context.currentReflect.sqrMagnitude > float.Epsilon)
            {
                _context.currentVelocity = _context.currentReflect.normalized * (_context.currentVelocity.magnitude * Random.Range(.55f, 0.95f));
                if (_context.currentVelocity.magnitude < 5f)
                {
                   _context.currentVelocity = _context.currentReflect.normalized * Random.Range(1.5f, 5f);
                }
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
            for (var i = 0; i < _pointsCount; i++)
            {
                var collisionPoint = _context.worldCollisionPoints[i];
                if (!colliderController.ContainsWorldPoint(collisionPoint, out Vector3 normal))
                    continue;

                _context.UpdateCurrentReflect(collisionPoint, normal);
            }
        }
    }
}