using System;
using System.Text;

class ConvertToUnicode
{
    static void Main()
    {
        string str = "Hi!";

        foreach (var c in str)
        {
            Console.Write(string.Format("\\u{0:X4}", (int)c));
        }

        Console.WriteLine();
    }
}