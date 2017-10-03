using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class RedKeyTile : Tile , ITiles
    {
        public bool pickedUp = false;
        public RedKeyTile()
        {
            IsVisible = true;
            Color = ConsoleColor.Red;
            Symbol = (char)Tiles.key;

        }

        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
