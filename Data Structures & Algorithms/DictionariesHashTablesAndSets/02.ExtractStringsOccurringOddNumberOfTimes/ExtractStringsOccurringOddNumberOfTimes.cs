using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.ExtractStringsOccurringOddNumberOfTimes
{
    public class ExtractStringsOccurringOddNumberOfTimes
    {
        public static void Main()
        {
            string[] words = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var resultWords = ExtractWordsThatOccurrOddNumberOfTimes(words);

            Console.WriteLine(string.Join(",", resultWords));
        }
  
        private static List<string> ExtractWordsThatOccurrOddNumberOfTimes(string[] words)
        {
            var wordsAndOccurrences = CountWords(words);
            List<string> wordsThatOccurrOddNumberOfTimes = new List<string>();

            foreach (var pair in wordsAndOccurrences)
            {
                if (pair.Value % 2 != 0)
                {
                    wordsThatOccurrOddNumberOfTimes.Add(pair.Key);
                }
            }

            return wordsThatOccurrOddNumberOfTimes;
        }

        private static Dictionary<string, int> CountWords(string[] words)
        {
            Dictionary<string, int> wordsAndOccurrences = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordsAndOccurrences.ContainsKey(word))
                {
                    wordsAndOccurrences[word] += 1;
                }
                else
                {
                    wordsAndOccurrences.Add(word, 1);
                }
            }

            return wordsAndOccurrences;
        }
    }
}
