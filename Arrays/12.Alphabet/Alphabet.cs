using System;

class Alphabet
{
    static void Main()
    {
        //initialize and fill the array
        char[] alphabet = new char[26];
        
        for (char i = 'a'; i <= 'z'; i++)
        {
            alphabet[((int)i - 'a')] = i;
        }

        //read the word
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        //print letter indexes

        //brute force way - few rows down you could find smarter solutions
        for (int i = 0; i < word.Length; i++)
        {
            for (int k = 0; k < alphabet.Length; k++)
            {
                if (word[i] == alphabet[k])
                {
                    Console.WriteLine("{0} - {1}", word[i], k);
                }
            }
        }
        //shorter way
        //string theAlphabet = new string(alphabet);

        //for (int i = 0; i < word.Length; i++)
        //{
        //    Console.WriteLine(theAlphabet.IndexOf(word[i]));
        //}

        //a way without using an array 
        //for (int i = 0; i < word.Length; i++)
        //{
        //    Console.WriteLine(word[i] - 'a');
        //}
    }
}

