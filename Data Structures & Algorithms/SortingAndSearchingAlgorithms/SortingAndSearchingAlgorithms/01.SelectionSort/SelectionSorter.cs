using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.SelectionSort
{
    public class SelectionSorter<T> where T : IComparable<T>
    {
        private List<T> colection;

        public SelectionSorter(IList<T> colection)
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
            for (int i = 0; i < this.colection.Count; i++)
            {
                for (int j = i + 1; j < this.colection.Count; j++)
                {
                    if (this.colection[j].CompareTo(this.colection[i]) < 0)
                    {
                        T holder = colection[j];
                        colection[j] = colection[i];
                        colection[i] = holder;
                    }
                }
            }

            return this.colection;
        }
    }
}
