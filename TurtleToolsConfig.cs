using System;
using UnityEngine;

namespace spyturtlestudio.tools
{
    [CreateAssetMenu(fileName = "TurtleToolsConfig", menuName = "TurtleTools/Config", order = 0)]
    public class TurtleToolsConfig : ScriptableObject
    {
        [Header("Directory Structure")] 
        [SerializeField]
        private TextAsset directoryStructureFile;

        public string[] DirStructure { get; private set; }

        private void OnValidate()
        {
            DirStructure = directoryStructureFile
                ? directoryStructureFile.text.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                : null;
        }
    }
}