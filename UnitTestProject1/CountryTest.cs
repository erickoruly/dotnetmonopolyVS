using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace UnitTestProject1
{
    [TestClass]
    public class CountryTest
    {
        [TestMethod]
        public void TestNewCountry()
        {
            var c = new Country("indo", 400);
            Assert.AreEqual("indo", c.Name);
            Assert.AreEqual(400, c.Price);
            Assert.AreEqual(4, c.MaxLevel);
            Assert.AreEqual(1, c.Level);
        }
        [TestMethod]
        public void TestSoldCountry()
        {
            var c = new Country("indo", 400);
            Assert.AreEqual(false, c.Owned);
            Assert.AreEqual(1, c.Level);
        }

    }
}
