using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class FloorTile : Tile, ITiles
    {
        //Sets color and chooses symbol
        public FloorTile()
        {
            Color = ConsoleColor.White;
            Symbol = (char)Tiles.floor; 
        }

        //Prints symbol
        public void Print()
        {
            Console.Write(Symbol); 
        }
    }
}
