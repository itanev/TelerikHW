using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.CarSearch.Models
{
    public class Producer
    {
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }

        public Producer()
        {
            this.Models = new List<Model>();
        }
    }
}