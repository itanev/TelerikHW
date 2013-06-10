using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.HashSet
{
    public class MainProgram
    {
        public static void Main()
        {
            HashSet<int> mySet = new HashSet<int>();
            mySet.Add(10);
            mySet.Add(11);
            mySet.Add(12);
            mySet.Add(13);
            mySet.Add(19);
            mySet.Add(14);
            mySet.Add(15);

            HashSet<int> myOtherSet = new HashSet<int>();
            myOtherSet.Add(10);
            myOtherSet.Add(11);
            myOtherSet.Add(12);
            myOtherSet.Add(13);
            myOtherSet.Add(14);
            myOtherSet.Add(15);
            myOtherSet.Add(16);

            //var union = mySet.Union(myOtherSet);

            //foreach (var item in union)
            //{
            //    Console.WriteLine(item);
            //}

            var intersect = mySet.Intersect(myOtherSet);

            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }
        }
    }
}
