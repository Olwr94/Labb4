using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class InnerWallTile : Tile, ITiles
    {
        public InnerWallTile()
        {
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
