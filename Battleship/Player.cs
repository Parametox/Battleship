using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    /// <summary>
    /// Klasa reprezentująca obiekt gracza w grze
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Statyczny licznik grczy
        /// </summary>
        public static int counter { get; private set; }

        /// <summary>
        /// Identyfikator gracza
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Główny kolor (pierwszy) szachownicy gracza
        /// </summary>
        public ConsoleColor PrimaryColor { get; set; }

        /// <summary>
        /// Dodatkowy kolor szachownicy gracza
        /// </summary>
        public ConsoleColor SecondaryColor { get; set; }

        /// <summary>
        /// Nazwa gracza
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Lista wysłanych ataków na przeciwnika
        /// </summary>
        public List<ShipPoint> SendShots { get; set; }

        /// <summary>
        /// Lista otrzymanych ataków
        /// </summary>
        public List<ShipPoint> ReceivedShots { get; set; }

        /// <summary>
        /// Lista statków gracza
        /// </summary>
        public List<Ship> Ships { get; private set; }

        /// <summary>
        /// Symbol statków gracza na planszy
        /// </summary>
        public char Symbol { get; set; }

        /// <summary>
        /// Określa, czy gracz wygrał
        /// </summary>
        public bool Winner { get; set; }


        public Player()
        {
            SendShots = new List<ShipPoint>();
            ReceivedShots = new List<ShipPoint>();
            Ships = new List<Ship>();
            Id = counter++;
        }

        /// <summary>
        /// Metoda odpowiedzialna za dodanie statków przy zachowaniu założeń gry
        /// </summary>
        /// <param name="shipToAdd"></param>
        public void AddShip(Ship shipToAdd)
        {
            if (shipToAdd == null)
            {
                return;
            }
            bool allowToAdd = true;
            switch (shipToAdd.Length)
            {
                case 1:
                    if (Ships.Where(x => x.Length == shipToAdd.Length).Count() >= GlobalRules.MaxQty1ElementShip)
                        allowToAdd = false;
                    break;
                case 2:
                    if (Ships.Where(x => x.Length == shipToAdd.Length).Count() >= GlobalRules.MaxQty2ElementsShip)
                        allowToAdd = false;
                    break;
                case 3:
                    if (Ships.Where(x => x.Length == shipToAdd.Length).Count() >= GlobalRules.MaxQty3ElementsShip)
                        allowToAdd = false;
                    break;
                case 4:
                    if (Ships.Where(x => x.Length == shipToAdd.Length).Count() >= GlobalRules.MaxQty4ElementsShip)
                        allowToAdd = false;
                    break;
                case 5:
                    if (Ships.Where(x => x.Length == shipToAdd.Length).Count() >= GlobalRules.MaxQty5ElementsShip)
                        allowToAdd = false;
                    break;

                default:
                    break;
            }

            if (allowToAdd)
            {
                Ships.Add(shipToAdd);
            }
        }

        /// <summary>
        /// Wykonanie ataku na wskazane koordynaty
        /// </summary>
        /// <param name="player">Gracz na którego ma być wykonany atak</param>
        /// <param name="point">Punkt</param>
        public void TakeaShot(Player player, ShipPoint point)
        {
            Ship ship = player.Ships.Where(o => o.ShipBody.Any(xy => xy.X == point.X && xy.Y == point.Y)).FirstOrDefault();
            if (ship != null)
            {
                ship.ShipBody.Where(xy => xy.X == point.X && xy.Y == point.Y).FirstOrDefault().Active = false;
                point.SuccesShot = true;
            }
            else
            {
                player.ReceivedShots.Add(point);
            }
            this.SendShots.Add(point);

            if (!player.Ships.Any(x => x.ShipBody.Any(y => y.Active == true)))
            {
                Winner = true;
            }
        }
    }
}
