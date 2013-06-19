using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Permutations
{
    public class Permutations
    {
        static void Main(string[] args)
        {
            int n = 3;
            bool[] used = new bool[n];
            int[] array = new int[n];

            Permute(0, n, array, used);
        }

        static void Permute(int index, int n, int[] array, bool[] used)
        {
            if (index >= n)
            {
                Print(n, array);
                return;
            }

            for (int k = 0; k < n; k++)
            {
                if (!used[k])
                {
                    used[k] = true;
                    array[index] = k;
                    Permute(index + 1, n, array, used);
                    used[k] = false;
                }
            }
        }

        static void Print(int n, int[] array)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", array[i] + 1);
            }
            Console.WriteLine();
        }
    }
}
