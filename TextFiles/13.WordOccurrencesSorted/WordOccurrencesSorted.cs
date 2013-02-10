using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class WordOccurrencesSorted
{
    static void Main()
    {
        try
        {
            StreamReader EntireTextReader = new StreamReader("test.txt");
            StreamReader WordsReader = new StreamReader("words.txt");
            StreamWriter ResultWriter = new StreamWriter("result.txt");

            //reading the text
            StringBuilder EntireText = new StringBuilder();

            using (EntireTextReader)
            {
                EntireText.AppendFormat(" {0} ", EntireTextReader.ReadToEnd());
            }

            //reading the words
            List<StringBuilder> words = new List<StringBuilder>();

            using (WordsReader)
            {
                while (!WordsReader.EndOfStream)
                {
                    words.Add(new StringBuilder(string.Format(" {0} ", WordsReader.ReadLine())));
                }
            }

            //find words occurrences and sorting the words by occurrences
            int occurrences = 0, i = 0;
            List<string> wordsResult = new List<string>();

            foreach (var word in words)
            {
                occurrences = 0;
                i = 0;

                while ((i = EntireText.ToString().IndexOf(word.ToString(), i + 1)) != -1)
                {
                    occurrences++;
                }

                word.Replace(word.ToString(), (string.Format("{0} - {1}", occurrences, word.ToString().Trim())));
                wordsResult.Add(word.ToString());
            }

            wordsResult.Sort();
            wordsResult.Reverse();

            //writing the result
            using (ResultWriter)
            {
                foreach (var word in wordsResult)
                {
                    ResultWriter.WriteLine(word);
                }
            }

            Console.WriteLine("The results have bee written successful in file result.txt");
        }
        catch (FieldAccessException fae)
        {
            Console.WriteLine("You dont't have access to this file: ", fae.Message);
        }
        catch (FileLoadException fle)
        {
            Console.WriteLine("Something went wrong while loading the file: ", fle.Message);
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine("Unable to find the file specified: ", fnfe.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong: ", e.Message);
        }
    }
}