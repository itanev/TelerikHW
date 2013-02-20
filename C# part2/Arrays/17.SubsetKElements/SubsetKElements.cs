using System;
using System.Collections.Generic;

class SubsetKElements
{
    static void Main()
    {
        //get the sum
        Console.Write("Enter sum: ");
        int s = int.Parse(Console.ReadLine());

        //how long the subset should be
        Console.Write("Subset length: ");
        int k = int.Parse(Console.ReadLine());

        //initialize array
        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        //enter the elements
        for (int i = 0; i < n; i++)
        {
            Console.Write("El({0}) = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        //find the subset of k elements with sum s
        int currSum, sequenceLength = 1;
        List<int> sequence = new List<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            currSum = arr[i];
            sequenceLength = 1;
            sequence.Clear();
            sequence.Add(arr[i]);

            for (int el = i + 1; el < arr.Length; el++)
            {
                sequenceLength++;
                currSum += arr[el];
                sequence.Add(arr[el]);

                if (sequenceLength == k && currSum == s)
                {
                    //output the result
                    foreach (int item in sequence)
                    {
                        Console.Write("{0} ", item);
                    }

                    Console.WriteLine();

                    return;
                }
                //performing some clearence
                else if(currSum > s || sequenceLength > k)
                {
                    currSum -= arr[el];
                    sequenceLength--;
                    sequence.RemoveAt(sequence.Count-1);
                    continue;
                }
            }
        }

        Console.WriteLine("No sub sequence of {0} elements with sum {1} found!", k, s);
    }
}
