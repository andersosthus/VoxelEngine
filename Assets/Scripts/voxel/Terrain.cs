using Assets.Scripts.voxel.Blocks;
using Assets.Scripts.voxel.Structs;
using UnityEngine;

namespace Assets.Scripts.voxel
{
    public static class Terrain
    {
        public static WorldPos GetBlockPos(Vector3 pos)
        {
            var blockPos = new WorldPos(
                Mathf.RoundToInt(pos.x),
                Mathf.RoundToInt(pos.y),
                Mathf.RoundToInt(pos.z)
                );

            return blockPos;
        }

        public static WorldPos GetBlockPos(RaycastHit hit, bool adjacent = false)
        {
            var pos = new Vector3(
                MoveWithinBlock(hit.point.x, hit.normal.x, adjacent),
                MoveWithinBlock(hit.point.y, hit.normal.y, adjacent),
                MoveWithinBlock(hit.point.z, hit.normal.z, adjacent)
                );

            return GetBlockPos(pos);
        }

        public static bool SetBlock(RaycastHit hit, Block block, bool adjacent = false)
        {
            var chunk = hit.collider.GetComponent<Chunk>();
            if (chunk == null)
                return false;

            var pos = GetBlockPos(hit, adjacent);
            chunk.World.SetBlock(pos.X,pos.Y,pos.Z, block);

            return true;
        }

        public static Block GetBlock(RaycastHit hit, bool adjacent = false)
        {
            var chunk = hit.collider.GetComponent<Chunk>();
            if (chunk == null)
                return null;

            var pos = GetBlockPos(hit, adjacent);
            var block = chunk.World.GetBlock(pos.X, pos.Y, pos.Z);

            return block;
        }

        private static float MoveWithinBlock(float pos, float norm, bool adjacent = false)
        {
// ReSharper disable CompareOfFloatsByEqualityOperator
            if (pos - (int) pos == 0.5f || pos - (int) pos == -0.5f)
            {
                if (adjacent)
                    pos += (norm/2);
                else
                    pos -= (norm/2);
            }

            return pos;
// ReSharper restore CompareOfFloatsByEqualityOperator
        }
    }
}