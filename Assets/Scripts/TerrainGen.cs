using UnityEngine;

namespace Assets.Scripts
{
    public class TerrainGen
    {
        private float _dirtBaseHeight = 1;
        private float _dirtNoise = 0.04f;
        private float _dirtNoiseHeight = 3;
        private float _stoneBaseHeight = -24;
        private float _stoneBaseNoise = 0.05f;
        private float _stoneBaseNoiseHeight = 4;
        private float _stoneMinHeight = -12;
        private float _stoneMountainFrequency = 0.008f;
        private float _stoneMountainHeight = 48;

        public Chunk ChunkGen(Chunk chunk)
        {
            for (var x = chunk.WorldPos.X; x < chunk.WorldPos.X + Chunk.ChunkSize; x++)
            {
                for (var z = chunk.WorldPos.Z; z < chunk.WorldPos.Z + Chunk.ChunkSize; z++)
                {
                    chunk = ChunkColumnGen(chunk, x, z);
                }
            }

            return chunk;
        }

        private Chunk ChunkColumnGen(Chunk chunk, int x, int z)
        {
            var stoneHeight = Mathf.FloorToInt(_stoneBaseHeight);
            stoneHeight += GetNoise(x, 0, z, _stoneMountainFrequency, Mathf.FloorToInt(_stoneMountainHeight));

            if (stoneHeight < _stoneMinHeight)
                stoneHeight = Mathf.FloorToInt(_stoneMinHeight);

            stoneHeight += GetNoise(x, 0, z, _stoneBaseNoise, Mathf.FloorToInt(_stoneBaseNoiseHeight));

            var dirtHeight = stoneHeight + Mathf.FloorToInt(_dirtBaseHeight);
            dirtHeight += GetNoise(x, 100, z, _dirtNoise, Mathf.FloorToInt(_dirtNoiseHeight));

            for (var y = chunk.WorldPos.Y; y < chunk.WorldPos.Y + Chunk.ChunkSize; y++)
            {
                if(y <= stoneHeight)
                    chunk.SetBlock(x - chunk.WorldPos.X, y - chunk.WorldPos.Y, z - chunk.WorldPos.Z, new Block());
                else if( y <= dirtHeight)
                    chunk.SetBlock(x - chunk.WorldPos.X, y - chunk.WorldPos.Y, z - chunk.WorldPos.Z, new BlockGrass());
                else
                    chunk.SetBlock(x - chunk.WorldPos.X, y - chunk.WorldPos.Y, z - chunk.WorldPos.Z, new BlockAir());
            }

            return chunk;
        }

        public static int GetNoise(int x, int y, int z, float scale, int max)
        {
            return Mathf.FloorToInt((Noise.Generate(x*scale, y*scale, z*scale) + 1f)*(max/2f));
        }
    }
}