using System;

class RestrictedLength
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string str = Console.ReadLine();

        if (str.Length > 20)
        {
            Console.WriteLine("The string is too long");
        }
        else
        {
            for (int i = str.Length; i < 20; i++)
            {
                str += '*';
            }

            Console.WriteLine(str);
        }
    }
}