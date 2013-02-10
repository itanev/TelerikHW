using System;
using System.IO;

class ConcatTextFiles
{
    static void Main()
    {
        StreamReader reader = new StreamReader("text1.txt");
        StreamWriter writer = new StreamWriter("text.txt");

        using (reader)
        {
            using (writer)
            {
                writer.Write(reader.ReadToEnd());
                reader = new StreamReader("text2.txt");
                writer.Write(reader.ReadToEnd());
            }
        }
    }
}
