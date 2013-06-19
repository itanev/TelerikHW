using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PermutationsWithRepetition
{
    class Program
    {
        static void Main(string[] args)
        {
            Permute(new int[] { 1, 3, 5, 5 }, 0, 4);
        }

        public static void Permute(int[] permutations, int start, int n)
        {
            int tmp = 0;
            Print(permutations);

            if (start < n)
            {
                for (int i = n - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (permutations[i] != permutations[j])
                        {
                            // swap ps[i] <--> ps[j]
                            tmp = permutations[i];
                            permutations[i] = permutations[j];
                            permutations[j] = tmp;

                            Permute(permutations, i + 1, n);
                        }
                    }

                    // Undo all modifications done by
                    // recursive calls and swapping
                    tmp = permutations[i];
                    for (int k = i; k < n - 1; )
                        permutations[k] = permutations[++k];
                    permutations[n - 1] = tmp;
                }
            }
        }

        private static void Print(int[] ps)
        {
            Console.WriteLine(String.Join("", ps));
        }
    }
}
