using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.KnapsackProblem
{
    class KnapsackProblem
    {
        static Stack<Product> knapsack;
        static List<Product> bestSolution;
        static List<Product> products;
        static int price;
        static int currPrice;
        static int currWeightCounter;
        static int capacity;
        static int counter;

        static void Main()
        {
            knapsack = new Stack<Product>();
            bestSolution = new List<Product>();
            products = new List<Product>()
            {
                new Product("beer", 3, 6),
                new Product("vodka", 8, 12),
                new Product("cheese", 4, 5),
                new Product("nuts", 1, 4),
                new Product("ham", 2, 3),
                new Product("whiskey", 8, 13)
            };

            currWeightCounter = 0;
            currPrice = 0;
            price = 0;
            counter = 0;
            capacity = 10;

            Solve(counter, string.Empty);
            Console.WriteLine(string.Join("\r\n", bestSolution));
            Console.WriteLine("Total cost: {0}", price);
        }

        static void Solve(int startPoint, string lastProductName)
        {
            if (startPoint >= products.Count)
            {
                if (currPrice >= price)
                {
                    bestSolution = new List<Product>(knapsack);
                }

                return;
            }

            var currProduct = products[startPoint];
            if (lastProductName.Equals(currProduct.Name))
            {
                return;
            }

            currWeightCounter += currProduct.Weight;

            if (currWeightCounter <= capacity)
            {
                knapsack.Push(currProduct);
                currPrice += currProduct.Cost;
            }
            else
            {
                currWeightCounter -= currProduct.Weight;
            }

            if (currPrice > price)
            {
                price = currPrice;
            }

            Solve(startPoint + 1, currProduct.Name);
            if (knapsack.Count == 0)
            {
                return;
            }
            else
            {
                var lastProduct = knapsack.Pop();
                currWeightCounter -= lastProduct.Weight;
                currPrice -= lastProduct.Cost;
                if (knapsack.Count == 0)
                {
                    Solve(++counter, lastProduct.Name);
                }

                Solve(startPoint, lastProduct.Name);
            }
        }
    }
}
