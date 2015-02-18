using System;

namespace Assets.Scripts.voxel
{
    [Serializable]
    public class BlockGrass : Block
    {
        public BlockGrass()
        {
        }

        public override Tile TexturePosition(Constants.Direction direction)
        {
            var tile = new Tile();

            switch (direction)
            {
                case Constants.Direction.Up:
                    tile.X = 2;
                    tile.Y = 0;
                    break;
                case Constants.Direction.Down:
                    tile.X = 1;
                    tile.Y = 0;
                    break;
                default:
                    tile.X = 3;
                    tile.Y = 0;
                    break;
            }

            return tile;
        }
    }
}