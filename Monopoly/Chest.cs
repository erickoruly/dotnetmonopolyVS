using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Chest : Place
    {
        List<Card> Cards;

        public Chest()
        {
        }

        public Chest(String name, int price, List<Card> cards)
        {
            this.Name = name;
            this.Price = price;
            this.Cards = cards;
        }

        public override void Effect(Player p)
        {
            Console.WriteLine("You arrive at {0}.", this.Name);
            Random r = new Random();
            int index = r.Next(1, this.Cards.Count);
            Console.WriteLine("{0}", this.Cards[index].Description);
            p.Money += this.Cards[index].Price;
            //throw new NotImplementedException();
        }

        public override int SellPrice()
        {
            throw new NotImplementedException();
        }

        public override void Sold()
        {
            throw new NotImplementedException();
        }
        
    }
}
