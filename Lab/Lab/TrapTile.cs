using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class TrapTile : Tile , ITiles
    {
        //Sets color and chooses symbol
        public TrapTile()
        {
            Color = ConsoleColor.Cyan;
            Symbol = (char)Tiles.floor;
        }

        //Prints out symbol
        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
