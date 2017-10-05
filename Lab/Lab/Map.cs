using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab
{
    public class Map
    {
        //Random generator
        Random r = new Random();

        //Score penalties
        int keyPoints = 10;
        int trapPoints = 30;

        //Secret bonus
        int lockPickBonus = 20;


        //Map array
        const int Rad = 16;
        const int Kolumn = 36;
        Tile[,] map = new Tile[Kolumn, Rad];
        
        //Outer walls
        OuterWallTile outerWall = new OuterWallTile();

        //Floor
        VisableFloorTile visableFloor = new VisableFloorTile();

        //Character
        CharacterTile charactertile = new CharacterTile();

        //Doors
        RedDoorTile redDoor = new RedDoorTile();
        DoorTile whiteDoor = new DoorTile();

        //Keys
        KeyTile whiteKey = new KeyTile();
        RedKeyTile redKey = new RedKeyTile();
        

        //Traps
        TrapTile trap = new TrapTile();
        TrapTile trap2 = new TrapTile();
        TrapTile trap3 = new TrapTile();
        TrapTile trap4 = new TrapTile();

        //LockPick
        LockPickTile lockPick = new LockPickTile();

        //Exit
        ExitTile exit = new ExitTile();



        public void MapArray()
        {
            //Keys rows/columns
            int randomKeyRow = r.Next(1, 13);
            int randomKeyRow2 = r.Next(1, 13);
            int randomKeyColumn = r.Next(4, 30);
            int randomKeyColumn2 = r.Next(4, 30);
            
            //Traps rows/columns
            int randomTrapRow = r.Next(1, 13);
            int randomTrapRow2 = r.Next(1, 13);
            int randomTrapRow3 = r.Next(1, 13);
            int randomTrapRow4 = r.Next(1, 13);
            int randomTrapColumn = r.Next(4, 30);
            int randomTrapColumn2 = r.Next(4, 30);
            int randomTrapColumn3 = r.Next(4, 30);
            int randomTrapColumn4 = r.Next(4, 30);

            //Player row/column
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
                    else if (rad == 5 && kolumn == 3)
                        map[kolumn, rad] = whiteDoor;
                    else if (rad == 3 && kolumn == 2)
                        map[kolumn, rad] = redDoor;

                    //Keys
                    else if (rad == randomKeyRow && kolumn == randomKeyColumn)
                        map[kolumn, rad] = whiteKey;
                    else if (rad == randomKeyRow2 && kolumn == randomKeyColumn2)
                        map[kolumn, rad] = redKey;

                    //Lockpick
                    else if (rad == 14 && kolumn == 1)
                        map[kolumn, rad] = lockPick;

                    //Traps
                    else if (rad == randomTrapRow && kolumn == randomTrapColumn)
                        map[kolumn, rad] = trap;
                    else if (rad == randomTrapRow2 && kolumn == randomTrapColumn2)
                        map[kolumn, rad] = trap2;
                    else if (rad == randomTrapRow3 && kolumn == randomTrapColumn3)
                        map[kolumn, rad] = trap3;
                    else if (rad == randomTrapRow4 && kolumn == randomTrapColumn4)
                        map[kolumn, rad] = trap4;

                    //Exit
                    else if (rad == 1 && kolumn == 1)
                        map[kolumn, rad] = exit;

                    //Visable Floor after enter the room
                    else if (rad == 1 && kolumn == 2 || rad == 2 && kolumn == 1 || rad == 2 && kolumn == 2)
                        map[kolumn, rad] = visableFloor;


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


            while (!exit.HasExit)
            {

                if (!map[playerColumn + 1, playerRow].IsVisible)
                    map[playerColumn + 1, playerRow].IsVisible = true;

                if (!map[playerColumn, playerRow + 1].IsVisible)
                    map[playerColumn, playerRow + 1].IsVisible = true;

                if (!map[playerColumn - 1, playerRow].IsVisible)
                    map[playerColumn - 1, playerRow].IsVisible = true;

                if (!map[playerColumn, playerRow - 1].IsVisible)
                    map[playerColumn, playerRow - 1].IsVisible = true;

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
                Console.WriteLine($"White keys: {whiteKey.AmountKeys}/1");
                Console.WriteLine($"Red keys: {redKey.AmountRedKeys}/1");


                if (map[playerColumn, playerRow] == trap || map[playerColumn, playerRow] == trap2 || map[playerColumn, playerRow] == trap3 || map[playerColumn, playerRow] == trap4)
                    charactertile.Score = charactertile.Score + trapPoints;

                if (map[playerColumn, playerRow] == lockPick)
                {
                    map[playerColumn, playerRow] = new FloorTile();
                    lockPick.pickedUp = true;
                    charactertile.Score = charactertile.Score - lockPickBonus;
                    Console.SetCursorPosition(40,7);
                    Console.WriteLine("You found a lockpick");
                }


                if (map[playerColumn,playerRow] == whiteKey)
                {
                    map[playerColumn, playerRow] = new FloorTile();
                    whiteKey.pickedUp = true;
                    charactertile.Score = charactertile.Score - keyPoints;
                    whiteKey.AmountKeys++;
                }

                if (map[playerColumn, playerRow] == redKey)
                {
                    map[playerColumn, playerRow] = new FloorTile();
                    redKey.pickedUp = true;
                    charactertile.Score = charactertile.Score - keyPoints;
                    redKey.AmountRedKeys++;
                }




                if (map[playerColumn, playerRow] == redDoor)
                {
                    exit.IsVisible = true;
                    visableFloor.IsVisible = true;
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
 
                        else if (map[playerColumn, playerRow - 1] == redDoor && redKey.pickedUp || map[playerColumn, playerRow - 1] == redDoor && lockPick.pickedUp)
                        {
                            playerRow--;
                            map[playerColumn, playerRow] = new FloorTile();
                            visableFloor.IsVisible = true;
                            exit.IsVisible = true;
                            if (redKey.AmountRedKeys < 0)
                                redKey.AmountRedKeys = 0;
                            else
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
                            
                        else if(map[playerColumn - 1, playerRow] == whiteDoor && whiteKey.pickedUp)
                        {
                            playerColumn--;
                            map[playerColumn, playerRow] = new FloorTile();
                            whiteKey.AmountKeys--;
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
            Console.WriteLine("You won... Yay...");
            Console.WriteLine();
            Console.WriteLine($"Your score is: {charactertile.Score}");
            Console.WriteLine();
            Console.WriteLine($"Your steps to complete the game: {charactertile.Steps}");

            Thread.Sleep(6000);
        }
    }
}
