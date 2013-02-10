using System;

class DecimalToHex
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        string result = string.Empty;

        while(number >= 1)
        {
            if (number % 16 == 10)
            {
                result += 'A';
            }
            else if (number % 16 == 11)
            {
                result += 'B';
            }
            else if (number % 16 == 12)
            {
                result += 'C';
            }
            else if (number % 16 == 13)
            {
                result += 'D';
            }
            else if (number % 16 == 14)
            {
                result += 'E';
            }
            else if (number % 16 == 15)
            {
                result += 'F';
            }
            else
            {
                result += number % 16;
            }
            
            number /= 16;
        }

        char[] output = new char[result.Length];

        for (int i = 0; i < result.Length; i++)
        {
            output[i] = result[result.Length - 1 - i];
        }

        Console.WriteLine(output);
    }
}