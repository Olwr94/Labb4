using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class LockPickTile : Tile, ITiles
    {

        public bool pickedUp = false;
        public LockPickTile()
        {
            Color = ConsoleColor.DarkGreen;
            Symbol = (char)Tiles.lockPick;

        }

        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
