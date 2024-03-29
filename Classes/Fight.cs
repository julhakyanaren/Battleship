using Octokit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static char[] AllowedChars = { 'F', 'D', 'C', 'B' };

        public static List<int> AllowedCoords = new List<int>();
        public static List<int> BlockedCoords = new List<int>();
        public static List<int> UsedCoords = new List<int>();
        public static List<int> ForbiddenCoords = new List<int>();
        public static List<int> PossibleTargets = new List<int>();

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
            //Debug
            if (index == 0)
            {
                index--;
                index++;
            }
            //Debug
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
                            SetRoundMines(3);
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
                            SetRoundMines(2);
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
                            SetRoundMines(1);
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
            if (coord == -1)
            {
                MessageBox.Show("Incorrect Coord");
            }
            return coord;
        }
        public static void Shoot_Advanced(out bool successShoot)
        {
            successShoot = true;
            bool checkedPosition = false;
            if (GuaranteedShot)
            {

            }
            else if (TargetingShoot) //Coment: Еслы первый выстрел был успешным
            {
                bool canShot = false;
                int possibleTarget;
                do
                {
                    if (PossibleTargets.Count == 0)
                    {
                        GenerateNearestCoords(FirstHitCoord + 1551, 1551);
                        PossibleTargets = AllowedCoords;
                    }
                    Random random = new Random();
                    int randomIndex = random.Next(0, PossibleTargets.Count);
                    possibleTarget = PossibleTargets[randomIndex];
                    if (AllowedValue(possibleTarget, ForbiddenCoords))
                    {
                        canShot = true;
                    }
                    else
                    {
                        PossibleTargets.Remove(possibleTarget);
                    }
                }
                while (!canShot);
                TargetButtonTag = possibleTarget;
                EnemyShoot(possibleTarget, out successShoot, out checkedPosition);
                ForbiddenCoords.Add(FindCorrectIndex(possibleTarget));
                switch (successShoot)
                {
                    case true:
                        {
                            PossibleTargets = UpdatePossibleCoords(FirstSuccessHitCoord, SecondSuccessHitCoord, ThirdSuccssHitCoord, PossibleTargets, true);
                            DeleteForbiddenCoords(PossibleTargets);
                            break;
                        }
                    case false:
                        {
                            break;
                        }
                }
                PossibleTargets.Remove(possibleTarget);
                ForbiddenCoords.Add(possibleTarget);
            }
            else if (NewMove) //Comment: Новый ход 
            {
                int newTarget;
                if (ForbiddenCoords.Count != 0)
                {
                    ForbiddenCoords.Sort();
                    do
                    {
                        bool correctCoord = false;
                        do
                        {
                            newTarget = FindShipCoord(false);
                            if (AllowedValue(newTarget, ForbiddenCoords))
                            {
                                correctCoord = true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        while (!correctCoord);
                        TargetButtonTag = newTarget;
                        EnemyShoot(newTarget, out successShoot, out checkedPosition);
                        ForbiddenCoords.Add(FindCorrectIndex(newTarget));
                    }
                    while (checkedPosition);
                }
                else
                {
                    newTarget = FindShipCoord(false);
                    EnemyShoot(newTarget, out successShoot, out checkedPosition);
                    ForbiddenCoords.Add(FindCorrectIndex(newTarget));
                }
            }
            ForbiddenCoords = SortUniqueInt(ForbiddenCoords);
        }
        public static void Shoot(out bool successShoot)
        {
            int newFoundTarget = -1;
            bool checkedPosition = false;
            successShoot = true;
            if (GuaranteedShot)
            {
                EnemyShoot(DefinedCoord, out successShoot, out checkedPosition);
                GuaranteedShot = !successShoot;
            }
            else
            {
                if (ThirdSuccssHitCoord != 0)
                {
                    List<int> lastcoords = FindLastCoord();
                    DeleteForbiddenCoords(lastcoords);
                    PossibleTargets.Clear();
                    PossibleTargets = DeleteForbiddenCoords(lastcoords);
                    if (PossibleTargets.Count != 0)
                    {
                        Random randLastCoord = new Random();
                        int randomItem = randLastCoord.Next(0, lastcoords.Count);
                        int lastTarget = PossibleTargets[randomItem];
                        lastTarget = FindCorrectCoord(lastTarget) + 1551;
                        TargetButtonTag = lastTarget;
                        EnemyShoot(lastTarget, out successShoot, out checkedPosition);
                        try
                        {
                            if (!successShoot)
                            {
                                PossibleTargets.Remove(lastTarget);
                                DefinedCoord = FindCorrectCoord(PossibleTargets[0]) + 1551;
                                GuaranteedShot = true;
                            }
                            else
                            {
                                GuaranteedShot = false;
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect hit data", "Data Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    do
                    {
                        if (DefinedShot)
                        {
                            NewMove = false;
                        }
                        if (NewMove)
                        {
                            bool correctCoord = false;
                            int target = -1;
                            do
                            {
                                if (ForbiddenCoords.Count != 0)
                                {
                                    ForbiddenCoords.Sort();
                                    target = FindShipCoord(false);
                                    if (target == 1660)
                                    {

                                    }
                                    int targetIndex = FindCorrectIndex(target);
                                    for (int t = 0; t < ForbiddenCoords.Count; t++)
                                    {
                                        if (targetIndex != ForbiddenCoords[t])
                                        {
                                            correctCoord = true;
                                            if (target < ForbiddenCoords[t])
                                            {
                                                correctCoord = false;
                                                break;
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            correctCoord = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    target = FindShipCoord(false);
                                    correctCoord = true;
                                }
                            }
                            while (!correctCoord);
                            newFoundTarget = target;
                            TargetButtonTag = target;
                            EnemyShoot(target, out successShoot, out checkedPosition);
                        }
                        else if (FirstHitCoord != 0 || DefinedShot)
                        {
                            bool canShot = false;
                            int nextTarget = -1;
                            int newIndex = -1;
                            newIndex = FirstHitCoord + 1551;
                            if (!DefinedShot)
                            {
                                GenerateNearestCoords(newIndex, 1551);
                                List<int> allowedCoords = AllowedCoords;
                                do
                                {
                                    if (allowedCoords.Count > 0)
                                    {
                                        ForbiddenCoords.Sort();
                                        Random randomShoot = new Random();
                                        int randomIndex = randomShoot.Next(0, AllowedCoords.Count);
                                        nextTarget = allowedCoords[randomIndex];
                                        for (int f = 0; f < ForbiddenCoords.Count; f++)
                                        {
                                            if (nextTarget != ForbiddenCoords[f])
                                            {
                                                canShot = true;
                                                if (nextTarget < ForbiddenCoords[f])
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                canShot = false;
                                                allowedCoords.Remove(nextTarget);
                                                AllowedCoords.Remove(nextTarget);
                                                allowedCoords.Sort();
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        GenerateSecondPossibleCoords(PossibleTargets);
                                        PossibleTargets = SortUniqueInt(PossibleTargets);
                                        allowedCoords = PossibleTargets;
                                        continue;
                                    }
                                }
                                while (!canShot);
                                nextTarget = FindCorrectCoord(nextTarget) + 1551;
                                PossibleTargets = AllowedCoords;
                            }
                            if (DefinedShot)
                            {
                                if (PossibleTargets.Count != 1)
                                {
                                    int counter = -1;
                                    do
                                    {
                                        counter++;
                                        ForbiddenCoords.Sort();
                                        PossibleTargets.Sort();
                                        if (PossibleTargets.Count == 2 && (Math.Abs(PossibleTargets[0] - PossibleTargets[1]) == 10 || Math.Abs(PossibleTargets[0] - PossibleTargets[1]) == 1))
                                        {
                                            if (PossibleTargets.Count >= counter + 1)
                                            {
                                                nextTarget = PossibleTargets[counter];
                                            }
                                        }
                                        else
                                        {
                                            if (PossibleTargets.Count > 0)
                                            {
                                                Random randomPT = new Random();
                                                int randomIndexPT = randomPT.Next(0, PossibleTargets.Count);
                                                nextTarget = PossibleTargets[randomIndexPT];
                                            }
                                            else
                                            {
                                                GenerateSecondPossibleCoords(PossibleTargets);
                                            }
                                            if (PossibleTargets.Count == 0)
                                            {
                                                NewMove = true;
                                            }
                                            else
                                            {
                                                Random randomPT = new Random();
                                                int randomIndexPT = randomPT.Next(0, PossibleTargets.Count);
                                                nextTarget = PossibleTargets[randomIndexPT];
                                                break;
                                            }
                                        }
                                        for (int f = 0; f < ForbiddenCoords.Count; f++)
                                        {
                                            if (nextTarget != ForbiddenCoords[f])
                                            {
                                                canShot = true;
                                                if (nextTarget < ForbiddenCoords[f])
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                canShot = false;
                                                break;
                                            }
                                        }
                                    }
                                    while (!canShot);
                                }
                                else
                                {
                                    DefinedCoord = PossibleTargets[0];
                                    nextTarget = DefinedCoord;
                                    nextTarget = FindCorrectCoord(nextTarget) + 1551;
                                }
                            }
                            //Debug
                            if (nextTarget / 1000 == 0)
                            {
                                nextTarget = FindCorrectCoord(nextTarget) + 1551;
                            }
                            //Debug
                            TargetButtonTag = nextTarget;
                            EnemyShoot(nextTarget, out successShoot, out checkedPosition);
                            PossibleTargets = DeleteForbiddenCoords(PossibleTargets);
                            int usedTarget = nextTarget;
                            if (nextTarget / 1000 != 0)
                            {
                                usedTarget = FindCorrectIndex(nextTarget);
                            }
                            if (!successShoot)
                            {
                                PossibleTargets.Remove(usedTarget);
                                ForbiddenCoords.Add(usedTarget);
                                DefinedShot = true;
                            }
                            else
                            {
                                int firstHitIndex = -1;
                                if (FirstSuccessHitCoord != 0)
                                {
                                    firstHitIndex = FindCorrectIndex(FirstSuccessHitCoord + 1551);
                                }
                                firstHitIndex = FindCorrectIndex(newFoundTarget);
                                List<int>[] listes = BannForbiddenCoords(usedTarget, firstHitIndex, PossibleTargets, ForbiddenCoords);
                                PossibleTargets = listes[0];
                                ForbiddenCoords = listes[1];
                                PossibleTargets.Remove(usedTarget);
                                ForbiddenCoords.Add(usedTarget);
                                switch (PossibleTargets.Count)
                                {
                                    case 0:
                                        {
                                            int firstCount = PossibleTargets.Count;
                                            PossibleTargets = UpdatePossibleTargets(FirstSuccessHitCoord, SecondSuccessHitCoord);
                                            int secondCount = PossibleTargets.Count;
                                            if (firstCount == secondCount)
                                            {
                                                DefinedShot = false;
                                            }
                                            break;
                                        }
                                    case 1:
                                        {
                                            DefinedShot = true;
                                            DefinedCoord = PossibleTargets[0];
                                            break;
                                        }
                                }
                            }
                            ForbiddenCoords.Sort();
                            PossibleTargets.Sort();
                        }
                    }
                    while (checkedPosition);
                }
            }
        }
        private static List<int>[] BannForbiddenCoords(int nextTarget, int firstHit, List<int> allowedList, List<int> forbiddenList)
        {
            int delta = Math.Abs(nextTarget - firstHit);
            for (int m = 0; m < allowedList.Count; m++)
            {
                if (Math.Abs(allowedList[m] - firstHit) != delta)
                {
                    forbiddenList.Add(m);
                    allowedList.Remove(m);
                }
            }
            List<int>[] listArray = {allowedList, forbiddenList};
            DeleteForbiddenCoords(allowedList);
            return listArray;
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
        static void SetRoundMines(int shipType)
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
                                mineTags[m] = FindCorrectIndex(mineTags[m] + 1551); 
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
        private static List<int> DeleteForbiddenCoords(List<int> inputList)
        {
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
        private static List<int> UpdatePossibleTargets(int firstHitCoord, int secondHitCoord)
        {
            List<int> newTargetsList = new List<int>();
            firstHitCoord = FindCorrectIndex(firstHitCoord + 1551);
            secondHitCoord = FindCorrectIndex(secondHitCoord + 1551);
            int thirdHitCoord = FindCorrectIndex(ThirdSuccssHitCoord);
            int delta = 0;
            if (thirdHitCoord != 0)
            {
                delta = secondHitCoord - thirdHitCoord;
                newTargetsList.Add(thirdHitCoord + delta);
                ForbiddenCoords.Sort();
                newTargetsList.Sort();
                HashSet<int> forbidden = new HashSet<int>(ForbiddenCoords);
                HashSet<int> possible = new HashSet<int>(newTargetsList);
                var intersection = possible.Where(x => forbidden.Contains(x)).ToList();
                foreach (var item in intersection)
                {
                    possible.Remove(item);
                }
                newTargetsList = new List<int>(possible);
            }
            else
            {
                delta = firstHitCoord - secondHitCoord;
                string secondCellTag = null;
                int cyclesCount = 0;
                try
                {
                    secondCellTag = FindCorrectCoord(secondHitCoord).ToString();
                }
                catch
                {
                    secondCellTag = null;
                }
                if (secondCellTag != null)
                {
                    bool correctTargets = false;
                    do
                    {
                        cyclesCount++;
                        newTargetsList.Clear();
                        switch (pos.GetCellPosition(secondCellTag))
                        {
                            case "top":
                                {
                                    if (Math.Abs(delta) == 1)
                                    {
                                        newTargetsList.Add(secondHitCoord + (-delta));
                                        newTargetsList.Add(secondHitCoord + (-delta * 2));
                                    }
                                    else
                                    {
                                        newTargetsList.Add(firstHitCoord + Math.Abs(delta));
                                        newTargetsList.Add(firstHitCoord + Math.Abs(delta * 2));
                                    }
                                    break;
                                }
                            case "bottom":
                                {
                                    if (Math.Abs(delta) == 1)
                                    {
                                        newTargetsList.Add(secondHitCoord + (-delta));
                                        newTargetsList.Add(secondHitCoord + (-delta * 2));
                                    }
                                    else
                                    {
                                        newTargetsList.Add(firstHitCoord - Math.Abs(delta));
                                        newTargetsList.Add(firstHitCoord - Math.Abs(delta * 2));
                                    }
                                    break;
                                }
                            case "left":
                                {
                                    if (Math.Abs(delta) == 10)
                                    {
                                        newTargetsList.Add(secondHitCoord + (-delta));
                                        newTargetsList.Add(secondHitCoord + (-delta * 2));
                                    }
                                    else
                                    {
                                        newTargetsList.Add(firstHitCoord + Math.Abs(delta));
                                        newTargetsList.Add(firstHitCoord + Math.Abs(delta * 2));
                                    }
                                    break;
                                }
                            case "right":
                                {
                                    if (Math.Abs(delta) == 10)
                                    {
                                        newTargetsList.Add(secondHitCoord + (-delta));
                                        newTargetsList.Add(secondHitCoord + (-delta * 2));
                                    }
                                    else
                                    {
                                        newTargetsList.Add(firstHitCoord - Math.Abs(delta));
                                        newTargetsList.Add(firstHitCoord - Math.Abs(delta * 2));
                                    }
                                    break;
                                }
                            case "center":
                                {
                                    newTargetsList.Add(secondHitCoord + (-delta));
                                    newTargetsList.Add(secondHitCoord + (-delta * 2));
                                    if ((newTargetsList[1] % 10) > newTargetsList[0] % 10)
                                    {
                                        newTargetsList.RemoveAt(1);
                                    }
                                    break;
                                }
                            case "corner1":
                                {
                                    newTargetsList.Add(firstHitCoord + Math.Abs(delta));
                                    newTargetsList.Add(firstHitCoord + Math.Abs(delta * 2));
                                    break;
                                }
                            case "corner2":
                                {
                                    if (Math.Abs(delta) == 1)
                                    {
                                        newTargetsList.Add(firstHitCoord - Math.Abs(delta));
                                        newTargetsList.Add(firstHitCoord - Math.Abs(delta * 2));
                                    }
                                    else
                                    {
                                        newTargetsList.Add(firstHitCoord + Math.Abs(delta));
                                        newTargetsList.Add(firstHitCoord + Math.Abs(delta * 2));
                                    }
                                    break;
                                }
                            case "corner3":
                                {
                                    newTargetsList.Add(firstHitCoord - Math.Abs(delta));
                                    newTargetsList.Add(firstHitCoord - Math.Abs(delta * 2));
                                    break;
                                }
                            case "corner4":
                                {
                                    if (Math.Abs(delta) == 1)
                                    {
                                        newTargetsList.Add(firstHitCoord + Math.Abs(delta));
                                        newTargetsList.Add(firstHitCoord + Math.Abs(delta * 2));
                                    }
                                    else
                                    {
                                        newTargetsList.Add(firstHitCoord - Math.Abs(delta));
                                        newTargetsList.Add(firstHitCoord - Math.Abs(delta * 2));
                                    }
                                    break;
                                }
                        }
                        ForbiddenCoords.Sort();
                        newTargetsList.Sort();
                        HashSet<int> forbidden = new HashSet<int>(ForbiddenCoords);
                        HashSet<int> possible = new HashSet<int>(newTargetsList);
                        var intersection = possible.Where(x => forbidden.Contains(x)).ToList();
                        foreach (var item in intersection)
                        {
                            possible.Remove(item);
                        }
                        newTargetsList = new List<int>(possible);
                        if (newTargetsList.Count != 0)
                        {
                            correctTargets = true;
                            break;
                        }
                        else
                        {
                            correctTargets = false;
                            TargetsSwap(ref firstHitCoord, ref secondHitCoord);
                            continue;
                        }
                    }
                    while (!correctTargets || cyclesCount <= 2);
                }
                else
                {
                    newTargetsList = PossibleTargets;
                }
                if (newTargetsList.Count == 0)
                {
                    return PossibleTargets;
                }
            }
            return newTargetsList;
        }
        private static void TargetsSwap(ref int firstTarget, ref int secondTarget)
        {
            (firstTarget, secondTarget) = (secondTarget, firstTarget);
        }
        private static void NewShotPreparing()
        {
            FirstHitCoord = 0;
            FirstSuccessHitCoord = 0;
            SecondSuccessHitCoord = 0;
            ThirdSuccssHitCoord = 0;
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
                }
                else
                {
                    if (SecondSuccessHitCoord == 0)
                    {
                        SecondSuccessHitCoord = target;
                    }
                    else
                    {
                        if (ThirdSuccssHitCoord == 0)
                        {
                            ThirdSuccssHitCoord = target;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Incorrect success hit data", "Data Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static List<int> FindLastCoord()
        {
            int[] coords  = new int[3];
            List<int> coordsList = new List<int>();
            coords[0] = FindCorrectIndex(FirstSuccessHitCoord + 1551);
            coords[1] = FindCorrectIndex(SecondSuccessHitCoord + 1551);
            coords[2] = FindCorrectIndex(ThirdSuccssHitCoord + 1551);
            if (coords[2] - coords[1] != coords[1] - coords[0])
            {
                TargetsSwap(ref coords[0], ref coords[1]);
            }
            coordsList.Add(2 * coords[0] - coords[1]);
            coordsList.Add(coords[2] + coords[1]- coords[0]);
            return coordsList;
        }
        private static bool AllowedValue(int value, List<int> forbiddenValues)
        {
            forbiddenValues.Sort();
            if (value >= forbiddenValues.Count / 2)
            {
                forbiddenValues.Reverse();
                for (int f = forbiddenValues.Count - 1; f >= 0; f--)
                {
                    if (forbiddenValues[f] == value)
                    {
                        return false;
                    }
                    else
                    {
                        if (value < forbiddenValues[f])
                        {
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                return true;
            }
            else
            {
                for (int f = 0; f < forbiddenValues.Count; f++)
                {
                    if (forbiddenValues[f] == value)
                    {
                        return false;
                    }
                    else
                    {
                        if (value > forbiddenValues[f])
                        {
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                return true;
            }
        }
        private static List<int> UpdatePossibleCoords(int firstCoord, int secondCoord, int thirdCoord, List<int> inputList, bool clearList = true)
        {
            List<int> updatedCoords = new List<int>();
            string secondCellTag;
            int delta;
            bool[] validCoords = { false, false, false };
            if (clearList)
            {
                inputList.Clear();
            }
            if (firstCoord != 0)
            {
                firstCoord = FindCorrectIndex(firstCoord + 1551);
                validCoords[0] = true;
            }
            if (secondCoord != 0)
            {
                secondCoord = FindCorrectIndex(secondCoord + 1551);
                validCoords[1] = true;
            }
            if (thirdCoord != 0)
            {
                thirdCoord = FindCorrectIndex(thirdCoord + 1551);
                validCoords[2] = true;
            }
            if (validCoords[0] && validCoords[1])
            {
                delta = secondCoord - firstCoord;
                secondCellTag = FindCorrectCoord(secondCoord).ToString();
                if (pos.GetCellPosition(secondCellTag) != "center")
                {
                    updatedCoords.Add(firstCoord + delta);
                    updatedCoords.Add(firstCoord + (2 * delta));
                }
                else
                {
                    updatedCoords.Add(firstCoord + delta);
                    updatedCoords.Add(firstCoord + (2 * delta));
                    updatedCoords.Add(secondCoord - delta);
                    if (updatedCoords[updatedCoords.Count - 1] % 10 > updatedCoords[updatedCoords.Count - 2] % 10)
                    {
                        updatedCoords.RemoveAt(updatedCoords.Count - 1);
                    }
                    updatedCoords.Add(secondCoord - (2 * delta));
                    if (updatedCoords[updatedCoords.Count - 1] % 10 > updatedCoords[updatedCoords.Count - 2] % 10)
                    {
                        updatedCoords.RemoveAt(updatedCoords.Count - 1);
                    }
                }
                return updatedCoords;
            }
            else
            {
                return inputList;
            }
        }
        private static List<int> GenerateSecondPossibleCoords(List<int> nextCoords)
        {
            if (FirstSuccessHitCoord + SecondSuccessHitCoord != 0)
            {
                bool correctCoords = false;
                int[] hitCoords = new int[2];
                hitCoords[0] = FindCorrectIndex(FirstSuccessHitCoord + 1551);
                hitCoords[1] = FindCorrectIndex(SecondSuccessHitCoord + 1551);
                do
                {
                    int delta = hitCoords[0] - hitCoords[1];
                    if (hitCoords[0] > hitCoords[1])
                    {
                        delta = -delta;
                    }
                    nextCoords.Add(hitCoords[0] + delta);
                    nextCoords.Add(hitCoords[0] + (2 * delta));
                    if (nextCoords[1] % 10 > nextCoords[1] % 10)
                    {
                        nextCoords.Remove(nextCoords[1]);
                    }
                    HashSet<int> hitSet = new HashSet<int>(hitCoords);
                    HashSet<int> newSet = new HashSet<int>(nextCoords);
                    var hitsIntersection = newSet.Where(x => hitSet.Contains(x)).ToList();
                    foreach (var item in hitsIntersection)
                    {
                        correctCoords = false;
                        TargetsSwap(ref hitCoords[0], ref hitCoords[1]);
                    }
                    correctCoords = true;
                }
                while (!correctCoords);
                HashSet<int> forbidden = new HashSet<int>(ForbiddenCoords);
                HashSet<int> possible = new HashSet<int>(nextCoords);
                var forbiddenIntersection = possible.Where(x => forbidden.Contains(x)).ToList();
                foreach (var item in forbiddenIntersection)
                {
                    possible.Remove(item);
                }
                nextCoords = new List<int>(possible);
                return nextCoords;
            }
            else
            {
                return nextCoords;
            }

        }
    }
}
