using System;
using System.IO;
using System.Text.RegularExpressions;

class Replace
{
    static void Main()
    {
        StreamReader reader = new StreamReader("text.txt");

        string content = string.Empty;

        using (reader)
        {
            content = reader.ReadToEnd();
           // content = content.Replace("start", "finish");   //07
            content = Regex.Replace(content, @"\bstart\b", "finish");   //08 regular expression
        }

        StreamWriter writer = new StreamWriter("text.txt");

        using (writer)
        {
            writer.Write(content);
        }
    }
}
