using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.FindMajorant
{
    public class FindMajorant
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

            int majorant = GetMajorant(numbers.GetRange(0, numbers.Count - 1));

            if (majorant != int.MinValue)
            {
                Console.WriteLine("Majorant: {0}", majorant);
            }
            else
            {
                Console.WriteLine("No majorant.");
            }
        }

        private static int GetMajorant(List<int> numbers)
        {
            Dictionary<int, int> numbersAndOccurrences = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (numbersAndOccurrences.ContainsKey(number))
                {
                    numbersAndOccurrences[number]++;
                }
                else
                {
                    numbersAndOccurrences.Add(number, 1);
                }
            }

            int maxOccuringElement = numbersAndOccurrences.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            int atLeastOccurrences = numbers.Count / 2 + 1;

            if(numbersAndOccurrences[maxOccuringElement] >= atLeastOccurrences)
                return maxOccuringElement;

            return int.MinValue;
        }
    }
}
