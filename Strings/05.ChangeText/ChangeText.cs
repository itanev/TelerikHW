using System;

class ChangeText
{
    static void Main()
    {
        string str = "We are living in a <upcase>yellow submarine</upcase>.We don't have <upcase>anything</upcase> else.";

        string[] splitBy = { "<upcase>", "</upcase>" };

        string[] parts = str.Split(splitBy, System.StringSplitOptions.None);

        for (int i = 0; i < parts.Length; i++)
        {
            if ((i + 1) % 2 == 0)
            {
                Console.WriteLine(parts[i].ToUpper());
            }
            else
            {
                Console.WriteLine(parts[i]);
            }
        }
    }
}