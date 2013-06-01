using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubsequence
{
    public class LongestSubsequence
    {
        // The test is in the unit tests project.
        public static void Main()
        {
            Utils longestSubsequenceUtils = new Utils();
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

            List<int> longestSequenceOfEqualNumbers = 
                      longestSubsequenceUtils.FindLongestSubsequence(numbers.GetRange(0, numbers.Count - 1));

            Console.WriteLine(string.Join(" ", longestSequenceOfEqualNumbers));
        }
    }
}
