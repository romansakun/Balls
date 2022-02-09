using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTranslationOnXaxis : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    [SerializeField] private MeshFilter _mesh;
    [SerializeField] private Transform _point;
    [SerializeField] private Transform _diff;
    [SerializeField] private List<Vector2> _uv = new List<Vector2>
    {
        new Vector2(0, 0),
        new Vector2(.5f, .5f),
        new Vector2(1,1)
    };

    public float _f1;
    public float _f2;
    public float _f3;
    
    
    private Vector3 _f;
    private Vector3 _s;
    private Vector3 _t;
    
    void Update()
    {
        _f = _line.GetPosition(0);
        _s = _line.GetPosition(1);
        _t = _line.GetPosition(2);
        
        var p = _point.position;

        _f1 = (_f.x - p.x) * (_s.y - _f.y) - (_s.x - _f.x) * (_f.y - p.y);
        _f2 = (_s.x - p.x) * (_t.y - _s.y) - (_t.x - _s.x) * (_s.y - p.y);
        _f3 = (_t.x - p.x) * (_f.y - _t.y) - (_f.x - _t.x) * (_t.y - p.y);

        if ((_f1 >= 0 && _f2 >= 0 && _f3 >= 0) || (_f1 < 0 && _f2 < 0 && _f3 < 0))
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        _mesh.mesh.SetVertices(new []
        {
            _f, _s, _t
        });
        _mesh.mesh.SetTriangles(new List<int>() {0,1,2}, 0);
        _mesh.mesh.SetUVs(0, _uv);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_f, _t);
    }
}
