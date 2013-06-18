using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.LinearSearch
{
    public class LinearSearch
    {
        public static void Main()
        {
            List<int> numbers = new List<int>() { 1,3,5,6,7,3,32,3,5,67,7,4,34,3};

            SortableCollection<int> collection = new SortableCollection<int>(numbers);
            Console.WriteLine(collection.LinearSearch(7));
        }
    }
}
