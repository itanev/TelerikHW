using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubsequence
{
    public class Utils
    {
        /// <summary>
        /// Finds the longest subsequence of equal numbers.
        /// </summary>
        /// <param name="numbers">Numbers where to search.</param>
        /// <returns>Longest subsequence.</returns>
        public List<int> FindLongestSubsequence(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                throw new ArgumentException("The sequence of numbers can not be empty!");
            }

            int sequenceLength = 1,
                currSequenceLength = 1,
                theNumber = numbers[0];

            int currNumber = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                if (currNumber == numbers[i])
                {
                    currSequenceLength++;
                }
                else
                {
                    NewSequence(ref sequenceLength, currSequenceLength, ref theNumber, currNumber);

                    currSequenceLength = 1;
                    currNumber = numbers[i];
                }
            }

            NewSequence(ref sequenceLength, currSequenceLength, ref theNumber, currNumber);

            return GenerateList(theNumber, sequenceLength);
        }

        /// <summary>
        /// Gets the current number that will compose the sequence,
        /// and the length of the sequence
        /// </summary>
        /// <param name="sequenceLength">End lenght.</param>
        /// <param name="currSequenceLength">Current lenght.</param>
        /// <param name="theNumber">End number.</param>
        /// <param name="currNumber">Current number.</param>
        private void NewSequence(ref int sequenceLength, int currSequenceLength, ref int theNumber, int currNumber)
        {
            if (currSequenceLength >= sequenceLength)
            {
                sequenceLength = currSequenceLength;
                theNumber = currNumber;
            }
        }

        /// <summary>
        /// Generate the list that will be the sequence.
        /// </summary>
        /// <param name="number">The number that will compose the sequence.</param>
        /// <param name="times">The sequence length.</param>
        /// <returns></returns>
        private List<int> GenerateList(int number, int times)
        {
            List<int> result = new List<int>(times);

            for (int i = 0; i < times; i++)
            {
                result.Add(number);
            }

            return result;
        }
    }
}
