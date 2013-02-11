using System;

class Dictionary
{
    static void Main()
    {
        string[] Words = { ".NET", "CLR", "namespace" };

        string[] Meaning = { "platform for applications from Microsoft",
                             "managed execution environment for .NET",
                             "hierarchical organization of classes"
                           };

        Console.Write("Enter a word: ");
        string word = Console.ReadLine();
        int i = 0;

        foreach (var piece in Words)
        {
            if (piece.Equals(word))
            {
                Console.WriteLine("{0} - {1}", word, Meaning[i]);
            }
            i++;
        }
    }
}