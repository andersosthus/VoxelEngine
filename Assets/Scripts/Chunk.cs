using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof (MeshFilter))]
    [RequireComponent(typeof (MeshRenderer))]
    [RequireComponent(typeof (MeshCollider))]
    public class Chunk : MonoBehaviour
    {
        public static int ChunkSize = 16;
        public Block[,,] Blocks = new Block[ChunkSize, ChunkSize, ChunkSize];
        public bool ShouldUpdate = false;
        public bool Rendered = false;
        public World World;
        public WorldPos WorldPos;
        private MeshCollider _collider;
        private MeshFilter _filter;

        public void SetBlocksUnModified()
        {
            foreach (var block in Blocks)
            {
                block.Changed = false;
            }
        }

        public Block GetBlock(int x, int y, int z)
        {
            if (InRange(x) && InRange(y) && InRange(z))
                return Blocks[x, y, z];

            return World.GetBlock(WorldPos.X + x, WorldPos.Y + y, WorldPos.Z + z);
        }

        public void SetBlock(int x, int y, int z, Block block)
        {
            if (InRange(x) && InRange(y) && InRange(z))
                Blocks[x, y, z] = block;
            else
                World.SetBlock(WorldPos.X + x, WorldPos.Y + y, WorldPos.Z + z, block);
        }

        private static bool InRange(int index)
        {
            return index >= 0 && index < ChunkSize;
        }

        private void Start()
        {
            _filter = gameObject.GetComponent<MeshFilter>();
            _collider = gameObject.GetComponent<MeshCollider>();
        }

        private void Update()
        {
            if (!ShouldUpdate)
                return;

            ShouldUpdate = false;
            UpdateChunk();
        }

        // Updates the chunk based on its contents
        private void UpdateChunk()
        {
            Rendered = true;
            var meshData = new MeshData();

            for (var x = 0; x < ChunkSize; x++)
            {
                for (var y = 0; y < ChunkSize; y++)
                {
                    for (var z = 0; z < ChunkSize; z++)
                    {
                        meshData = Blocks[x, y, z].BlockData(this, x, y, z, meshData);
                    }
                }
            }

            RenderMesh(meshData);
        }

        // Sends the calculated mesh information
        // to the mesh and collision components
        private void RenderMesh(MeshData meshData)
        {
            _filter.mesh.Clear();
            _filter.mesh.vertices = meshData.Verticies.ToArray();
            _filter.mesh.triangles = meshData.Triangles.ToArray();

            _filter.mesh.uv = meshData.Uv.ToArray();
            _filter.mesh.RecalculateNormals();

            _collider.sharedMesh = null;
            var mesh = new Mesh
            {
                vertices = meshData.ColliderVerticies.ToArray(),
                triangles = meshData.ColliderTriangles.ToArray()
            };
            mesh.RecalculateNormals();

            _collider.sharedMesh = mesh;
        }
    }
}