using System;
using System.Collections.Generic;
using System.Text;

class ReplaceIdenticalLetters
{
    static void Main()
    {
        string str = "aaaaabbbbbcdddeeeedssaa";

        str += '*'; // we need this because of the loop condition

        char currLetter;

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < str.Length-1; i++)
        {
            currLetter = str[i];
            if (currLetter != str[i + 1])
            {
                result.Append(currLetter);
            }
        }

        Console.WriteLine(result);
    }
}