using System;

namespace Battleship
{
    /// <summary>
    /// Klasa charakteryzująca punk na osi XY należący do ciała statku
    /// </summary>
    public class ShipPoint 
    {
        /// <summary>
        /// Współrzędna X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Współrzędna Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Informuje czy punkt ostał zestrzelony przez przeciwnika
        /// sterownaie właściwością DispColor
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Wyświetlany kolor
        /// </summary>
        public ConsoleColor DispColor 
        {
            get 
            {
                return Active ? ConsoleColor.Black : ConsoleColor.Red;
            }             
        }
        /// <summary>
        /// Informuje czy strał na ten punkt był celny czy nie
        /// </summary>
        public bool SuccesShot { get; set; }

        /// <summary>
        /// Informuje czy punkt został użyty w algorytmie do obliczania pól sąsiadujących
        /// </summary>
        public bool UsedtoAutoAim { get; set; }

        public ShipPoint()
        {
            Active = true;
        }
    }
}
