using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;

namespace _01.Mongo
{
    class MongoDictionary
    {
        static void Main()
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dictionary");
            var words = db.GetCollection<Word>("words");

            DisplayStartupMenu();
            ChooseAction(words);
        }
  
        private static void ChooseAction(MongoCollection<Word> words)
        {
            string action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    ReadWord(words);
                    break;
                case "2":
                    ListWords(words);
                    break;
                case "3":
                    FindWords(words);
                    break;
                case "4":
                    DisplayStartupMenu();
                    break;
                case "exit":
                    Console.WriteLine("Goodbuy!");
                    return;
                default:
                    Console.WriteLine("Invalid action, please choose again.");
                    break;
            }

            ChooseAction(words);
        }
  
        private static void DisplayStartupMenu()
        {
            Console.WriteLine("Enter action:");
            Console.WriteLine("1. For adding new word.");
            Console.WriteLine("2. For listing all words and their translations.");
            Console.WriteLine("3. To find a translation of given word.");
            Console.WriteLine("4. To display startup menu.");
            Console.WriteLine("Enter exit to leave the program.");
        }

        private static void FindWords(MongoCollection<Word> words)
        {
            Console.Write("Enter word to search for:");
            var word = Console.ReadLine();

            string foundWordTranslation = words.AsQueryable<Word>().
                                                Where(w => w.TheWord == word).
                                                Select(w => w.Translation).
                                                FirstOrDefault();

            if (foundWordTranslation != null)
            {
                Console.WriteLine(foundWordTranslation);
            }
            else
            {
                Console.WriteLine("No such word found!");
            }
        }

        private static void ListWords(MongoCollection<Word> words)
        {
            var allWords = from w in words.AsQueryable<Word>()
                           select w;

            foreach (var word in allWords)
            {
                Console.WriteLine("{0} - {1}", word.TheWord, word.Translation);
            }
        }

        private static void ReadWord(MongoCollection<Word> words)
        {
            Console.Write("Enter word: ");
            var word = Console.ReadLine();

            Console.Write("Enter transalation for the word: ");
            var translation = Console.ReadLine();

            Word currWord = new Word()
            {
                TheWord = word,
                Translation = translation
            };

            words.Insert(currWord);
        }
    }
}
