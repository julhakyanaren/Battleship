using Octokit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public static int FirstHitCoord = 0;
        public static List<int> AllowedCoords = new List<int>();
        public static List<int> BlockedCoords = new List<int>();
        public static bool FirstMove = true;
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
        public static int WhoStartGame()
        {
            Random randomStart = new Random();
            int number = randomStart.Next(1, 101);
            double numberDouble = Math.Sqrt(number);
            bool perfectSqrt = (numberDouble == (int)numberDouble);
            switch (Options.Difficulty)
            {
                case 0:
                    {
                        return 0;
                    }
                case 1:
                    {
                        return Convert.ToInt32(!perfectSqrt);
                    }
                case 2:
                    {
                        return randomStart.Next(0, 2);
                    }
                case 3:
                    {
                        return Convert.ToInt32(perfectSqrt);
                    }
                default:
                    {
                        return -1;
                    }
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
        static void Move()
        {
            if (FirstMove)
            {
                int target = FindShipCoord(false);
                Button targetButton;
                int index = 0;
                int counter = 0;
                using (GamePlayerOne gpo = new GamePlayerOne())
                {
                    foreach (Button b in gpo.MapButtons)
                    {
                        if (b.Tag.ToString() == Convert.ToString(target - 1551))
                        {
                            targetButton = b;
                            index = counter;
                            counter = 0;
                            break;
                        }
                        else
                        {
                            counter++;
                        }
                    }
                    switch (PlayerData.Map[index])
                    {
                        case 'E':
                            {
                                FirstHitCoord = 0;
                                PlayerData.Map[index] = 'M';
                                break;
                            }
                        case 'S':
                        case 'M':
                        case 'H':
                            {
                                MessageBox.Show("Checked position", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FirstHitCoord = 0;
                                break;
                            }
                        case 'F':
                            {
                                PlayerData.Map[index] = 'S';
                                break;
                            }
                        case 'D':
                        case 'C':
                        case 'B':
                            {
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Incorrect Position", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                FirstHitCoord = 0;
                                break;
                            }

                    }
                }
                FirstMove = false;
            }
            else
            {
                if (FirstHitCoord == 0)
                {

                }
            }
        }
        static int FindShipCoord(bool hitStatus)
        {
            if (!hitStatus)
            {
                Random randCoord = new Random();
                int vertical = randCoord.Next(65, 75);
                int horizontal = randCoord.Next(1,11);
                int target = vertical * 10 + horizontal + 1000;
                return target;
            }
            else
            {
                //GenerateNearestCoords();
            }
            return 0;
        }

        static void GenerateNearestCoords(int firstCoords)
        {
            if (firstCoords != 0)
            {
                Position pos = new Position(); 
                AllowedCoords.Clear();
                BlockedCoords.Clear();
                switch (pos.GetCellPosition(firstCoords.ToString()))
                {
                    case "center":
                        {
                            AllowedCoords.Add(firstCoords - 1);
                            AllowedCoords.Add(firstCoords + 1);
                            AllowedCoords.Add(firstCoords - 10);
                            AllowedCoords.Add(firstCoords + 10);
                            BlockedCoords.Add(firstCoords + -11);
                            BlockedCoords.Add(firstCoords - 9);
                            BlockedCoords.Add(firstCoords + 9);
                            BlockedCoords.Add(firstCoords - 11);
                            break;
                        }
                    case "left":
                        {
                            AllowedCoords.Add(firstCoords - 1);
                            AllowedCoords.Add(firstCoords + 10);
                            AllowedCoords.Add(firstCoords + 1);
                            BlockedCoords.Add(firstCoords + 9);
                            BlockedCoords.Add(firstCoords + 11);
                            break;
                        }
                    case "right":
                        {
                            AllowedCoords.Add(firstCoords + 1);
                            AllowedCoords.Add(firstCoords - 10);
                            AllowedCoords.Add(firstCoords - 1);
                            BlockedCoords.Add(firstCoords - 11);
                            BlockedCoords.Add(firstCoords - 9);
                            break;
                        }
                    case "top":
                        {
                            AllowedCoords.Add(firstCoords - 10);
                            AllowedCoords.Add(firstCoords + 1);
                            AllowedCoords.Add(firstCoords + 10);
                            BlockedCoords.Add(firstCoords - 9);
                            BlockedCoords.Add(firstCoords + 11);
                            break;
                        }
                    case "bottom":
                        {
                            AllowedCoords.Add(firstCoords - 10);
                            AllowedCoords.Add(firstCoords - 1);
                            AllowedCoords.Add(firstCoords + 10);
                            BlockedCoords.Add(firstCoords + 9);
                            BlockedCoords.Add(firstCoords - 11);
                            break;
                        }
                    case "corner1":
                        {
                            AllowedCoords.Add(firstCoords + 10);
                            AllowedCoords.Add(firstCoords + 1);
                            BlockedCoords.Add(firstCoords + 11);
                            break;
                        }
                    case "corner2":
                        {
                            AllowedCoords.Add(firstCoords - 10);
                            AllowedCoords.Add(firstCoords + 1);
                            BlockedCoords.Add(firstCoords -9);
                            break;
                        }
                    case "corner3":
                        {
                            AllowedCoords.Add(firstCoords - 10);
                            AllowedCoords.Add(firstCoords - 1);
                            BlockedCoords.Add(firstCoords - 11);
                            break;
                        }
                    case "corner4":
                        {   
                            AllowedCoords.Add(firstCoords + 10);
                            AllowedCoords.Add(firstCoords - 1);
                            BlockedCoords.Add(firstCoords + 9);
                            break;
                        }
                }
            }
        }
    }
}
