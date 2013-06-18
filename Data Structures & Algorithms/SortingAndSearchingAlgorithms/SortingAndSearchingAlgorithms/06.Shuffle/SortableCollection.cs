using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Shuffle
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

            this.collection = collection;
        }

        /// <summary>
        /// The complexity is O(n*n) because of the RemoveAt method.
        /// Its complexity is O(n) and the for loop gives as the another half
        /// and that's how we get O(n*n).
        /// </summary>
        /// <returns></returns>
        public List<T> Shuffle()
        {
            List<T> shuffledCollection = new List<T>();
            Random randomIndex = new Random();
            int collectionLength = this.collection.Count;

            for (int i = 0; i < collectionLength; i++)
            {
                int currIndex = randomIndex.Next(0, this.collection.Count);
                shuffledCollection.Add(this.collection[currIndex]);
                this.collection.RemoveAt(currIndex);
            }

            return shuffledCollection;
        }
    }
}
