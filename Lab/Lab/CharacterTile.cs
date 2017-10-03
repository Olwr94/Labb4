using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class CharacterTile : Tile, ITiles
    {
        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public CharacterTile()
        {
            IsVisible = true;
            Color = ConsoleColor.White;
            Symbol = (char)Tiles.character;
            Score = 0;
        }
        
        public void Print()
        {
            Console.Write(Symbol);
        }
    }
}
