using System;
using System.Collections.Generic;

class LetterOccurrences
{
    static void Main()
    {
        string str = "this is a string. And we will count the symbols of this string.";

        //create a list with uniq letters
        List<char> uniqLetters = new List<char>();

        foreach (var letter in str)
        {
            if (!uniqLetters.Contains(letter))
            {
                uniqLetters.Add(letter);
            }
        }

        //find the number of occurrences of each uniq letter
        int i = 0, count = 0;

        foreach (var letter in uniqLetters)
        {
            count = 0;

            while ((i = str.IndexOf(letter, i + 1)) != -1)
            {
                count++;
            }

            Console.WriteLine("{0} - {1} times", letter, count);
        }
    }
}
