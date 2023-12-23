using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Battleship
{
    public static class Fight
    {
        static ColorMethods cm;
        static Position pos;
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
        public static bool NewMove = true;
        public static char[] AllowedChars = { 'F', 'D', 'C', 'B' };
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
            int target = FindShipCoord(false);
            if (NewMove)
            {
                Button targetButton;
                int index = 0;
                int counter = 0;
                bool incorrectValue = false;
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
                                NewMove = true;
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
                                PlayerData.FrigatesCountCurrent--;
                                PlayerData.SunkenFrigatesCount++;
                                PlayerData.FrigatesHited[PlayerData.SunkenFrigatesCount - 1, 0] = true;
                                NewMove = true;
                                break;
                            }
                        case 'D':
                            {
                                PlayerData.Map[index] = 'H';
                                for (int d0 = 0; d0 < 3; d0++)
                                {
                                    for (int d1 = 0; d1 < 2; d1++)
                                    {
                                        if (PlayerData.DestroyerCoords[d0, d1] == target - 1551)
                                        {
                                            PlayerData.DestroyersHited[d0, d1] = true;
                                            break;
                                        }
                                    }
                                }
                                PlayerData.DoesDestroyerSunken();
                                int sunkenDestroyers = 0;
                                for (int d = 0; d < PlayerData.DestroyersSunken.Length; d++)
                                {
                                    sunkenDestroyers += Convert.ToInt32(PlayerData.DestroyersSunken[d]);
                                }
                                NewMove = PlayerData.SunkenDestroyersCount < sunkenDestroyers;
                                PlayerData.SunkenDestroyersCount = sunkenDestroyers;
                                PlayerData.DestroyersCountCurrent = PlayerData.DestroyersCountMax - PlayerData.SunkenDestroyersCount;
                                break;
                            }
                        case 'C':
                            {
                                PlayerData.Map[index] = 'H';
                                for (int c0 = 0; c0 < 2; c0++)
                                {
                                    for (int c1 = 0; c1 < 3; c1++)
                                    {
                                        if (PlayerData.CruiserCoords[c0, c1] == target - 1551)
                                        {
                                            PlayerData.CruiserHited[c0, c1] = true;
                                            break;
                                        }
                                    }
                                }
                                PlayerData.DoesCruiserSunken();
                                int sunkenCruisers = 0;
                                for (int c = 0; c < PlayerData.CruisersSunken.Length; c++)
                                {
                                    sunkenCruisers += Convert.ToInt32(PlayerData.CruisersSunken[c]);
                                }
                                NewMove = PlayerData.SunkenCruisersCount < sunkenCruisers;
                                PlayerData.SunkenCruisersCount = sunkenCruisers;
                                PlayerData.CruiserCountCurrent = PlayerData.CruiserCountMax - PlayerData.SunkenCruisersCount;
                                break;
                            }
                        case 'B':
                            {
                                PlayerData.Map[index] = 'H';
                                for (int b0 = 0; b0 < 1; b0++)
                                {
                                    for (int b1 = 0; b1 < 4; b1++)
                                    {
                                        if (PlayerData.BattleshipCoords[b0, b1] == target - 1551)
                                        {
                                            PlayerData.BattleshipHited[b0, b1] = true;
                                            break;
                                        }
                                    }
                                }
                                PlayerData.DoesBattleshipSunken();
                                int sunkenBattleship = 0;
                                for (int b = 0; b < PlayerData.BattleshipSunken.Length; b++)
                                {
                                    sunkenBattleship += Convert.ToInt32(PlayerData.BattleshipSunken[b]);
                                }
                                NewMove = PlayerData.SunkenBattleshipCount < sunkenBattleship;
                                PlayerData.SunkenBattleshipCount = sunkenBattleship;
                                PlayerData.BattleshipCountCurrent = PlayerData.BattleshipCountMax - PlayerData.SunkenBattleshipCount;
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Incorrect Position", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                FirstHitCoord = 0;
                                incorrectValue = true;
                                break;
                            }

                    }
                    if (!incorrectValue)
                    {
                        GenerateNearestCoords(target, 1551);
                        for (int bl = 0; bl < BlockedCoords.Count; bl++)
                        {
                            PlayerData.Map[BlockedCoords[bl]] = 'E';
                        }
                    }
                    cm.SetButtonColors(PlayerData.Map);
                }
            }
            else
            {
                if (FirstHitCoord == 0)
                {
                    GenerateNearestCoords(FirstHitCoord, 1551);
                    Random randomShoot = new Random();
                    int nextTarget = randomShoot.Next(1, AllowedCoords.Count + 1);
                    bool allow = true;
                    for (int s = 0; s < AllowedChars.Length; s++)
                    {
                        allow &= AllowedCoords[nextTarget] - 1551 != AllowedChars[s];
                    }
                    if (allow)
                    {
                        //Shoot on target
                    }
                    switch (pos.GetCellPosition((FirstHitCoord - 1551).ToString()))
                    {
                        case "center":
                            {
                                break;
                            }
                        case "top":
                            {
                                break;
                            }
                        case "bottom":
                            {
                                break;
                            }
                        case "left":
                            {
                                break;
                            }
                        case "right":
                            {
                                break;
                            }
                        case "corner1":
                            {
                                break;
                            }
                        case "corner2":
                            {
                                break;
                            }
                        case "corner3":
                            {
                                break;
                            }
                        case "corner4":
                            {
                                break;
                            }
                    }
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

        static void GenerateNearestCoords(int firstCoords, int reduction = 0)
        {
            if (firstCoords != 0)
            {
                firstCoords -= reduction;
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
