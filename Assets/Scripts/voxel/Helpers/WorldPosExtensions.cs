namespace Assets.Scripts.voxel.Helpers
{
    public static class WorldPosExtensions
    {
        public static WorldPos CloneWithAdd(this WorldPos source, int x, int y, int z)
        {
            return new WorldPos(source.X + x, source.Y + y, source.Z + z);
        }
    }
}