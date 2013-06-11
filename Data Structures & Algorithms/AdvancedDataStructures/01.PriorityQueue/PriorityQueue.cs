using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PriorityQueue
{
    public class PriorityQueue<T> where T: IComparable
    {
        private BinaryHeap<T> queue;

        public PriorityQueue()
        {
            this.queue = new BinaryHeap<T>();
        }

        public void Push(T value)
        {
            queue.Add(value);
        }

        public T Pop()
        {
            return queue.Pop();
        }
    }
}
