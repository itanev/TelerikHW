using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.OccurencesOfWordsInTextFile
{
    public class OccurencesOfWordsInTextFile
    {
        public static void Main()
        {
            var wordsInFile = GetWordsAsCollection("words.txt");

            IDictionary<string, int> wordsAndTheirOccurrences = CountWords(wordsInFile);
            List<KeyValuePair<string, int>> wordsSortedByOccurrences = wordsAndTheirOccurrences.ToList();
            wordsSortedByOccurrences.Sort
            (
                (firstWord, secondWord) =>
                {
                    return firstWord.Value.CompareTo(secondWord.Value);
                }
            );

            foreach (var word in wordsSortedByOccurrences)
            {
                Console.WriteLine("{0} -> {1}", word.Key, word.Value);
            }
        }

        private static Dictionary<string, int> CountWords(List<string> words)
        {
            Dictionary<string, int> numbersAndOccurrences = new Dictionary<string, int>();
            foreach (var word in words)
            {
                string currWordToLower = word.ToLower();
                if (numbersAndOccurrences.ContainsKey(currWordToLower))
                {
                    numbersAndOccurrences[currWordToLower] += 1;
                }
                else
                {
                    numbersAndOccurrences.Add(currWordToLower, 1);
                }
            }

            return numbersAndOccurrences;
        }

        private static List<string> GetWordsAsCollection(string filePath)
        {
            List<string> words = new List<string>();

            StreamReader wordsFile = new StreamReader(filePath);
            using (wordsFile)
            {
                int lineNumber = 0;
                string line = wordsFile.ReadLine();

                while (line != null)
                {
                    string[] wordsOnCurrLine = line.Split(new char[] { ' ', ',', '.', '!', '?', '–' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in wordsOnCurrLine)
                    {
                        words.Add(word);    
                    }

                    lineNumber++;
                    line = wordsFile.ReadLine();
                }
            }

            return words;
        }
    }
}
