using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativeNumbers
{
    public class RemoveNegativeNumbers
    {
        public static void Main()
        {
            List<int> numbers = new List<int>();

            int currNumber = 0;
            bool isValidNumber = false;

            Console.WriteLine("Enter some numbers. Enter invalid number to stop entering.");

            do
            {
                Console.Write("Enter number: ");
                isValidNumber = int.TryParse(Console.ReadLine(), out currNumber);
                numbers.Add(currNumber);
            }
            while (isValidNumber);

            List<int> positiveNumbers = GenerateListWithoutNegativeNumbers(numbers.GetRange(0, numbers.Count - 1));

            Console.WriteLine(string.Join(" ", positiveNumbers));
        }

        private static List<int> GenerateListWithoutNegativeNumbers(List<int> numbers)
        {
            List<int> positiveNumbers = new List<int>();

            foreach (var number in numbers)
            {
                if (number >= 0)
                {
                    positiveNumbers.Add(number);
                }
            }

            return positiveNumbers;
        }
    }
}
