using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    [Serializable]
    public class Save
    {
        public Dictionary<WorldPos, Block> Blocks = new Dictionary<WorldPos, Block>();

        public Save(Chunk chunk)
        {
            for (var x = 0; x < Chunk.ChunkSize; x++)
            {
                for (var y = 0; y < Chunk.ChunkSize; y++)
                {
                    for (var z = 0; z < Chunk.ChunkSize; z++)
                    {
                        if (!chunk.Blocks[x, y, z].Changed)
                            continue;

                        var pos = new WorldPos(x, y, z);
                        Blocks.Add(pos, chunk.Blocks[x, y, z]);
                    }
                }
            }
        }
    }
}