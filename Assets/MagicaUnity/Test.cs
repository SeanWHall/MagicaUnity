using System.Collections.Generic;
using MagicaUnity;
using UnityEngine;

public class Test : MonoBehaviour
{
    private List<Voxel> Voxels = new List<Voxel>();
    public VoxFile File;
    
    private void OnDrawGizmos()
    {
        if (File == null)
            return;

        
        int Voxels_Len = File.Models[0].GetVoxelsNonAlloc(Voxels);
        Gizmos.matrix = transform.localToWorldMatrix;

        for (int i = 0; i < Voxels_Len; i++)
        {
            Voxel Current = Voxels[i];
            
            Gizmos.color = File.GetColor(Current.Index);
            Gizmos.DrawCube(new Vector3(Current.X, Current.Y, Current.Z), Vector3.one);
        }
    }
}
