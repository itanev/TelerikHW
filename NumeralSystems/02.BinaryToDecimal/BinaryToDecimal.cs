using System;

class BinaryToDecimal
{
    static void Main()
    {
        string binaryNumber = Console.ReadLine();
        int result = 0;

        for (int i = binaryNumber.Length-1; i >= 0; i--)
        {
            result += int.Parse(binaryNumber[i] + " ") * (int)Math.Pow(2, i);
        }

        Console.WriteLine(result);
    }
}
