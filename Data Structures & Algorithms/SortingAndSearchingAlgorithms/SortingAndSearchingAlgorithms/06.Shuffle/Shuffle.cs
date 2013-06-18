using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Shuffle
{
    public class Shuffle
    {
        public static void Main()
        {
            List<int> numbers = new List<int>() { 1,2,4,5,67,87,2,1,2,4,5,6,7,54,8 };
            SortableCollection<int> sortableCollection = new SortableCollection<int>(numbers);

            List<int> shuffledNumbers = new List<int>(sortableCollection.Shuffle());

            Console.WriteLine(string.Join(",", shuffledNumbers));
        }
    }
}
