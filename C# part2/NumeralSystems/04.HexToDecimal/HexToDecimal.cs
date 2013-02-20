using System;

class HexToDecimal
{
    static void Main()
    {
        string hexNumber = Console.ReadLine();
        int result = 0;

        for (int i = hexNumber.Length - 1; i >= 0; i--)
        {
            if (hexNumber[i] == 'A' || hexNumber[i] == 'a')
            {
                result += 10 * (int)Math.Pow(16, hexNumber.Length - i - 1);
            }
            else if (hexNumber[i] == 'B' || hexNumber[i] == 'b')
            {
                result += 11 * (int)Math.Pow(16, hexNumber.Length - i - 1);
            }
            else if (hexNumber[i] == 'C' || hexNumber[i] == 'c')
            {
                result += 12 * (int)Math.Pow(16, hexNumber.Length - i - 1);
            }
            else if (hexNumber[i] == 'D' || hexNumber[i] == 'd')
            {
                result += 13 * (int)Math.Pow(16, hexNumber.Length - i - 1);
            }
            else if (hexNumber[i] == 'E' || hexNumber[i] == 'e')
            {
                result += 14 * (int)Math.Pow(16, hexNumber.Length - i - 1);
            }
            else if (hexNumber[i] == 'F' || hexNumber[i] == 'f')
            {
                result += 15 * (int)Math.Pow(16, hexNumber.Length - i - 1);
            }
            else
            {
                result += int.Parse(hexNumber[i] + " ") * (int)Math.Pow(16, hexNumber.Length - i - 1);
            }
        }

        Console.WriteLine(result);
    }
}
