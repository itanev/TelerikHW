using System;

class StringSequenceSum
{
    static void Main()
    {
        string sequence = "10 304 4 32 54";

        string[] numbers = sequence.Split(' ');

        int sum = 0;

        foreach (var num in numbers)
        {
            sum += int.Parse(num);
        }

        Console.WriteLine(sum);
    }
}