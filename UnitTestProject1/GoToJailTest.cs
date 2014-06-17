using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace UnitTestProject1
{
    [TestClass]
    public class GoToJailTest
    {
        [TestMethod]
        public void TestNewGoToJail()
        {
            var gtj = new GoToJail();
            Assert.AreEqual("Go to Jail", gtj.Name);
            Assert.AreEqual(0, gtj.Price);
        }
        [TestMethod]
        public void TestGoToJailEffect()
        {
            var gtj = new GoToJail();
            var p = new Player("asd");
            gtj.Effect(p);
            Assert.AreEqual(8, p.Position);
            Assert.AreEqual(3, p.Arrest);
        }

    }
}
