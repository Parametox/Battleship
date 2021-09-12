using Battleship.Controller;
using Battleship.View;
using BattleShip.Controller;
using System;
using System.Threading;

namespace BattleshipConsole
{
    class Program
    {

        static void Main(string[] args)
        {

            InitClass.InitGme();
            RandomRound randomRound = new RandomRound();
            Board.DrowMap();
            do
            {
                randomRound.DoRandomRound();
                Board.DrowMap();
                Thread.Sleep(500);
            } while (true && !Board.EndGame);

            if (Board.EndGame)
            {
                Board.DoEndGame();
                
            }

            Console.ReadKey();
        }

    }
}
