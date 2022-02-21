// using UnityEngine;
//
// namespace Physics2D.Runtime.Rigidbodies.Model
// {
//     public class RigidbodyModel
//     {
//        
//
//         public ColliderModel(ICollisionCheckBehaviour collisionCheckBehaviour)
//         {
//             SetCollisionCheckBehaviour(collisionCheckBehaviour);
//         }
//
//         public void SetCollisionCheckBehaviour(ICollisionCheckBehaviour collisionCheckBehaviour)
//         {
//             _collisionCheckBehaviour = collisionCheckBehaviour;
//         }
//
//         public void UpdateRigidbodyPosition()
//         {
//             _collisionCheckBehaviour.UpdateColliderPosition();
//         }
//
//         public bool ContainsWorldPoint(Vector3 point)
//         {
//             return _collisionCheckBehaviour.ContainsWorldPoint(point);
//         }
//
//     }
// }
//
