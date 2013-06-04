using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _02.TraverseWindowsDirectory
{
    public class TraverseWindowsDirectory
    {
        public static void Main()
        {
            // If you try to search windows directory it may throw an unauthorized access exception.
            string someDirectoryPath = "D://Others";
            DirSearch(someDirectoryPath);
        }

        static void DirSearch(string path)
        {
            string[] dirs = Directory.GetDirectories(path);

            foreach (string dir in dirs)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                var currDirFiles = dirInfo.GetFiles();

                foreach (var file in currDirFiles)
                {
                    if (file.Extension == ".exe")
                    {
                        Console.WriteLine(file.FullName);
                    }
                }

                DirSearch(dir);
            }
        }
    }
}
