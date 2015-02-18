using Assets.Scripts.voxel.Structs;

namespace Assets.Scripts.voxel.Blocks
{
    public class BlockGold : Block
    {
        public BlockGold()
        {
        }

        public override Tile TexturePosition(Constants.Direction direction)
        {
            var tile = new Tile
            {
                X = 3,
                Y = 3
            };

            return tile;
        }
    }
}