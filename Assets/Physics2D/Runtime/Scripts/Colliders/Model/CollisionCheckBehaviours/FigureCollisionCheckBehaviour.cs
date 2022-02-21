using Physics2D.Runtime.Colliders.Model.Datas;
using UnityEngine;

namespace Physics2D.Runtime.Colliders.Model.CollisionCheckBehaviours
{
    class FigureCollisionCheckBehaviour : ICollisionCheckBehaviour
    {
        private readonly Transform _transform;
        private readonly Vector3[] _localVertices;
        private readonly int[] _triangles;
        private Vector3[] _worldVertices;

        public FigureCollisionCheckBehaviour(FigureColliderData data, Transform transform)
        {
            _transform = transform;
            _localVertices = data.LocalVertices;
            _triangles = data.Triangles;
        }
        
        public void UpdateColliderPosition()
        {
            _worldVertices = new Vector3[_localVertices.Length];
            for (var i = 0; i < _localVertices.Length; i++)
            {
                _worldVertices[i] = _transform.TransformPoint(_localVertices[i]);
            }
        }
        
        public bool ContainsWorldPoint(Vector3 point)
        {
            for (var i = 0; i < _triangles.Length; i+=3)
            {
                var f = _worldVertices[_triangles[i]];
                var s = _worldVertices[_triangles[i+1]]; 
                var t = _worldVertices[_triangles[i+2]];
                
                var fistSegment = (f.x - point.x) * (s.y - f.y) - (s.x - f.x) * (f.y - point.y);
                var secondSegment = (s.x - point.x) * (t.y - s.y) - (t.x - s.x) * (s.y - point.y);
                var thirdSegment = (t.x - point.x) * (f.y - t.y) - (f.x - t.x) * (t.y - point.y);
                
                if (fistSegment >= 0 && secondSegment >= 0 && thirdSegment >= 0 || 
                    fistSegment < 0 && secondSegment < 0 && thirdSegment < 0)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}