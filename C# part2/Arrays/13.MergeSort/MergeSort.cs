using System;
using System.Collections.Generic;

class MergeSort
{
    static void Main()
    {
        //initialize and read list of n elements
        //we could use arrays but with lists is easier :P
        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());

        List<int> arr = new List<int>();
        //enter the elements
        for (int i = 0; i < n; i++)
        {
            Console.Write("El({0}) = ", i);
            arr.Add(int.Parse(Console.ReadLine()));
        }

        //implement merge sort - wikipedia
        List<int> NewList= SortNumbers(arr);

        //output the result
        for (int i = 0; i < NewList.Count; i++)
        {
            Console.Write("{0} ", NewList[i]);
        }
        Console.WriteLine();
    }

    static List<int> SortNumbers(List<int> a)
    {
        if (a.Count <= 1)
        {
            return a;
        }
        else
        {
            int middle = a.Count / 2;
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < middle; i++)
            {
                left.Add(a[i]);
            }

            for (int i = 0; i < a.Count - middle; i++)
            {
                right.Add(a[middle + i]);
            }

            left = SortNumbers(left);
            right = SortNumbers(right);

            return Merge(left, right);
        }
    }

    static List<int> Merge(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();

        while (left.Count > 0 || right.Count > 0)
        {
            if (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            else if (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }
            else if (right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
        }

        return result;
    }
}

