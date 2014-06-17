using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace UnitTestProject1
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void TestNewCard()
        {
            var c = new Card("asd", 100, "wow", 0);
            Assert.AreEqual("asd", c.Name, "its same");
        }
    }
}
