using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.CarSearch.Models
{
    public class Model
    {
        public string Name { get; set; }
        public ICollection<Extra> Extras { get; set; }

        public Model()
        {
            this.Extras = new List<Extra>();
        }
    }
}
