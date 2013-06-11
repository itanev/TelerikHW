using System;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.Products
{
    public class Products
    {
        public static void Main()
        {
            OrderedDictionary<double, Product> products = new OrderedDictionary<double, Product>();

            for (int i = 0; i < 500000; i++)
            {
                var currPrice = 100 + i;
                products.Add(currPrice, new Product("Pesho" + i, currPrice));
            }

            // Wait 2-3 seconds.
            Console.WriteLine(products.Range(120, true, 1040, true));
        }
    }
}
