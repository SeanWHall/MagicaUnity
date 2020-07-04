using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using Unity.Mathematics;

using UnityEditor;
using UnityEditor.Experimental.AssetImporters;

namespace MagicaUnity
{
    [CustomEditor(typeof(VoxFileImporterEditor))]
    public class VoxFileImporterEditor : Editor
    {
        
    }

    [ScriptedImporter(1, "vox")]
    public class VoxFileImporter : ScriptedImporter
    {
        private static Dictionary<string, HandleChunk> Handlers = new Dictionary<string,HandleChunk>();

        static VoxFileImporter()
        {
            Handlers["SIZE"] = ProcessSize;
            Handlers["XYZI"] = ProcessXYZI;
            Handlers["RGBA"] = ProcessRGBA;
            Handlers["PACK"] = ProcessPack;
        }

        private static void ProcessPack(VoxFile File, BinaryReader Reader, ChunkInfo Info)
        {
            int numModels = Reader.ReadInt32();
            File.Models = new VoxModel[numModels];
        }
        
        private static void ProcessRGBA(VoxFile File, BinaryReader Reader, ChunkInfo Info)
        {
            byte[] Pallete = File.Palette = new byte [256 * 4];
            for (int i = 0; i < 256; i++)
            {
                for (int c = 0; c < 4; c++)
                    Pallete[i * 4 + c] = Reader.ReadByte();
            }
        }

        private static void ProcessXYZI(VoxFile File, BinaryReader Reader, ChunkInfo Info)
        {
            int numModels = File.Models.Length;
            for (int i = 0; i < numModels; i++)
            {
                VoxModel Model = File.Models[i];
                if(Model.Voxels != null)
                    continue;

                Model.Voxels_Len = Reader.ReadInt32();
                Model.Voxels = new Byte[Model.Voxels_Len * 4];
                
                for (int v = 0; v < Model.Voxels_Len; v++)
                {
                    Model.Voxels[v * 4 + 0] = Reader.ReadByte(); //X
                    Model.Voxels[v * 4 + 1] = Reader.ReadByte(); //Y
                    Model.Voxels[v * 4 + 2] = Reader.ReadByte(); //Z
                    Model.Voxels[v * 4 + 3] = Reader.ReadByte(); //Color
                }

                return;
            }
        }

        private static void ProcessSize(VoxFile File, BinaryReader Reader, ChunkInfo Info)
        {
            if(File.Models == null)
                File.Models = new VoxModel[1];
            
            int numModels = File.Models.Length;
            for (int i = 0; i < numModels; i++)
            {
                if(File.Models[i] != null)
                    continue;

                VoxModel Model = File.Models[i] = new VoxModel();
                Model.Size_X = Reader.ReadInt32();
                Model.Size_Y = Reader.ReadInt32();
                Model.Size_Z = Reader.ReadInt32();
                return;
            }
        }

        private static void ProcessChunk(VoxFile File, BinaryReader Reader, ChunkInfo Info)
        {
            while (Reader.BaseStream.Position < Reader.BaseStream.Length)
            {
                ChunkInfo Chunk = new ChunkInfo(Reader);
                if (!Handlers.TryGetValue(Chunk.ID, out HandleChunk Handler))
                {
                    Reader.BaseStream.Seek(Chunk.Chunk_Bytes + Chunk.Children_Bytes, SeekOrigin.Current);
                    continue;
                }

                using (MemoryStream Chunk_Stream = new MemoryStream(Reader.ReadBytes(Chunk.Total_Bytes)))
                using (BinaryReader Chunk_Reader = new BinaryReader(Chunk_Stream))
                {
                    Handler(File, Chunk_Reader, Chunk);
                }
            }
        }
        
        public override void OnImportAsset(AssetImportContext ctx)
        {
            VoxFile VoxAsset = VoxFile.CreateInstance<VoxFile>();
            
            using (FileStream   Stream = File.Open(ctx.assetPath, FileMode.Open, FileAccess.Read))
            using (BinaryReader Reader = new BinaryReader(Stream))
            {
                if(ReadHeader(Reader)) //Make sure the header is valid
                    ProcessChunk(VoxAsset, Reader, new ChunkInfo(Reader)); //Read Main Chunk
            }

            if (VoxAsset.Palette == null) //If no Palette has been read, assign the default pallete
                VoxAsset.Palette = VoxFile.Default_Palette;
            
            ctx.AddObjectToAsset("VoxFile", VoxAsset);
            ctx.SetMainObject(VoxAsset);
        }

        private bool ReadHeader(BinaryReader Reader)
        {
            if (Reader.BaseStream.Length <= 8)
                return false;
            
            char[] Vox     = Reader.ReadChars(4);
            int    Version = Reader.ReadInt32();
            if (Vox[0] != 'V' || Vox[1] != 'O' || Vox[2] != 'X' || Vox[3] != ' ')
                return false;

            return Version == 150; //Make sure the file version is correct
        }

        delegate void HandleChunk(VoxFile File, BinaryReader Reader, ChunkInfo Info);
        
        class ChunkInfo
        {
            public string ID;
            public int Chunk_Bytes;
            public int Children_Bytes;

            public int Total_Bytes => Chunk_Bytes + Children_Bytes;
            
            public ChunkInfo(BinaryReader Reader)
            {
                ID             = new string(Reader.ReadChars(4));
                Chunk_Bytes    = Reader.ReadInt32();
                Children_Bytes = Reader.ReadInt32();
            }
        }
    }
}
