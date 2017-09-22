using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class Character
    {

    }
    public abstract class Map
    {
        private static string[] map = new string[80 + 1];
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
