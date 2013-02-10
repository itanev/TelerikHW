using System;

class DecimalToBinary
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        string result = string.Empty;
       
        while (number >= 1)
        {
            if ((number & 1) > 0)
            {
                result += 1;
            }
            else
            {
                result += 0;
            }
            number /= 2;
        }

        char[] output = new char[result.Length];

        for (int i = 0; i < result.Length; i++)
        {
            output[i] = result[result.Length - 1 - i];
        }

        Console.WriteLine(output);
    }
}
