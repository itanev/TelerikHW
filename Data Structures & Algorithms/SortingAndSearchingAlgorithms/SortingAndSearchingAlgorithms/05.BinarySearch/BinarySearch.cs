using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BinarySearch
{
    public class BinarySearch
    {
        public static void Main()
        {
            List<int> numbers = new List<int>() {1,3,4,6,7,8,9,10,23,42};

            SortableCollection<int> sortableCollection = new SortableCollection<int>(numbers);
            Console.WriteLine(sortableCollection.BinarySearch(-12));
        }
    }
}
