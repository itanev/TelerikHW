using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.NestedLoops
{
    public class NestedLoops
    {
        public static int[] numbers;

        public static void Main()
        {
            int n = 3;
            numbers = new int[n];
            Loops(n - 1, n);
        }

        public static void Loops(int n, int endPoint)
        {
            if (n < 0)
            {
                Print(numbers);
                return;
            }

            for (int i = 1; i <= endPoint; i++)
            {
                numbers[n] = i;
                Loops(n - 1, endPoint);
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
