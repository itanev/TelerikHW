using System;

class Converter
{
    static void Main()
    {
        Console.Write("S = ");
        int s = int.Parse(Console.ReadLine());

        if (!isValid(s))
        {
            Console.WriteLine("Invalid input");
            return;
        }

        Console.Write("D = ");
        int d = int.Parse(Console.ReadLine());

        if (!isValid(d))
        {
            Console.WriteLine("Invalid input");
            return;
        }

        Console.Write("Enter value: ");
        string a = Console.ReadLine();

        //converting from s to decimal
        int decimalRepresentation = 0;

        for (int i = a.Length - 1; i >= 0; i--)
        {
            if (a[i] == 'A' || a[i] == 'a')
            {
                decimalRepresentation += 10 * (int)Math.Pow(s, a.Length - i - 1);
            }
            else if (a[i] == 'B' || a[i] == 'b')
            {
                decimalRepresentation += 11 * (int)Math.Pow(s, a.Length - i - 1);
            }
            else if (a[i] == 'C' || a[i] == 'c')
            {
                decimalRepresentation += 12 * (int)Math.Pow(s, a.Length - i - 1);
            }
            else if (a[i] == 'D' || a[i] == 'd')
            {
                decimalRepresentation += 13 * (int)Math.Pow(s, a.Length - i - 1);
            }
            else if (a[i] == 'E' || a[i] == 'e')
            {
                decimalRepresentation += 14 * (int)Math.Pow(s, a.Length - i - 1);
            }
            else if (a[i] == 'F' || a[i] == 'f')
            {
                decimalRepresentation += 15 * (int)Math.Pow(s, a.Length - i - 1);
            }
            else
            {
                decimalRepresentation += int.Parse(a[i] + " ") * (int)Math.Pow(s, a.Length - i - 1);
            }
        }

        //converting from decimal to d
        string result = string.Empty;

        while (decimalRepresentation >= 1)
        {
            if (decimalRepresentation % d >= 10 && decimalRepresentation % d <= 15)
            {
                result += (char)('A' + decimalRepresentation % d - 10);
            }
            else
            {
                result += decimalRepresentation % d;
            }
            decimalRepresentation /= d;
        }

        //reverse result
        ReverseAndOutput(result);
    }

    static bool isValid(int n)
    {
        if (n < 2 || n > 16)
            return false;
        return true;
    }

    static void ReverseAndOutput(string result)
    {
        char[] output = new char[result.Length];

        for (int i = 0; i < result.Length; i++)
        {
            output[i] = result[result.Length - 1 - i];
        }

        Console.WriteLine(output);
    }
}

