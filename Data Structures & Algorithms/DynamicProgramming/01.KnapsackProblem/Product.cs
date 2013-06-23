using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.KnapsackProblem
{
    class Product
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }

        public Product(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", this.Name, this.Weight, this.Cost);
        }
    }
}
