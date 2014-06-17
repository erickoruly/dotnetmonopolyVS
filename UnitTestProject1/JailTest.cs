using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace UnitTestProject1
{
    [TestClass]
    public class JailTest
    {
        [TestMethod]
        public void TestNewJail()
        {
            var j = new Jail();
            Assert.AreEqual("Jail", j.Name);
            Assert.AreEqual(0, j.Price);
        }
    }
}
