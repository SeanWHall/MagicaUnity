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

    public static class eDirectionExtensions
    {
        public static Vector3Int GetOffset(this eDirection Direction)
        {
            switch (Direction)
            {
                case eDirection.Up:
                    return new Vector3Int(0, 1, 0);
                case eDirection.Down:
                    return new Vector3Int(0, -1, 0);
                case eDirection.Left:
                    return new Vector3Int(1, 0, 0);
                case eDirection.Right:
                    return new Vector3Int(1, 0, 0);
                case eDirection.Forward:
                    return new Vector3Int(0, 0, 1);
                case eDirection.Backwards:
                    return new Vector3Int(0, 0, -1);
            }
            
            return Vector3Int.zero;
        }
    }
    
    [Serializable]
    public class VoxModel
    {
        public byte Size_X;
        public byte Size_Y;
        public byte Size_Z;
        
        public byte[] Data; //0 = No Voxel
        public Mesh Vox_Mesh;

        public bool IsWithin(VoxPos Pos) => Pos.X < Size_X && Pos.Y < Size_Y && Pos.Z < Size_Z;
        
        public Voxel? GetVoxel(VoxPos Pos)
        {
            if (!IsWithin(Pos))
                return null;
            
            byte Index = Data[To1D(Pos)];
            if (Index == 0)
                return null;
            
            return new Voxel
            {
                Position   = Pos,
                Index      = Index,
                Neighbours = GetNeighbours(Pos)
            };
        }

        public eDirection GetNeighbours(VoxPos Position)
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
                int Neighbour_X = Position.X + X_Offset;
                int Neighbour_Y = Position.Y + Y_Offset;
                int Neighbour_Z = Position.Z + Z_Offset;
                
                if (!VoxPos.IsValidVoxPos(Neighbour_X, Neighbour_Y, Neighbour_Z))
                    return false;
                
                VoxPos Pos = new VoxPos(Neighbour_X, Neighbour_Y, Neighbour_Z);
                return IsWithin(Pos) && Data[To1D(Pos)] != 0;
            }
        }
        
        public void SetIndex(VoxPos Pos, byte Index) => Data[To1D(Pos)] = Index;
        public byte GetIndex(VoxPos Pos)             => Data[To1D(Pos)];

        public int To1D(VoxPos Pos)
        {
            return Pos.X + Pos.Y * Size_X + Pos.Z * Size_X * Size_Y;
        }

        public VoxPos To3D(int i)
        {
            return new VoxPos
            {
                X = (byte)(i % Size_X),
                Y = (byte)(i / Size_X % Size_Y),
                Z = (byte)(i / (Size_X * Size_Y))
            };
        }
    }
    
    public struct Voxel
    {
        public VoxPos     Position;
        public byte       Index;
        public eDirection Neighbours;
    }

    public struct VoxPos
    {
        public byte X;
        public byte Y;
        public byte Z;
        
        public byte this[int i]
        {
            get => i == 0 ? X : i == 1? Y : Z;
            set
            {
                if (i == 0)      X = value;
                else if (i == 1) Y = value;
                else             Z = value;
            }
        }

        public VoxPos(byte X, byte Y, byte Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public VoxPos(int X, int Y, int Z)
        {
            if(!IsValidVoxPos(X, Y, Z))
                throw new SystemException("Attempted to Create VoxPos with a Coords, out of range of 255");
            
            this.X = (byte)X;
            this.Y = (byte)Y;
            this.Z = (byte)Z;
        }
        
        public VoxPos(int[] Coord) : this(Coord[0], Coord[1], Coord[2]) {}

        public static bool IsValidVoxPos(int X, int Y, int Z)
        {
            if (X < Byte.MinValue || X >= Byte.MaxValue) return false;
            if (Y < Byte.MinValue || Y >= Byte.MaxValue) return false;
            if (Z < Byte.MinValue || Z >= Byte.MaxValue) return false;

            return true;
        }

        public override string ToString() => $"(X:{X}, Y:{Y}, Z:{Z})";
        
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() << 2 ^ Z.GetHashCode() >> 2;
        public override bool Equals(object obj) => obj is VoxPos Other && X == Other.X && Y == Other.Y && Z == Other.Z;

        public static VoxPos operator +(VoxPos A, VoxPos B) => new VoxPos(A.X + B.X, A.Y + B.Y, A.Z + B.Z);
        public static VoxPos operator -(VoxPos A, VoxPos B) => new VoxPos(A.X - B.X, A.Y - B.Y, A.Z - B.Z);
        public static VoxPos operator *(VoxPos A, float Val) => new VoxPos((byte)(A.X * Val), (byte)(A.Y * Val), (byte)(A.Z * Val));
        public static VoxPos operator /(VoxPos A, float Val) => new VoxPos((byte)(A.X / Val), (byte)(A.Y / Val), (byte)(A.Z / Val));
        
        public static implicit operator Vector3(VoxPos Pos)    => new Vector3(Pos.X, Pos.Y, Pos.Z);
        public static implicit operator Vector3Int(VoxPos Pos) => new Vector3Int(Pos.X, Pos.Y, Pos.Z);
        public static implicit operator VoxPos(Vector3 Pos)    => new VoxPos((byte)Pos.x, (byte)Pos.y, (byte)Pos.z);
        public static implicit operator VoxPos(Vector3Int Pos) => new VoxPos((byte)Pos.x, (byte)Pos.y, (byte)Pos.z);
    }
}