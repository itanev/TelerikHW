using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.QuickSort
{
    public class QuickSorter<T> where T : IComparable
    {
        private List<T> colection;

        public QuickSorter(List<T> colection)
        {
            if (colection == null)
            {
                throw new ArgumentNullException("The collection can not be null!");
            }
            else if (colection.Count == 0)
            {
                throw new ArgumentException("The collection can not be empty!");
            }

            this.colection = new List<T>(colection);
        }

        public List<T> Sort()
        {
            return QuickSort(this.colection);
        }

        private List<T> QuickSort(List<T> currList)
        {
            if (currList.Count <= 1)
            {
                return currList;
            }

            T pivot = currList[currList.Count / 2];
            currList.RemoveAt(currList.Count / 2);

            List<T> less = new List<T>();
            List<T> gratter = new List<T>();

            foreach (var item in currList)
            {
                if (item.CompareTo(pivot) < 0)
                {
                    less.Add(item);
                }
                else
                {
                    gratter.Add(item);
                }
            }

            return Concatenate(QuickSort(less), pivot, QuickSort(gratter));
        }

        private List<T> Concatenate(List<T> less, T pivot, List<T> gratter)
        {
            List<T> concatenatedList = new List<T>();
            concatenatedList.AddRange(less);
            concatenatedList.Add(pivot);
            concatenatedList.AddRange(gratter);

            return concatenatedList;
        }
    }
}
