using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.LinearSearch
{
    public class SortableCollection<T> where T : IComparable
    {
        private List<T> collection;

        public SortableCollection(List<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("The collection can not be null!");
            }
            else if (collection.Count == 0)
            {
                throw new ArgumentException("The collection can not be empty!");
            }

            this.collection = new List<T>(collection);
        }

        public int LinearSearch(T searchedItem)
        {
            int index = -1;
            for (int i = 0; i < this.collection.Count; i++)
            {
                if (searchedItem.CompareTo(this.collection[i]) == 0)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
