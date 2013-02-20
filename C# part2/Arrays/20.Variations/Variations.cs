using System;
using System.Collections.Generic;

class Variations
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());

        //initialize array to hold the numbers [1..n]
        int[] arr = new int[n];

        //putting all the numbers into array
        for (int i = 1; i <= n; i++)
        {
            arr[i - 1] = i;
        }

        List<int> sequence = new List<int>();

        //generates uniq variations 
        for (int i = 0; i < arr.Length-1; i++)
        {
            sequence.Clear();
            sequence.Add(arr[i]);

            for (int t = i; t < arr.Length; t++)
			{
                if (arr[i] <= arr[t])
                {
                    sequence.Add(arr[t]);
                }

                if (sequence.Count == k)
                {
                    for (int p = 0; p < k; p++)
                    {
                        Console.Write("{0} ", sequence[p]);
                    }
                    Console.WriteLine();

                    sequence.Clear();
                    sequence.Add(arr[i]);
                }
			}

        }

    }
}

