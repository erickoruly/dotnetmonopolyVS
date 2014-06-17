using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace UnitTestProject1
{
    [TestClass]
    public class DiceTest
    {
        [TestMethod]
        public void TestNewDice()
        {
            var d = new Dice();
            d.Roll();
            Assert.AreNotEqual(7, d.Number);
            Assert.AreNotEqual(0, d.Number);
        }
    }
}
