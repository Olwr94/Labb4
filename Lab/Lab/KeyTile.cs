using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class KeyTile : Tile, ITiles
    {
        //Sets color, chooses symbol and so you can pickup items
        public KeyTile()
        {
            Color = ConsoleColor.White;
            Symbol = (char)Tiles.key;
            PickedUp = false;
        }

        //White key counter
        private int amountKeys;
        public int AmountKeys
        {
            get { return amountKeys; }
            set { amountKeys = value; }
        }

        //Prints symbol
        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
