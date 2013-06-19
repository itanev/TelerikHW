using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CombinationsWithoutDuplicates
{
    public class CombinationsWithoutDuplicates
    {
        private static int[] numbers;
        public static void Main()
        {
            int n = 4;
            int k = 2;
            numbers = new int[k];
            Loops(k - 1, 1, n);
        }

        public static void Loops(int n, int startPoint, int endPoint)
        {
            if (n < 0)
            {
                Print(numbers);
                return;
            }

            for (int i = startPoint; i <= endPoint; i++)
            {
                numbers[n] = i;
                Loops(n - 1, startPoint + 1, endPoint);
                startPoint++;
            }
        }

        public static void Print(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }

            Console.WriteLine();
        }
    }
}
