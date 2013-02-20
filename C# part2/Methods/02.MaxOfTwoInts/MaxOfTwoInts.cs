using System;

class MaxOfTwoInts
{
    static void Main()
    {
        int a, b, c;
        Console.Write("a = ");
        a = int.Parse(Console.ReadLine());

        Console.Write("b = ");
        b = int.Parse(Console.ReadLine());

        Console.Write("c = ");
        c = int.Parse(Console.ReadLine());

        Console.WriteLine(GetMax(GetMax(a,b), c));
    }

    static int GetMax(int a, int b)
    {
        return Math.Max(a, b);
    }
}
