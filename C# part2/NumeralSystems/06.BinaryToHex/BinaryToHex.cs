using System;

class BinaryToHex
{
    static void Main()
    {
        string binaryNumber = Console.ReadLine();
        string four = string.Empty;

        if (binaryNumber.Length % 4 != 0)
        {
            while(binaryNumber.Length % 4 != 0)
            {
                binaryNumber = binaryNumber.Insert(0, "0");
            }
        }

        for (int i = 0; i < binaryNumber.Length; i++)
        {
            four += binaryNumber[i];
            if ((i + 1) % 4 == 0)
            {
                if (ConvertToDecimal(four) == 10)
                {
                    Console.Write('A');
                }
                else if (ConvertToDecimal(four) == 11)
                {
                    Console.Write('B');
                }
                else if (ConvertToDecimal(four) == 12)
                {
                    Console.Write('C');
                }
                else if (ConvertToDecimal(four) == 13)
                {
                    Console.Write('D');
                }
                else if (ConvertToDecimal(four) == 14)
                {
                    Console.Write('E');
                }
                else if (ConvertToDecimal(four) == 15)
                {
                    Console.Write('F');
                }
                else
                {
                    Console.Write(ConvertToDecimal(four));
                }
                four = string.Empty;
            }
        }
        Console.WriteLine();
    }

    static int ConvertToDecimal(string four)
    {
        int result = 0;

        for (int i = 3; i >= 0; i--)
        {
            result += int.Parse(four[i] + " ") * (int)Math.Pow(2, 3-i);
        }

        return result;
    }
}

