using System;
using System.Collections.Generic;
using System.IO;

class SortWords
{
    static void Main()
    {
        StreamReader reader = new StreamReader("unsorted.txt");
        StreamWriter writer = new StreamWriter("sorted.txt");

        using (reader)
        {
            using (writer)
            {
                List<string> words = new List<string>();

                while (!reader.EndOfStream)
                {
                    words.Add(reader.ReadLine());
                }

                words.Sort();

                foreach (var word in words)
                {
                    writer.WriteLine(word);
                }
            }
        }
    }
}