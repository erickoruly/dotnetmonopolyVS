using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class ChestTest
    {
        [TestMethod]
        public void TestNewChest()
        {
            var c = new Card("250", 250, "player get money 250", 0);
            List<Card> cards = new List<Card>();
            cards.Add(c);
            var chest = new Chest("chest1", 0, cards);

            Assert.AreEqual("chest1", chest.Name, "its same");
            Assert.AreEqual(0, chest.Price, "its same");
        }

        [TestMethod]
        public void TestChestEffect()
        {
            Player p = new Player("ASD");
            var c = new Card("card1", 250, "player get money 250", 0);
            var c1 = new Card("card2", 250, "player get money 250", 0);
            List<Card> cards = new List<Card>();
            cards.Add(c);
            cards.Add(c1);
            var chest = new Chest("chest1", 0, cards);
            chest.Effect(p);
            Assert.AreEqual("chest1", chest.Name, "its same");
            Assert.AreEqual(1000250, p.Money);
        }
    }
}
