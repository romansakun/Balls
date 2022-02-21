using System.Collections.Generic;
using UnityEngine;

namespace Physics2D.Runtime.Rigidbodies
{
    public class Context
    {
        public Transform transform;
        public Vector3 currentVelocity;
        public Vector3 currentPosition;
        public Vector3 currentReflect;
        public List<Vector3> localCollisionPoints;
        public List<Vector3> worldCollisionPoints;

        public Context(Transform transform, List<Vector3> collisionPoints)
        {
            this.transform = transform;
            localCollisionPoints = new List<Vector3>(collisionPoints);
            worldCollisionPoints = new List<Vector3>(collisionPoints);
            currentPosition = transform.position;
            currentVelocity = new Vector3();
            currentReflect = Vector3.zero;
        }
    }
}