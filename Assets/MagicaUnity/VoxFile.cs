using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicaUnity
{
    public class VoxFile : ScriptableObject
    {
        #region Default Palette
        public static byte[] Default_Palette = new byte[]
        {
            //Line 1
            0, 0, 0, 255,
            255, 255, 255, 255,
            204, 255, 255, 255,
            153, 255, 255, 255,
            102, 255, 255, 255,
            51, 255, 255, 255,
            0, 255, 255, 255,
            255, 204, 255, 255,
            204, 204, 255, 255,
            153, 204, 255, 255,
            102, 204, 255, 255,
            51, 204, 255, 255,
            0, 204, 255, 255,
            255, 153, 255, 255,
            204, 153, 255, 255,
            153, 153, 255, 255,
            
            //Line 2
            102, 153, 255, 255,
            51, 153, 255, 255,
            0, 153, 255, 255,
            255, 102, 255, 255,
            204, 102, 255, 255,
            153, 102, 255, 255,
            102, 102, 255, 255,
            51, 102, 255, 255,
            0, 102, 255, 255,
            255, 51, 255, 255,
            204, 51, 255, 255,
            153, 51, 255, 255,
            102, 51, 255, 255,
            51, 51, 255, 255,
            0, 51, 255, 255,
            255, 0, 255, 255,
            
            //Line 3
            204, 0, 255, 255,
            153, 0, 255, 255,
            102, 0, 255, 255,
            51, 0, 255, 255,
            0, 0, 255, 255,
            255, 255, 204, 255,
            204, 255, 204, 255,
            153, 255, 204, 255,
            102, 255, 204, 255,
            51, 255, 204, 255,
            0, 255, 204, 255,
            255, 204, 204, 255,
            204, 204, 204, 255,
            153, 204, 204, 255,
            102, 204, 204, 255,
            51, 204, 204, 255,
            
            //Line 4
            0, 204, 204, 255,
            255, 153, 204, 255,
            204, 153, 204, 255,
            153, 153, 204, 255,
            102, 153, 204, 255,
            51, 153, 204, 255,
            0, 153, 204, 255,
            255, 102, 204, 255,
            204, 102, 204, 255,
            153, 102, 204, 255,
            102, 102, 204, 255,
            51, 102, 204, 255,
            0, 102, 204, 255,
            255, 51, 204, 255,
            204, 51, 204, 255,
            153, 51, 204, 255,
            
            //Line 5
            102, 51, 204, 255,
            51, 51, 204, 255,
            0, 51, 204, 255,
            255, 0, 204, 255,
            204, 0, 204, 255,
            153, 0, 204, 255,
            102, 0, 204, 255,
            51, 0, 204, 255,
            0, 0, 204, 255,
            255, 255, 153, 255,
            204, 255, 153, 255,
            153, 255, 153, 255,
            102, 255, 153, 255,
            51, 255, 153, 255,
            0, 255, 153, 255,
            255, 204, 153, 255,
            
            //Line 6
            204, 204, 153, 255,
            153, 204, 153, 255,
            102, 204, 153, 255,
            51, 204, 153, 255,
            0, 204, 153, 255,
            255, 153, 153, 255,
            204, 153, 153, 255,
            153, 153, 153, 255,
            102, 153, 153, 255,
            51, 153, 153, 255,
            0, 153, 153, 255,
            255, 102, 153, 255,
            204, 102, 153, 255,
            153, 102, 153, 255,
            102, 102, 153, 255,
            51, 102, 153, 255,
            
            //Line 7
            0, 102, 153, 255,
            255, 51, 153, 255,
            204, 51, 153, 255,
            153, 51, 153, 255,
            102, 51, 153, 255,
            51, 51, 153, 255,
            0, 51, 153, 255,
            255, 0, 153, 255,
            204, 0, 153, 255,
            153, 0, 153, 255,
            102, 0, 153, 255,
            51, 0, 153, 255,
            0, 0, 153, 255,
            255, 255, 102, 255,
            204, 255, 102, 255,
            153, 255, 102, 255,
            
            //Line 8
            102, 255, 102, 255,
            51, 255, 102, 255,
            0, 255, 102, 255,
            255, 204, 102, 255,
            204, 204, 102, 255,
            153, 204, 102, 255,
            102, 204, 102, 255,
            51, 204, 102, 255,
            0, 204, 102, 255,
            255, 153, 102, 255,
            204, 153, 102, 255,
            153, 153, 102, 255,
            102, 153, 102, 255,
            51, 153, 102, 255,
            0, 153, 102, 255,
            255, 102, 102, 255,
            
            //Line 9
            204, 102, 102, 255,
            153, 102, 102, 255,
            102, 102, 102, 255,
            51, 102, 102, 255,
            0, 102, 102, 255,
            255, 51, 102, 255,
            204, 51, 102, 255,
            153, 51, 102, 255,
            102, 51, 102, 255,
            51, 51, 102, 255,
            0, 51, 102, 255,
            255, 0, 102, 255,
            204, 0, 102, 255,
            153, 0, 102, 255,
            102, 0, 102, 255,
            51, 0, 102, 255,
            
            //Line 10
            0, 0, 102, 255,
            255, 255, 51, 255,
            204, 255, 51, 255,
            153, 255, 51, 255,
            102, 255, 51, 255,
            51, 255, 51, 255,
            0, 255, 51, 255,
            255, 204, 51, 255,
            204, 204, 51, 255,
            153, 204, 51, 255,
            102, 204, 51, 255,
            51, 204, 51, 255,
            0, 204, 51, 255,
            255, 153, 51, 255,
            204, 153, 51, 255,
            153, 153, 51, 255,
            
            //Line 11
            102, 153, 51, 255,
            51, 153, 51, 255,
            0, 153, 51, 255,
            255, 102, 51, 255,
            204, 102, 51, 255,
            153, 102, 51, 255,
            102, 102, 51, 255,
            51, 102, 51, 255,
            0, 102, 51, 255,
            255, 51, 51, 255,
            204, 51, 51, 255,
            153, 51, 51, 255,
            102, 51, 51, 255,
            51, 51, 51, 255,
            0, 51, 51, 255,
            255, 0, 51, 255,
            
            //Line 12
            204, 0, 51, 255,
            153, 0, 51, 255,
            102, 0, 51, 255,
            51, 0, 51, 255,
            0, 0, 51, 255,
            255, 255, 0, 255,
            204, 255, 0, 255,
            153, 255, 0, 255,
            102, 255, 0, 255,
            51, 255, 0, 255,
            0, 255, 0, 255,
            255, 204, 0, 255,
            204, 204, 0, 255,
            153, 204, 0, 255,
            102, 204, 0, 255,
            51, 204, 0, 255,
            
            //Line 13
            0, 204, 0, 255,
            255, 153, 0, 255,
            204, 153, 0, 255,
            153, 153, 0, 255,
            102, 153, 0, 255,
            51, 153, 0, 255,
            0, 153, 0, 255,
            255, 102, 0, 255,
            204, 102, 0, 255,
            153, 102, 0, 255,
            102, 102, 0, 255,
            51, 102, 0, 255,
            0, 102, 0, 255,
            255, 51, 0, 255,
            204, 51, 0, 255,
            153, 51, 0, 255,
            
            //Line 14
            102, 51, 0, 255,
            51, 51, 0, 255,
            0, 51, 0, 255,
            255, 0, 0, 255,
            204, 0, 0, 255,
            153, 0, 0, 255,
            102, 0, 0, 255,
            51, 0, 0, 255,
            0, 0, 238, 255,
            0, 0, 221, 255,
            0, 0, 187, 255,
            0, 0, 170, 255,
            0, 0, 136, 255,
            0, 0, 119, 255,
            0, 0, 85, 255,
            0, 0, 68, 255,
            
            //Line 15
            0, 0, 34, 255,
            0, 0, 17, 255,
            0, 238, 0, 255,
            0, 221, 0, 255,
            0, 187, 0, 255,
            0, 170, 0, 255,
            0, 136, 0, 255,
            0, 119, 0, 255,
            0, 85, 0, 255,
            0, 68, 0, 255,
            0, 34, 0, 255,
            0, 17, 0, 255,
            238, 0, 0, 255,
            221, 0, 0, 255,
            187, 0, 0, 255,
            170, 0, 0, 255,
            
            //Line 16
            136, 0, 0, 255,
            119, 0, 0, 255,
            85, 0, 0, 255,
            68, 0, 0, 255,
            34, 0, 0, 255,
            17, 0, 0, 255,
            238, 238, 238, 255,
            221, 221, 221, 255,
            187, 187, 187, 255,
            170, 170, 170, 255,
            136, 136, 136, 255,
            119, 119, 119, 255,
            85, 85, 85, 255,
            68, 68, 68, 255,
            34, 34, 34, 255,
            17, 17, 17, 255
        };
        #endregion
        
        [HideInInspector]
        public VoxModel[] Models;
        [HideInInspector]
        public Byte[]     Palette;
        
        public Color32 GetColor(int Index) => new Color32(Palette[Index * 4 + 0], Palette[Index * 4 + 1], Palette[Index * 4 + 2], Palette[Index * 4 + 3]);
    }

    [Flags]
    public enum eDirection
    {
        Up        = 1 << 1,
        Down      = 1 << 2,
        Left      = 1 << 3,
        Right     = 1 << 4,
        Forward   = 1 << 5,
        Backwards = 1 << 6
    }
    
    [Serializable]
    public class VoxModel
    {
        public byte Size_X;
        public byte Size_Y;
        public byte Size_Z;
        
        public byte[] Data; //0 = No Voxel
        public Mesh Vox_Mesh;

        public Voxel GetVoxel(int i)
        {
            To3D(i, out byte X, out byte Y, out byte Z);
            return GetVoxel(X, Y, Z);
        }
        
        public Voxel GetVoxel(byte X, byte Y, byte Z)
        {
            return new Voxel
            {
                X = X,
                Y = Y,
                Z = Z,
                Index = Data[To1D(X, Y, Z)]
            };
        }

        public eDirection GetNeighbours(byte X, byte Y, byte Z)
        {
            eDirection Directions = 0;

            if (Check( 1, 0, 0)) Directions |= eDirection.Right;
            if (Check(-1, 0, 0)) Directions |= eDirection.Left;
            
            if (Check( 0, 1, 0)) Directions |= eDirection.Up;
            if (Check(0, -1, 0)) Directions |= eDirection.Down;
            
            if (Check( 0, 0, 1)) Directions |= eDirection.Forward;
            if (Check(0, 0, -1)) Directions |= eDirection.Backwards;
            
            return Directions;

            bool Check(int X_Offset, int Y_Offset, int Z_Offset)
            {
                int Neighbour_X = X + X_Offset;
                int Neighbour_Y = Y + Y_Offset;
                int Neighbour_Z = Z + Z_Offset;

                if (Neighbour_X < Byte.MinValue || Neighbour_X >= Byte.MaxValue) return false;
                if (Neighbour_Y < Byte.MinValue || Neighbour_Y >= Byte.MaxValue) return false;
                if (Neighbour_Z < Byte.MinValue || Neighbour_Z >= Byte.MaxValue) return false;

                return Data[To1D((byte) Neighbour_X, (byte) Neighbour_Y, (byte) Neighbour_Z)] != 0;
            }
        }
        
        public void SetIndex(byte X, byte Y, byte Z, byte Index) => Data[To1D(X, Y, Z)] = Index;
        public byte GetIndex(byte X, byte Y, byte Z)             => Data[To1D(X, Y, Z)];

        public int To1D(byte X, byte Y, byte Z)
        {
            return X + Y * Size_X + Z * Size_X * Size_Y;
        }

        public void To3D(int i, out byte X, out byte Y, out byte Z)
        {
            X = (byte)(i % Size_X);
            Y = (byte)(i / Size_X  % Size_Y);
            Z = (byte)(i / (Size_X * Size_Y));
        }

        public int GetVoxelsNonAlloc(List<Voxel> Voxels)
        {
            Voxels.Clear();
            int Voxel_Count = 0; 
            int Data_Len    = Data.Length;
            for (int i = 0; i < Data_Len; i++)
            {
                byte Index = Data[i];
                if(Index == 0)
                    continue;
                Voxels.Add(GetVoxel(i));
                Voxel_Count++;
            }

            return Voxel_Count;
        }

        //Creates Garbage
        public Voxel[] GetVoxels()
        {
            int     Data_Len    = Data.Length;
            int     Voxel_Count = 0;
            Voxel[] Voxels      = new Voxel[Data_Len];
            for (int i = 0; i < Data_Len; i++)
            {
                byte Index = Data[i];
                if(Index == 0)
                    continue;
                
                Voxels[Voxel_Count++] = GetVoxel(i);
            }
            
            Array.Resize(ref Voxels, Voxel_Count);
            return Voxels;
        }
        
        public void BuildVoxMesh()
        {
            //Simple Voxel Generation
            Voxel[] Voxels     = GetVoxels();
            int     Voxels_Len = Voxels.Length;

            for (int v = 0; v < Voxels_Len; v++)
            {
                
            }
        }
    }

    public struct Voxel
    {
        public byte X;
        public byte Y;
        public byte Z;
        public byte Index;
    }
}