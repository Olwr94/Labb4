using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Countdown to game start
            int startGame = 5;
            while(startGame != 0)
            {
                Console.SetCursorPosition(0,0);
                Console.WriteLine($"Game will start in {startGame}...");
                startGame--;
                Thread.Sleep(1000);
            }

            //Starts Map/game
            Map map = new Map();
            map.MapArray();

            //Leaderboard
            //André - Score: 131 & Steg: 151
            //Emil - Score: 85 & Steg: 112
            //Daniel - Score: 75 & Steg: 95
        }
    }
}
