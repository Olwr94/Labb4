using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Map
    {
        char[,] map;
        WallTile walltile = new WallTile();
        FloorTile floortile = new FloorTile();
        CharacterTile charactertile = new CharacterTile();

        public void MapArray()
        {
            const int Rad = 16;
            const int Kolumn = 36;
            int playerRow = 3;
            int playerColumn = 11;
            map = new char[Rad, Kolumn];
            
            for(int rad = 0; rad < Rad; rad++)
            {
                for(int kolumn = 0; kolumn < Kolumn; kolumn++)
                {
                    if(rad == 0 || rad == Rad - 1 || kolumn == 0 || kolumn == Kolumn - 1)
                    {
                        map[kolumn, rad] = walltile.Symbol;
                    }
                    else
                    {
                        map[kolumn, rad] = floortile.Symbol;
                    }
                }
            }

            while (true) //TODO: hur ska användaren avsluta?
            {
                //Rita ut karta
                string buffer = "";
                for (int rad = 0; rad < Rad; rad++)
                {
                    string line = "";
                    for (int kolumn = 0; kolumn < Kolumn; kolumn++)
                    {
                        if (kolumn == playerColumn && rad == playerRow)
                            line += charactertile.Symbol;
                        else
                            line += map[kolumn, rad];
                    }
                    buffer += line + "\n";
                }
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.Write(buffer);

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.W)
                {
                    playerRow--;
                    if (playerRow == Rad - Rad)
                        playerRow++;
                }
                else if (key.Key == ConsoleKey.A)
                {
                    playerColumn--;
                    if (playerColumn == Kolumn - Kolumn)
                        playerColumn++;
                }
                else if (key.Key == ConsoleKey.S)
                {
                    playerRow++;
                    if (playerRow == Rad - 1)
                        playerRow--;
                }
                else if (key.Key == ConsoleKey.D)
                {
                    playerColumn++;
                    if (playerColumn == Kolumn - 1)
                        playerColumn--;
                }
            }
        }
    }
}
