using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BinarySearch
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

        public int BinarySearch(T searchedItem)
        {
            return this.Search(0, this.collection.Count, searchedItem);
        }

        private int Search(int leftBoud, int rightBound, T item)
        {
            int middle = (leftBoud + rightBound) / 2;
            int index = -1;

            if (leftBoud < rightBound)
            {
                if (item.CompareTo(this.collection[middle]) < 0)
                {
                    index = Search(leftBoud, middle, item);
                }
                else if (item.CompareTo(this.collection[middle]) > 0)
                {
                    index = Search(middle + 1, rightBound, item);
                }
                else
                {
                    return middle;
                }
            }

            return index;
        }
    }
}
