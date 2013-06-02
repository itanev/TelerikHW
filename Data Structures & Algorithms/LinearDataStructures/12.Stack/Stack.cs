using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Stack
{
    public class Stack
    {
        public static void Main()
        {
            MyStack<int> testStack = new MyStack<int>();

            testStack.Push(1);
            testStack.Push(2);
            testStack.Push(3);
            testStack.Push(1);
            testStack.Push(4);
            testStack.Push(4);
            testStack.Push(2);
            testStack.Push(7);

            Console.WriteLine(testStack);

            Console.WriteLine(testStack.Pop());

            testStack.Push(12);
            Console.WriteLine(testStack);
        }
    }
}
