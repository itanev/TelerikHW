using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class RemoveWords
{
    static void Main()
    {
        try
        {
            StreamReader EntireTextReader = new StreamReader("text.txt");

            string entireText = string.Empty;

            using (EntireTextReader)
            {
                entireText = EntireTextReader.ReadToEnd();
            }
            //reading words to be removed
            StreamReader WordsToBeRemovedReader = new StreamReader("words.txt");

            List<string> wordsToBeRemoved = new List<string>();

            using (WordsToBeRemovedReader)
            {
                while (!WordsToBeRemovedReader.EndOfStream)
                {
                    wordsToBeRemoved.Add(WordsToBeRemovedReader.ReadLine());
                }
            }

            //remove words
            for (int i = 0; i < wordsToBeRemoved.Count; i++)
            {
                entireText = entireText.Replace(wordsToBeRemoved[i], string.Empty);
            }

            //overwrite the file with the new content

            StreamWriter overwriter = new StreamWriter("text.txt");

            using (overwriter)
            {
                overwriter.Write(entireText);
            }

            Console.WriteLine("Success!");
        }
        catch (FieldAccessException fae)
        {
            Console.WriteLine("You don't have access to this file: {0}", fae.Message);
        }
        catch (FileLoadException fle)
        {
            Console.WriteLine("Could not load the file: {0}", fle.Message);
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine("File not found: {0}", fnfe.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong: {0}", e.Message);
        }
    }
}
