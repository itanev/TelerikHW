using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PrintFirstMembersFromSequence
{
    public class PrintFirstMembersFromSequence
    {
        public static void Main()
        {
            Console.Write("Enter value for N: ");
            int n = int.Parse(Console.ReadLine());
            const int numMembersToPrint = 50;

            Queue<int> baseMembers = new Queue<int>();
            baseMembers.Enqueue(n);
            int currCoefficient = baseMembers.Dequeue();

            List<int> resultNumbers = new List<int>();
            resultNumbers.Add(n);

            for (int i = 1; i < numMembersToPrint; i += 3)
            {
                resultNumbers.Add(currCoefficient + 1);
                resultNumbers.Add(2 * currCoefficient + 1);
                resultNumbers.Add(currCoefficient + 2);

                baseMembers.Enqueue(currCoefficient + 1);
                baseMembers.Enqueue(2 * currCoefficient + 1);
                baseMembers.Enqueue(currCoefficient + 2);
                currCoefficient = baseMembers.Dequeue();
            }

            PrintNumbers(resultNumbers, numMembersToPrint);
        }

        private static void PrintNumbers(List<int> numbers, int howMany)
        {
            Console.WriteLine(string.Join(", ", numbers.GetRange(0, howMany)));
        }
    }
}
