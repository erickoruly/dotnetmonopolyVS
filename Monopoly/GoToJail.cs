using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class GoToJail : Place
    {
        public GoToJail()
        {
            this.Name = "Go to Jail";
            this.Price = 0;
        }

        public override void Effect(Player p)
        {
            Console.WriteLine("You arrive at {0}.", this.Name);
            p.Position = 8;
            Console.WriteLine("{0} go to Jail", p.Name);
            p.Arrest = 3;
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
