using UnityEditor;
using static spyturtlestudio.tools.Packages;

namespace spyturtlestudio.tools
{
    public static class PackageMenu
    {
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

        [MenuItem(("Tools/Packages/Install LINQ for GameObjects"))]
        private static void InstallLINQ() =>
            InstallUnityPackagesFromGit("https://github.com/neuecc/LINQ-to-GameObject-for-Unity.git");
    }
}