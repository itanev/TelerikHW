using System;
using Library;
using System.Collections.Generic;

class ExtendIEnumerable
{
    static void Main()
    {
        List<int> test = new List<int>();
       
        test.Add(1);
        test.Add(3);
        test.Add(3);

        List<string> testStr = new List<string>();

        testStr.Add("adf");
        testStr.Add("adf");
        testStr.Add("addsaff");

        int[] arr = new int[3];
        arr[0] = 1;
        arr[1] = 2;
        arr[2] = 3;

        //Console.WriteLine(test.Sum<int>());
        //Console.WriteLine(testStr.Sum<string>());
        //Console.WriteLine(arr.Sum<int>());

        //Console.WriteLine( testStr.Product<string>() );
        //Console.WriteLine(test.Product<int>());

        //Console.WriteLine(testStr.Min<string>());
        Console.WriteLine(testStr.Average<string>());
    }
}
