﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class TrapTile : Tile , ITiles
    {
        public TrapTile()
        {
            Color = ConsoleColor.Cyan;
            Symbol = (char)Tiles.floor;

        }

        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
