using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MagicaUnity
{
    public class VoxelMeshBuilder
    {
	    private static int[][] Faces =
	    {
		    new[] {0, 1, 2, 2, 3, 0},
		    new[] {0, 3, 2, 2, 1, 0}
	    };
	    
        private List<Vector3> Verts   = new List<Vector3>();
        private List<Vector3> Normals = new List<Vector3>();
        private List<int>     Tris    = new List<int>();
        private List<byte>    Colours = new List<byte>();
        private Voxel?[]      Mask    = new Voxel?[0];
        
        public Mesh BuildMesh(VoxModel Model, Mesh Target, float Scale)
        {
	        /*
	         * These are just working variables for the algorithm - almost all taken 
	         * directly from Mikola Lysenko's javascript implementation.
	         */
	        int Size     = Mathf.Max(Model.Size_X, Model.Size_Y, Model.Size_Z);
	        int Mask_Len = Size * Size;
	        
	        if (Mask.Length < Mask_Len)
	        {
		        //Create a new Mask
		        Mask = new Voxel?[Mask_Len];
	        }
	        else
	        {
		        //Clear the Mask
		        for (int i = 0; i < Mask_Len; i++)
			        Mask[i] = null;
	        }
	        
        	//Loops twice, causing the inner loop to iterate 6 times in total
        	for (int b = 0; b < 2; b++)
            {
        	    //Loops though the 3 Axis
        	    for(int d = 0; d < 3; d++) 
				{
        	        int u = (d + 1) % 3; 
        	        int v = (d + 2) % 3;

                    Vector3 x = default;
                    Vector3 q = default;
        	        x[d] = 1;  
        	        q[d] = 1;

                    Vector3    normal = default;
                    eDirection side   = default;
        	        switch (d)
                    {
	                    case 0:
		                    normal = b == 1 ? Vector3.left    : Vector3.right;
		                    side   = b == 1 ? eDirection.Left : eDirection.Right;
		                    break;
	                    case 1:
		                    normal = b == 1 ? Vector3.down    : Vector3.up;
		                    side   = b == 1 ? eDirection.Down : eDirection.Up;
		                    break;
	                    case 2:
		                    normal = b == 1 ? Vector3.back         : Vector3.forward;
		                    side   = b == 1 ? eDirection.Backwards : eDirection.Forward;
		                    break;
                    }            
			        
                    //Loop From Front to Back         
        	        for(x[d] = -1; x[d] < Size;) 
					{
        	            //Calculate the Mask
        	            x[v] = 0;
        	            for(int n = 0; x[v] < Size; x[v]++) 
						{
        	                for(x[u] = 0; x[u] < Size; x[u]++) 
							{
        	                    Voxel? voxelFace  = x[d] >= 0       ? Model.GetVoxel(x)          : null;
        	                    Voxel? voxelFace1 = x[d] < Size - 1 ? Model.GetVoxel(x + q) : null;
			
        	                    if(voxelFace  != null && (voxelFace.Value.Neighbours  & side) != 0) voxelFace = null;
        	                    if(voxelFace1 != null && (voxelFace1.Value.Neighbours & side) != 0) voxelFace1 = null;
                                
                                Mask[n++] = voxelFace != null && voxelFace1 != null && voxelFace.Value.Index == voxelFace1.Value.Index ? null : b == 1 ? voxelFace1 : voxelFace;
        	                }
        	            }
        	            x[d]++;
			
        	            //Generate Mesh from Mask
        	            for(int j = 0, n = 0; j < Size; j++) 
						{
        	                for(int i = 0; i < Size;) 
							{
								if (Mask[n] == null)
								{
									i++;
									n++;
									continue;
								}
								
								//Calculate Width
								int width = 1;
								for(; i + width < Size && Mask[n + width] != null && Mask[n + width].Value.Index == Mask[n].Value.Index; width++);
		
								//Calculate Height
								int height = 1;
								bool done = false;
								for(; j + height < Size; height++) 
								{
									for(int k = 0; k < width; k++)
									{
										if (Mask[n + k + height * Size] != null &&  Mask[n + k + height * Size].Value.Index == Mask[n].Value.Index) 
											continue;
										
										done = true; 
										break;
									}
		
									if(done) 
										break; 
								}
								x[u] = i;  
								x[v] = j;

								Vector3 du = default;
								Vector3 dv = default;
								du[u] = width;
								dv[v] = height;

								//Build Voxel Verts
								int  Vert_Idx    = Verts.Count;
								byte ColourIndex = Mask[n].Value.Index;
								Verts.Add(x * Scale);
								Verts.Add((x + du) * Scale);
								Verts.Add((x + du + dv) * Scale);
								Verts.Add((x + dv) * Scale);
								
								//Buld Voxel Normals
								for(int l = 0; l < 4; l++)
									Normals.Add(normal);
								
								//Build Voxel Tris
								for(int t = 0; t < 6; t++)
									Tris.Add(Vert_Idx + Faces[b][t]);

								Colours.Add(ColourIndex);
								Colours.Add(ColourIndex);
								
								//Clear Mask
								for(int l = 0; l < height; ++l) 
								{
									for(int k = 0; k < width; ++k) 
										Mask[n + k + l * Size] = null; 
								}
		
								i += width; 
								n += width;
        	                }
        	            } 
        	        }
        	    }        
        	}

            Target.Clear();
	        Target.vertices  = Verts.ToArray();
	        Target.triangles = Tris.ToArray();
	        Target.normals   = Normals.ToArray();
	        Model.Colours    = Colours.ToArray();
	        
            Verts.Clear();
            Normals.Clear();
            Tris.Clear();

            return Target;
        }
    }
}

