using System;
using System.Collections.Generic;

class LongestSortedSubsequence
{
    static void Main()
    {
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

        //find the longest subsequence
        List<int> theSequence = new List<int>();
        theSequence.Add(arr[0]);

        int lastIndex = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (theSequence.Count == 1)
            {
                if (arr[i] < theSequence[0])
                {
                    theSequence[0] = arr[i];
                }
                else if (arr[i] >= theSequence[lastIndex])
                {
                    theSequence.Add(arr[i]);
                }
            }
            else
            {
                lastIndex = theSequence.Count - 1;

                if (arr[i] < theSequence[lastIndex] && arr[i] > theSequence[lastIndex-1])
                {
                    theSequence[lastIndex] = arr[i];
                }
                else if(arr[i] >= theSequence[lastIndex])
                {
                    theSequence.Add(arr[i]);
                }
            }
        }

        //output the result
        foreach (int item in theSequence)
        {
            Console.Write("{0} ", item);
        }

        Console.WriteLine();
    }
}
