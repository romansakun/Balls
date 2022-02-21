using UnityEngine;

namespace Physics2D.Runtime.Colliders.Model.Datas
{
    public readonly struct FigureColliderData
    {
        public readonly Vector3[] LocalVertices;
        public readonly int[] Triangles;

        public FigureColliderData(Vector3[] localVertices, int[] triangles)
        {
            LocalVertices = localVertices;
            Triangles = triangles;
        }
    }    
}

