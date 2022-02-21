using System.Collections.Generic;
using UnityEngine;

namespace Balls.Runtime.Scripts
{
    [CreateAssetMenu()]
    public class FigureData: ScriptableObject
    {
        public List<Vector3> vertices = new List<Vector3>
        {
            new Vector3(-1, -1),
            new Vector3(0, 1),
            new Vector3(1, 0),
            new Vector3(-1, -1)
        };
        public List<Vector2> uvs = new List<Vector2>
        {
            new Vector2(0, 0),
            new Vector2(.5f, 1),
            new Vector2(1, .5f),
            new Vector2(1, 0f),
        };
        public List<int> triangles = new List<int>()
        {
            0,
            1,
            2,
            0,
            2,
            3
        };
    }
}