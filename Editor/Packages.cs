using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using UnityEngine;
using static System.IO.File;
using static System.IO.Path;
using static UnityEditor.PackageManager.Client;
using static UnityEngine.Application;

namespace spyturtlestudio.tools
{
    public static class Packages
    {
        private static PackageCollection _packageCollection;
        
        public static async Task ReplacePackagesFromGist(string id)
        {
            var url = GetGistUrl(id);
            var contents = await GetContents(url);
            ReplacePackageFile(contents);
            UpdateInstalledPackages();
        }

        public static void InstallUnityPackages(params string[] packageNames)
        {
            var packages = GetInstalledPackages();
            foreach (var package in packageNames)
            {
                if (packages.Any(s => s.name == $"com.unity.{package}"))
                    Debug.Log($"The Package com.unity.{package} is already installed.");
                else
                {
                    Debug.Log($"Installing com.unity.{package}.");
                    Add($"com.unity.{package}");
                }
            }
            UpdateInstalledPackages();
        }
        
        public static void InstallUnityPackagesFromGit(params string[] repositoryUrls)
        {
            foreach (var package in repositoryUrls)
            { 
                Debug.Log($"Installing {package}.");
                Add($"{package}");
            }
            UpdateInstalledPackages();
        }

        /// <summary>
        /// Checks if all packages with a given name are already installed.
        /// </summary>
        /// <param name="packageNames">Names of packages (not including prefix of "com.unity").</param>
        /// <returns>true, if all packages are installed</returns>
        public static bool CheckForInstalledPackages(params string[] packageNames) => 
            packageNames.All(package => GetInstalledPackages().Any(s => s.name == $"com.unity.{package}"));

        public static IEnumerable<string> InstalledPackageSequence()
        {
            var packageList = GetInstalledPackages();
            foreach (var package in packageList)
                yield return package.name;
        }

        private static async Task<string> GetContents(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        
        private static void ReplacePackageFile(string contents)
        {
            var existing = Combine(dataPath, "..", "Packages", "manifest.json");
            WriteAllText(existing, contents);
            Resolve();
        }

        private static string GetGistUrl(string id, string user = "DDiekmann") =>
            $"https://gist.github.com/{user}/{id}/raw";

        private static PackageCollection GetInstalledPackages()
        {
            if (_packageCollection != null) return _packageCollection;
            UpdateInstalledPackages();
            return _packageCollection;
        }

        private static void UpdateInstalledPackages()
        {
            var request = List();
            while (true)
                if (request.IsCompleted)
                    break;
            if (request.Status >= StatusCode.Failure)
                throw new UnityException(request.Error.message);
            _packageCollection = request.Result;
        }
    }
}