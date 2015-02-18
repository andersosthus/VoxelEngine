using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class MeshData
    {
        public List<int> ColliderTriangles = new List<int>();
        public List<Vector3> ColliderVerticies = new List<Vector3>();
        public List<int> Triangles = new List<int>();
        public List<Vector2> Uv = new List<Vector2>();
        public List<Vector3> Verticies = new List<Vector3>();
        public bool UseRenderDataForCollision;
        public MeshData()
        {
        }

        public void AddQuadTriangles()
        {
            Triangles.Add(Verticies.Count - 4);
            Triangles.Add(Verticies.Count - 3);
            Triangles.Add(Verticies.Count - 2);

            Triangles.Add(Verticies.Count - 4);
            Triangles.Add(Verticies.Count - 2);
            Triangles.Add(Verticies.Count - 1);

            if (!UseRenderDataForCollision) return;

            ColliderTriangles.Add(ColliderVerticies.Count - 4);
            ColliderTriangles.Add(ColliderVerticies.Count - 3);
            ColliderTriangles.Add(ColliderVerticies.Count - 2);
            ColliderTriangles.Add(ColliderVerticies.Count - 4);
            ColliderTriangles.Add(ColliderVerticies.Count - 2);
            ColliderTriangles.Add(ColliderVerticies.Count - 1);
        }

        public void AddTriangle(int triangle)
        {
            Triangles.Add(triangle);

            if(UseRenderDataForCollision)
                ColliderTriangles.Add(triangle - (Verticies.Count - ColliderVerticies.Count));
        }

        public void AddVertex(Vector3 vertex)
        {
            Verticies.Add(vertex);

            if(UseRenderDataForCollision)
                ColliderVerticies.Add(vertex);
        }
    }
}