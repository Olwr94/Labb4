﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Program
    {
        enum Walls {  };

        static void Main(string[] args)
        {

        }
    }
    public class Character
    {

    }
    public abstract class Map
    {
        private static string[,] map = new string[80, 40];
    }
    public class Walls : Map
    {
        public void PrintWalls()
        {
            
            
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
