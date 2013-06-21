using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Balls
{
    class Balls
    {
        static int counter = 0;

        static void Main()
        {
            string input = Console.ReadLine();

            Permute(input.ToCharArray().OrderBy((x) => x).ToArray(), 0, input.Length);
            Console.WriteLine(counter);
        }

        public static void Permute(char[] permutations, int start, int n)
        {
            char tmp = permutations[0];
            counter++;
            Console.WriteLine(permutations);

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
    }
}
