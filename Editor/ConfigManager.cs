using System.IO;
using UnityEngine;
using static UnityEditor.AssetDatabase;

namespace spyturtlestudio.tools
{
    public class ConfigManager
    {
        public TurtleToolsConfig Config
        {
            get
            {
                TurtleToolsConfig config;
                var assetNames = FindAssets("t:TurtleToolsConfig", new[] {"Assets"});
                if (assetNames.Length > 1)
                    throw new FileLoadException("Multiple turtle tools configs found.");
                if (assetNames.Length == 1)
                    config = LoadAssetAtPath<TurtleToolsConfig>(GUIDToAssetPath(assetNames[0]));
                else
                {
                    assetNames = FindAssets("t:TurtleToolsConfig", new[] {"Packages"});
                    config = LoadAssetAtPath<TurtleToolsConfig>(GUIDToAssetPath(assetNames[0]));
                }
                return config;
            }
        }
    }
}