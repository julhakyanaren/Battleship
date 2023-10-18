using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public static class Fight
    {
        public static bool GameStarted = false;
        public static int TargetCoord;
        public static int Turn = 0;
        public static bool FirstTurn = true;
        public static bool PlayerHited = false;

        public static double SuccessThreshold(int difficulty)
        {
            double successThreshold = 0.0;
            switch (difficulty)
            {
                case 0:
                    {
                        successThreshold = 0.10;
                        break;
                    }
                case 1:
                    {
                        successThreshold = 0.25;
                        break;
                    }
                case 2:
                    {
                        successThreshold = 0.50;
                        break;
                    }
                case 3:
                    {
                        successThreshold = 0.75;
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException("Incorrect difficulty level");
                    }
            }
            return successThreshold;
        }
        public static bool Hit(double successThreshold)
        {
            Random hitRandom = new Random();
            double randomNumber = hitRandom.NextDouble();
            return randomNumber <= successThreshold;
        }
        public static int WhoStartGame()
        {
            if (!GameStarted)
            {
                return -1;
            }
            else
            {
                Random rand = new Random();
                return rand.Next(0, 2);
            }
        }
        public static int ReverseTurn(bool hited)
        {
            if (Fight.Turn >= 0)
            {
                return -1;
            }
            else
            {
                if (!hited)
                {
                    return Convert.ToInt32(!Convert.ToBoolean(Fight.Turn));
                }
                else
                {
                    return Convert.ToInt32(Convert.ToBoolean(Fight.Turn));
                }
            }
        }
    }
}
