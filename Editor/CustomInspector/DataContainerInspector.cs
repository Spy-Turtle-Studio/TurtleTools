using SavableDataManagement;
using UnityEditor;
using UnityEngine;

namespace spyturtlestudio.tools.Editor.CustomInspector
{
    [CustomEditor(typeof(SavableData), true)]
    public class SavableDataInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (!GUILayout.Button("ResetData")) return;
            var data = (SavableData) target;
            data.ResetPlayerPrefs();
        }
    }
}