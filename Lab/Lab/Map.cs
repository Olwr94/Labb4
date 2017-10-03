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
        DoorTile doortile = new DoorTile();
        DoorTile doortile1 = new DoorTile();
        KeyTile keytile = new KeyTile();
        ExitTile exit = new ExitTile();

        public void MapArray()
        {
            for(int rad = 0; rad < Rad; rad++)
            {
                for(int kolumn = 0; kolumn < Kolumn; kolumn++)
                {
                    if (rad == 0 || rad == Rad - 1 || kolumn == 0 || kolumn == Kolumn - 1)
                    {
                        map[kolumn, rad] = walltile;
                    }
                    //Door
                    else if (rad == 5 && kolumn == 3) //Skapar dörröppning
                        map[kolumn, rad] = doortile1;
                    else if (rad == 3 && kolumn == 2)
                        map[kolumn, rad] = doortile;

                    //Keys
                    else if (rad == 1 && kolumn == 30)
                        map[kolumn, rad] = keytile;

                    //Exit
                    else if (rad == 1 && kolumn == 1)
                        map[kolumn, rad] = exit;

                    //Inner walls
                    else if (kolumn == 3 || rad == 3 && kolumn == 1)
                        map[kolumn, rad] = walltile;

                    //Walkable surface
                    else
                    {
                        map[kolumn, rad] = floortile;
                    }
                }
            }


            while (!exit.HasExit) //TODO: hur ska användaren avsluta?
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
                Console.SetCursorPosition(0, 16);
                Console.CursorVisible = false;

                Console.WriteLine($"Score: {charactertile.Score}");


                if(map[playerColumn,playerRow] == keytile)
                {
                    map[playerColumn, playerRow] = floortile;
                    keytile.pickedUp = true;
                    charactertile.Score = charactertile.Score - 10;
                }

                
                    var player = Console.ReadKey(true);
                switch(player.Key)
                {
                     case ConsoleKey.W:
                        if(!map[playerColumn, playerRow - 1].CanCollide)
                        {
                            playerRow--;
                            charactertile.Score++;
                        }

                        else if (map[playerColumn, playerRow - 1] == doortile && keytile.pickedUp)
                        {
                            playerRow--;
                            map[playerColumn, playerRow] = floortile;
                        }

                        if (map[playerColumn, playerRow] == exit)
                            exit.HasExit = true;
                        break;
                     
                     case ConsoleKey.A:
                        if(!map[playerColumn - 1, playerRow].CanCollide)
                        {
                            playerColumn--;
                            charactertile.Score++;
                        }
                            
                        else if(map[playerColumn - 1, playerRow] == doortile1 && keytile.pickedUp)
                        {
                            playerColumn--;
                            map[playerColumn, playerRow] = floortile;
                        }

                        if (map[playerColumn, playerRow] == exit)
                            exit.HasExit = true;
                        break;

                     case ConsoleKey.S:
                        if(!map[playerColumn, playerRow + 1].CanCollide)
                        {
                            playerRow++;
                            charactertile.Score++;
                        }


                        if (map[playerColumn, playerRow] == exit)
                            exit.HasExit = true;
                        break;

                     case ConsoleKey.D:
                         if(!map[playerColumn + 1, playerRow].CanCollide)
                         {
                            playerColumn++;
                            charactertile.Score++;
                         }


                        if (map[playerColumn, playerRow] == exit)
                            exit.HasExit = true;
                        break;

                }
                
            }

            Console.Clear();
            Console.WriteLine("You won!!");
            Console.WriteLine($"Your score is: {charactertile.Score}");

        }
    }
}
