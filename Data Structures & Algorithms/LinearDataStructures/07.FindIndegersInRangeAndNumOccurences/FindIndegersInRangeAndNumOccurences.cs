using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FindIndegersInRangeAndNumOccurences
{
    public class FindIndegersInRangeAndNumOccurences
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

            Dictionary<int, int> result = FindNumbersInRangeAndTheirOccurrences(numbers.GetRange(0, numbers.Count - 1));

            PrintNumbersAndOccurrences(result);
        }

        private static void PrintNumbersAndOccurrences(Dictionary<int, int> numbersAndOccurrences)
        {
            foreach (var number in numbersAndOccurrences)
            {
                Console.WriteLine("{0} -> {1}", number.Key, number.Value);
            }
        }

        private static Dictionary<int, int> FindNumbersInRangeAndTheirOccurrences(List<int> numbers)
        {
            Dictionary<int, int> resultNumbersAndOccurrences = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (number >= 0 && number <= 1000) continue;

                if (resultNumbersAndOccurrences.ContainsKey(number))
                {
                    resultNumbersAndOccurrences[number]++;
                }
                else
                {
                    resultNumbersAndOccurrences.Add(number, 1);
                }
            }

            return resultNumbersAndOccurrences;
        }
    }
}
