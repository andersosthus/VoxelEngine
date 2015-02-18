using System;

namespace Assets.Scripts.voxel
{
    [Serializable]
    public struct WorldPos
    {
        public int X;
        public int Y;
        public int Z;

        public WorldPos(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is WorldPos))
                return false;

            var pos = (WorldPos) obj;

            return pos.X == X && pos.Y == Y && pos.Z == Z;
        }
    }
}