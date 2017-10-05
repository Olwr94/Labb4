using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class OuterWallTile : Tile, ITiles
    {
        public OuterWallTile()
        {
            IsVisible = true;
            Color = ConsoleColor.DarkMagenta;
            Symbol = (char)Tiles.wall;
            CanCollide = true;
        }

        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
