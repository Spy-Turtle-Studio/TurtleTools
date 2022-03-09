using UnityEditor;
using static spyturtlestudio.tools.FolderStructure;
using static spyturtlestudio.tools.Packages;
using static UnityEngine.Debug;

namespace spyturtlestudio.tools
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Project Setup/Create Default Folders")]
        private static void CreateDefaultFolders() => CreateDefaultDirectories();

        [MenuItem("Tools/Log/Log Installed Packages")]
        private static void LogPackages()
        {
            foreach (var package in InstalledPackageSequence()) Log(package);
        }
    }
}
