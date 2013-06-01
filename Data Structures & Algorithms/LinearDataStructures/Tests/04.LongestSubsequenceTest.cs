using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LongestSubsequence;

namespace Tests
{
    [TestClass]
    public class LongestSubsequenceTest
    {
        [TestMethod]
        public void LongestSubsequenceOfOneNumber()
        {
            List<int> theNumbers = new List<int> { 1 };
            Utils longestSubsequenceUtils = new Utils();
            List<int> longestSubsequence = longestSubsequenceUtils.FindLongestSubsequence(theNumbers);

            Assert.AreEqual(1, longestSubsequence[0]);
        }

        [TestMethod]
        public void LongestSubsequenceOfManyNumbers()
        {
            List<int> theNumbers = new List<int>{ 1,3,2,2,4,56,67,7,1 };
            Utils longestSubsequenceUtils = new Utils();
            List<int> longestSubsequence = longestSubsequenceUtils.FindLongestSubsequence(theNumbers);

            Assert.AreEqual(2, longestSubsequence.Count);

            foreach (var number in longestSubsequence)
            {
                Assert.AreEqual(2, number);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LongestSubsequenceNoNumbers()
        {
            List<int> theNumbers = new List<int>();
            Utils longestSubsequenceUtils = new Utils();
            List<int> longestSubsequence = longestSubsequenceUtils.FindLongestSubsequence(theNumbers);
        }
    }
}
