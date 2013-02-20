using System;

class ReverseWords
{
    static void Main()
    {
        string sentence = Console.ReadLine();

        string[] reversed = sentence.Split(' ');

        Array.Reverse(reversed);

        foreach (var word in reversed)
        {
            Console.Write("{0} ", word);
        }

        Console.WriteLine();
    }
}