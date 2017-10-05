using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Map
    {
        Random r = new Random();
        const int Rad = 16;
        const int Kolumn = 36;
        int reducedPoint = 10;

        Tile[,] map = new Tile[Kolumn, Rad];
        
        OuterWallTile outerWall = new OuterWallTile();
        CharacterTile charactertile = new CharacterTile();
        RedDoorTile redDoor = new RedDoorTile();
        DoorTile doortile = new DoorTile();
        KeyTile keytile = new KeyTile();
        RedKeyTile redKey = new RedKeyTile();
        ExitTile exit = new ExitTile();
        TrapTile trapTile = new TrapTile();

        

        public void MapArray()
        {
            int randomRow = r.Next(1, 13);
            int randomRow2 = r.Next(1, 13);
            int randomTrapRow = r.Next(1, 13);
            int randomTrapRow2 = r.Next(1, 13);
            int randomColumn = r.Next(4, 30);
            int randomColumn2 = r.Next(4, 30);
            int randomTrapColumn = r.Next(4, 30);
            int randomTrapColumn2 = r.Next(4, 30);
            int playerRow = r.Next(1,16);
            int playerColumn = r.Next(4,35);

            for (int rad = 0; rad < Rad; rad++)
            {
                for(int kolumn = 0; kolumn < Kolumn; kolumn++)
                {
                    if (rad == 0 || rad == Rad - 1 || kolumn == 0 || kolumn == Kolumn - 1)
                    {
                        map[kolumn, rad] = outerWall;
                    }
                    //Door
                    else if (rad == 5 && kolumn == 3) //Skapar dörröppning
                        map[kolumn, rad] = doortile;
                    else if (rad == 3 && kolumn == 2)
                        map[kolumn, rad] = redDoor;

                    //Keys
                    else if (rad == randomRow && kolumn == randomColumn)
                        map[kolumn, rad] = keytile;
                    else if (rad == randomRow2 && kolumn == randomColumn2)
                        map[kolumn, rad] = redKey;

                    //Traps
                    else if (rad == randomTrapRow && kolumn == randomTrapColumn)
                        map[kolumn, rad] = new TrapTile();
                    else if (rad == randomTrapRow2 && kolumn == randomTrapColumn2)
                        map[kolumn, rad] = new TrapTile();

                    //Exit
                    else if (rad == 1 && kolumn == 1)
                        map[kolumn, rad] = exit;

                    //Inner walls
                    else if (kolumn == 3 || rad == 3 && kolumn == 1)
                        map[kolumn, rad] = new InnerWallTile();

                    //Walkable surface
                    else
                    {
                        map[kolumn, rad] = new FloorTile();
                    }
                }
            }


            while (!exit.HasExit) //TODO: hur ska användaren avsluta?
            {

                if (!map[playerColumn + 1, playerRow].IsVisible)
                    map[playerColumn + 1, playerRow].IsVisible = true;
                else
                    map[playerColumn, playerRow].IsVisible = false;

                if (!map[playerColumn, playerRow + 1].IsVisible)
                    map[playerColumn, playerRow + 1].IsVisible = true;
                else
                    map[playerColumn, playerRow].IsVisible = false;

                if (!map[playerColumn - 1, playerRow].IsVisible)
                    map[playerColumn - 1, playerRow].IsVisible = true;
                else
                    map[playerColumn, playerRow].IsVisible = false;

                if (!map[playerColumn, playerRow - 1].IsVisible)
                    map[playerColumn, playerRow - 1].IsVisible = true;
                else
                    map[playerColumn, playerRow].IsVisible = false;

                //Rita ut karta
                Console.SetCursorPosition(0, 0);
                for (int rad = 0; rad < Rad; rad++)
                {
                    for (int kolumn = 0; kolumn < Kolumn; kolumn++)
                    {
                        if (kolumn == playerColumn && rad == playerRow)
                            charactertile.Draw();

                        else
                            map[kolumn, rad].Draw();
                    }
                    Console.WriteLine();
                }
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.SetCursorPosition(0, 16);
                Console.CursorVisible = false;

                Console.WriteLine($"Score: {charactertile.Score}");
                Console.WriteLine($"Steps: {charactertile.Steps}");
                Console.WriteLine($"White keys: {keytile.AmountKeys}/1");
                Console.WriteLine($"Red keys: {redKey.AmountRedKeys}/1");


                if (map[playerColumn, playerRow] == new TrapTile())
                    charactertile.Score = charactertile.Score + 30;




                if (map[playerColumn,playerRow] == keytile)
                {
                    map[playerColumn, playerRow] = new FloorTile();
                    keytile.pickedUp = true;
                    charactertile.Score = charactertile.Score - reducedPoint;
                    keytile.AmountKeys++;
                }

                if (map[playerColumn, playerRow] == redKey)
                {
                    map[playerColumn, playerRow] = new FloorTile();
                    redKey.pickedUp = true;
                    charactertile.Score = charactertile.Score - reducedPoint;
                    redKey.AmountRedKeys++;
                }




                





                var player = Console.ReadKey(true);
                switch(player.Key)
                {
                     case ConsoleKey.W:
                        if(!map[playerColumn, playerRow - 1].CanCollide)
                        {
                            playerRow--;
                            charactertile.Score++;
                            charactertile.Steps++;
                        }
 
                        else if (map[playerColumn, playerRow - 1] == redDoor && redKey.pickedUp)
                        {
                            playerRow--;
                            map[playerColumn, playerRow] = new FloorTile();
                            redKey.AmountRedKeys--;
                        }

                        if (map[playerColumn, playerRow] == exit)
                            exit.HasExit = true;
                        break;
                     
                     case ConsoleKey.A:
                        if(!map[playerColumn - 1, playerRow].CanCollide)
                        {
                            playerColumn--;
                            charactertile.Score++;
                            charactertile.Steps++;
                        }
                            
                        else if(map[playerColumn - 1, playerRow] == doortile && keytile.pickedUp)
                        {
                            playerColumn--;
                            map[playerColumn, playerRow] = new FloorTile();
                            keytile.AmountKeys--;
                        }


                        if (map[playerColumn, playerRow] == exit)
                            exit.HasExit = true;
                        break;

                     case ConsoleKey.S:
                        if(!map[playerColumn, playerRow + 1].CanCollide)
                        {
                            playerRow++;
                            charactertile.Score++;
                            charactertile.Steps++;
                        }
                                                

                        if (map[playerColumn, playerRow] == exit)
                            exit.HasExit = true;
                        break;

                     case ConsoleKey.D:
                         if(!map[playerColumn + 1, playerRow].CanCollide)
                         {
                            playerColumn++;
                            charactertile.Score++;
                            charactertile.Steps++;
                         }
                         

                        if (map[playerColumn, playerRow] == exit)
                            exit.HasExit = true;
                        break;

                }
                
            }

            Console.Clear();
            Console.WriteLine("You won!!");
            Console.WriteLine($"Your score is: {charactertile.Score}");
            Console.WriteLine($"Your steps to complete the game: {charactertile.Steps}");

        }
    }
}
