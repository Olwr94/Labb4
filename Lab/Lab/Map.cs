using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Map
    {
        const int Rad = 16;
        const int Kolumn = 36;
        int playerRow = 3;
        int playerColumn = 11;

        Tile[,] map = new Tile[Kolumn, Rad];

        WallTile walltile = new WallTile();
        FloorTile floortile = new FloorTile();
        CharacterTile charactertile = new CharacterTile();
        DoorTile door = new DoorTile();

        public void MapArray()
        {
            for(int rad = 0; rad < Rad; rad++)
            {
                for(int kolumn = 0; kolumn < Kolumn; kolumn++)
                {
                    if(rad == 0 || rad == Rad - 1 || kolumn == 0 || kolumn == Kolumn - 1)
                    {
                        map[kolumn, rad] = walltile;
                    }
                    else if(rad == 7 && kolumn == 5) //Skapar dörröppning
                        map[kolumn, rad] = door;
                    else if(kolumn == 5)
                        map[kolumn, rad] = walltile;
                    else
                    {
                        map[kolumn, rad] = floortile;
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
                            line += map[kolumn, rad].Symbol;
                    }
                    buffer += line + "\n";
                }
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.Write(buffer);
                
                
                var player = Console.ReadKey();
                switch(player.Key)
                {
                     case ConsoleKey.W:
                        if(!map[playerColumn, playerRow - 1].CanCollide)
                            playerRow--;
                        break;
                     
                     case ConsoleKey.A:
                        if(!map[playerColumn - 1, playerRow].CanCollide)
                            playerColumn--;
                        break;

                     case ConsoleKey.S:
                        if(!map[playerColumn, playerRow + 1].CanCollide)
                            playerRow++;
                        break;

                     case ConsoleKey.D:
                         if(!map[playerColumn + 1, playerRow].CanCollide)
                            playerColumn++;
                        break;

                }
	            
            }
        }
    }
}
