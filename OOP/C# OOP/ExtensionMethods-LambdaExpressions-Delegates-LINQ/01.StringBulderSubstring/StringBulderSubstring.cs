using System;
using Library;
using System.Text;

class StringBulderSubstring
{
    static void Main()
    {
        StringBuilder testStr = new StringBuilder();

        testStr.Append("This is string");

        Console.WriteLine( testStr.Substring(0, 7).ToString() );
    }
}