using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test04
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] a = { 1,2,3,1 };
            int result = NumberOccurences.NumberOccurences.GetOccurences(a, 1);
            Assert.AreEqual(2, result);
        }
    }
}
