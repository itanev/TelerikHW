using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ReadAndSortsNumbers
{
    public class ReadAndSortsNumbers
    {
        public static void Main()
        {
            List<int> numbers = new List<int>();

            int currNumber = 0;
            bool isValidNumber = false;

            do
            {
                Console.Write("Enter number: ");
                isValidNumber = int.TryParse(Console.ReadLine(), out currNumber);
                numbers.Add(currNumber);
            }
            while (isValidNumber);

            numbers.RemoveAt(numbers.Count - 1); // Just remove the last number, bacause it is zero, aways.
            numbers.Sort();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
