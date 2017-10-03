using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class FloorTile : Tile, ITiles
    {
        public FloorTile()
        {
            IsVisible = true;
            Color = ConsoleColor.White;
            Symbol = (char)Tiles.floor; 
        }

        public void Print()
        {
            Console.Write(Symbol); 
        }
    }
}
