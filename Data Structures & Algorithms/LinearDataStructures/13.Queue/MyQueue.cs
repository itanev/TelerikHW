using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Queue
{
    public class MyQueue : IEnumerable
    {
        public Item CurrentElement { get; set; }
        private Item firstElement;

        public MyQueue()
        {
            this.CurrentElement = null;
            this.firstElement = null;
        }

        public void Enqueue(object item)
        {
            Item currItem = new Item();
            currItem.Value = item;

            currItem.NextItem = CurrentElement;
            CurrentElement = currItem;
        }

        public Item Dequeue()
        {
            Item currElement = new Item();

            if (CurrentElement == null)
            {
                currElement = null;
            }
            else
            {
                currElement.Value = this.CurrentElement.Value;
                CurrentElement = CurrentElement.NextItem;
            }

            return currElement;
        }

        public IEnumerator GetEnumerator()
        {
            this.firstElement = CurrentElement;

            while (CurrentElement != null)
            {
                yield return CurrentElement.Value;
                CurrentElement = CurrentElement.NextItem;
            }

            this.CurrentElement = this.firstElement;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder queueAsString = new StringBuilder();

            foreach (var item in this)
            {
                queueAsString.AppendFormat("{0} ", CurrentElement.Value);
            }

            return queueAsString.ToString();
        }
    }
}
