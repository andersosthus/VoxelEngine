using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Block
    {
        private const float TileSize = 0.25f;
        public bool Changed = true;

        public Block()
        {
        }

        public virtual MeshData BlockData(Chunk chunk, int x, int y, int z, MeshData meshData)
        {
            meshData.UseRenderDataForCollision = true;

            if (!chunk.GetBlock(x, y + 1, z).IsSolid(Constants.Direction.Down))
                meshData = FaceDataUp(chunk, x, y, z, meshData);

            if (!chunk.GetBlock(x, y - 1, z).IsSolid(Constants.Direction.Up))
                meshData = FaceDataDown(chunk, x, y, z, meshData);

            if (!chunk.GetBlock(x, y, z + 1).IsSolid(Constants.Direction.South))
                meshData = FaceDataNorth(chunk, x, y, z, meshData);

            if (!chunk.GetBlock(x, y, z - 1).IsSolid(Constants.Direction.North))
                meshData = FaceDataSouth(chunk, x, y, z, meshData);

            if (!chunk.GetBlock(x + 1, y, z).IsSolid(Constants.Direction.West))
                meshData = FaceDataEast(chunk, x, y, z, meshData);

            if (!chunk.GetBlock(x - 1, y, z).IsSolid(Constants.Direction.East))
                meshData = FaceDataWest(chunk, x, y, z, meshData);

            return meshData;
        }

        protected virtual MeshData FaceDataUp(Chunk chunk, int x, int y, int z, MeshData meshData)
        {
            meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));

            meshData.AddQuadTriangles();
            meshData.Uv.AddRange(FaceUVs(Constants.Direction.Up));
            return meshData;
        }

        protected virtual MeshData FaceDataDown(Chunk chunk, int x, int y, int z, MeshData meshData)
        {
            meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));

            meshData.AddQuadTriangles();
            meshData.Uv.AddRange(FaceUVs(Constants.Direction.Down));
            return meshData;
        }

        protected virtual MeshData FaceDataNorth(Chunk chunk, int x, int y, int z, MeshData meshData)
        {
            meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));

            meshData.AddQuadTriangles();
            meshData.Uv.AddRange(FaceUVs(Constants.Direction.North));
            return meshData;
        }

        protected virtual MeshData FaceDataEast(Chunk chunk, int x, int y, int z, MeshData meshData)
        {
            meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));

            meshData.AddQuadTriangles();
            meshData.Uv.AddRange(FaceUVs(Constants.Direction.East));
            return meshData;
        }

        protected virtual MeshData FaceDataSouth(Chunk chunk, int x, int y, int z, MeshData meshData)
        {
            meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));

            meshData.AddQuadTriangles();
            meshData.Uv.AddRange(FaceUVs(Constants.Direction.South));
            return meshData;
        }

        protected virtual MeshData FaceDataWest(Chunk chunk, int x, int y, int z, MeshData meshData)
        {
            meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));

            meshData.AddQuadTriangles();
            meshData.Uv.AddRange(FaceUVs(Constants.Direction.West));
            return meshData;
        }

        public virtual bool IsSolid(Constants.Direction direction)
        {
            switch (direction)
            {
                case Constants.Direction.North:
                case Constants.Direction.East:
                case Constants.Direction.South:
                case Constants.Direction.West:
                case Constants.Direction.Up:
                case Constants.Direction.Down:
                    return true;
                default:
                    return false;
            }
        }

        public virtual Tile TexturePosition(Constants.Direction direction)
        {
            var tile = new Tile
            {
                X = 0,
                Y = 0
            };

            return tile;
        }

        public virtual Vector2[] FaceUVs(Constants.Direction direction)
        {
            // ReSharper disable once InconsistentNaming
            var UVs = new Vector2[4];
            var tilePos = TexturePosition(direction);

            UVs[0] = new Vector2(TileSize*tilePos.X + TileSize, TileSize*tilePos.Y);
            UVs[1] = new Vector2(TileSize*tilePos.X + TileSize, TileSize*tilePos.Y + TileSize);
            UVs[2] = new Vector2(TileSize*tilePos.X, TileSize*tilePos.Y + TileSize);
            UVs[3] = new Vector2(TileSize*tilePos.X, TileSize*tilePos.Y);

            return UVs;
        }

        public struct Tile
        {
            public int X;
            public int Y;
        }
    }
}