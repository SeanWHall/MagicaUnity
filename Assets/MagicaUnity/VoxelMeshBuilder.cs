using System.Collections;
using System.Collections.Generic;
using MagicaUnity;
using UnityEngine;

namespace UnityMagica
{
    public class VoxelMeshBuilder
    {
        private List<Vector3> Verts   = new List<Vector3>();
        private List<Vector3> Normals = new List<Vector3>();
        private List<int>     Tris    = new List<int>();
        private List<Voxel>   Voxels  = new List<Voxel>();
        
        public void BuildMesh(VoxModel Model, Mesh Target)
        {
            int Voxels_Len = Model.GetVoxelsNonAlloc(Voxels);

            for (int v = 0; v < Voxels_Len; v++)
            {
                Voxel Current = Voxels[v];
            }
            
            Target.Clear();
            Target.vertices = Verts.ToArray();
            Target.normals = Normals.ToArray();
            Target.triangles = Tris.ToArray();
            
            Verts.Clear();
            Normals.Clear();
            Tris.Clear();
            Voxels.Clear();
        }
    }
}

