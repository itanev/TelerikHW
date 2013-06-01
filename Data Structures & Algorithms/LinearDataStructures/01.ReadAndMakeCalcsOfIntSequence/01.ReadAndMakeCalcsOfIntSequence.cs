using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReadAndMakeCalcsOfIntSequence
{
    public class ReadAndMakeCalcsOfIntSequence
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

            long sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            long average = sum / numbers.Count;

            Console.WriteLine("Sum is {0}", sum);
            Console.WriteLine("Average is {0}", average);
        }
    }
}
