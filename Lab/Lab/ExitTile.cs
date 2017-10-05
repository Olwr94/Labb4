using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class ExitTile: Tile, ITiles
    {
        //Sets color, chooses symbol and creates exit option.
        public ExitTile()
        {
            Color = ConsoleColor.Magenta;
            Symbol = (char)Tiles.exit;
            ExitDoor = false;
        }

        //Prints symbol
        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
