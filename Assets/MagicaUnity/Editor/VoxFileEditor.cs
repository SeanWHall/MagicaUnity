using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MagicaUnity
{
    [CustomEditor(typeof(VoxFile))]
    public class VoxFileEditor : Editor
    {
        private VoxFile File => (VoxFile) target;
        
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            DrawPallete();
        }

        private void DrawPallete()
        {
            const float PixelSize = 15;
            float ScreenWidth = Screen.width - 25;
            int Pixels_XCount = Mathf.FloorToInt(ScreenWidth / PixelSize);
            int Pixels_YCount = Mathf.CeilToInt(File.Palette.Length / Pixels_XCount);

            EditorGUILayout.LabelField("Pallete");
            Rect Pallete_Rect = EditorGUILayout.GetControlRect(false, GUILayout.Height(Pixels_YCount * PixelSize));
            int  Pallete_Len  = File.Palette.Length / 4;
            
            for (int i = 0; i < Pallete_Len; i++)
                EditorGUI.DrawRect(GetPixelRect(i), File.GetColor(i));
            
            Rect GetPixelRect(int i)
            {
                int x = i % Pixels_XCount;
                int y = i / Pixels_XCount;
                Vector2 Pos  = new Vector2(x * PixelSize, y * PixelSize);
                Vector2 Size = new Vector2(PixelSize, PixelSize);
                return new Rect(Pallete_Rect.position + Pos, Size);
            }
        }
    }
}