using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class RedKeyTile : Tile , ITiles
    {
        //Sets color, chooses symbol and so you can pickup items
        public RedKeyTile()
        {
            Color = ConsoleColor.Red;
            Symbol = (char)Tiles.key;
            PickedUp = false;
        }

        //Red key counter
        private int amountRedKeys;
        public int AmountRedKeys
        {
            get { return amountRedKeys; }
            set { amountRedKeys = value; }
        }

        //Prints symbol
        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
