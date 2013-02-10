using System;

class MaxSum
{
    static void Main()
    {
        int n, k;
        Console.Write("N = ");
        n = int.Parse(Console.ReadLine());

        Console.Write("K = ");
        k = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("el({0}) = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        int maxSum = 0, maxEl = arr[0], minEl = arr[0], maxElIndex = 0;

        for (int els = 0; els < k; els++)
        {
            maxEl = arr[0];
            maxElIndex = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > maxEl)
                {
                    maxEl = arr[i];
                    maxElIndex = i;
                }

                if (arr[i] < minEl)
                {
                    minEl = arr[i];
                }
            }

            maxSum += maxEl;
            Console.Write("{0} ", arr[maxElIndex]);
            arr[maxElIndex] = minEl;
        }

        Console.WriteLine("\nMax sum: {0}", maxSum);
    }
}

