using UnityEditor;
using static spyturtlestudio.tools.Editor.FolderStructure;
using static spyturtlestudio.tools.Editor.Packages;
using static UnityEngine.Debug;

namespace spyturtlestudio.tools.Editor.Menu
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
