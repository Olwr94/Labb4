﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class ExitTile: Tile, ITiles
    {

        
        public ExitTile()
        {
            Symbol = (char)Tiles.exit;
            HasExit = false;
        }

        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}