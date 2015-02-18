using System;

namespace Assets.Scripts.voxel.Blocks
{
    [Serializable]
    public class BlockAir : Block
    {
        public BlockAir()
            : base()
        {
        }

        public override MeshData BlockData(Chunk chunk, int x, int y, int z, MeshData meshData)
        {
            return meshData;
        }

        public override bool IsSolid(Constants.Direction direction)
        {
            return false;
        }
    }
}