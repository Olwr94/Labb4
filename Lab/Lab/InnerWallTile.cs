using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class InnerWallTile : Tile, ITiles
    {
        //Sets color, chooses symbol and makes it uncolliedable
        public InnerWallTile()
        {
            Color = ConsoleColor.DarkMagenta; 
            Symbol = (char)Tiles.wall;
            CanCollide = true;
        }

        //Prints symbols
        public void Print()
        {
            Console.Write(Symbol); 
        }
    }
}
