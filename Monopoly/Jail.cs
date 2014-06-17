using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Jail : Place
    {
        public Jail()
        {
            this.Name = "Jail";
            this.Price = 0;
        }

        public override void Effect(Player p)
        {
            Console.WriteLine("You arrive at {0}.", this.Name);
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
