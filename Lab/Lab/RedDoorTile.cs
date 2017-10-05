using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class RedDoorTile : Tile , ITiles
    {
        public RedDoorTile()
        {
            Color = ConsoleColor.Red;
            Symbol = (char)Tiles.door;
            CanCollide = true;
        }

        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
