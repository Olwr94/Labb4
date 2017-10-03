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
            key = 'k', 
            door = 'D',
            exit = 'E',
            character = '@'
        }

        private bool isVisible = false;

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        private ConsoleColor color;
        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            if (isVisible)
                Console.Write(Symbol);
            else
                Console.Write(" ");
            Console.ResetColor();
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

        private bool hasExit;
        public bool HasExit
        {
            get { return hasExit; }
            set { hasExit = value; }
        }

    }
}
