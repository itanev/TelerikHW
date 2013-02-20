using System;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        StreamReader reader = new StreamReader("text.txt");
        StreamWriter writer = new StreamWriter("textWithLines.txt");

        using (reader)
        {
            using (writer)
            {
                string line = string.Empty;
                int lineNum = 1;
                
                while((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine("{1}: {0}", line, lineNum);
                    lineNum++;
                }
            }
        }
    }
}