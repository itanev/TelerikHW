using System;

namespace NumberOccurences
{
    public class NumberOccurences
    {
        static void Main()
        {
            int[] array = { 10, 5, 6, 7, 4, 3, 6, 8, 4, 6, 4, 3, 3, 2, 4, 7, 8, 9 };
            int theNumber = 4;
            Console.WriteLine(GetOccurences(array, theNumber));
        }

        public static int GetOccurences(int[] a, int number)
        {
            int count = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == number)
                    count++;
            }

            return count;
        }
    }
}
