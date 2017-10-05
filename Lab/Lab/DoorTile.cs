using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class DoorTile : Tile, ITiles
    {
        //Sets color, chooses symbol and makes it uncolliedable
        public DoorTile()
        {
            Color = ConsoleColor.White; 
            Symbol = (char)Tiles.door;
            CanCollide = true;
        }

        //Prints symbols
        public void Print()
        {
            Console.Write(Symbol); 
        }
    }
}
