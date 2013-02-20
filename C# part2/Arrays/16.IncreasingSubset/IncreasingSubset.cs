using System;
using System.Collections.Generic;

class IncreasingSubset
{
    static void Main()
    {
        //get the sum
        Console.Write("Enter sum: ");
        int s = int.Parse(Console.ReadLine());

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

        //find the increasing subset
        int currSum;
        List<int> sequence = new List<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            currSum = arr[i];

            sequence.Clear();
            sequence.Add(arr[i]);

            for (int k = i+1; k < arr.Length; k++)
            {
                //make sure the element won's make the sequence ordinary
                if (arr[k] > arr[i])
                {
                    bool biggerFound = false;

                    for (int el = 0; el < sequence.Count; el++)
                    {
                        if (sequence[el] >= arr[k])
                        {
                            biggerFound = true;
                            break;
                        }
                    }

                    if (biggerFound)
                    {
                        continue;
                    }

                    currSum += arr[k];
                    sequence.Add(arr[k]);
                }
                else
                {
                    continue;
                }

                if (currSum == s)
                {
                    //output the result
                    foreach (int item in sequence)
                    {
                        Console.Write("{0} ", item);
                    }

                    Console.WriteLine();

                    return;
                }
                else if (currSum > s)
                {
                    break;
                }
            }
        }

        Console.WriteLine("No increasing sub sequence found!");
    }
}
