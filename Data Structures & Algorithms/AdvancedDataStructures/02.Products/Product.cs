using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Products
{
    public class Product
    {
        private string name;
        private double price;

        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}\r\n", this.name, this.price);
        }
    }
}
