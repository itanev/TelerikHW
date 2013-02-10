using System;

class LargestSmallerOrEqualToK
{
    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        //enter array
        for (int i = 0; i < n; i++)
        {
            Console.Write("El({0}) = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(arr);

        if (arr[0] > k)
        {
            Console.WriteLine("No such element");
            return;
        }

        int position = Array.BinarySearch(arr,k);
        int t = 0;
        while (position < 0)
        {
            t++;
            position = Array.BinarySearch(arr, k-t);
        }

        Console.WriteLine("The largest element <= {0} is {1}",k ,arr[position]);
    }
}
