using Battleship.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Controller
{
    /// <summary>
    /// Klasa obsługująca elemnet losowy gry
    /// </summary>
    public class RandomRound
    {
        private List<ShipPoint> localSendShots;

        /// <summary>
        /// Wysyłanie ataków na przeciwnika
        /// </summary>
        public void DoRandomRound()
        {
            Board.Player1.TakeaShot(Board.Player2, getRandomPoint(Board.Player1.SendShots));
            Board.Player2.TakeaShot(Board.Player1, getRandomPoint(Board.Player2.SendShots));
        }

        /// <summary>
        /// Losowanie punktu ataku
        /// </summary>
        /// <param name="_sendShots">Lista oddanych strzałów gracza</param>
        /// <returns></returns>
        private ShipPoint getRandomPoint(List<ShipPoint> _sendShots)
        {
            Random random = new Random();
            int randomX = random.Next(1, Board.Columns + 1);
            int randomY = random.Next(1, Board.Rows + 1);

            //Pierwszy celny strzał, który nie został wykorzystany do obliczania algorytmu
            var succesPoint = _sendShots.Where(x => x.SuccesShot == true && x.UsedtoAutoAim == false).FirstOrDefault();
            if (_sendShots.Any(x => x.SuccesShot == true) && succesPoint != null)
            {
                //kwerenda sprawdza czy dookoła ustrzelonego punktu został wykonany strzał. 
                if (_sendShots.Any(xy => xy.X == (succesPoint.X + 1 > Board.Columns ? succesPoint.X : succesPoint.X + 1) && xy.Y == succesPoint.Y)
                    && _sendShots.Any(xy => xy.Y == (succesPoint.Y + 1 > Board.Rows ? succesPoint.Y : succesPoint.Y + 1) && xy.X == succesPoint.X)
                    && _sendShots.Any(xy => xy.Y == (succesPoint.Y - 1 <= 0 ? succesPoint.Y : succesPoint.Y - 1) && xy.X == succesPoint.X)
                    && _sendShots.Any(xy => xy.X == (succesPoint.X - 1 <= 0 ? succesPoint.X : succesPoint.X - 1) && xy.Y == succesPoint.Y))
                {
                    _sendShots.Where(x => x.SuccesShot == true && x.UsedtoAutoAim == false).FirstOrDefault().UsedtoAutoAim = true;
                }

                if (!_sendShots.Any(xy => xy.X == (succesPoint.X + 1 > Board.Columns ? succesPoint.X : succesPoint.X + 1) && xy.Y == succesPoint.Y))
                {
                    randomX = succesPoint.X + 1;
                    randomY = succesPoint.Y;
                }
                else if (!_sendShots.Any(xy => xy.Y == (succesPoint.Y + 1 > Board.Rows ? succesPoint.Y : succesPoint.Y + 1) && xy.X == succesPoint.X))
                {
                    randomX = succesPoint.X;
                    randomY = succesPoint.Y + 1;
                }
                else if (!_sendShots.Any(xy => xy.Y == (succesPoint.Y - 1 <= 0 ? succesPoint.Y : succesPoint.Y - 1) && xy.X == succesPoint.X))
                {
                    randomX = succesPoint.X;
                    randomY = succesPoint.Y - 1;
                }
                else if (!_sendShots.Any(xy => xy.X == (succesPoint.X - 1 <= 0 ? succesPoint.X : succesPoint.X - 1) && xy.Y == succesPoint.Y))
                {
                    randomX = succesPoint.X - 1;
                    randomY = succesPoint.Y;
                }
            }


            if (_sendShots.Any(x => x.X == randomX && x.Y == randomY))
            {
                localSendShots = _sendShots;
                ShipPoint unique = getUniquePoint();
                return unique;
            }

            return new ShipPoint { X = randomX, Y = randomY };
        }

        /// <summary>
        /// Losowanie koordynatów, gdzię nie został jeszcze wykonany strzał
        /// </summary>
        /// <returns>Unikalne koordynaty</returns>
        private ShipPoint getUniquePoint()
        {
            for (int i = 1; i <= Board.Rows; i++)
            {
                for (int j = 1; j <= Board.Columns; j++)
                {
                    if (!localSendShots.Any(x => x.X == i && x.Y == j))
                    {
                        return new ShipPoint { X = i, Y = j };
                    }
                }
            }
            return new ShipPoint();
        }
    }
}
