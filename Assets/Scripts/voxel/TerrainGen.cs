using Assets.Scripts.voxel.Blocks;
using UnityEngine;

namespace Assets.Scripts.voxel
{
    public class TerrainGen
    {
        private const float DirtBaseHeight = 1;
        private const float DirtNoise = 0.04f;
        private const float DirtNoiseHeight = 3;
        private const float StoneBaseHeight = -24;
        private const float StoneBaseNoise = 0.05f;
        private const float StoneBaseNoiseHeight = 4;
        private const float StoneMinHeight = -12;
        private const float StoneMountainFrequency = 0.008f;
        private const float StoneMountainHeight = 48;
        
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

        private static Chunk ChunkColumnGen(Chunk chunk, int x, int z)
        {
            var stoneHeight = Mathf.FloorToInt(StoneBaseHeight);
            stoneHeight += GetNoise(x, 0, z, StoneMountainFrequency, Mathf.FloorToInt(StoneMountainHeight));

            if (stoneHeight < StoneMinHeight)
                stoneHeight = Mathf.FloorToInt(StoneMinHeight);

            stoneHeight += GetNoise(x, 0, z, StoneBaseNoise, Mathf.FloorToInt(StoneBaseNoiseHeight));

            var dirtHeight = stoneHeight + Mathf.FloorToInt(DirtBaseHeight);
            dirtHeight += GetNoise(x, 100, z, DirtNoise, Mathf.FloorToInt(DirtNoiseHeight));

            for (var y = chunk.WorldPos.Y; y < chunk.WorldPos.Y + Chunk.ChunkSize; y++)
            {
                if (y <= stoneHeight)
                    chunk.SetBlock(x - chunk.WorldPos.X, y - chunk.WorldPos.Y, z - chunk.WorldPos.Z, new Block());
                else if (y <= dirtHeight)
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