using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class GenericList<T>
    {
        private T[] list;
        private bool[] usedIndexes;
        private int capacity;
        private int addedElements = -1;

        //initializing the list and array for used indexes
        public GenericList(int capacity)
        {
            this.list = new T[capacity];
            this.usedIndexes = new bool[capacity];

            for (int i = 0; i < capacity; i++)
            {
                usedIndexes[i] = false;
            }

            this.capacity = capacity;
        }

        private void AutoGrow()
        {
            if (this.addedElements >= this.capacity)
            {
                T[] newList = new T[this.capacity * 2];
                bool[] newUsedIndexes = new bool[this.capacity * 2];

                for (int i = 0; i < this.capacity; i++)
                {
                    newList[i] = this.list[i];
                    newUsedIndexes[i] = this.usedIndexes[i];
                }

                this.capacity *= 2;

                this.list = newList;
                this.usedIndexes = newUsedIndexes;
            }
        }

        //add element to list
        public void Add(T element)
        {
            this.addedElements++;

            //auto grow
            AutoGrow();

            //safely adding elements - this is here so it would work if you remove auto grow (ex 05)
            if (this.addedElements < this.capacity)
            {
                int addElementIndex = 0;

                //adds the element to first free index
                while (this.usedIndexes[addElementIndex])
                {
                    addElementIndex++;
                }

                usedIndexes[addElementIndex] = true;

                this.list[addElementIndex] = element;
            }
            else
            {
                throw new OverflowException("You have overflow the list! Enter bigger value for capacity.");
            }
        }

        //adds element at specified index
        public void AddElementAt(T element, int index)
        {
            if (index < this.capacity)
            {
                this.list[index] = element;

                this.addedElements++;

                this.usedIndexes[index] = true;
            }
            else
            {
                throw new IndexOutOfRangeException("Index exceeds capacity! Enter smaller value for index.");
            }
        }

        //gets value at specified index in list
        public T GetElementAt(int index)
        {
            if (index < this.capacity)
            {
                return this.list[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Index exceeds capacity! Enter smaller value for index.");
            }
        }

        //removes element at specified index and the entire position in the list
        public void RemoveElementAt(int index)
        {
            if (index < this.capacity)
            {
                //decreses the capacity and number of added elements
                this.capacity--;
                this.addedElements--;

                //creates new list
                T[] newList = new T[this.capacity];
                bool[] newUsedIndexes = new bool[capacity];
                int j = 0;

                //copy the elements in new list except the element at the specified index
                for (int i = 0; i < this.capacity+1; i++)
                {
                    if (i != index)
                    {
                        newList[j] = this.list[i];
                        newUsedIndexes[j] = this.usedIndexes[i];
                        j++;
                    }
                }

                //change reference of the inner list
                this.list = newList;
                this.usedIndexes = newUsedIndexes;
            }
            else
            {
                throw new IndexOutOfRangeException("Index exceeds capacity! Enter smaller value for index.");
            }
        }

        //clears the list by redirecting reference to empty list
        public void Clear()
        {
            T[] EmptyList = new T[this.capacity];
            bool[] EmptyUsedIndexes = new bool[this.capacity];

            //change reference
            this.list = EmptyList;
            this.usedIndexes = EmptyUsedIndexes;

            this.addedElements = -1;
        }

        //get element index by value
        public int GetElementIndex(T value)
        {
            for (int i = 0; i < this.capacity; i++)
            {
                if (this.list[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        //checks if list contains the value
        public bool Contains(T value)
        {
            if (this.list.Contains(value))
            {
                return true;
            }
            
            return false;
        }

        //overrides the ToString() method
        public override string ToString()
        {
            StringBuilder output = new StringBuilder(this.capacity);

            for (int i = 0; i < this.capacity; i++)
            {
                output.AppendFormat("{0} ", this.list[i]);
            }

            return output.ToString();
        }

        //generic Min method
        public T Min<T>() where T : IComparable<T>, IComparable
        {
            dynamic min = this.list[0];

            for (int i = 0; i < this.capacity; i++)
            {
                if (this.list[i] < min)
                {
                    min = this.list[i];
                }
            }

            return min;
        }

        //generic Max method
        public T Max<T>() where T : IComparable<T>, IComparable
        {
            dynamic max = this.list[0];

            for (int i = 0; i < this.capacity; i++)
            {
                if (this.list[i] > max)
                {
                    max = this.list[i];
                }
            }

            return max;
        }
    }
}
