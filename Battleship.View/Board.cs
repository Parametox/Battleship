using System;
using System.Linq;

namespace Battleship.View
{
    /// <summary>
    /// Klasa określająca pole gry
    /// </summary>
    public static class Board
    {
        /// <summary>
        /// Kolumny
        /// </summary>
        public static int Columns { get; set; }

        /// <summary>
        /// Wiersze
        /// </summary>
        public static int Rows { get; set; }

        /// <summary>
        /// Odległość między tablicami graczy
        /// </summary>
        public static int BoardSeperator { get; set; }

        /// <summary>
        /// Gracz 1
        /// </summary>
        public static Player Player1 { get; set; }

        /// <summary>
        /// Gracz 2
        /// </summary>
        public static Player Player2 { get; set; }

        /// <summary>
        /// Określa czy gra dobiegła końca
        /// </summary>
        public static bool EndGame { get; set; }


        /// <summary>
        /// Metoda odpowiedzialna za narysowanie mapy w konsoli
        /// </summary>
        public static void DrowMap()
        {
            Console.Clear();
            if (Columns > 0 && Rows > 0)
            {
                drowMapforPlayer(Player1);

                if (BoardSeperator > 0)
                {
                    for (int i = 0; i < BoardSeperator; i++)
                    {
                        Console.WriteLine();
                    }
                }

                drowMapforPlayer(Player2);

                if (Player1.Winner || Player2.Winner)
                {
                    EndGame = true;
                }
               
            }
        }

        /// <summary>
        /// Metoda kończąca grę
        /// </summary>
        public static void DoEndGame()
        {
            if (Player1.Winner)
            {
                Console.WriteLine("The winner is " + Player1.Name);
            }
            else if (Player2.Winner)
            {
                Console.WriteLine("The winner is " + Player2.Name);
            }
        }

        /// <summary>
        /// Rysowanie mapy dla konkretnego gracza
        /// </summary>
        /// <param name="player">Gracz</param>
        private static void drowMapforPlayer(Player player)
        {
            Console.WriteLine($"\t {player.Name.ToUpper()}\n");
            for (int i = 1; i <= Rows; i++)
            {
                for (int j = 1; j <= Columns; j++)
                {
                    if (j % 2 == 0  )
                    {
                        if (i % 2 != 0)
                        {
                            Console.BackgroundColor = player.SecondaryColor;
                        }
                        else
                        {
                            Console.BackgroundColor = player.PrimaryColor;
                        }
                    }
                    else
                    {
                        if (i % 2 != 0)
                        {
                            Console.BackgroundColor = player.PrimaryColor;
                        }
                        else
                        {
                            Console.BackgroundColor = player.SecondaryColor;
                        }
                    }

                    Ship tmp = player.Ships.FirstOrDefault(o => o.ShipBody.Any(xy => xy.X == j && xy.Y == i));
                    if (tmp != null)
                    {
                        Console.ForegroundColor = tmp.ShipBody.Where(xy => xy.X == j && xy.Y == i).FirstOrDefault().DispColor;
                        Console.Write(player.Symbol);
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else if (player.ReceivedShots.Where(xy => xy.X == j && xy.Y == i).FirstOrDefault() !=null)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("");
            }
        }
    }
}
