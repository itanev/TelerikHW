using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.FindShortestSequenceOfOperations
{
    public class FindShortestSequenceOfOperations
    {
        public enum Operation
        {
            PlusOne,
            PlusTwo,
            TwoTimes
        }

        public static void Main()
        {
            Console.Write("Enter start number (N): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter end number (M): ");
            int m = int.Parse(Console.ReadLine());

            List<Operation> operations = new List<Operation> { Operation.TwoTimes, Operation.PlusTwo, Operation.PlusOne };

            Stack<int> sequence = new Stack<int>();
            sequence.Push(n);

            int currNumber = sequence.Peek();
            int currOperationIndex = 0;
            Operation currOperation = operations[currOperationIndex];

            while (currNumber != m)
            {
                switch (currOperation)
                {
                    case Operation.TwoTimes:
                        currNumber *= 2;
                        currOperationIndex = 0;
                        break;
                    case Operation.PlusTwo:
                        currNumber += 2;
                        currOperationIndex = 1;
                        break;
                    case Operation.PlusOne:
                        currNumber += 1;
                        currOperationIndex = 2;
                        break; 
                    default:
                        currOperationIndex = 0;
                        break;
                }

                if (currNumber <= m)
                {
                    sequence.Push(currNumber);
                    currOperationIndex = 0;
                }
                else
                {
                    currNumber = sequence.Peek();
                    currOperationIndex++;
                }

                currOperation = operations[currOperationIndex];
            }

            Console.WriteLine(string.Join("->", sequence));
        }
    }
}
