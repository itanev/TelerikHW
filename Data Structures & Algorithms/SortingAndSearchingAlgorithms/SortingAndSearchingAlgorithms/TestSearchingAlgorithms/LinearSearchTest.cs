using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04.LinearSearch;
using System.Collections.Generic;

namespace TestSearchingAlgorithms
{
    [TestClass]
    public class LinearSearchTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PassNullCollection()
        {
            SortableCollection<int> sortableCollection = new SortableCollection<int>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PassEmptyCollection()
        {
            SortableCollection<int> sortableCollection = new SortableCollection<int>(new List<int>());
        }

        [TestMethod]
        public void FindItemTest()
        {
            List<int> numbers = new List<int>() { 1,2,3,5,6,7,8,3,32,2,2,34,5,3 };
            SortableCollection<int> sortableCollection = new SortableCollection<int>(numbers);

            int index = sortableCollection.LinearSearch(3);
            int expectedIndex = 2;

            Assert.AreEqual(expectedIndex, index);
        }

        [TestMethod]
        public void DoesNotFindItemTest()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 5, 6, 7, 8, 3, 32, 2, 2, 34, 5, 3 };
            SortableCollection<int> sortableCollection = new SortableCollection<int>(numbers);

            int index = sortableCollection.LinearSearch(34345);
            int expectedIndex = -1;

            Assert.AreEqual(expectedIndex, index);
        }
    }
}
