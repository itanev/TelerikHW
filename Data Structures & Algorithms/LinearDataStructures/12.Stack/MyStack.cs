using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private T[] elementHolder;
        private int capacity = 4;

        public int Count { get; set; }

        public MyStack()
        {
            elementHolder = new T[capacity];
            this.Count = 0;
        }

        public void Push(T item)
        {
            int holderLength = elementHolder.Length;

            if (this.Count + 1 > this.capacity)
            {
                this.capacity *= 2;
                T[] currHolder = elementHolder;
                elementHolder = new T[capacity];

                for (int i = 0; i < holderLength; i++)
                {
                    elementHolder[i] = currHolder[i];
                }

                this.Count = holderLength;
            }

            elementHolder[this.Count] = item;
            this.Count++;
        }

        public void RemoveFirst()
        {
            this.Count--;
        }

        public T Pop()
        {
            this.Count--;
            T currElement = this.elementHolder[Count];
            return currElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return elementHolder[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sequenceAsString = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
			{
                sequenceAsString.AppendFormat("{0} ", elementHolder[i]);
            }

            return sequenceAsString.ToString();
        }
    }
}
