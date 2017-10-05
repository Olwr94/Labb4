using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class DoorTile : Tile, ITiles
    {
        public DoorTile()
        {
            Color = ConsoleColor.White; 
            Symbol = (char)Tiles.door;
            CanCollide = true;
        }

        public void Print()
        {
            Console.Write(Symbol); 
        }
    }
}
