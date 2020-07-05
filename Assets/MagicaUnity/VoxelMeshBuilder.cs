using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace MagicaUnity
{
    public class VoxelMeshBuilder
    {
        public static eDirection[] Directions  = (eDirection[]) Enum.GetValues(typeof(eDirection)); 
        public static Vector3[]    Voxel_Verts = 
        {
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),
            
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, 0.5f), 
        };

        public static int[][] Voxel_Tris = 
        {
            new[] { 6, 5, 4,    7, 5, 6}, // Up   Face
            new[] { 0, 1, 2,    2, 1, 3}, // Down Face
            
            new[] { 0, 2, 6,    6, 4, 0 }, // Left Face
            new[] { 7, 3, 1,    5, 7, 1 }, // Right Face
            
            new[] { 6, 2, 3,    7, 6, 3 }, // Forwards Face
            new[] { 5, 1, 4,    0, 4, 1 }, // Backwards Face
        };
        
        private List<Vector3> Verts         = new List<Vector3>();
        private List<Vector3> Normals       = new List<Vector3>();
        private List<int>     Tris          = new List<int>();
        private List<Voxel>   Voxels        = new List<Voxel>();
        private int[]         Voxel_Indexes = new int[6];
        
        public void BuildMesh(VoxModel Model, Mesh Target)
        {
            int Dir_Len    = Directions.Length;
            int Voxels_Len = Model.GetVoxelsNonAlloc(Voxels); 
            for (int v = 0; v < Voxels_Len; v++)
            {
                for (int i = 0; i < 6; i++)
                    Voxel_Indexes[i] = -1;
                
                Voxel      Current    = Voxels[v];
                eDirection Neighbours = Model.GetNeighbours(Current.X, Current.Y, Current.Z);
                int        Vert_IDx   = Verts.Count;
                for (int d = 0; d < Dir_Len; d++)
                {
                    if((Neighbours & Directions[d]) != 0)
                        continue;
                    
                    int[] Side = Voxel_Tris[d];
                    //for (int t = 0; t < 6; t++)
                    //    Tris.Add(GetOrAdd());
                }

                int GetOrAdd(int V, int IDx)
                {
                    if (Voxel_Indexes[V] != -1)
                        return Voxel_Indexes[V];

                    Vector3 Vert = Voxel_Verts[IDx];
                    Vert += new Vector3(Current.X, Current.Y, Current.Z);
                    Voxel_Indexes[V] = Verts.Count;
                    Verts.Add(Vert);

                    return Voxel_Indexes[v];
                }
            }
            
            Target.Clear();
            Target.vertices  = Verts.ToArray();
            Target.normals   = Normals.ToArray();
            Target.triangles = Tris.ToArray();
            
            Verts.Clear();
            Normals.Clear();
            Tris.Clear();
            Voxels.Clear();
        }
    }
}

