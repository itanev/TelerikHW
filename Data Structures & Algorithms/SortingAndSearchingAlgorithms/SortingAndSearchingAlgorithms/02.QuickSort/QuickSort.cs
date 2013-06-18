using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.QuickSort
{
    public class QuickSort
    {
        public static void Main()
        {
            List<int> numbers = new List<int>() { 1,3,4,5,3,5,7,8,4,3,23,2 };
            QuickSorter<int> quickSorter = new QuickSorter<int>(numbers);
            numbers = quickSorter.Sort();

            Console.WriteLine(string.Join(",", numbers));
        }
    }
}
