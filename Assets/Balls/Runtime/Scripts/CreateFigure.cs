using System;
using System.Collections.Generic;
using UnityEngine;

namespace Balls.Runtime.Scripts
{
    public class CreateFigure : MonoBehaviour
    {
        [SerializeField] private List<Vector3> _vertices = new List<Vector3>
        {
            new Vector3(-1, -1),
            new Vector3(0, 1),
            new Vector3(1, 0),
            new Vector3(-1, -1)
        };
        [SerializeField] private List<Vector3> _calcVertices = new List<Vector3>();
        [SerializeField] private List<Vector2> _uvs = new List<Vector2>
        {
            new Vector2(0, 0),
            new Vector2(.5f, 1),
            new Vector2(1, .5f),
            new Vector2(1, 0f),
        };
        [SerializeField] private List<int> _triangles = new List<int>()
        {
            0,
            1,
            2,
            0,
            2,
            3
        };
        [SerializeField] private MeshFilter _meshFilter;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Transform _point;

        
        void Start()
        {
            _calcVertices = new List<Vector3>();
            _vertices = new List<Vector3>
            {
                new Vector3(-1, -1),
                new Vector3(0, 1),
                new Vector3(1, 0),
                new Vector3(1, -1)
            };
            _triangles = new List<int>()
            {
                0,
                1,
                2,
                0,
                2,
                3
            };
            _uvs = new List<Vector2>
            {
                new Vector2(0, 0),
                new Vector2(.5f, 1),
                new Vector2(1, .5f),
                new Vector2(1, 0f),
            };
        }

        private void OnValidate()
        {
            Start();
        }


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

        private void CheckPointInFigure()
        {
            var t = transform;
            var firurePosition = t.position;
            var point = _point.position;
            var up = t.up + firurePosition;
            var right = t.right + firurePosition;
            var forward = t.forward + firurePosition;

            for (int i = 0; i < _triangles.Count; i+=3)
            {
                var _f = _calcVertices[_triangles[i]]  ; // + firurePosition;
                var _s = _calcVertices[_triangles[i+1]]; // + firurePosition;
                var _t = _calcVertices[_triangles[i+2]]; // + firurePosition;
                
                var _f1 = (_f.x - point.x) * (_s.y - _f.y) - (_s.x - _f.x) * (_f.y - point.y);
                var _f2 = (_s.x - point.x) * (_t.y - _s.y) - (_t.x - _s.x) * (_s.y - point.y);
                var _f3 = (_t.x - point.x) * (_f.y - _t.y) - (_f.x - _t.x) * (_t.y - point.y);
                
                if ((_f1 >= 0 && _f2 >= 0 && _f3 >= 0) || (_f1 < 0 && _f2 < 0 && _f3 < 0))
                {
                    _meshRenderer.material.color = Color.green;
                    return;
                }
                else
                {
                    _meshRenderer.material.color = Color.red;
                }
            }
        }

        private void SetVertices()
        {
            var t = transform;
            
            _calcVertices.Clear();
            for (int i = 0; i < _vertices.Count; i++)
            {
                var v = _vertices[i];
                _calcVertices.Add(t.TransformPoint(v));
            }
            
            _meshFilter.mesh.SetVertices(_vertices);
        }

        private void OnDrawGizmos()
        {
            var t = transform;
            var p = t.position;
            var up = t.up + p;
            var right = t.right + p;
            var forward = t.forward + p;
            
            SetVertices();
            _meshFilter.mesh.SetTriangles(_triangles, 0);
            _meshFilter.mesh.SetUVs(0, _uvs);

            CheckPointInFigure();
            
            // Gizmos.color = Color.red;
            // Gizmos.DrawSphere(up, 0.1f);
            //
            // Gizmos.color = Color.blue;
            // Gizmos.DrawSphere(right, 0.1f);
            //
            // Gizmos.color = Color.yellow;
            // Gizmos.DrawSphere(forward, 0.1f);
            //
            // Gizmos.color = Color.black;
            // Gizmos.DrawLine(p, up);
            // Gizmos.DrawLine(p, right);
            // Gizmos.DrawLine(p, forward);  
            
            if (_calcVertices == null || _calcVertices.Count == 0)
                return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_calcVertices[0], 0.1f);
            
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_calcVertices[1], 0.1f);
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(_calcVertices[2], 0.1f);
            
            Gizmos.color = Color.black;
            Gizmos.DrawLine(_calcVertices[0], _calcVertices[1]);
            Gizmos.DrawLine(_calcVertices[1], _calcVertices[2]);
            Gizmos.DrawLine(_calcVertices[2], _calcVertices[0]);
        }
    }
}
