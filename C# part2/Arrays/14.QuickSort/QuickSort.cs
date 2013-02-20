using System;
using System.Collections.Generic;

class QuickSort
{
    static void Main()
    {
        //I use list becouse I'm lasy :D - it's the same with arrays. 
        //Only diference is +30 rows of code

        //list of numbers - we could read user input here using for loop
        List<int> numbers = new List<int> { 1, 2, 54, 67, 3, 8, 2, 89, 6, 3, 76 };

        numbers = SortNumbers(numbers);  //Reusing the same list

        for (int i = 0; i < numbers.Count; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }

        Console.WriteLine();
    }

    static List<int> SortNumbers(List<int> sequence)
    {
        if (sequence.Count <= 1)
        {
            return sequence;
        }
        else
        {
            int pivot = sequence[sequence.Count/2];
            sequence.RemoveAt(sequence.Count / 2);

            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] < pivot)
                {
                    less.Add(sequence[i]);
                }
                else
                {
                    greater.Add(sequence[i]);
                }
            }

            return Concatenate(SortNumbers(less), pivot, SortNumbers(greater));
        }
    }

    static List<int> Concatenate(List<int> less, int pivot, List<int> greater)
    {
        List<int> result = new List<int>();

        result.AddRange(less);
        result.Add(pivot);
        result.AddRange(greater);

        return result;
    }
}
