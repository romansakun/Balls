using System.Collections.Generic;
using UnityEngine;

namespace Physics2D.Runtime.Rigidbodies
{
    public class Context
    {
        public readonly Transform transform;
        public readonly Vector3[] localCollisionPoints;
        public readonly Vector3[] worldCollisionPoints;
        public Vector3 currentVelocity;
        public Vector3 currentPosition;
        public Vector3 currentReflect;

        public Context(Transform transform, List<Vector3> collisionPoints)
        {
            this.transform = transform;
            localCollisionPoints = collisionPoints.ToArray();
            worldCollisionPoints = collisionPoints.ToArray();
            currentPosition = transform.position;
            currentVelocity = new Vector3();
            currentReflect = Vector3.zero;
        }

        public void UpdateCurrentReflect(Vector3 collisionPoint, Vector3 normal)
        {
            currentReflect.x =  currentReflect.x + currentPosition.x - collisionPoint.x + normal.x;
            currentReflect.y =  currentReflect.y + currentPosition.y - collisionPoint.y + normal.y;
            currentReflect.z = 0;
        }
    }
}