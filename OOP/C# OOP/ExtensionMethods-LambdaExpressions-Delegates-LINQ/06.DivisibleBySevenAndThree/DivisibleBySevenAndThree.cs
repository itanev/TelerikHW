using System;
using System.Linq;
using Library;

class DivisibleBySevenAndThree
{
    static void Main()
    {
        int[] numbers = {4,5,6,7,1,6,3,8,9,21};

        //with lambda
        Console.WriteLine("With lambda");
        
        var divisibleNumbers = numbers.Where((number) => (number % 7 == 0) || (number % 3 == 0)).
                                        Select((number) => number);

        foreach (var number in divisibleNumbers)
        {
            Console.WriteLine(number);
        }

        //with LINQ
        Console.WriteLine("\nWith LINQ");

        var divNumbers =
            from number in numbers
            where number % 3 == 0 || number % 7 == 0
            select number;

        foreach (var number in divNumbers)
        {
            Console.WriteLine(number);
        }
    }
}
