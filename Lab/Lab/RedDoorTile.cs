using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class RedDoorTile : Tile , ITiles
    {
        //Sets color, chooses symbol and makes it uncolliedable
        public RedDoorTile()
        {
            Color = ConsoleColor.Red;
            Symbol = (char)Tiles.door;
            CanCollide = true;
        }

        //Prints out symbol
        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
