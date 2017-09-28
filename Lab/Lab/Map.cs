using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Map
    {
        Tile[,] map;

        public void MapArray()
        {
            int Rad = 16;
            int Kolumn = 36;
            map = new Tile[Rad, Kolumn];
            Console.WriteLine("Array");
        }
    }
}
