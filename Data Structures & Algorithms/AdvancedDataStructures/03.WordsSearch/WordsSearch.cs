using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordsSearch
{
    public class WordsSearch
    {
        static void Main()
        {
            // This files are for example. If you want you can generate your own 100mb file and 1000 words to search.
            string[] wordsInText = ExtractWordsFromText("text.txt");
            string[] searchedWords = ExtractWordsFromText("searchedWords.txt");

            Trie wordsTrie = BuildTrie(wordsInText);

            Console.WriteLine("Found words:");

            foreach (var word in searchedWords)
            {
                if (wordsTrie.Search(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
  
        private static Trie BuildTrie(string[] wordsInText)
        {
            Trie wordsTrie = new Trie();

            foreach (var word in wordsInText)
            {
                wordsTrie.Insert(word);   
            }
            return wordsTrie;
        }
  
        private static string[] ExtractWordsFromText(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            string entireText = string.Empty;

            using (reader)
            {
                entireText = reader.ReadToEnd();
            }

            string[] wordsInText = entireText.Split(new char[] { ' ', '.', ',', '!', '?', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return wordsInText;
        }
    }
}
