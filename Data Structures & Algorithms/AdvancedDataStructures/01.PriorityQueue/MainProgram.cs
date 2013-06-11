using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.PriorityQueue
{
    public class MainProgram
    {
        public static void Main()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();

            queue.Push(1);
            queue.Push(2);
            queue.Push(12);
            queue.Push(34);
            queue.Push(6);
            queue.Push(9);

            Console.WriteLine(queue.Pop());
            Console.WriteLine(queue.Pop());
        }
    }
}
