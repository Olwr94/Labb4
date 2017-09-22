using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Program
    {

        enum Walls {wall = "#"};

        static void Main(string[] args)
        {
            for (int rad = 0; rad < 20; rad++)
            {
                for (int kolumn = 0; kolumn < 80; kolumn++)
                {
                    if (rad == 19 || rad == 0)//kolumn
                        Console.Write("#");
                    else if (kolumn == 79 || kolumn == 0)/*kolumn-9*/
                        Console.Write("#");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
    public class Character
    {

    }
    public abstract class Map
    {
        private static string[,] map = new string[80,40];
    }
    public class Walls : Map
    {
        public void PrintWalls()
        {
            Console.WriteLine();
            
        }
    }
    public class Rooms : Map
    {

    }
    public class Doors : Map
    {

    }
    public class Keys : Map
    {

    }
    public class Monster : Map
    {

    }
    public class Secrets : Map
    {

    }

}
