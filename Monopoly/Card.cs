using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Card
    {
        public String Name;
        public int Price;
        public String Description;
        public int Effect;

        public Card()
        {
        }

        public Card(String name, int price, String description, int effect)
        {
            Name = name;
            Price = price;
            Description = description;
            Effect = effect;
        }
    }
}
