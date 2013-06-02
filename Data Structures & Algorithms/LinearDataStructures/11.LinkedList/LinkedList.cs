using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public ListItem<T> CurrentElement { get; set; }
        private ListItem<T> firstElement;

        public LinkedList()
        {
            this.CurrentElement = null;
            this.firstElement = null;
        }

        public void Add(T item)
        {
            ListItem<T> currItem = new ListItem<T>();
            currItem.Value = item;

            currItem.NextItem = CurrentElement;
            CurrentElement = currItem;
        }

        public void RemoveFirst()
        {
            CurrentElement = CurrentElement.NextItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            this.firstElement = this.CurrentElement;

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
            StringBuilder listAsString = new StringBuilder();

            foreach (var item in this)
            {
                listAsString.AppendFormat("{0} ", CurrentElement.Value);
            }

            return listAsString.ToString();
        }
    }
}
