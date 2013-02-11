using System;

class ExtractEmail
{
    static void Main()
    {
        string input = Console.ReadLine();

        string[] words = input.Split(' ');

        foreach (var word in words)
        {
            if (word.Contains("@") && word.Contains("."))
            {
                if (isValid(word, '@', 1) && isValid(word, '.', 2))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }

    static bool isValid(string word, char symbol, int allowed)
    {
        int i = 0;
        int count = 0;

        if (word.EndsWith(symbol.ToString()) || word.StartsWith(symbol.ToString()))
            return false;

        while ((i = word.IndexOf(symbol, i+1)) != -1)
        {
            count++;
            if (count > allowed)
            {
                return false;
            }
        }

        return true;
    }
}
