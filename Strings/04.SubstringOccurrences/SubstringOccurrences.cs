using System;

class SubstringOccurrences
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string str = Console.ReadLine();

        Console.Write("Enter substring: ");
        string substr = Console.ReadLine();

        str = str.ToLower();
        substr = substr.ToLower();

        int i = 0, occurrences = 0;

        while((i = str.IndexOf(substr, i+1)) != -1)
        {
            occurrences++;
        }

        Console.WriteLine("{0} times", occurrences);
    }
}