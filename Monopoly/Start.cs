using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly 
{
    public class Start : Place
    {
        public Start()
        {
            this.Name = "Start";
            this.Price = 0;
        }

        public override void Effect(Player p)
        {
            Console.WriteLine("You arrive at {0}.", this.Name);
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
