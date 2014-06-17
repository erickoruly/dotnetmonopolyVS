using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Dice
    {
        public int Number;
        static Random r = new Random();

        public Dice()
        {
            Number = 1;
        }

        public int Roll()
        {
            Number = r.Next(1, 7);
            return Number;
        }
    }
}
