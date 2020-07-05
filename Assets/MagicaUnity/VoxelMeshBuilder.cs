using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MagicaUnity
{
    public class VoxelMeshBuilder
    {
        private List<Vector3>   Verts   = new List<Vector3>();
        private List<Vector3>   Normals = new List<Vector3>();
        private List<int>       Tris    = new List<int>();
        private List<Voxel>     Voxels  = new List<Voxel>();

        public void BuildMesh(VoxModel Model, Mesh Target)
        {
	        /*
	         * These are just working variables for the algorithm - almost all taken 
	         * directly from Mikola Lysenko's javascript implementation.
	         */
	        int Size = Mathf.Max(Model.Size_X, Model.Size_Y, Model.Size_Z);
	        Voxel?[] mask = new Voxel? [Size * Size];
			Target.Clear();
			
        	//Loops twice, causing the inner loop to iterate 6 times in total
        	for (int b = 0; b < 2; b++)
            {
        	    //Loops though the 3 Axis
        	    for(int d = 0; d < 3; d++) 
				{
        	        int u = (d + 1) % 3; 
        	        int v = (d + 2) % 3;

                    Vector3Int x = default;
                    Vector3Int q = default;
        	        q[d] = 1;  
        	        q[d] = 1;

                    eDirection side = default;
        	        switch (d)
                    {
	                    case 0:
		                    side = b == 1 ? eDirection.Left   : eDirection.Right;
		                    break;
	                    case 1:
		                    side = b == 1 ? eDirection.Down : eDirection.Up;
		                    break;
	                    case 2:
		                    side = b == 1 ? eDirection.Backwards : eDirection.Forward;
		                    break;
                    }            
			
                    
                    Voxel? voxelFace, voxelFace1;
        	        //Loop From Front to Back         
        	        for(x[d] = -1; x[d] < Size;) 
					{
        	            //Calculate the Mask
        	            x[v] = 0;
        	            for(int n = 0; x[v] < Size; x[v]++) 
						{
        	                for(x[u] = 0; x[u] < Size; x[u]++) 
							{
        	                    voxelFace  = x[d] >= 0       ? Model.GetVoxel(x)          : null;
        	                    voxelFace1 = x[d] < Size - 1 ? Model.GetVoxel(x + q) : null;
			
        	                    if(voxelFace != null && (voxelFace.Value.Neighbours & side) != 0) 
									voxelFace = null;
			
        	                    if(voxelFace1 != null && (voxelFace1.Value.Neighbours & side) != 0) 
									voxelFace1 = null;
			
        	                    mask[n++] = voxelFace != null && voxelFace1 != null && voxelFace.Value.Index == voxelFace1.Value.Index ? null : b == 1 ? voxelFace1 : voxelFace;
        	                }
        	            }
        	            x[d]++;
			
        	            //Generate Mesh from Mask
        	            for(int j = 0, n = 0; j < Size; j++) 
						{
        	                for(int i = 0; i < Size;) 
							{
								if (mask[n] == null)
								{
									i++;
									n++;
									continue;
								}
								
								//Calculate Width
								int width = 1;
								for(; i + width < Size && mask[n + width] != null && mask[n + width].Value.Index == mask[n].Value.Index; width++);
		
								//Calculate Height
								int height = 1;
								bool done = false;
								for(; j + height < Size; height++) 
								{
									for(int k = 0; k < width; k++) 
									{
										if(mask[n + k + height * Size] == null || mask[n + k + height * Size].Value.Index != mask[n].Value.Index) 
										{ 
											done = true; 
											break; 
										}
									}
		
									if(done) 
										break; 
								}
								
								x[u] = i;  
								x[v] = j;

								Vector3Int du = default;
								du[u] = width;

								Vector3Int dv = default;
								dv[v] = height;

								//Build Voxel Verts
								int index = Verts.Count;
								Verts.Add(new Vector3(x[0], x[1], x[2]));
								Verts.Add(new Vector3(x[0] + du[0], x[1] + du[1], x[2] + du[2]));
								Verts.Add(new Vector3(x[0] + du[0] + dv[0], x[1] + du[1] + dv[1], x[2] + du[2] + dv[2]));
								Verts.Add(new Vector3(x[0] + dv[0], x[1] + dv[1], x[2] + dv[2]));
								
								//Build Voxel Tris
								Tris.Add(index);
								if(b == 1)
								{
									Tris.Add(index + 3);
									Tris.Add(index + 2);
									Tris.Add(index + 2);
									Tris.Add(index + 1);
								}
								else
								{
									Tris.Add(index + 1);
									Tris.Add(index + 2);
									Tris.Add(index + 2);
									Tris.Add(index + 3);
								}
								Tris.Add(index);
		
								//Clear Mask
								for(int l = 0; l < height; ++l) 
								{
									for(int k = 0; k < width; ++k) 
										mask[n + k + l * Size] = null; 
								}
		
								i += width; 
								n += width;
        	                }
        	            } 
        	        }
        	    }        
        	}

	        Target.vertices  = Verts.ToArray();
	        Target.triangles = Tris.ToArray();
	        Target.RecalculateNormals();
	        Target.RecalculateBounds();
	        
            Verts.Clear();
            Normals.Clear();
            Tris.Clear();
            Voxels.Clear();
        }
    }
}

