using System;
using System.Collections.Generic;

namespace _03.BiDictionary
{
    public class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, T> firstDictionary;
        private Dictionary<K2, T> secondDictionary;

        public BiDictionary()
        {
            this.firstDictionary = new Dictionary<K1, T>();
            this.secondDictionary = new Dictionary<K2, T>();
            this.Count = 0;
        }

        public void Add(K1 firstKey, K2 secondKey, T value)
        {
            this.firstDictionary.Add(firstKey, value);
            this.secondDictionary.Add(secondKey, value);
            this.Count++;
        }

        public void Remove(K1 firstKey, K2 secondKey, T value)
        {
            this.firstDictionary.Remove(firstKey);
            this.secondDictionary.Remove(secondKey);
            this.Count--;
        }

        public T Find(K1 firstKey)
        {
            if (this.firstDictionary.ContainsKey(firstKey))
            {
                return firstDictionary[firstKey];
            }

            throw new KeyNotFoundException("The dictionary does not contain the given key.");
        }

        public T Find(K2 secondKey)
        {
            if (this.secondDictionary.ContainsKey(secondKey))
            {
                return secondDictionary[secondKey];
            }

            throw new KeyNotFoundException("The dictionary does not contain the given key.");
        }

        public T Find(K1 firstKey, K2 secondKey)
        {
            if (this.firstDictionary.ContainsKey(firstKey) &&
                this.secondDictionary.ContainsKey(secondKey))
            {
                return secondDictionary[secondKey];
            }

            throw new KeyNotFoundException("The dictionary does not contain the given keys.");
        }

        public int Count { get; set; }
    }
}
