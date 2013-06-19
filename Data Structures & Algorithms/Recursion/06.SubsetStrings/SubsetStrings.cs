using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SubsetStrings
{
    class SubsetStrings
    {
        private static int[] numbers;
        private static string[] set;
        public static void Main()
        {
            const int n = 3;
            int k = 2;
            set = new string[n] { "test", "rock", "fun" };
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

        public static void Print(int[] indexArray)
        {
            for (int i = 0; i < indexArray.Length; i++)
            {
                int index = indexArray[i] - 1;
                Console.Write("{0} ", set[index]);
            }
            Console.WriteLine();
        }
    }
}
