using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergeSort
{
    public class MergeSort
    {
        public static void Main()
        {
            List<int> numbers = new List<int>() { 1,3,4,5,1,4,6,7,3,3,6,8,9,2 };

            MergeSorter<int> mergeSorter = new MergeSorter<int>(numbers);
            numbers = mergeSorter.Sort();

            Console.WriteLine(string.Join(",", numbers));
        }
    }
}
