using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03.MergeSort;
using System.Collections.Generic;

namespace TestSortingAlgorithms
{
    [TestClass]
    public class MergeSortTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PassingNullCollection()
        {
            MergeSorter<int> sorter = new MergeSorter<int>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PassingEmptyCollection()
        {
            MergeSorter<int> sorter = new MergeSorter<int>(new List<int>());
        }

        [TestMethod]
        public void PassingOneItemCollection()
        {
            List<int> numbers = new List<int>() {1};
            MergeSorter<int> sorter = new MergeSorter<int>(numbers);
            List<int> sortedList = new List<int>(sorter.Sort());

            Assert.AreEqual(numbers[0], sortedList[0]);
        }

        [TestMethod]
        public void PassingMultipleItemCollection()
        {
            List<int> numbers = new List<int>() { 1,2,4,5,2,1,2,3,5,7,8,9 };
            List<int> sortedNumbers = new List<int>() { 1, 1, 2, 2, 2, 3, 4, 5, 5, 7, 8, 9 };
            MergeSorter<int> sorter = new MergeSorter<int>(numbers);
            List<int> sortedList = new List<int>(sorter.Sort());

            for (int i = 0; i < numbers.Count; i++)
            {
                Assert.AreEqual(sortedNumbers[i], sortedList[i]);
            }
        }

        [TestMethod]
        public void PassingSortedItemCollection()
        {
            List<int> sortedNumbers = new List<int>() { 1, 1, 2, 2, 2, 3, 4, 5, 5, 7, 8, 9 };
            MergeSorter<int> sorter = new MergeSorter<int>(sortedNumbers);
            List<int> sortedList = new List<int>(sorter.Sort());

            for (int i = 0; i < sortedNumbers.Count; i++)
            {
                Assert.AreEqual(sortedNumbers[i], sortedList[i]);
            }
        }
    }
}
