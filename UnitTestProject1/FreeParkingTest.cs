using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace UnitTestProject1
{
    [TestClass]
    public class FreeParkingTest
    {
        [TestMethod]
        public void TestNewFreeParking()
        {
            FreeParking fp = new FreeParking();
            Assert.AreEqual(500, fp.Price);
        }
        [TestMethod]
        public void TestFreeParkingEffect()
        {
            Player p = new Player("asd");
            FreeParking fp = new FreeParking();
            fp.Effect(p);
            Assert.AreEqual(1000500, p.Money);
        }

    }
}
