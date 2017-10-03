using System;
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
            IsVisible = true; 
            Color = ConsoleColor.White;
            Symbol = (char)Tiles.exit;
            HasExit = false;
        }

        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
