using System;
using Library;

class GenericListTest
{
    static void Main()
    {
        GenericList<int> myList = new GenericList<int>(5);

        myList.AddElementAt(8,3);
        myList.Add(1);
        myList.Add(4);
        myList.Add(5);
        myList.Add(6);
        myList.Add(6);
        myList.Add(6);
        myList.Add(6);
        myList.Add(6);
        myList.Add(6);

        Console.WriteLine(myList);

        Console.WriteLine(myList.Min<int>());
        Console.WriteLine(myList.Max<int>());
    }
}
