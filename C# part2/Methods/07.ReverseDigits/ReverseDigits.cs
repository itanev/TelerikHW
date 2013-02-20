using System;
using System.Text;

class ReverseDigits
{
    static void Main()
    {
        Console.WriteLine(ReverseTheDigits(567));
    }

    static string ReverseTheDigits(int number)
    {
        string result = string.Empty;

        while (number > 1)
        {
            result += number % 10;
            number /= 10;
        }

        Array.Reverse(result.ToCharArray());

        result.ToString();

        return result;
    }
}