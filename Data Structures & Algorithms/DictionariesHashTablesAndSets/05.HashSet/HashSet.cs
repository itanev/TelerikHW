using System;
using System.Collections.Generic;
using System.Linq;
using _04.HashTable;

namespace _05.HashSet
{
    public class HashSet<T> : IEnumerable<T>
    {
        private HashTable<int, T> hashTable;

        public HashSet()
        {
            hashTable = new HashTable<int, T>();
        }

        public int Count { get; set; }

        public void Add(T item)
        {
            this.Count++;
            int key = this.GetHash(item);
            hashTable.Add(key, item);
        }

        public T Find(T item)
        {
            int key = this.GetHash(item);
            var foundItem = this.hashTable.Find(key);

            return foundItem;
        }

        public void Remove(T item)
        {
            try
            {
                int key = this.GetHash(item);
                var foundItem = this.hashTable.Find(key);
                if (foundItem != null)
                {
                    this.Count--;
                    this.hashTable.Remove(key);
                }
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public HashSet<T> Union(HashSet<T> other)
        {
            HashSet<T> theUnion = new HashSet<T>();

            foreach (var item in this.hashTable)
            {
                theUnion.Add(item.Value);
            }

            foreach (var item in other)
            {
                try
                {
                    this.Find(item);
                }
                catch(ArgumentException ex)
                {
                    theUnion.Add(item);
                }
            }

            return theUnion;
        }

        public HashSet<T> Intersect(HashSet<T> other)
        {
            HashSet<T> theIntersect = new HashSet<T>();

            foreach (var item in other)
            {
                try
                {
                    this.Find(item);
                    theIntersect.Add(item);
                }
                catch (ArgumentException ex)
                {
                    
                }
            }

            return theIntersect;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.hashTable)
            {
                yield return item.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetHash(T item)
        {
            return Math.Abs(item.GetHashCode());
        }
    }
}
