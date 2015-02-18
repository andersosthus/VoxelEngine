using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class LoadChunks : MonoBehaviour
    {
        private static readonly WorldPos[] _chunkPositions =
        {
            new WorldPos(0, 0, 0), new WorldPos(-1, 0, 0), new WorldPos(0, 0, -1), new WorldPos(0, 0, 1),
            new WorldPos(1, 0, 0),
            new WorldPos(-1, 0, -1), new WorldPos(-1, 0, 1), new WorldPos(1, 0, -1), new WorldPos(1, 0, 1),
            new WorldPos(-2, 0, 0),
            new WorldPos(0, 0, -2), new WorldPos(0, 0, 2), new WorldPos(2, 0, 0), new WorldPos(-2, 0, -1),
            new WorldPos(-2, 0, 1),
            new WorldPos(-1, 0, -2), new WorldPos(-1, 0, 2), new WorldPos(1, 0, -2), new WorldPos(1, 0, 2),
            new WorldPos(2, 0, -1),
            new WorldPos(2, 0, 1), new WorldPos(-2, 0, -2), new WorldPos(-2, 0, 2), new WorldPos(2, 0, -2),
            new WorldPos(2, 0, 2),
            new WorldPos(-3, 0, 0), new WorldPos(0, 0, -3), new WorldPos(0, 0, 3), new WorldPos(3, 0, 0),
            new WorldPos(-3, 0, -1),
            new WorldPos(-3, 0, 1), new WorldPos(-1, 0, -3), new WorldPos(-1, 0, 3), new WorldPos(1, 0, -3),
            new WorldPos(1, 0, 3),
            new WorldPos(3, 0, -1), new WorldPos(3, 0, 1), new WorldPos(-3, 0, -2), new WorldPos(-3, 0, 2),
            new WorldPos(-2, 0, -3),
            new WorldPos(-2, 0, 3), new WorldPos(2, 0, -3), new WorldPos(2, 0, 3), new WorldPos(3, 0, -2),
            new WorldPos(3, 0, 2),
            new WorldPos(-4, 0, 0), new WorldPos(0, 0, -4), new WorldPos(0, 0, 4), new WorldPos(4, 0, 0),
            new WorldPos(-4, 0, -1),
            new WorldPos(-4, 0, 1), new WorldPos(-1, 0, -4), new WorldPos(-1, 0, 4), new WorldPos(1, 0, -4),
            new WorldPos(1, 0, 4),
            new WorldPos(4, 0, -1), new WorldPos(4, 0, 1), new WorldPos(-3, 0, -3), new WorldPos(-3, 0, 3),
            new WorldPos(3, 0, -3),
            new WorldPos(3, 0, 3), new WorldPos(-4, 0, -2), new WorldPos(-4, 0, 2), new WorldPos(-2, 0, -4),
            new WorldPos(-2, 0, 4),
            new WorldPos(2, 0, -4), new WorldPos(2, 0, 4), new WorldPos(4, 0, -2), new WorldPos(4, 0, 2),
            new WorldPos(-5, 0, 0),
            new WorldPos(-4, 0, -3), new WorldPos(-4, 0, 3), new WorldPos(-3, 0, -4), new WorldPos(-3, 0, 4),
            new WorldPos(0, 0, -5),
            new WorldPos(0, 0, 5), new WorldPos(3, 0, -4), new WorldPos(3, 0, 4), new WorldPos(4, 0, -3),
            new WorldPos(4, 0, 3),
            new WorldPos(5, 0, 0), new WorldPos(-5, 0, -1), new WorldPos(-5, 0, 1), new WorldPos(-1, 0, -5),
            new WorldPos(-1, 0, 5),
            new WorldPos(1, 0, -5), new WorldPos(1, 0, 5), new WorldPos(5, 0, -1), new WorldPos(5, 0, 1),
            new WorldPos(-5, 0, -2),
            new WorldPos(-5, 0, 2), new WorldPos(-2, 0, -5), new WorldPos(-2, 0, 5), new WorldPos(2, 0, -5),
            new WorldPos(2, 0, 5),
            new WorldPos(5, 0, -2), new WorldPos(5, 0, 2), new WorldPos(-4, 0, -4), new WorldPos(-4, 0, 4),
            new WorldPos(4, 0, -4),
            new WorldPos(4, 0, 4), new WorldPos(-5, 0, -3), new WorldPos(-5, 0, 3), new WorldPos(-3, 0, -5),
            new WorldPos(-3, 0, 5),
            new WorldPos(3, 0, -5), new WorldPos(3, 0, 5), new WorldPos(5, 0, -3), new WorldPos(5, 0, 3),
            new WorldPos(-6, 0, 0),
            new WorldPos(0, 0, -6), new WorldPos(0, 0, 6), new WorldPos(6, 0, 0), new WorldPos(-6, 0, -1),
            new WorldPos(-6, 0, 1),
            new WorldPos(-1, 0, -6), new WorldPos(-1, 0, 6), new WorldPos(1, 0, -6), new WorldPos(1, 0, 6),
            new WorldPos(6, 0, -1),
            new WorldPos(6, 0, 1), new WorldPos(-6, 0, -2), new WorldPos(-6, 0, 2), new WorldPos(-2, 0, -6),
            new WorldPos(-2, 0, 6),
            new WorldPos(2, 0, -6), new WorldPos(2, 0, 6), new WorldPos(6, 0, -2), new WorldPos(6, 0, 2),
            new WorldPos(-5, 0, -4),
            new WorldPos(-5, 0, 4), new WorldPos(-4, 0, -5), new WorldPos(-4, 0, 5), new WorldPos(4, 0, -5),
            new WorldPos(4, 0, 5),
            new WorldPos(5, 0, -4), new WorldPos(5, 0, 4), new WorldPos(-6, 0, -3), new WorldPos(-6, 0, 3),
            new WorldPos(-3, 0, -6),
            new WorldPos(-3, 0, 6), new WorldPos(3, 0, -6), new WorldPos(3, 0, 6), new WorldPos(6, 0, -3),
            new WorldPos(6, 0, 3),
            new WorldPos(-7, 0, 0), new WorldPos(0, 0, -7), new WorldPos(0, 0, 7), new WorldPos(7, 0, 0),
            new WorldPos(-7, 0, -1),
            new WorldPos(-7, 0, 1), new WorldPos(-5, 0, -5), new WorldPos(-5, 0, 5), new WorldPos(-1, 0, -7),
            new WorldPos(-1, 0, 7),
            new WorldPos(1, 0, -7), new WorldPos(1, 0, 7), new WorldPos(5, 0, -5), new WorldPos(5, 0, 5),
            new WorldPos(7, 0, -1),
            new WorldPos(7, 0, 1), new WorldPos(-6, 0, -4), new WorldPos(-6, 0, 4), new WorldPos(-4, 0, -6),
            new WorldPos(-4, 0, 6),
            new WorldPos(4, 0, -6), new WorldPos(4, 0, 6), new WorldPos(6, 0, -4), new WorldPos(6, 0, 4),
            new WorldPos(-7, 0, -2),
            new WorldPos(-7, 0, 2), new WorldPos(-2, 0, -7), new WorldPos(-2, 0, 7), new WorldPos(2, 0, -7),
            new WorldPos(2, 0, 7),
            new WorldPos(7, 0, -2), new WorldPos(7, 0, 2), new WorldPos(-7, 0, -3), new WorldPos(-7, 0, 3),
            new WorldPos(-3, 0, -7),
            new WorldPos(-3, 0, 7), new WorldPos(3, 0, -7), new WorldPos(3, 0, 7), new WorldPos(7, 0, -3),
            new WorldPos(7, 0, 3),
            new WorldPos(-6, 0, -5), new WorldPos(-6, 0, 5), new WorldPos(-5, 0, -6), new WorldPos(-5, 0, 6),
            new WorldPos(5, 0, -6),
            new WorldPos(5, 0, 6), new WorldPos(6, 0, -5), new WorldPos(6, 0, 5)
        };

        private readonly List<WorldPos> _buildList = new List<WorldPos>();
        private readonly List<WorldPos> _updateList = new List<WorldPos>();
        public World World;
        private int _timer;

        private void Update()
        {
            DeleteChunks();
            FindChunksToLoad();
            LoadAndRenderChunks();
        }

        private void DeleteChunks()
        {
            if (_timer == 10)
            {
                var chunksToDelete = new List<WorldPos>();
                foreach (var chunk in World.Chunks)
                {
                    var distance = Vector3.Distance(
                        new Vector3(chunk.Value.WorldPos.X, 0, chunk.Value.WorldPos.Z),
                        new Vector3(transform.position.x, 0, transform.position.z));

                    if (distance > 256)
                        chunksToDelete.Add(chunk.Key);
                }

                foreach (var chunk in chunksToDelete)
                    World.DestroyChunk(chunk.X, chunk.Y, chunk.Z);

                _timer = 0;
            }

            _timer++;
        }

        private void BuildChunk(WorldPos pos)
        {
            for (var y = pos.Y - Chunk.ChunkSize; y <= pos.Y + Chunk.ChunkSize; y += Chunk.ChunkSize)
            {
                if (y > 64 || y < -64)
                    continue;

                for (var x = pos.X - Chunk.ChunkSize; x <= pos.X + Chunk.ChunkSize; x += Chunk.ChunkSize)
                {
                    for (var z = pos.Z - Chunk.ChunkSize; z <= pos.Z + Chunk.ChunkSize; z += Chunk.ChunkSize)
                    {
                        if (World.GetChunk(x, y, z) == null)
                            World.CreateChunk(x, y, z);
                    }
                }
            }

            _updateList.Add(pos);
        }

        private void LoadAndRenderChunks()
        {
            for (var i = 0; i < 4; i++)
            {
                if (_buildList.Count == 0)
                    continue;

                BuildChunk(_buildList[0]);
                _buildList.RemoveAt(0);
            }

            for (var i = 0; i < _updateList.Count; i++)
            {
                var chunk = World.GetChunk(_updateList[0].X, _updateList[0].Y, _updateList[0].Z);
                if (chunk != null)
                    chunk.ShouldUpdate = true;

                _updateList.RemoveAt(0);
            }
        }

        private void FindChunksToLoad()
        {
            var playerPos = new WorldPos(
                Mathf.FloorToInt(transform.position.x/Chunk.ChunkSize)*Chunk.ChunkSize,
                Mathf.FloorToInt(transform.position.y/Chunk.ChunkSize)*Chunk.ChunkSize,
                Mathf.FloorToInt(transform.position.z/Chunk.ChunkSize)*Chunk.ChunkSize
                );

            if (_buildList.Count != 0)
                return;

            for (var i = 0; i < _chunkPositions.Length; i++)
            {
                var newChunkPos = new WorldPos(
                    _chunkPositions[i].X*Chunk.ChunkSize + playerPos.X,
                    0,
                    _chunkPositions[i].Z*Chunk.ChunkSize + playerPos.Z);
                var newChunk = World.GetChunk(newChunkPos);
                if (newChunk != null && newChunk.Rendered || _updateList.Contains(newChunkPos))
                    continue;

                for (var y = -4; y < 4; y++)
                    _buildList.Add(new WorldPos(newChunkPos.X, y*Chunk.ChunkSize, newChunkPos.Z));

                return;
            }
        }
    }
}