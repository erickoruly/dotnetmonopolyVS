using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        public String Name;
        public int Money;
        public int Position;
        public int PlaceIndex;
        List<Place> Places;
        public bool Alive;
        public int Arrest;

        public Player()
        {
        }

        public Player(String name)
        {
            this.Name = name;
            this.Money = 1000000;
            this.Position = 1;
            this.PlaceIndex = 0;
            this.Alive = true;
            this.Places = new List<Place>() ;
            this.Arrest = 0;
        }

        public bool Owned(Place p) // mengetahui apakah player sudah memiliki tempat yang dicari
        {
            if(Places != null)
            {
                foreach (Place element in Places)
                {
                    if (element.Name.Equals(p.Name)) return true;
                }
            }
            return false;
        }

        public void AddPlace(Place p)
        {
            Places.Add(p);
            PlaceIndex++;
        }

        public bool CheckMoney() // mengecek apakah player sudah bangkrut atau belum
        {
            if (this.Money <= 0)
            {
                Console.WriteLine("{0} is bancrupt", this.Name);
                this.Alive = false;
                return false;
            }
            return true;
        }

        public bool CheckPlace()// check apakah player punya tempat yang telah dibeli
        {
            if (this.PlaceIndex == 0) return false;
            else return true;
        }

        public void SellPlaces()
        {
            while (true)
            {
                Console.WriteLine("List of place {0} have : ", this.Name);
                int i = 1;
                Console.WriteLine("=========================================================================");
                Console.WriteLine();
                foreach (Place place in this.Places)
                {
                    Console.WriteLine("{0}. Name : {1}, Sell Price : {2}.", i, place.Name, place.SellPrice());
                }
                Console.WriteLine("=========================================================================");
                Console.WriteLine();
                Console.WriteLine("Do you want to sell something ?? (yes = 1, no = 2)");
                int ans = Convert.ToInt32(Console.ReadLine());
                if (ans == 2) break;
                else if (ans == 1)
                {
                    Console.WriteLine("Choose the index of the place you want to sell (0 = cancel) : ");
                    int ans1 = Convert.ToInt32(Console.ReadLine());
                    if (ans1 > 0 && ans1 <= this.Places.Count)
                    {
                        this.Money += this.Places[ans1 - 1].SellPrice();
                        Console.WriteLine("{0} has been sold. {1} get {2}.", this.Places[ans1 - 1].Name, this.Name, this.Places[ans1 - 1].SellPrice());
                        this.Places[ans1-1].Sold();
                        this.Places.RemoveAt(ans1 - 1);
                        this.PlaceIndex--;
                    }
                    else if (ans1 == 0) continue;
                    else Console.WriteLine("WRONG INPUT");
                }
                else Console.WriteLine("WRONG INPUT");
                if (this.PlaceIndex == 0) break;
            }
        }
    }
}
