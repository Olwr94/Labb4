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
            lockPick = '~',
            character = '@'
        }

        //Makes visible/invisible
        private bool isVisible = false;
        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
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

        //Change color
        private ConsoleColor color;
        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }
        
        //Gets/Sets symbol
        private char symbol; 
        public char Symbol 
        { 
            get { return symbol; }
            set { symbol = value; }
        }

        //Makes so you can not walk on/through them
        private bool canCollide;
        public bool CanCollide 
        {
            get { return canCollide;}
            set { canCollide = value;}
        }

        //Pick up items
        private bool pickedUp = false;
        public bool PickedUp
        {
            get { return pickedUp; }
            set { pickedUp = value; }
        }

        //Exit
        private bool exitDoor;
        public bool ExitDoor
        {
            get { return exitDoor; }
            set { exitDoor = value; }
        }

    }
}
