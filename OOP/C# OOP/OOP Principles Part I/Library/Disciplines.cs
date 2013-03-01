using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Disciplines : Comments
    {
        public string numberLectures { get; set; }
        public string numberExcercises { get; set; }
        public Teacher teacher { get; set; }

        public Disciplines(string name)
        {
            this.name = name;
        }
    }
}
