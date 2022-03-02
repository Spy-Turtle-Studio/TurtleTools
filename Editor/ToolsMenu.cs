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

        [MenuItem("Tools/Project Setup/Load Base Packages")]
        private static async void LoadNewManifest() => 
            await ReplacePackagesFromGist("60f656b263649d3237e2bdea0b10015f");

        [MenuItem("Tools/Packages/Install ECS")]
        private static void InstallEcs() => 
            InstallUnityPackages("entities", "rendering.hybrid", "dots.editor");
        
        [MenuItem("Tools/Packages/Install ECS 2D", true)]
        private static bool EcsInstalled() => 
            CheckForInstalledPackages("entities", "rendering.hybrid", "dots.editor");

        [MenuItem("Tools/Packages/Install ECS 2D")]
        private static void InstallEcs2D() =>
            InstallUnityPackages("2d.entities", "2d.entities.physics");

        [MenuItem("Tools/Log/Log Installed Packages")]
        private static void LogPackages()
        {
            foreach (var package in InstalledPackageSequence()) Log(package);
        }
    }
}
