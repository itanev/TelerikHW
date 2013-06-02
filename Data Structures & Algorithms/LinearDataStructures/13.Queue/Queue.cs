using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.Queue
{
    public class Queue
    {
        public static void Main()
        {
            MyQueue testQueue = new MyQueue();

            testQueue.Enqueue("some item");
            testQueue.Enqueue(1);
            testQueue.Enqueue(1.24);

            Console.WriteLine(testQueue);

            var element = testQueue.Dequeue();

            while (element != null)
            {
                Console.WriteLine(element);
                element = testQueue.Dequeue();
            }
        }
    }
}
