using Physics2D.Runtime.Colliders.Model.Datas;
using UnityEngine;

namespace Physics2D.Runtime.Colliders
{
    public class ColliderController
    {
        private const float EPS = 0.15f;
        private const float MINUS_EPS = -0.15f;
        
        private static readonly Vector3 Zero = new Vector3(0, 0, 0);
        private static readonly Vector3 EdgeDir = new Vector3(1, 0, 0);
        
        private readonly Transform _transform;
        private readonly Vector3[] _localVertices;
        private readonly int[] _triangles;
        private Vector3[] _worldVertices;
        private Vector3 _edgeDir;

        public ColliderController(FigureColliderData data, Transform transform)
        {
            _transform = transform;
            _localVertices = data.LocalVertices;
            _worldVertices = new Vector3[_localVertices.Length];
            _triangles = data.Triangles;
        }
        
        public void UpdateColliderPosition()
        {
            for (var i = 0; i < _localVertices.Length; i++)
            {
                _worldVertices[i] = _transform.TransformPoint(_localVertices[i]);
            }
        }

        public bool ContainsWorldPoint(Vector3 point, out Vector3 normal)
        { 
            normal = Zero;
            _edgeDir = EdgeDir;
            
            Vector3 f;
            Vector3 s; 
            Vector3 t;
            float fistSegment;
            float secondSegment;
            float thirdSegment;
            
            for (var i = 0; i < _triangles.Length; i+=3)
            {
                f = _worldVertices[_triangles[i]];
                s = _worldVertices[_triangles[i+1]]; 
                t = _worldVertices[_triangles[i+2]];
                
                fistSegment = (f.x - point.x) * (s.y - f.y) - (s.x - f.x) * (f.y - point.y);
                secondSegment = (s.x - point.x) * (t.y - s.y) - (t.x - s.x) * (s.y - point.y);
                thirdSegment = (t.x - point.x) * (f.y - t.y) - (f.x - t.x) * (t.y - point.y);
                
                if (fistSegment >= 0 && secondSegment >= 0 && thirdSegment >= 0 || 
                    fistSegment < 0 && secondSegment < 0 && thirdSegment < 0)
                {
                    if (fistSegment >= 0 && fistSegment < EPS || fistSegment > MINUS_EPS)
                    {
                        _edgeDir.x = s.x - f.x;
                        _edgeDir.y = s.y - f.y;
                    }
                    if (secondSegment >= 0 && secondSegment < EPS || secondSegment > MINUS_EPS)
                    {
                        _edgeDir.x = t.x - s.x;
                        _edgeDir.y = t.y - s.y;
                    }
                    if (thirdSegment >= 0 && thirdSegment < EPS || thirdSegment > MINUS_EPS)
                    {
                        _edgeDir.x = f.x - t.x;
                        _edgeDir.y = f.y - t.y;
                    }
                    normal.x = -_edgeDir.y;
                    normal.y = _edgeDir.x;
                    return true;
                }
            }
            return false;
        }
        
    }
}