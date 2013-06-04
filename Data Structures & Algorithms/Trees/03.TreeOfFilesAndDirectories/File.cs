﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.TreeOfFilesAndDirectories
{
    public class File
    {
        public string Name { get; set; }
        public long Size { get; set; }

        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }
    }
}
