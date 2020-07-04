using System;
using System.Collections;
using System.Collections.Generic;

using Unity.Mathematics;
using UnityEngine;

namespace MagicaVoxel
{
    public class VoxFile : ScriptableObject
    {
        public VoxModel[] Models;
    }
    
    [Serializable]
    public class VoxModel
    {
        public int3   Size;
        public uint[] Voxels;
    }
}