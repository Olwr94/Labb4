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
            

            Console.ReadLine();
        }
    }
    public class Character
    {
        int numberOfMoves;
        int amountOfKeys;
    }
    public abstract class Map
    {
        public static string[,] map = new string[80 , 40];
    }
    
    public class Walls : Map
    {
        
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
        public void ShowSecret()
        {

        }
    }
}
