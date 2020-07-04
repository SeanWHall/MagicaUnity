using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEditor;
using UnityEditor.Experimental.AssetImporters;

namespace MagicaVoxel
{
    [CustomEditor(typeof(VoxFileImporterEditor))]
    public class VoxFileImporterEditor : Editor
    {
        
    }
    
    [ScriptedImporter(1, "vox")]
    public class VoxFileImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            
        }
    }
}
