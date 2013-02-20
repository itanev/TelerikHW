using System;
using System.Collections.Generic;

class PartionMax
{
    static void Main()
    {
        int[] a = { 4, 6, 7, 3, 6, 7, 8, 4, 4, 3, 3, 6, 7, 8, 8, 0 };

        //sorts the array in decending order
        for (int i = 0; i < a.Length; i++)
        {
            swap(ref a[GetMax(a, i)], ref a[i]);
        }

        for (int i = 0; i < a.Length; i++)
        {
            Console.WriteLine(a[i]);
        }
    }

    static void swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    //a little modification to the method - now it returns not the element but his index
    static int GetMax(int[] a, int index = 0)
    {
        if (index < a.Length)
        {
            int maxIndex = index;

            for (int i = index; i < a.Length; i++)
            {
                if (a[i] > a[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
        else return int.MinValue;
    }
}