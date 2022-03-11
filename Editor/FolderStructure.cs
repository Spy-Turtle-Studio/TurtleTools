using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Linq.Enumerable;
using static System.String;
using static UnityEditor.AssetDatabase;
using static UnityEngine.Application;

namespace spyturtlestudio.tools.Editor
{
    public static class FolderStructure
    {
        public static void CreateDirectories(string root, params string[] dir)
        {
            var fullPath = Combine(dataPath, root);
            foreach (var newDirectory in dir)
            {
                CreateDirectory(Combine(fullPath, newDirectory));
            }
            Refresh();
        }
        
        public static void CreateDefaultDirectories()
        {
            CreateDirectoriesFromTextFile(ConfigManager.Config.DirStructure);
            Refresh();
        }

        private static void CreateDirectoriesFromTextFile([NotNull] string[] directories)
        {
            if (directories == null) throw new ArgumentNullException(nameof(directories));
            var depth = 0;
            var root = new Stack<string>();
            root.Push(dataPath);
            var lastCreated = "";
            foreach (var dir in directories)
            {
                if (dir.StartsWith(Concat(Repeat("\t", depth + 1))))
                {
                    depth += 1;
                    root.Push(lastCreated);
                }
                while (!dir.StartsWith(Concat(Repeat("\t", depth))))
                {
                    depth -= 1;
                    root.Pop();
                }
                var dirName = Regex.Replace(dir.Replace("\t",""), @"[ ]{2,}", "");
                lastCreated = Combine(root.Peek(), dirName);
                CreateDirectory(lastCreated);
            }
        }
    }
}