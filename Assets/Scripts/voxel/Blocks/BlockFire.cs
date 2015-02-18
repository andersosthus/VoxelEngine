namespace Assets.Scripts.voxel.Blocks
{
    public class BlockFire : Block
    {
        public BlockFire()
        {
        }

        public override bool IsSolid(Constants.Direction direction)
        {
            return false;
        }
    }
}