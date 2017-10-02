using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public abstract class Tile : Map, ITiles
    {
        public char Symbol { get; set; }

        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
