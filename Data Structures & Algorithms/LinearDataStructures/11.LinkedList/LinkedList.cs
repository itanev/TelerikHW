using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public ListItem<T> FirstElement { get; set; }

        public LinkedList()
        {
            this.FirstElement = null;
        }

        public void Add(T item)
        {
            ListItem<T> currItem = new ListItem<T>();
            currItem.Value = item;

            currItem.NextItem = FirstElement;
            FirstElement = currItem;
        }

        public void RemoveFirst()
        {
            FirstElement = FirstElement.NextItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (FirstElement != null)
            {
                yield return FirstElement.Value;
                FirstElement = FirstElement.NextItem;
            }
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
                listAsString.AppendFormat("{0} ", FirstElement.Value);
            }

            return listAsString.ToString();
        }
    }
}
