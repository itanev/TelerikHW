using System;
using System.Collections.Generic;
using System.Text;

class ForbiddenWords
{
    static void Main()
    {
        string str = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        
        List<string> words = new List<string>();
        words.Add("PHP");
        words.Add("CLR");
        words.Add("Microsoft");

        Console.WriteLine("The old string: {0}\n", str);

        foreach (var word in words)
        {
            str = str.Replace(word, TransformIntoAstrixes(word));
        }

        Console.WriteLine("The new string: {0}", str);
    }

    static string TransformIntoAstrixes(string str)
    {
        StringBuilder result = new StringBuilder(str.Length);

        foreach (var c in str)
        {
            result.Append('*');
        }

        return result.ToString();
    }
}