using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01.SelectionSort;
using System.Collections.Generic;

namespace TestSortingAlgorithms
{
    [TestClass]
    public class SelectionSortTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PassingNullCollection()
        {
            SelectionSorter<int> selectionSorter = new SelectionSorter<int>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PassingEmptyCollection()
        {
            SelectionSorter<int> selectionSorter = new SelectionSorter<int>(new List<int>());
        }

        [TestMethod]
        public void PassingOneItemCollection()
        {
            List<int> numbers = new List<int>() {1};
            SelectionSorter<int> selectionSorter = new SelectionSorter<int>(numbers);
            List<int> sortedList = new List<int>(selectionSorter.Sort());

            Assert.AreEqual(numbers[0], sortedList[0]);
        }

        [TestMethod]
        public void PassingMultipleItemCollection()
        {
            List<int> numbers = new List<int>() { 1,2,4,5,2,1,2,3,5,7,8,9 };
            List<int> sortedNumbers = new List<int>() { 1, 1, 2, 2, 2, 3, 4, 5, 5, 7, 8, 9 };
            SelectionSorter<int> selectionSorter = new SelectionSorter<int>(numbers);
            List<int> sortedList = new List<int>(selectionSorter.Sort());

            for (int i = 0; i < numbers.Count; i++)
            {
                Assert.AreEqual(sortedNumbers[i], sortedList[i]);
            }
        }

        [TestMethod]
        public void PassingSortedItemCollection()
        {
            List<int> sortedNumbers = new List<int>() { 1, 1, 2, 2, 2, 3, 4, 5, 5, 7, 8, 9 };
            SelectionSorter<int> sorter = new SelectionSorter<int>(sortedNumbers);
            List<int> sortedList = new List<int>(sorter.Sort());

            for (int i = 0; i < sortedNumbers.Count; i++)
            {
                Assert.AreEqual(sortedNumbers[i], sortedList[i]);
            }
        }
    }
}
