using System;

class ReverseString
{
    static void Main()
    {
        string str = "This string will be reversed";

        char[] rev = str.ToCharArray();

        Array.Reverse(rev);

        Console.Write("{0} -> ", str);

        foreach (var c in rev)
        {
            Console.Write(c);
        }

        Console.WriteLine();
    }
}