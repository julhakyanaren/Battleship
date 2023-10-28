using Octokit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
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
        public static string InfoType = "Null";
        public static int SunkenShipType = 0;

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
        public static bool CanHit(double successThreshold)
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
            if (Turn < 0)
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
        public static bool FindEmptyCell(out string targetTag)
        {
            int[] emptyIndexes = new int[0];
            int index = 0;
            for (int c = 0; c < PlayerData.Map.Length; c++)
            {
                if (PlayerData.Map[c] == 'N')
                {
                    index++;
                    Array.Resize(ref emptyIndexes, index);
                    emptyIndexes[index] = 100 + c;
                }
            }
            if (emptyIndexes.Length == 0)
            {
                targetTag = "-100";
                return false;
            }
            else
            {
                Random randomEmptyCell = new Random();
                targetTag = randomEmptyCell.Next(0, emptyIndexes.Length).ToString();
                return true;
            }
        }
        public static char FindShipChar(out int randomShipType)
        {
            Random setRandomShip = new Random();
            randomShipType = setRandomShip.Next(1, 5);
            switch (randomShipType)
            {
                case 1:
                    {
                        return 'F';
                    }
                case 2:
                    {
                        return 'D';
                    }
                case 3:
                    {
                        return 'C';
                    }
                case 4:
                    {
                        return 'B';
                    }
                default:
                    {
                        return 'N';
                    }
            }
        }
        public static string FindShipTag()
        {
            char shipChar = FindShipChar(out int shipIndex);
            int index = -1;
            if (shipIndex <= 0)
            {
                return "-100";
                //Error_Catch
            }
            else
            {
                foreach (char c in PlayerData.Map)
                {
                    if (c == shipChar)
                    {
                        index = Array.IndexOf(PlayerData.Map, c);
                        break;
                    }
                }
                return $"1{index}";
            }
        }
        public static bool EnemyShot(out string targetTag, out bool successShot, out bool alreadyHited)
        {
            alreadyHited = false;
            successShot = CanHit(SuccessThreshold(Options.Difficulty));
            targetTag = "-100";
            if (Turn == 1)
            {
                if (successShot)
                {
                    targetTag = FindShipTag();
                    if (targetTag != "-100")
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    if (FindEmptyCell(out targetTag))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}
