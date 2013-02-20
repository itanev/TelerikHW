using System;
using System.Collections.Generic;

class WordOccurrences
{
    static void Main()
    {
        string str = "This are words and we will count each and every one of them. This is another sentence from the string.";

        string[] words = str.Split(' ');

        List<string> displayedWords = new List<string>();

        int occurrences = 0;

        foreach (var word in words)
        {
            occurrences = 0;

            if (!displayedWords.Contains(word))
            {
                displayedWords.Add(word);

                for (int i = 0; i < words.Length; i++)
                {
                    if (word == words[i])
                    {
                        occurrences++;
                    }
                }

                Console.WriteLine("{0} - {1} times", word, occurrences);
            }
        }
    }
}
