using System.Collections.Generic;
using UnityEngine;

namespace Balls.Runtime.Scripts
{
    public class FigureDrawing : MonoBehaviour
    {
        [SerializeField] private FigureData _data;
        [SerializeField] private List<Vector3> _calcVertices = new List<Vector3>();
        [SerializeField] private MeshFilter _meshFilter;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Transform _point;
     
        // Update is called once per frame
        // void Update()
        // {
        //     var t = transform;
        //     var p = t.position;
        //     var up = t.up + p;
        //     var right = t.right + p;
        //     var forward = t.forward + p;
        //     
        //     SetVertices();
        //     _meshFilter.mesh.SetTriangles(_triangles, 0);
        //     _meshFilter.mesh.SetUVs(0, _uvs);
        //
        //     CheckPointInFigure();
        // }

        private bool CheckPointInFigure(Vector3 point)
        {
            for (int i = 0; i <  _data.triangles.Count; i+=3)
            {
                var _f = _calcVertices[_data.triangles[i]]  ; // + firurePosition;
                var _s = _calcVertices[_data.triangles[i+1]]; // + firurePosition;
                var _t = _calcVertices[_data.triangles[i+2]]; // + firurePosition;
                
                var _f1 = (_f.x - point.x) * (_s.y - _f.y) - (_s.x - _f.x) * (_f.y - point.y);
                var _f2 = (_s.x - point.x) * (_t.y - _s.y) - (_t.x - _s.x) * (_s.y - point.y);
                var _f3 = (_t.x - point.x) * (_f.y - _t.y) - (_f.x - _t.x) * (_t.y - point.y);
                
                if ((_f1 >= 0 && _f2 >= 0 && _f3 >= 0) || (_f1 < 0 && _f2 < 0 && _f3 < 0))
                {
                    _meshRenderer.material.color = Color.green;
                    return true;
                }
                else
                {
                    _meshRenderer.material.color = Color.red;
                }
            }
            return false;
        }

        private void SetVertices()
        {
            var t = transform;
            _calcVertices.Clear();
            for (int i = 0; i < _data.vertices.Count; i++)
            {
                var v =  _data.vertices[i];
                _calcVertices.Add(t.TransformPoint(v));
            }
            _meshFilter.mesh.SetVertices( _data.vertices);
            
            //t.Rotate();
        }

        private void OnDrawGizmos()
        {
            SetVertices();
            _meshFilter.mesh.SetTriangles( _data.triangles, 0);
            _meshFilter.mesh.SetUVs(0,  _data.uvs);

            if (_calcVertices == null || _calcVertices.Count == 0)
                return;

            IsFigureContainsPoint(_point.position);
            
            //
            // Gizmos.color = Color.red;
            // Gizmos.DrawSphere(_calcVertices[0], 0.1f);
            //
            // Gizmos.color = Color.blue;
            // Gizmos.DrawSphere(_calcVertices[1], 0.1f);
            //
            // Gizmos.color = Color.yellow;
            // Gizmos.DrawSphere(_calcVertices[2], 0.1f);
            //
            // Gizmos.color = Color.black;
            // Gizmos.DrawLine(_calcVertices[0], _calcVertices[1]);
            // Gizmos.DrawLine(_calcVertices[1], _calcVertices[2]);
            // Gizmos.DrawLine(_calcVertices[2], _calcVertices[0]);
         
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(_calcVertices[0], 0.1f);
            Gizmos.DrawSphere(_calcVertices[1], 0.1f);
            Gizmos.DrawSphere(_calcVertices[2], 0.1f);
            Gizmos.DrawSphere(_calcVertices[3], 0.1f);
        }

        public bool IsFigureContainsPoint(Vector3 point)
        {
            return CheckPointInFigure(_point.position);
        }
    }
}
