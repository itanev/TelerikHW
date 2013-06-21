using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Sequences
{
    class Sequences
    {
        static int k;
        static int n;
        static int seqCount = 0;
        static bool[] used;

        static void Main()
        {
            string input = Console.ReadLine();
            string[] kAndN = input.Split(' ');

            n = int.Parse(kAndN[0]);
            k = int.Parse(kAndN[1]);

            bool validN = n >= 1 && n <= 20;
            bool validK = k >= 1 && k <= 10 && k <= n;

            if (!(validN && validK))
            {
                return;
            }

            if (k == 1)
            {
                Console.WriteLine(n);
            }
            else
            {
                used = new bool[n];
                PutBigger(0, -1);
                Console.WriteLine(seqCount);
            }
        }

        static void PutBigger(int index, int current)
        {
            if (index == k)
            {
                seqCount++;
                return;
            }

            if (current == n - 1)
            {
                return;
            }
            for (int i = current + 1; i < n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    PutSmaller(index + 1, i);
                    used[i] = false;
                }
            }
        }

        static void PutSmaller(int index, int current)
        {
            if (index == k)
            {
                seqCount++; 
                return;
            }
            if (current == 0)
            {
                return;
            }
            for (int i = current - 1; i >= 0; i--)
            {
                if (!used[i])
                {
                    used[i] = true;
                    PutBigger(index + 1, i);
                    used[i] = false;
                }
            }
        }
    }
}
