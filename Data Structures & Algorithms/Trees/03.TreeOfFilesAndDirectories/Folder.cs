using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.TreeOfFilesAndDirectories
{
    public class Folder
    {
        public string Name { get; set; }
        public List<File> Files { get; set; }
        public List<Folder> ChildFolders { get; set; }

        public Folder()
        {
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public Folder(string name)
            : this()
        {
            this.Name = name;
        }
    }
}
