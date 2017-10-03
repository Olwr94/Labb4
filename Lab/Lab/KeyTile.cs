using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class KeyTile : Tile, ITiles
    {

        public bool pickedUp = false;
        public KeyTile()
        {
            Symbol = (char)Tiles.redkey;
            
        }

        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
