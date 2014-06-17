using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Country : Place
    {
        public int MaxLevel;
        public int Level;
        public bool Owned;
        Player Player;

        public Country(String name, int price)
        {
            Name = name;
            Level = 1;
            MaxLevel = 4;
            Price = price;
            Owned = false;
            Player = null;
        }

        public override void Effect(Player p)
        {
            //throw new NotImplementedException();
            Console.WriteLine("You arrive at {0}.", this.Name);
            if (p.Owned(this) == false && this.Owned == false)
            {
                int cost = this.Price * (this.Level * 8);
                char ans;
                while (true && p.Money >= cost)// country tidak ada yang punya
                {
                    Console.WriteLine("This country cost {0}. Do you want to buy this country ??(y/n)", cost);
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
            else if (p.Owned(this) == false && this.Owned == true)// country ada yang punya cmn bukan player
            {
                Console.WriteLine("({0})You gotta pay buddy!!", p.Name);
                int cost = this.Price * (this.Level * 4);
                p.Money -= cost;
                this.Player.Money += cost;
                Console.WriteLine("{0} pay {1} to {2}", p.Name, cost, Player.Name);
            }
            else if(p.Owned(this) == true && this.Level < this.MaxLevel) // country pny player
            {
                while (true)
                {
                    char ans;
                    Console.WriteLine("You want to improve your country ??(y/n)");
                    ans = Convert.ToChar(Console.ReadLine());
                    if (ans == 'y')
                    {
                        int cost = this.Price * (this.Level * 5);
                        this.Level++;
                        p.Money -= cost;
                        Console.WriteLine("You just improve this country. Cost {0}.", cost);
                        break;
                    }
                    else if (ans == 'n')
                    {
                        Console.WriteLine("You want to lose?? cuz thats how you lose in this game!!");
                        break;
                    }
                    else Console.WriteLine("ARE YOU RETARDED?? CUZ YOU JUST PUT THE WRONG INPUT");
                }
            }
        }

        public override int SellPrice()
        {
            return this.Price * ((this.Level )* 4) * this.Level;
        }

        public override void Sold()
        {
            this.Owned = false;
            this.Player = null;
            this.Level = 1;
        }
    }
}
