using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Battleship
{
    public static class Fight
    {
        static ColorMethods cm = new ColorMethods();
        static Position pos = new Position();
        static Support sp = new Support();
        static Map map = new Map();

        public static bool GameStarted = false;
        public static int TargetCoord;
        public static int Turn = 0;
        public static bool FirstTurn = true;
        public static bool PlayerHits = false;
        public static string InfoType = "Null";
        public static int SunkenShipType = 0;
        public static int FirstHitCoord = 0;
        public static List<int> AllowedCoords = new List<int>();
        public static List<int> BlockedCoords = new List<int>();
        public static bool NewMove = true;
        public static char[] AllowedChars = { 'F', 'D', 'C', 'B' };
        public static bool Hited = false;
        public static int[] TargetData = { 0, 0, 0 };
        public static int TargetButtonTag = 0;
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
        public static void EnemyShoot(int target, out bool successShoot, out bool checkedPosition)
        {
            Button targetButton;
            int index = 0;
            int counter = 0;
            bool incorrectValue = false;
            for (int b = 0; b < PlayerData.MapButtons.Length; b++)
            {
                if (PlayerData.MapButtons[b].Tag.ToString() == Convert.ToString(target - 1551))
                {
                    targetButton = PlayerData.MapButtons[b];
                    index = counter;
                    counter = 0;
                    break;
                }
                else
                {
                    counter++;
                }
            }
            successShoot = true;
            char charter = Char.ToUpper(PlayerData.Map[index]);
            bool hited = true;
            checkedPosition = false;
            switch (charter)
            {
                case 'N':
                case 'E':
                    {
                        FirstHitCoord = 0;
                        PlayerData.Map[index] = 'M';
                        NewMove = true;
                        successShoot = false;
                        hited = false;
                        checkedPosition = false;
                        break;
                    }
                case 'S':
                case 'M':
                case 'H':
                    {
                        //MessageBox.Show("Checked position", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FirstHitCoord = 0;
                        checkedPosition = true;
                        break;
                    }
                case 'F':
                    {
                        PlayerData.Map[index] = 'S';
                        PlayerData.FrigatesCountCurrent--;
                        PlayerData.SunkenFrigatesCount++;
                        PlayerData.FrigatesHited[PlayerData.SunkenFrigatesCount - 1, 0] = true;
                        NewMove = true;
                        successShoot = true;
                        checkedPosition = false;
                        break;
                    }
                case 'D':
                    {
                        PlayerData.Map[index] = 'H';
                        for (int d0 = 0; d0 < 3; d0++)
                        {
                            for (int d1 = 0; d1 < 2; d1++)
                            {
                                if (PlayerData.DestroyerCoords[d0, d1] == index/*target - 1551*/)
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
                        successShoot = true;
                        checkedPosition = false;
                        FirstHitCoord = FindCorrectCoord(index);

                        break;
                    }
                case 'C':
                    {
                        PlayerData.Map[index] = 'H';
                        for (int c0 = 0; c0 < 2; c0++)
                        {
                            for (int c1 = 0; c1 < 3; c1++)
                            {
                                if (PlayerData.CruiserCoords[c0, c1] == index/*target - 1551*/)
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
                        FirstHitCoord = FindCorrectCoord(index);
                        successShoot = true;
                        checkedPosition = false;
                        break;
                    }
                case 'B':
                    {
                        PlayerData.Map[index] = 'H';
                        for (int b0 = 0; b0 < 1; b0++)
                        {
                            for (int b1 = 0; b1 < 4; b1++)
                            {
                                if (PlayerData.BattleshipCoords[b0, b1] == index/*target - 1551*/)
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
                        FirstHitCoord = FindCorrectCoord(index);
                        successShoot = true;
                        checkedPosition = false;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Incorrect Position", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        FirstHitCoord = 0;
                        incorrectValue = true;
                        successShoot = false;
                        hited = false;
                        checkedPosition = false;
                        break;
                    }
            }
            if (!incorrectValue && successShoot && !checkedPosition)
            {
                GenerateNearestCoords(target, 1551);
                for (int bl = 0; bl < BlockedCoords.Count; bl++)
                {
                    PlayerData.Map[BlockedCoords[bl]] = 'E';
                }
            }
            Hited = hited;
        }
        static int FindCorrectIndex(int index)
        {
            index -= 1551;
            for (int b = 0; b < 100; b++)
            {
                if (PlayerData.MapButtons[b].Tag.ToString() == $"{index}")
                {
                    return b;
                }
            }
            return -1;
        }
        static int FindCorrectCoord(int index)
        {
            sp.StringToInt(PlayerData.MapButtons[index].Tag.ToString(), out int coord);
            return coord;
        }
        public static void Shoot(out bool successShoot)
        {
            bool checkedPosition = false;
            do
            {
                successShoot = true;
                int target = FindShipCoord(false);
                if (NewMove)
                {
                    EnemyShoot(target, out successShoot, out checkedPosition);
                }
                else
                {
                    if (FirstHitCoord != 0)
                    {
                        int newIndex = FirstHitCoord + 1551;
                        GenerateNearestCoords(newIndex/*FirstHitCoord*/ /*1551*/);
                        Random randomShoot = new Random();
                        int nextTarget = randomShoot.Next(1, AllowedCoords.Count + 1);
                        nextTarget--;
                        bool allow = true;
                        for (int s = 0; s < AllowedChars.Length; s++)
                        {
                            allow &= AllowedCoords[nextTarget] - 1551 != AllowedChars[s];
                        }
                        if (allow)
                        {
                            EnemyShoot(AllowedCoords[nextTarget], out successShoot, out checkedPosition);
                        }
                    }
                }
            }
            while (checkedPosition);
        }
        public static int FindShipCoord(bool hitStatus)
        {
            if (!hitStatus)
            {
                Random randCoord = new Random();
                int vertical = randCoord.Next(65, 75);
                int horizontal = randCoord.Next(1,11);
                int target = vertical * 10 + horizontal + 1000;
                TargetData[0] = target;
                TargetData[1] = vertical;
                TargetData[2] = horizontal;
                TargetButtonTag = target;
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
                int targetCoord = firstCoords - reduction;
                firstCoords = FindCorrectIndex(firstCoords);
                AllowedCoords.Clear();
                //BlockedCoords.Clear();
                string position = pos.GetCellPosition(targetCoord.ToString());
                switch (position)
                {
                    case "center":
                        {
                            AllowedCoords.Add(firstCoords - 1);
                            AllowedCoords.Add(firstCoords + 1);
                            AllowedCoords.Add(firstCoords - 10);
                            AllowedCoords.Add(firstCoords + 10);
                            BlockedCoords.Add(firstCoords - 11);
                            BlockedCoords.Add(firstCoords + 11);
                            BlockedCoords.Add(firstCoords - 9);
                            BlockedCoords.Add(firstCoords + 9);
                            break;
                        }
                    case "left":
                        {
                            AllowedCoords.Add(firstCoords - 10);
                            AllowedCoords.Add(firstCoords + 10);
                            AllowedCoords.Add(firstCoords + 1);
                            BlockedCoords.Add(firstCoords - 9);
                            BlockedCoords.Add(firstCoords + 11);
                            break;
                        }
                    case "right":
                        {
                            AllowedCoords.Add(firstCoords - 1);
                            AllowedCoords.Add(firstCoords - 10);
                            AllowedCoords.Add(firstCoords + 10);
                            BlockedCoords.Add(firstCoords - 11);
                            BlockedCoords.Add(firstCoords + 9);
                            break;
                        }
                    case "top":
                        {
                            AllowedCoords.Add(firstCoords - 1);
                            AllowedCoords.Add(firstCoords + 1);
                            AllowedCoords.Add(firstCoords + 10);
                            BlockedCoords.Add(firstCoords + 9);
                            BlockedCoords.Add(firstCoords + 11);
                            break;
                        }
                    case "bottom":
                        {
                            AllowedCoords.Add(firstCoords - 10);
                            AllowedCoords.Add(firstCoords - 1);
                            AllowedCoords.Add(firstCoords + 1);
                            BlockedCoords.Add(firstCoords - 9);
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
                            AllowedCoords.Add(firstCoords - 1);
                            AllowedCoords.Add(firstCoords + 10);
                            BlockedCoords.Add(firstCoords +9);
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
                            AllowedCoords.Add(firstCoords - 10);
                            AllowedCoords.Add(firstCoords + 11);
                            BlockedCoords.Add(firstCoords - 9);
                            break;
                        }
                }
            }
        }
    }
}
