using System;
using System.IO;
using System.Text;

class DeleteOddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader("text.txt");

        StringBuilder evenLines = new StringBuilder();
        string currLine = string.Empty;
        int lineIndex = 1;

        using (reader)
        {
            while (!reader.EndOfStream)
            {
                currLine = reader.ReadLine();

                if (lineIndex % 2 == 0)
                {
                    evenLines.AppendFormat("{0}\n", currLine);
                }
                lineIndex++;
            }
        }

        StreamWriter writer = new StreamWriter("text.txt");

        using (writer)
        {
            writer.Write(evenLines);
        }
    }
}
