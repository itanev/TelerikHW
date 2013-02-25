using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class PathStorage
    {
        public static void SavePaths(Path paths, string txtFileAddr)
        {
            StreamWriter targetTxt = new StreamWriter(txtFileAddr);

            using (targetTxt)
            {
                foreach (var path in paths.points)
                {
                    targetTxt.WriteLine(path);
                }
            }
        }

        public static void LoadPaths(string txtFileAddr)
        {
            StreamReader targetTxt = new StreamReader(txtFileAddr);

            using (targetTxt)
            {
                Console.WriteLine(targetTxt.ReadToEnd());
            }
        }
    }
}
