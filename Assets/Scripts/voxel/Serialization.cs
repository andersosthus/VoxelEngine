using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.voxel.Structs;

namespace Assets.Scripts.voxel
{
    public static class Serialization
    {
        public static string SaveFolder = "voxelGameSave";

        private static string SaveLocation(string worldName)
        {
            var saveLocation = SaveFolder + "/" + worldName + "/";

            if (!Directory.Exists(saveLocation))
                Directory.CreateDirectory(saveLocation);

            return saveLocation;
        }

        private static string FileName(WorldPos chunkLocation)
        {
            var fileName = chunkLocation.X + "_" + chunkLocation.Y + "_" + chunkLocation.Z + ".bin";
            return fileName;
        }

        private static string SaveFile(Chunk chunk)
        {
            var saveFile = SaveLocation(chunk.World.WorldName) + FileName(chunk.WorldPos);

            return saveFile;
        }

        public static void SaveChunk(Chunk chunk)
        {
            var save = new Save(chunk);
            if (save.Blocks.Count == 0)
                return;

            var saveFile = SaveFile(chunk);
            var formatter = new BinaryFormatter();

            using (var stream = new FileStream(saveFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, save);
            }
        }

        public static bool LoadChunk(Chunk chunk)
        {
            var loadfile = SaveFile(chunk);
            if (!File.Exists(loadfile))
                return false;

            Save save;
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(loadfile, FileMode.Open))
            {
                save = (Save) formatter.Deserialize(stream);
            }

            foreach (var block in save.Blocks)
                chunk.Blocks[block.Key.X, block.Key.Y, block.Key.Z] = block.Value;

            return true;
        }
    }
}