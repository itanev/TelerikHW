using System;

class SignedInt
{
    static void Main()
    {
        short num = short.Parse(Console.ReadLine());

        bool isNegative = false;

        if (num < 0)
        {
            num *= -1;
            isNegative = true;
        }

        string result = string.Empty;

        for (int i = 0; i < 16; i++)
        {
            if ((num & 1) > 0)
            {
                result += 1;
            }
            else
            {
                result += 0;
            }
            num /= 2;
        }

        char[] output = new char[result.Length];

        for (int i = 0; i < result.Length; i++)
        {
            output[i] = result[result.Length - 1 - i];
        }

        if (isNegative)
            output[0] = '1';

        Console.WriteLine(output);
    }
}

