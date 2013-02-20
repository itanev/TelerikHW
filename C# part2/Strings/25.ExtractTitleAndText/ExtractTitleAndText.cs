using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractTitleAndText
{
    static void Main()
    {
        StreamReader reader = new StreamReader("file.html");

        using (reader)
        {
            while (!reader.EndOfStream)
            {
                MatchCollection matches = Regex.Matches(reader.ReadLine(), @"(?<=^|>)[^><]+?(?=<|$)");
                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString().Trim());
                }
            }
        }
    }
}
