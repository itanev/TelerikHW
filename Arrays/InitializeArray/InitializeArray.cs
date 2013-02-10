using System;

class InitializeArray
{
    static void Main()
    {
        int[] arr = new int[20];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i * 5;
            //reuse this loop for printing
            Console.Write("{0} ", arr[i]);
        }
        Console.WriteLine();

        //we could also do it this way
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.Write("{0} ", arr[i]);
        //}
    }
}
