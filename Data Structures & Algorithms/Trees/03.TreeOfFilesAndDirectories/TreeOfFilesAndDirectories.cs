using System;
using System.IO;

namespace _03.TreeOfFilesAndDirectories
{
    public class TreeOfFilesAndDirectories
    {
        public static void Main()
        {
            string rootFolderPath = "D://others";
            Folder rootFolder = new Folder("Others");
            CreateTree(rootFolderPath, ref rootFolder);

            var filesSize = CalcFileSizes(rootFolder);
            Console.WriteLine(filesSize);
        }

        private static long CalcFileSizes(Folder startFolder)
        {
            long size = 0;

            foreach (var file in startFolder.Files)
            {
                size += file.Size;
            }

            foreach (var childFolder in startFolder.ChildFolders)
            {
                size += CalcFileSizes(childFolder);
            }

            return size;
        }

        private static void CreateTree(string path, ref Folder folder)
        {
            var directory = new DirectoryInfo(path);
            var directoryName = directory.Name;
            folder = new Folder(directoryName);

            var currentFiles = directory.GetFiles();
            foreach (var file in currentFiles)
            {
                var name = file.Name;
                var length = file.Length;

                folder.Files.Add(new File(name, length));
            }

            var currentDirs = directory.GetDirectories();
            foreach (var dir in currentDirs)
	        {
		        var name = dir.Name;
                var currentFolder = new Folder(name);
                CreateTree(dir.FullName, ref currentFolder);
                folder.ChildFolders.Add(currentFolder);
	        }
        }
    }
}
