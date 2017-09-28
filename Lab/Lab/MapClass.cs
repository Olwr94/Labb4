using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public abstract class Map
    {
        public static string[,] map = new string[80, 20];
    }

    public class Walls : Map
    {
        public void PrintWalls()
        {
            const int ROWS = 16, COLUMNS = 36;
            char[,] map = new char[COLUMNS, ROWS];
            int playerRow = 3, playerColumn = 11;

            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    if (row == 0 || row == ROWS - 1 || column == 0 || column == COLUMNS - 1)
                        map[column, row] = '#';

                    else
                        map[column, row] = '-';
                }
            }


            while (true) 
            {
                //Rita ut karta
                string buffer = "";
                for (int row = 0; row < ROWS; row++)
                {
                    string line = string.Empty;
                    for (int column = 0; column < COLUMNS; column++)
                    {
                        if (column == playerColumn && row == playerRow)
                            line += "@";
                        else
                            line += map[column, row];
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
                    if (playerRow == ROWS - ROWS)
                        playerRow++;
                }
                else if (key.Key == ConsoleKey.A)
                {
                    playerColumn--;
                    if (playerColumn == COLUMNS - COLUMNS)
                        playerColumn++;
                }
                else if (key.Key == ConsoleKey.S)
                {
                    playerRow++;
                    if (playerRow == ROWS - 1)
                        playerRow--;
                }
                else if (key.Key == ConsoleKey.D)
                {
                    playerColumn++;
                    if (playerColumn == COLUMNS - 1)
                        playerColumn--;
                }
            }
        }
    }
}
