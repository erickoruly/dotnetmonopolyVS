using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class FreeParking : Place
    {
        public FreeParking()
        {
            this.Name = "Free Parking Area";
            this.Price = 500;
        }

        public override void Effect(Player p)
        {
            Console.WriteLine("You arrive at {0}.", this.Name);
            p.Money = p.Money + this.Price;
            Console.WriteLine("{0} just get {1}.", p.Name, this.Price);
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
