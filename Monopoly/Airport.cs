using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Airport : Place
    {
        public bool Owned;
        Player Player;

        public Airport(String name, int price)
        {
            Name = name;
            Price = price;
            Owned = false;
            Player = null;
        }

        public override void Effect(Player p)
        {
            Console.WriteLine("You arrive at {0}.", this.Name);
            //throw new NotImplementedException();
            if (p.Owned(this) == false && this.Owned == false)// airport tidak ada yang punya
            {
                int cost = this.Price * 8;
                char ans;
                while (true && p.Money >= cost)
                {
                    Console.WriteLine("This Airport cost {0}. Do you want to buy {1} ??(y/n)", cost, this.Name);
                    ans = Convert.ToChar(Console.ReadLine());
                    if (ans == 'y')
                    {
                        p.Money -= cost;
                        this.Owned = true;
                        p.PlaceIndex++;
                        p.AddPlace(this);
                        this.Player = p;
                        Console.WriteLine("{0} just buy {1} for ${2}", p.Name, this.Name, cost);
                        break;
                    }
                    else if (ans == 'n')
                    {
                        Console.WriteLine("You either CHEAP or POOR BASTARD!!!");
                        break;
                    }
                    else Console.WriteLine("ARE YOU RETARDED?? CUZ YOU JUST PUT THE WRONG INPUT");
                }
            }
            else if (p.Owned(this) == false && this.Owned == true)// airport ada yang punya dan bukan player yng memiliki
            {
                Console.WriteLine("({0})You gotta pay buddy!!", p.Name);
                int cost = this.Price * 5;
                p.Money -= cost;
                this.Player.Money += cost;
                Console.WriteLine("{0} pay {1} to {2}", p.Name, cost, Player.Name);
            }
        }

        public override int SellPrice()
        {
            return this.Price * 4;
        }

        public override void Sold()
        {
            this.Owned = false;
            this.Player = null;
        }
    }
}
