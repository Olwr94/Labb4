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
            Walls walls = new Walls();
            walls.PrintWalls();
            Console.ReadLine();
        }
    }


    public class Character
    {

    }
    public abstract class Map
    {
        public static string[,] map = new string[80,20];
    }
    public class Walls : Map
    {
        public void PrintWalls()
        {
          for (int rad = 0; rad < map.GetLength(1); rad++)
             {
                 for (int kolumn = 0; kolumn < map.GetLength(0); kolumn++)
                 {
                     if (rad == 19 || rad == 0)/*((rad + kolumn) % 2 == 0)*/
                     {
                         Console.Write("#");
                         //map[rad, kolumn] = x;
                         //Console.Write(map[rad, kolumn]);
                     }
                     else if (kolumn == 79 || kolumn == 0)/*kolumn-9*/
                     {
                         Console.Write("#");
                     }
                     else
                     {
                         Console.Write(" ");
                         //map[rad, kolumn] = o;
 
                         //Console.Write(map[rad, kolumn]);
                     }
                 }
                 Console.WriteLine("");
             }
 
 
             //for (int rad = 0; rad < 20; rad++)
             //{
             //    for (int kolumn = 0; kolumn < 80; kolumn++)
             //    {
             //        if (rad == 19 || rad == 0)//kolumn
             //            Console.Write("#");
             //        else if (kolumn == 79 || kolumn == 0)/*kolumn-9*/
             //            Console.Write("#");
             //        else
             //            Console.Write(" ");
             //    }
             //    Console.WriteLine("");
             //}
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
