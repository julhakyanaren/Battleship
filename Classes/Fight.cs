using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
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
        public static bool FirstTurn = true;
        public static bool PlayerHits = false;
        public static bool NewMove = true;
        public static bool Hited = false;
        public static bool DefinedShot = false;
        public static bool TargetingShoot = false;
        public static bool GuaranteedShot = false;

        public static bool[] SuccessShoots = { false, false, false };

        public static int TargetCoord;
        public static int Turn = 0;
        public static int SunkenShipType = 0;
        public static int FirstHitCoord = 0;
        public static int[] TargetData = { 0, 0, 0 };
        public static int TargetButtonTag = 0;
        public static int FirstSuccessHitCoord = 0;
        public static int SecondSuccessHitCoord = 0;
        public static int ThirdSuccssHitCoord = 0;
        public static int DefinedCoord = 0;

        public static string InfoType = "Null";

        public static List<int> AllowedCoords = new List<int>();
        public static List<int> BlockedCoords = new List<int>();
        public static List<int> UsedCoords = new List<int>();
        public static List<int> ForbiddenCoords = new List<int>();
        public static List<int> PossibleTargets = new List<int>();

        public static List<int> FirstCheckedCoords = new List<int>();
        public static List<int> SecondCheckedCoords = new List<int>();
        public static List<int> ThirdCheckedCoords = new List<int>();

        private static bool sunkenFrigate = false;
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
            int index = 0;
            int counter = 0;
            bool incorrectValue = false;
            bool targetInMap = true;
            for (int b = 0; b < PlayerData.MapButtons.Length; b++)
            {
                if (PlayerData.MapButtons[b].Tag.ToString() == Convert.ToString(target - 1551))
                {
                    index = counter;
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
                        EnemyData.MissedShotsCount++;
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
                        sunkenFrigate = true;
                        NewShotPreparing();
                        break;
                    }
                case 'D':
                    {
                        PlayerData.Map[index] = 'H';
                        bool canBreak = false;
                        for (int d0 = 0; d0 < 3; d0++)
                        {
                            for (int d1 = 0; d1 < 2; d1++)
                            {
                                int currentDestroyer = PlayerData.DestroyerCoords[d0, d1];
                                if (PlayerData.DestroyerCoords[d0, d1] == index)
                                {
                                    PlayerData.DestroyersHited[d0, d1] = true;
                                    canBreak = true;
                                    break;
                                }
                            }
                            if (canBreak)
                            {
                                break;
                            }
                        }
                        PlayerData.DoesDestroyerSunken();
                        int sunkenDestroyers = 0;
                        for (int d = 0; d < PlayerData.DestroyersSunken.Length; d++)
                        {
                            sunkenDestroyers += Convert.ToInt32(PlayerData.DestroyersSunken[d]);
                        }
                        NewMove = PlayerData.SunkenDestroyersCount < sunkenDestroyers;
                        TargetingShoot = true;
                        if (sunkenDestroyers - PlayerData.SunkenDestroyersCount == 1)
                        {
                            PlayerData.DestroyersCountCurrent--;
                            SetRoundMinesInPlayerMap(3);
                            PossibleTargets.Clear();
                            NewShotPreparing();
                        }
                        else
                        {
                            FirstHitCoord = FindCorrectCoord(index);
                            SetHitCoords(index);
                        }
                        PlayerData.SunkenDestroyersCount = sunkenDestroyers;
                        PlayerData.DestroyersCountCurrent = PlayerData.DestroyersCountMax - PlayerData.SunkenDestroyersCount;
                        successShoot = true;
                        checkedPosition = false;

                        break;
                    }
                case 'C':
                    {
                        PlayerData.Map[index] = 'H';
                        bool canBreak = false;
                        for (int c0 = 0; c0 < 2; c0++)
                        {
                            for (int c1 = 0; c1 < 3; c1++)
                            {
                                int curentCruiser = PlayerData.CruiserCoords[c0, c1];
                                if (PlayerData.CruiserCoords[c0, c1] == index)
                                {
                                    PlayerData.CruiserHited[c0, c1] = true;
                                    canBreak = true;
                                    break;
                                }
                            }
                            if (canBreak)
                            {
                                break;
                            }
                        }
                        PlayerData.DoesCruiserSunken();
                        int sunkenCruisers = 0;
                        for (int c = 0; c < PlayerData.CruisersSunken.Length; c++)
                        {
                            sunkenCruisers += Convert.ToInt32(PlayerData.CruisersSunken[c]);
                        }
                        NewMove = PlayerData.SunkenCruisersCount < sunkenCruisers;
                        TargetingShoot = true;
                        if (sunkenCruisers - PlayerData.SunkenCruisersCount == 1)
                        {
                            PlayerData.CruiserCountCurrent--;
                            SetRoundMinesInPlayerMap(2);
                            PossibleTargets.Clear();
                            NewShotPreparing();
                        }
                        else
                        {
                            FirstHitCoord = FindCorrectCoord(index);
                            SetHitCoords(index);
                        }
                        PlayerData.SunkenCruisersCount = sunkenCruisers;
                        PlayerData.CruiserCountCurrent = PlayerData.CruiserCountMax - PlayerData.SunkenCruisersCount;

                        successShoot = true;
                        checkedPosition = false;
                        break;
                    }
                case 'B':
                    {
                        PlayerData.Map[index] = 'H';
                        for (int b1 = 0; b1 < 4; b1++)
                        {
                            int currnetBattleship = PlayerData.BattleshipCoords[0, b1];
                            if (PlayerData.BattleshipCoords[0, b1] == index)
                            {
                                PlayerData.BattleshipHited[0, b1] = true;
                                break;
                            }
                        }
                        PlayerData.DoesBattleshipSunken();
                        int sunkenBattleship = 0;
                        for (int b = 0; b < PlayerData.BattleshipSunken.Length; b++)
                        {
                            sunkenBattleship += Convert.ToInt32(PlayerData.BattleshipSunken[b]);
                        }
                        NewMove = PlayerData.SunkenBattleshipCount < sunkenBattleship;
                        TargetingShoot = true;
                        if (sunkenBattleship == 1)
                        {
                            PlayerData.BattleshipCountCurrent--;
                            SetRoundMinesInPlayerMap(1);
                            PossibleTargets.Clear();
                            NewShotPreparing();
                        }
                        else
                        {
                            FirstHitCoord = FindCorrectCoord(index);
                            SetHitCoords(index);
                        }
                        PlayerData.SunkenBattleshipCount = sunkenBattleship;
                        PlayerData.BattleshipCountCurrent = PlayerData.BattleshipCountMax - PlayerData.SunkenBattleshipCount;

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
                        targetInMap = false;
                        break;
                    }
            }
            if (charter == 'F' || charter == 'D' || charter == 'C' || charter == 'B')
            {
                ShipData.HitedDeckCount++;
                EnemyData.HitCountCurrent++;
            }
            if (!incorrectValue && successShoot && !checkedPosition)
            {
                GenerateNearestCoords(target, 1551);
                for (int bl = 0; bl < BlockedCoords.Count; bl++)
                {
                    PlayerData.Map[BlockedCoords[bl]] = 'E';
                }
                if (sunkenFrigate)
                {
                    for (int bl = 0; bl < AllowedCoords.Count; bl++)
                    {
                        PlayerData.Map[AllowedCoords[bl]] = 'E';
                        ForbiddenCoords.Add(AllowedCoords[bl]);
                    }
                    ForbiddenCoords = SortUniqueInt(ForbiddenCoords);
                    sunkenFrigate = false;
                }
            }
            if (targetInMap)
            {
                UsedCoords.Add(index);
                ForbiddenCoords.Add(index);
            }
            Hited = hited;
        }
        static int FindCorrectIndex(int index, bool enemyMap = false, string codeIndex = "null")
        {
            index -= 1551;
            if (!enemyMap)
            {
                for (int b = 0; b < 100; b++)
                {
                    if (PlayerData.MapButtons[b].Tag.ToString() == $"{index}")
                    {
                        return b;
                    }
                }
            }
            else
            {
                for (int b = 0; b < 100; b++)
                {
                    if (EnemyData.MapButtons[b].Tag.ToString() == $"{index}")
                    {
                        return b;
                    }
                }
            }
            return -1;
        }
        internal static int FindCorrectCoord(int index, bool enemyMap = false)
        {
            int coord = -1;
            try
            {
                if (!enemyMap)
                {
                    sp.StringToInt(PlayerData.MapButtons[index].Tag.ToString(), out coord);
                }
                else
                {
                    sp.StringToInt(EnemyData.MapButtons[index].Tag.ToString(), out coord);
                }
                if (coord == -1)
                {
                    MessageBox.Show("Incorrect Coord");
                }
            }
            catch
            {
                coord = -1;
            }
            return coord;
        }

        public static void Shoot(out bool successShoot)
        {
            bool checkedPosition;
            successShoot = false;
            if (DefinedShot)
            {
                NewMove = false;
            }
            if (NewMove)
            {
                bool correctCoord = false;
                int target;
                do
                {
                    if (ForbiddenCoords.Count != 0)
                    {
                        ForbiddenCoords.Sort();
                        target = FindShipCoord(false);
                        int targetIndex = FindCorrectIndex(target, codeIndex: "Fight 663");
                        correctCoord = !ForbiddenCoords.Contains(targetIndex);
                    }
                    else
                    {
                        target = FindShipCoord(false);
                        correctCoord = true;
                    }
                }
                while (!correctCoord);
                TargetButtonTag = target;
                EnemyShoot(target, out successShoot, out checkedPosition);
            }
            else if (SuccessShoots[0] && !SuccessShoots[1] && !SuccessShoots[2])
            {
                int secondTarget = -1;
                bool canShot = false;
                int firstCoord = FirstSuccessHitCoord + 1551;
                GenerateNearestCoords(firstCoord, 1551);
                List<int> allowedCoords = AllowedCoords;
                allowedCoords.RemoveAll(item => FirstCheckedCoords.Contains(item));
                do
                {
                    Random random = new Random();
                    int randomIndex = random.Next(0, allowedCoords.Count);
                    secondTarget = allowedCoords[randomIndex];
                    if (ForbiddenCoords.Contains(secondTarget))
                    {
                        allowedCoords.Remove(secondTarget);
                        AllowedCoords.Remove(secondTarget);
                    }
                    else
                    {
                        canShot = true;
                    }
                }
                while (!canShot);
                PossibleTargets = AllowedCoords;
                secondTarget = FindCorrectCoord(secondTarget) + 1551;
                TargetButtonTag = secondTarget;
                EnemyShoot(secondTarget, out successShoot, out checkedPosition);
                if (!successShoot)
                {
                    FirstCheckedCoords.Add(FindCorrectIndex(secondTarget, codeIndex: "Fight 682"));
                    PossibleTargets.Remove(FindCorrectIndex(secondTarget, codeIndex: "Fight 683"));
                    DefinedShot = true;
                }
            }
            else if (SuccessShoots[0] && SuccessShoots[1] && !SuccessShoots[2])
            {
                int[] indexes = new int[2];
                int thirdTarget = -2;
                List<int> nextCoords = new List<int>();
                if (SecondCheckedCoords.Count == 0)
                {
                    indexes[0] = FindCorrectIndex(FirstSuccessHitCoord + 1551, codeIndex: "Fight 690");
                    indexes[1] = FindCorrectIndex(SecondSuccessHitCoord + 1551, codeIndex: "Fight 691");
                    int delta = indexes[0] - indexes[1];
                    char lineChar = 'n';
                    switch (delta)
                    {
                        case -10:
                            {
                                nextCoords.Add(indexes[0] + delta);
                                nextCoords.Add(indexes[1] + Math.Abs(delta));
                                lineChar = 'c';
                                break;
                            }
                        case -1:
                            {
                                nextCoords.Add(indexes[0] + delta);
                                nextCoords.Add(indexes[1] + Math.Abs(delta));
                                lineChar = 'r';
                                break;
                            }
                        case 1:
                            {
                                nextCoords.Add(indexes[1] - Math.Abs(delta));
                                nextCoords.Add(indexes[0] + Math.Abs(delta));
                                lineChar = 'r';
                                break;
                            }
                        case 10:
                            {
                                nextCoords.Add(indexes[1] - Math.Abs(delta));
                                nextCoords.Add(indexes[0] + delta);
                                lineChar = 'c';
                                break;
                            }
                    }
                    nextCoords = pos.DeleteOutLineCoords(nextCoords, indexes[0], lineChar);
                    nextCoords = DeleteForbiddenCoords(nextCoords);
                }
                else
                {
                    nextCoords.RemoveAll(coord => SecondCheckedCoords.Contains(coord));
                }
                Random random = new Random();
                int randomIndex = random.Next(nextCoords.Count);
                thirdTarget = FindCorrectCoord(nextCoords[randomIndex]) + 1551;
                TargetButtonTag = thirdTarget;
                EnemyShoot(thirdTarget, out successShoot, out checkedPosition);
                if (!successShoot)
                {
                    SecondCheckedCoords.Add(FindCorrectIndex(thirdTarget, codeIndex: "Fight 741"));
                    DefinedShot = true;
                }
            }
            else if (SuccessShoots[0] && SuccessShoots[1] && SuccessShoots[2])
            {
                char lineChar = 'n';
                int fourthTarget = -3;
                int[] indexes = new int[3];
                List<int> nextCoords = new List<int>();
                if (ThirdCheckedCoords.Count == 0)
                {
                    indexes[0] = FindCorrectIndex(FirstSuccessHitCoord + 1551, codeIndex: "Fight 748");
                    indexes[1] = FindCorrectIndex(SecondSuccessHitCoord + 1551, codeIndex: "Fight 749");
                    indexes[2] = FindCorrectIndex(ThirdSuccssHitCoord + 1551, codeIndex: "Fight 750");
                    int max = indexes.Max();
                    int min = indexes.Min();
                    int delta = indexes[0] - indexes[1];
                    switch (delta)
                    {
                        case -10:
                            {
                                nextCoords.Add(max + Math.Abs(delta));
                                nextCoords.Add(min + delta);
                                lineChar = 'c';
                                break;
                            }
                        case -1:
                            {
                                nextCoords.Add(max + Math.Abs(delta));
                                nextCoords.Add(min + delta);
                                lineChar = 'r';
                                break;
                            }
                        case 1:
                            {
                                nextCoords.Add(max + delta);
                                nextCoords.Add(min - delta);
                                lineChar = 'r';
                                break;
                            }
                        case 10:
                            {
                                nextCoords.Add(max + delta);
                                nextCoords.Add(min - delta);
                                lineChar = 'c';
                                break;
                            }
                    }
                    nextCoords = pos.DeleteOutLineCoords(nextCoords, indexes[0], lineChar);
                    nextCoords = DeleteForbiddenCoords(nextCoords);
                }
                else
                {
                    nextCoords.RemoveAll(coord => ThirdCheckedCoords.Contains(coord));
                }
                Random random = new Random();
                int randomIndex = random.Next(nextCoords.Count);
                fourthTarget = FindCorrectCoord(nextCoords[randomIndex]) + 1551;
                TargetButtonTag = fourthTarget;
                EnemyShoot(fourthTarget, out successShoot, out checkedPosition);
                if (!successShoot)
                {
                    ThirdCheckedCoords.Add(FindCorrectIndex(fourthTarget, codeIndex: "Fight 741"));
                    DefinedShot = true;
                }
            }
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
                firstCoords = FindCorrectIndex(firstCoords, codeIndex: "Fight 655");
                AllowedCoords.Clear();
                BlockedCoords.Clear();
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
                            AllowedCoords.Add(firstCoords + 1);
                            BlockedCoords.Add(firstCoords - 9);
                            break;
                        }
                }
                for (int b = 0; b < BlockedCoords.Count; b++)
                {
                    ForbiddenCoords.Add(BlockedCoords[b]);
                }
                ForbiddenCoords = SortUniqueInt(ForbiddenCoords);
                AllowedCoords.Sort();
                BlockedCoords.Sort();
            }
        }
        private static List<int> SortUniqueInt(List<int> disorderedList)
        {
            HashSet<int> unique = new HashSet<int>(disorderedList);
            List<int> newList = new List<int>(unique);
            newList.Sort();
            return newList;
        }
        private static List<int> DeleteForbiddenCoords(List<int> inputList)
        {
            int[] coords = new int[2];
            HashSet<int> forbiddenSet = new HashSet<int>(ForbiddenCoords);
            HashSet<int> convertedSet = new HashSet<int>(inputList);
            var intersection = convertedSet.Where(x => forbiddenSet.Contains(x)).ToList();
            foreach (var item in intersection)
            {
                convertedSet.Remove(item);
            }
            inputList = new List<int>(convertedSet);
            return inputList;
        }
        private static void NewShotPreparing()
        {
            FirstHitCoord = 0;
            FirstSuccessHitCoord = 0;
            SecondSuccessHitCoord = 0;
            ThirdSuccssHitCoord = 0;
            SuccessShoots = new[] { false, false, false };
            DefinedCoord = 0;
            DefinedShot = false;
            TargetingShoot = false;
        }
        private static void SetHitCoords(int target)
        {
            target = FindCorrectCoord(target);
            if (target > 0)
            {
                if (FirstSuccessHitCoord == 0)
                {
                    FirstSuccessHitCoord = target;
                    SuccessShoots[0] = true;
                }
                else
                {
                    if (SecondSuccessHitCoord == 0)
                    {
                        SecondSuccessHitCoord = target;
                        SuccessShoots[1] = true;
                    }
                    else
                    {
                        if (ThirdSuccssHitCoord == 0)
                        {
                            ThirdSuccssHitCoord = target;
                            SuccessShoots[2] = true;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Incorrect success hit data", "Data Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void SetRoundMinesInPlayerMap(int shipType)
        {
            for (int s = 0; s < shipType; s++)
            {
                int[] mineTags = new int[0];
                int firstCoord = -1;
                string orientation = null;
                int shipSize = 5 - shipType;
                int[] sunkenShips = new int[shipSize];
                switch (shipSize)
                {
                    case 2:
                        {
                            if (PlayerData.DestroyersSunken[s])
                            {
                                if (Math.Abs(PlayerData.DestroyerCoords[s, 0] - PlayerData.DestroyerCoords[s, 1]) == 1)
                                {
                                    firstCoord = PlayerData.DestroyerCoords[s, 0];
                                    orientation = "H";
                                }
                                else if (Math.Abs(PlayerData.DestroyerCoords[s, 0] - PlayerData.DestroyerCoords[s, 1]) == 10)
                                {
                                    firstCoord = PlayerData.DestroyerCoords[s, 1];
                                    orientation = "V";
                                }
                                for (int sk = 0; sk < shipSize; sk++)
                                {
                                    sunkenShips[sk] = PlayerData.DestroyerCoords[s, sk];
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            if (PlayerData.CruisersSunken[s])
                            {
                                if (Math.Abs(PlayerData.CruiserCoords[s, 0] - PlayerData.CruiserCoords[s, 1]) == 1)
                                {
                                    firstCoord = PlayerData.CruiserCoords[s, 0];
                                    orientation = "H";
                                }
                                else if (Math.Abs(PlayerData.CruiserCoords[s, 0] - PlayerData.CruiserCoords[s, 1]) == 10)
                                {
                                    firstCoord = PlayerData.CruiserCoords[s, 2];
                                    orientation = "V";
                                }
                                for (int sk = 0; sk < shipSize; sk++)
                                {
                                    sunkenShips[sk] = PlayerData.CruiserCoords[s, sk];
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            if (PlayerData.BattleshipSunken[s])
                            {
                                if (Math.Abs(PlayerData.BattleshipCoords[s, 0] - PlayerData.BattleshipCoords[s, 1]) == 1)
                                {
                                    firstCoord = PlayerData.BattleshipCoords[s, 0];
                                    orientation = "H";
                                }
                                else if (Math.Abs(PlayerData.BattleshipCoords[s, 0] - PlayerData.BattleshipCoords[s, 1]) == 10)
                                {
                                    firstCoord = PlayerData.BattleshipCoords[s, 3];
                                    orientation = "V";
                                }
                                for (int sk = 0; sk < shipSize; sk++)
                                {
                                    sunkenShips[sk] = PlayerData.BattleshipCoords[s, sk];
                                }
                            }
                            break;
                        }
                }
                if (firstCoord != -1)
                {
                    firstCoord = FindCorrectCoord(firstCoord);
                    pos.GetCoordsFromTag(firstCoord.ToString(), out int x, out int y, out int id);
                    string cellPos = pos.GetCellPosition(firstCoord.ToString());
                    if (orientation != null)
                    {
                        int minesCount = ShipData.GetMineCount(cellPos, shipSize, x, y, orientation);
                        Array.Resize(ref mineTags, minesCount);
                        if (shipSize > 0)
                        {
                            mineTags = ShipData.MineTagsFill(mineTags, cellPos, shipSize, firstCoord, orientation);
                            for (int m = 0; m < minesCount; m++)
                            {
                                mineTags[m] = FindCorrectIndex(mineTags[m] + 1551, codeIndex: "Fight 1162");
                                PlayerData.Map[mineTags[m]] = 'E';
                                ForbiddenCoords.Add(mineTags[m]);
                            }
                            for (int sk = 0; sk < sunkenShips.Length; sk++)
                            {
                                PlayerData.Map[sunkenShips[sk]] = 'S';
                            }
                            ForbiddenCoords = SortUniqueInt(ForbiddenCoords);
                        }
                        else
                        {
                            //Error_Catch
                        }
                    }
                    else
                    {
                        //Error_Catch
                    }
                }
            }
        }
        internal static void SetRoundMinesInEnemyMap(int shipType)
        {
            for (int s = 0; s < shipType; s++)
            {
                int[] mineTags = new int[0];
                int firstCoord = -1;
                string orientation = null;
                int shipSize = 5 - shipType;
                int[] sunkenShips = new int[shipSize];
                switch (shipSize)
                {
                    case 2:
                        {
                            if (EnemyData.DestroyersSunken[s])
                            {
                                if (Math.Abs(EnemyData.DestroyerCoords[s, 0] - EnemyData.DestroyerCoords[s, 1]) == 1)
                                {
                                    firstCoord = EnemyData.DestroyerCoords[s, 0];
                                    orientation = "H";
                                }
                                else if (Math.Abs(EnemyData.DestroyerCoords[s, 0] - EnemyData.DestroyerCoords[s, 1]) == 10)
                                {
                                    firstCoord = EnemyData.DestroyerCoords[s, 1];
                                    orientation = "V";
                                }
                                for (int sk = 0; sk < shipSize; sk++)
                                {
                                    sunkenShips[sk] = EnemyData.DestroyerCoords[s, sk];
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            if (EnemyData.CruisersSunken[s])
                            {
                                if (Math.Abs(EnemyData.CruiserCoords[s, 0] - EnemyData.CruiserCoords[s, 1]) == 1)
                                {
                                    firstCoord = EnemyData.CruiserCoords[s, 0];
                                    orientation = "H";
                                }
                                else if (Math.Abs(EnemyData.CruiserCoords[s, 0] - EnemyData.CruiserCoords[s, 1]) == 10)
                                {
                                    firstCoord = EnemyData.CruiserCoords[s, 2];
                                    orientation = "V";
                                }
                                for (int sk = 0; sk < shipSize; sk++)
                                {
                                    sunkenShips[sk] = EnemyData.CruiserCoords[s, sk];
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            if (EnemyData.BattleshipSunken[s])
                            {
                                if (Math.Abs(EnemyData.BattleshipCoords[s, 0] - EnemyData.BattleshipCoords[s, 1]) == 1)
                                {
                                    firstCoord = EnemyData.BattleshipCoords[s, 0];
                                    orientation = "H";
                                }
                                else if (Math.Abs(EnemyData.BattleshipCoords[s, 0] - EnemyData.BattleshipCoords[s, 1]) == 10)
                                {
                                    firstCoord = EnemyData.BattleshipCoords[s, 3];
                                    orientation = "V";
                                }
                                for (int sk = 0; sk < shipSize; sk++)
                                {
                                    sunkenShips[sk] = EnemyData.BattleshipCoords[s, sk];
                                }
                            }
                            break;
                        }
                }
                if (firstCoord != -1)
                {
                    firstCoord = FindCorrectCoord(firstCoord, true);
                    pos.GetCoordsFromTag(firstCoord.ToString(), out int x, out int y, out int id);
                    string cellPos = pos.GetCellPosition(firstCoord.ToString());
                    if (orientation != null)
                    {
                        int minesCount = ShipData.GetMineCount(cellPos, shipSize, x, y, orientation);
                        Array.Resize(ref mineTags, minesCount);
                        if (shipSize > 0)
                        {
                            mineTags = ShipData.MineTagsFill(mineTags, cellPos, shipSize, firstCoord, orientation);
                            for (int m = 0; m < minesCount; m++)
                            {
                                mineTags[m] = FindCorrectIndex(mineTags[m] + 1551, true, codeIndex: "Fight 1273");
                                EnemyData.Map[mineTags[m]] = 'M';
                            }
                            for (int sk = 0; sk < sunkenShips.Length; sk++)
                            {
                                EnemyData.Map[sunkenShips[sk]] = 'S';
                            }
                        }
                        else
                        {
                            //Error_Catch
                        }
                    }
                    else
                    {
                        //Error_Catch
                    }
                }
            }
        }
        internal static void GenerateBlockedCoords(string position, int firstCoord, bool isFrigate = false)
        {
            EnemyData.AllowedCoords.Clear();
            EnemyData.BlockedCoords.Clear();
            switch (position)
            {
                case "center":
                    {
                        EnemyData.AllowedCoords.Add(firstCoord - 1);
                        EnemyData.AllowedCoords.Add(firstCoord + 1);
                        EnemyData.AllowedCoords.Add(firstCoord - 10);
                        EnemyData.AllowedCoords.Add(firstCoord + 10);
                        EnemyData.BlockedCoords.Add(firstCoord - 11);
                        EnemyData.BlockedCoords.Add(firstCoord + 11);
                        EnemyData.BlockedCoords.Add(firstCoord - 9);
                        EnemyData.BlockedCoords.Add(firstCoord + 9);
                        break;
                    }
                case "left":
                    {
                        EnemyData.AllowedCoords.Add(firstCoord - 10);
                        EnemyData.AllowedCoords.Add(firstCoord + 10);
                        EnemyData.AllowedCoords.Add(firstCoord + 1);
                        EnemyData.BlockedCoords.Add(firstCoord - 9);
                        EnemyData.BlockedCoords.Add(firstCoord + 11);
                        break;
                    }
                case "right":
                    {
                        EnemyData.AllowedCoords.Add(firstCoord - 1);
                        EnemyData.AllowedCoords.Add(firstCoord - 10);
                        EnemyData.AllowedCoords.Add(firstCoord + 10);
                        EnemyData.BlockedCoords.Add(firstCoord - 11);
                        EnemyData.BlockedCoords.Add(firstCoord + 9);
                        break;
                    }
                case "top":
                    {
                        EnemyData.AllowedCoords.Add(firstCoord - 1);
                        EnemyData.AllowedCoords.Add(firstCoord + 1);
                        EnemyData.AllowedCoords.Add(firstCoord + 10);
                        EnemyData.BlockedCoords.Add(firstCoord + 9);
                        EnemyData.BlockedCoords.Add(firstCoord + 11);
                        break;
                    }
                case "bottom":
                    {
                        EnemyData.AllowedCoords.Add(firstCoord - 10);
                        EnemyData.AllowedCoords.Add(firstCoord - 1);
                        EnemyData.AllowedCoords.Add(firstCoord + 1);
                        EnemyData.BlockedCoords.Add(firstCoord - 9);
                        EnemyData.BlockedCoords.Add(firstCoord - 11);
                        break;
                    }
                case "corner1":
                    {
                        EnemyData.AllowedCoords.Add(firstCoord + 10);
                        EnemyData.AllowedCoords.Add(firstCoord + 1);
                        EnemyData.BlockedCoords.Add(firstCoord + 11);
                        break;
                    }
                case "corner2":
                    {
                        EnemyData.AllowedCoords.Add(firstCoord - 1);
                        EnemyData.AllowedCoords.Add(firstCoord + 10);
                        EnemyData.BlockedCoords.Add(firstCoord + 9);
                        break;
                    }
                case "corner3":
                    {
                        EnemyData.AllowedCoords.Add(firstCoord - 10);
                        EnemyData.AllowedCoords.Add(firstCoord - 1);
                        EnemyData.BlockedCoords.Add(firstCoord - 11);
                        break;
                    }
                case "corner4":
                    {
                        EnemyData.AllowedCoords.Add(firstCoord - 10);
                        EnemyData.AllowedCoords.Add(firstCoord + 1);
                        EnemyData.BlockedCoords.Add(firstCoord - 9);
                        break;
                    }
            }
            if (!isFrigate)
            {
                EnemyData.AllowedCoords.Clear();
            }
        }
        //Unused 6
        //Unused 8
        //Unused 7
        //Unused 10
        //Unused 11
        //Unused 12
        //Unused 13
        //Unused 14
        //Unused 15
    }
}
