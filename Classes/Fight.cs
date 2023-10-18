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
    }
}
