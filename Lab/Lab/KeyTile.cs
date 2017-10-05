﻿using System;
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
            Color = ConsoleColor.White;
            Symbol = (char)Tiles.key;
            
        }
        private int amountKeys;
        public int AmountKeys
        {
            get { return amountKeys; }
            set { amountKeys = value; }
        }
        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
