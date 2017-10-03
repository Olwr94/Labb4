using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class CharacterTile : Tile, ITiles
    {
        public CharacterTile()
        {
            Symbol = (char)Tiles.character;
        }
        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
