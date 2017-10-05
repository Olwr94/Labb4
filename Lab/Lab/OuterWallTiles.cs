using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class OuterWallTile : Tile, ITiles
    {
        //Sets color, chooses symbol and makes it uncolliedable and always visible
        public OuterWallTile()
        {
            IsVisible = true;
            Color = ConsoleColor.DarkMagenta;
            Symbol = (char)Tiles.wall;
            CanCollide = true;
        }

        //Prints symbol
        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
