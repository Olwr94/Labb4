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
            Color = ConsoleColor.Red;
            Symbol = (char)Tiles.key;

        }
        private int amountRedKeys;
        public int AmountRedKeys
        {
            get { return amountRedKeys; }
            set { amountRedKeys = value; }
        }
        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
