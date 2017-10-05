using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class CharacterTile : Tile, ITiles
    {
        //Sets color, chooses symbol and makes it always visible
        public CharacterTile()
        {
            IsVisible = true; 
            Color = ConsoleColor.Magenta;
            Symbol = (char)Tiles.character;
        }

        //Score counter
        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        //Steps counter
        private int steps;
        public int Steps
        {
            get { return steps; }
            set { steps = value; }
        }

        //Prints symbol
        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
