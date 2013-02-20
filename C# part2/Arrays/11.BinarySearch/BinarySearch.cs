using System;

class BinarySearch
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Number elements: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        //enter the elements
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("El({0}) = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        //sort the array
        Array.Sort(arr);

        //output the sorted array
        Console.WriteLine("\nThe sorted array: ");

        foreach (int item in arr)
        {
            Console.Write("{0} ", item);
        }

        Console.WriteLine();

        //find element using binary search
        int result = SearchElementBinary(arr, 0, arr.Length, number);

        if (result == int.MinValue)
        {
            Console.WriteLine("Element not found!");
            return;
        }

        Console.WriteLine("The element is found at index: {0}", result);
        
    }

    //binary search recursivly - wikipedia :P (with litle modification)
    static int SearchElementBinary(int[] a, int min, int max, int item)
    {
        int mid = min + ((max - min) / 2);

        if(mid >= a.Length) 
        {
            return int.MinValue;
        }

        if (a[mid] > item)
        {
            return SearchElementBinary(a, min, mid - 1, item);
        }
        else if (a[mid] < item)
        {
            return SearchElementBinary(a, mid + 1, max, item);
        }
        else
        {
            return mid;
        }

    }
}

