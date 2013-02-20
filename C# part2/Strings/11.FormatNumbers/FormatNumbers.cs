using System;

class FormatNumbers
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Decimal:    {0,15}", n);
        Console.WriteLine("hexdecimal: {0,15:X}", n);
        Console.WriteLine("Percentage: {0,15:P}", n);
        Console.WriteLine("Scientific: {0,15:E}", n);
    }
}