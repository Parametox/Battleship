using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public class Ship
    {
        /// <summary>
        /// Statyczny licznik
        /// </summary>
        public static int counter = 0;

        /// <summary>
        /// Identyfikator statku
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Lista punktów z których składa się statek
        /// </summary>
        public List<ShipPoint> ShipBody { get; private set; }

        /// <summary>
        /// Długość statku
        /// </summary>
        public int Length
        {
            get
            {
                return ShipBody.Count;
            }
        }

        /// <summary>
        /// Ustawienie koordynatów wg zasad gry
        /// </summary>
        /// <param name="point">Punkt do dodania</param>
        public void SetCoordinates(ShipPoint point)
        {
            if (Length > 0)
            {
                // Nie może być jeden statek zawierający swoje punkty po przekątnej
                if (ShipBody.Any(xy => xy.X == point.X || xy.Y == point.Y)) 
                {
                    ShipBody.Add(point);
                }
            }
            else
            {
                ShipBody.Add(point);
            }
        }

        
        public Ship()
        {
            this.ShipBody = new List<ShipPoint>();
            this.Id = Ship.counter++;
        }
    }
}
