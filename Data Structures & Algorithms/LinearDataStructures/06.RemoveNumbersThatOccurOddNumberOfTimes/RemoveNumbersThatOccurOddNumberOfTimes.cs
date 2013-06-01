using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.RemoveNumbersThatOccurOddNumberOfTimes
{
    public class RemoveNumbersThatOccurOddNumberOfTimes
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

            numbers = ComposeNewSequence(numbers.GetRange(0, numbers.Count - 1));
            Console.WriteLine(string.Join(" ", numbers));
        }

        /// <summary>
        /// Compose new sequence of numbers that
        /// occur even number of times.
        /// </summary>
        private static List<int> ComposeNewSequence(List<int> numbers)
        {
            List<int> numbersToRemove = GetNumbersToRemove(numbers);
            List<int> resultNumbers = new List<int>();

            foreach (var number in numbers)
            {
                if (numbersToRemove.Contains(number))
                {
                    continue;
                }

                resultNumbers.Add(number);
            }

            return resultNumbers;
        }
  
        private static List<int> GetNumbersToRemove(List<int> numbers)
        {
            List<int> sortedNumbers = new List<int>(numbers);
            sortedNumbers.Sort();

            int currNumber = sortedNumbers[0],
            occurTimes = 1;

            List<int> numbersToRemove = new List<int>();

            for (int i = 1; i < sortedNumbers.Count; i++)
            {
                if (currNumber != sortedNumbers[i])
                {
                    AddNumberIfOccuredOddNumberOfTimes(currNumber, occurTimes, numbersToRemove);

                    currNumber = sortedNumbers[i];
                    occurTimes = 1;
                    continue;
                }

                occurTimes++;
            }

            AddNumberIfOccuredOddNumberOfTimes(currNumber, occurTimes, numbersToRemove);

            return numbersToRemove;
        }

        private static void AddNumberIfOccuredOddNumberOfTimes(int currNumber, int occurTimes, List<int> resultNumbers)
        {
            if (occurTimes % 2 != 0)
            {
                resultNumbers.Add(currNumber);
            }
        }
    }
}
