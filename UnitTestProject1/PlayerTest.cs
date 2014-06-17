using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace UnitTestProject1
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestNewPlayer()
        {
            var p = new Player("ericko");
            Assert.AreEqual("ericko", p.Name);
            Assert.AreEqual(1000000, p.Money);
            Assert.AreEqual(1, p.Position);
            Assert.AreEqual(0, p.PlaceIndex);
            Assert.AreEqual(true, p.Alive);
            Assert.AreEqual(0, p.Arrest);
        }
        [TestMethod]
        public void TestPlayerCheckMoney()
        {
            var p = new Player("ericko");
            p.Money = 0;
            p.CheckMoney();
            Assert.AreEqual(false, p.Alive);
        }
        [TestMethod]
        public void TestPlayerOwned()
        {
            var p = new Player("ericko");
            var c1 = new Country("indo", 100);
            var c2 = new Country("china", 100);
            var c3 = new Country("jap", 100);
            p.AddPlace(c1);
            p.AddPlace(c2);
            p.AddPlace(c3);
            bool test = p.Owned(c2);
            Assert.AreEqual(true, test);

        }
    }
}
