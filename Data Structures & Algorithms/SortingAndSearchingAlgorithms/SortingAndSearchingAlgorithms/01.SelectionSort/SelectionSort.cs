using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SelectionSort
{
    public class SelectionSort
    {
        public static void Main()
        {
            List<int> numbers = new List<int>(){ 1,3,4,6,7,3,2,2,3,5,7,9,9,1 };

            SelectionSorter<int> selectionSorter = new SelectionSorter<int>(numbers);
            numbers = selectionSorter.Sort();

            Console.WriteLine(string.Join(",", numbers));
        }
    }
}
