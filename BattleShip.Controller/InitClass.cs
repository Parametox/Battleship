using Battleship;
using Battleship.View;
using System;

namespace BattleShip.Controller
{
    /// <summary>
    /// Klasa inicjująca parametry gry
    /// </summary>
    public static class InitClass
    {      
        /// <summary>
        /// Metoda inicjalizująca
        /// </summary>
        public static void InitGme()
        {
            
            Console.ForegroundColor = ConsoleColor.White;

            Board.Rows = 10;
            Board.Columns = 15;
            Board.BoardSeperator = 1;


            /*
                GRACZ 1
             */
            Board.Player1 = new Player
            {
                Name = "GRACZ1",
                PrimaryColor = ConsoleColor.Blue,
                SecondaryColor = ConsoleColor.Gray,
                Symbol = 'X',

            };
            Ship ship = new Ship();
            ship.SetCoordinates(new ShipPoint { X = 3, Y = 1 });
            ship.SetCoordinates(new ShipPoint { X = 4, Y = 1 });
            ship.SetCoordinates(new ShipPoint { X = 5, Y = 1 });
            ship.SetCoordinates(new ShipPoint { X = 6, Y = 1 });

            Ship ship1 = new Ship();
            ship1.SetCoordinates(new ShipPoint { X = 2, Y = 8 });

            Board.Player1.AddShip(ship);
            Board.Player1.AddShip(ship1);


            /*
                GRACZ 2
             */
            Board.Player2 = new Player
            {
                Name = "GRACZ2",
                PrimaryColor = ConsoleColor.Green,
                SecondaryColor = ConsoleColor.Yellow,
                Symbol = 'X'

            };
            Ship ship22 = new Ship();
            ship22.SetCoordinates(new ShipPoint { X = 5, Y = 4 });

            Ship ship221 = new Ship();
            ship221.SetCoordinates(new ShipPoint { X = 7, Y = 6 });
            ship221.SetCoordinates(new ShipPoint { X = 7, Y = 5 });
            ship221.SetCoordinates(new ShipPoint { X = 7, Y = 4 });
            ship221.SetCoordinates(new ShipPoint { X = 7, Y = 3 });

            Board.Player2.AddShip(ship22);
            Board.Player2.AddShip(ship221);
        }
    }
}
