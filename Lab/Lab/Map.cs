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
            int playerRow = r.Next(2,16);
            int playerColumn = r.Next(4,34);

            for (int rad = 0; rad < Rad; rad++)
            {
                for(int kolumn = 0; kolumn < Kolumn; kolumn++)
                {
                    if (rad == 0 || rad == Rad - 1 || kolumn == 0 || kolumn == Kolumn - 1)
                    {
                        map[kolumn, rad] = outerWall;
                    }

                    //Doors
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


            while (!exit.ExitDoor)
            {

                //Makes the markers visible 1 step in every direction
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

                //Places the player in the map and overwrites the previous map
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

                //Takes away the Cursor (puts the cursor in the background)
                Console.CursorLeft = 0;
                Console.CursorTop = 0;

                //Sets position for counters and stats
                Console.SetCursorPosition(0, 16);
                Console.CursorVisible = false;
                Console.WriteLine($"Score: {charactertile.Score}");
                Console.WriteLine($"Steps: {charactertile.Steps}");
                Console.WriteLine($"White keys: {whiteKey.AmountKeys}/1");
                Console.WriteLine($"Red keys: {redKey.AmountRedKeys}/1");
                
                //Info screen on the right side
                Console.SetCursorPosition(38,0);
                Console.WriteLine("Mission: find the exit");
                Console.SetCursorPosition(38, 1);
                Console.WriteLine("Objective: Get as score as possible..");
                Console.SetCursorPosition(38, 2);
                Console.WriteLine("D = Doors");
                Console.SetCursorPosition(38, 3);
                Console.WriteLine("K = keys");
                Console.SetCursorPosition(38, 4);
                Console.WriteLine("# = Walls");
                Console.SetCursorPosition(38, 5);
                Console.WriteLine("Hint: Nothing is what it seemes..");


                //When you walk on a trap
                if (map[playerColumn, playerRow] == trap || map[playerColumn, playerRow] == trap2 || map[playerColumn, playerRow] == trap3 || map[playerColumn, playerRow] == trap4)
                {
                    charactertile.Score = charactertile.Score + trapPoints;
                    Console.SetCursorPosition(38, 6);
                    Console.WriteLine(" ____________________________________");
                    Console.SetCursorPosition(38, 7);
                    Console.WriteLine("|Woopsie.. watch out for them traps..|");
                    Console.SetCursorPosition(38, 8);
                    Console.WriteLine("|You just gained 30 points..         |");
                    Console.SetCursorPosition(38, 9);
                    Console.WriteLine("|____________________________________|");
                }

                //When you pick up an item
                if (map[playerColumn, playerRow] == lockPick)
                {
                    map[playerColumn, playerRow] = new FloorTile();
                    lockPick.PickedUp = true;
                    charactertile.Score = charactertile.Score - lockPickBonus;
                    Console.SetCursorPosition(38,13);
                    Console.WriteLine("You found a lockpick");
                }
                if (map[playerColumn,playerRow] == whiteKey)
                {
                    map[playerColumn, playerRow] = new FloorTile();
                    whiteKey.PickedUp = true;
                    charactertile.Score = charactertile.Score - keyPoints;
                    whiteKey.AmountKeys++;
                }
                if (map[playerColumn, playerRow] == redKey)
                {
                    map[playerColumn, playerRow] = new FloorTile();
                    redKey.PickedUp = true;
                    charactertile.Score = charactertile.Score - keyPoints;
                    redKey.AmountRedKeys++;
                }
                

                //Movement
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

                        //unlock door
                        else if (map[playerColumn, playerRow - 1] == redDoor && redKey.PickedUp || map[playerColumn, playerRow - 1] == redDoor && lockPick.PickedUp)
                        {
                            playerRow--;
                            exit.IsVisible = true;
                            map[playerColumn, playerRow] = new FloorTile();
                            if (redKey.AmountRedKeys < 1)
                                redKey.AmountRedKeys = 0;
                            else
                                redKey.AmountRedKeys--;
                        }

                        if (map[playerColumn, playerRow] == exit)
                            exit.ExitDoor = true;
                        break;
                     
                     case ConsoleKey.A:
                        if(!map[playerColumn - 1, playerRow].CanCollide)
                        {
                            playerColumn--;
                            charactertile.Score++;
                            charactertile.Steps++;
                        }
                            
                        else if(map[playerColumn - 1, playerRow] == whiteDoor && whiteKey.PickedUp)
                        {
                            playerColumn--;
                            map[playerColumn, playerRow] = new FloorTile();
                            whiteKey.AmountKeys--;
                        }


                        if (map[playerColumn, playerRow] == exit)
                            exit.ExitDoor = true;
                        break;

                     case ConsoleKey.S:
                        if(!map[playerColumn, playerRow + 1].CanCollide)
                        {
                            playerRow++;
                            charactertile.Score++;
                            charactertile.Steps++;
                        }

                        if (map[playerColumn, playerRow] == exit)
                            exit.ExitDoor = true;
                        break;

                     case ConsoleKey.D:
                         if(!map[playerColumn + 1, playerRow].CanCollide)
                         {
                            playerColumn++;
                            charactertile.Score++;
                            charactertile.Steps++;
                         }
                         

                        if (map[playerColumn, playerRow] == exit)
                            exit.ExitDoor = true;
                        break;

                }
                
            }
            
            //End scene
            Console.Clear();
            Console.WriteLine("You won... Yay...");
            Console.WriteLine();
            Console.WriteLine($"Your score is: {charactertile.Score}");
            Console.WriteLine();
            Console.WriteLine($"Your steps to complete the game: {charactertile.Steps}");

            //Pauses screen for 6 sec
            Thread.Sleep(6000);
        }
    }
}
