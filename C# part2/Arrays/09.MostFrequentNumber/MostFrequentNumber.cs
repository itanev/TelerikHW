using System;
using System.Collections.Generic;

class MostFrequentNumber
{
    static void Main()
    {
        Console.Write("Number elements: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        //enter the elements
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("El({0}) = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        //find the most frequent number in the array
        int mostFrequent = arr[0], times = 1, currTimes = 1;
        List<int> checkedNumbers = new List<int>(); //To hold already checked numbers
        
        for (int i = 0; i < arr.Length; i++)
        {
            if (checkedNumbers.Contains(arr[i]))
            {
                continue;
            }

            currTimes = 1;
            checkedNumbers.Add(arr[i]);

            for (int k = i + 1; k < arr.Length; k++)
            {
                if (arr[i] == arr[k])
                {
                    currTimes++;
                }
            }

            if (currTimes >= times)
            {
                mostFrequent = arr[i];
                times = currTimes;
            }
        }

        //output the result
        Console.WriteLine("{0} ({1} times)", mostFrequent, times);
    }
}

