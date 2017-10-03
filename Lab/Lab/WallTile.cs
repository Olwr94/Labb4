﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class WallTile : Tile, ITiles
    {
        public WallTile()
        {
            Symbol = (char)Tiles.wall;
            CanCollide = true;
        }

        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
