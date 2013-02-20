using System;

class SortWords
{
    static void Main()
    {
        string str = "This is the string that contains the words to be sorted.";

        string[] words = str.Split(' ');

        Array.Sort(words);

        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}
