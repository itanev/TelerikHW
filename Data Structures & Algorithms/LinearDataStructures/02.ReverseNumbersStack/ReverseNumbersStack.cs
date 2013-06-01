using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ReverseNumbersStack
{
    public class ReverseNumbersStack
    {
        public static void Main()
        {
            Stack<int> numbers = new Stack<int>();

            int currNumber = 0;
            bool isValidNumber = false;

            do
            {
                Console.Write("Enter number: ");
                isValidNumber = int.TryParse(Console.ReadLine(), out currNumber);
                numbers.Push(currNumber);
            }
            while (isValidNumber);

            numbers.Pop();

            Console.WriteLine("Original numbers:");
            Console.WriteLine(string.Join(" ", numbers.Reverse()));
            Console.WriteLine("Reversed numbers:");
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
