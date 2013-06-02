using System;
using System.Linq;

namespace _11.LinkedList
{
    public class LinkedListMain
    {
        public static void Main()
        {
            LinkedList<int> myList = new LinkedList<int>();

            myList.Add(2);
            myList.Add(2);
            myList.Add(2);
            myList.Add(3);
            myList.Add(3);
            myList.Add(2);

            Console.WriteLine(myList);
            myList.RemoveFirst();
            Console.WriteLine(myList);
        }
    }
}
