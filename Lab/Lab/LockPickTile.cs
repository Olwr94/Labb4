using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class LockPickTile : Tile, ITiles
    {
        //Sets color, chooses symbol and pickable
        public LockPickTile()
        {
            PickedUp = false;
            Color = ConsoleColor.DarkGreen;
            Symbol = (char)Tiles.lockPick;
        }

        //Prints symbol
        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
