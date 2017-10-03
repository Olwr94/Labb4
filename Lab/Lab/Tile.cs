using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    abstract class Tile
    {
        public enum Tiles 
        {
            wall = '#',
            floor = '.',
            redkey = 'k',
            door = 'D',
            character = '@'
        }

        private char symbol; 

        public char Symbol 
        { 
            get { return symbol; }
            set { symbol = value; }
        }

        private bool canCollide;

        public bool CanCollide 
        {
            get { return canCollide;}
            set { canCollide = value;}
        }
    }
}
