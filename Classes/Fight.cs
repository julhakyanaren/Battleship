using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
            Button targetButton;
            int index = 0;
            int counter = 0;
            bool incorrectValue = false;
            bool targetInMap = true;
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
                        if (sunkenDestroyers - PlayerData.SunkenDestroyersCount == 1)
                        {
                            SetRoundMines(3);
                            PossibleTargets.Clear();
                        }
                        PlayerData.SunkenDestroyersCount = sunkenDestroyers;
                        PlayerData.DestroyersCountCurrent = PlayerData.DestroyersCountMax - PlayerData.SunkenDestroyersCount;
                        successShoot = true;
                        checkedPosition = false;
                        SetHitCoords(FindCorrectCoord(index));
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
                        if (sunkenCruisers - PlayerData.SunkenCruisersCount == 1)
                        {
                            SetRoundMines(2);
                            PossibleTargets.Clear();
                        }
                        PlayerData.SunkenCruisersCount = sunkenCruisers;
                        PlayerData.CruiserCountCurrent = PlayerData.CruiserCountMax - PlayerData.SunkenCruisersCount;
                        SetHitCoords(FindCorrectCoord(index));
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
                        if (sunkenBattleship == 1)
                        {
                            SetRoundMines(1);
                            PossibleTargets.Clear();
                        }
                        PlayerData.SunkenBattleshipCount = sunkenBattleship;
                        PlayerData.BattleshipCountCurrent = PlayerData.BattleshipCountMax - PlayerData.SunkenBattleshipCount;
                        SetHitCoords(FindCorrectCoord(index));
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
A:
                try
                {
                    if (target == 1660)
                    {
                        string f = "Frigate";
                    }
                    if (target / 1000 == 0)
                    {
                        target = FindCorrectCoord(target) + 1551;
                    }
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
                catch (Exception ex)
                {
                    DialogResult dr = MessageBox.Show($"Exception:\r\n{ex}\r\n\r\nMessage:\r\n{ex.Message}\r\n\r\nContinue?", "Exception Manager", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    switch (dr)
                    {
                        case DialogResult.Cancel:
                            {
                                ReverseTurn(false);
                                break;
                            }
                        case DialogResult.Abort:
                            {
                                ReverseTurn(true);
                                break;
                            }
                        default:
                            {
                                goto A;
                            }
                    }
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
            try
            {
                sp.StringToInt(PlayerData.MapButtons[index].Tag.ToString(), out int coord);
                return coord;
            }
            catch
            {
                return -1;
            }
        }
        public static void Shoot(out bool successShoot)
        {
            int newFoundTarget = -1;
            bool checkedPosition = false;
            do
            {
                if (DefinedShot)
                {
                    NewMove = false;
                }
                successShoot = true;
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
                    if (successShoot && FirstSuccessHitCoord == 0)
                    {
                        FirstSuccessHitCoord = target;
                    }
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
                                DefinedShot = true;
                                break;
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
                    if (successShoot && SecondSuccessHitCoord == 0 && DefinedShot)
                    {
                        SecondSuccessHitCoord = nextTarget;
                    }
                    if (successShoot && SecondSuccessHitCoord != 0 && DefinedShot)
                    {
                        ThirdSuccssHitCoord = nextTarget;
                    }
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
                            firstHitIndex = FindCorrectIndex(FirstSuccessHitCoord);
                        }
                        firstHitIndex = FindCorrectIndex(newFoundTarget);
                        List<int>[] listes = BannForbiddenCoords(usedTarget, firstHitIndex, PossibleTargets, ForbiddenCoords);
                        PossibleTargets = listes[0];
                        ForbiddenCoords = listes[1];
                        PossibleTargets.Remove(usedTarget);
                        ForbiddenCoords.Add(usedTarget);
                        switch(PossibleTargets.Count)
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
                            AllowedCoords.Add(firstCoords + 11);
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
                            NewShotPreparing();
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
            firstHitCoord = FindCorrectIndex(firstHitCoord);
            secondHitCoord = FindCorrectIndex(secondHitCoord);
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
        }
        private static void SetHitCoords(int currentCoord)
        {
            if (FirstSuccessHitCoord == 0)
            {
                FirstSuccessHitCoord = currentCoord;
            }
            else
            {
                if (SecondSuccessHitCoord == 0)
                {
                    SecondSuccessHitCoord = currentCoord;
                }
                else
                {
                    if (ThirdSuccssHitCoord == 0)
                    {
                        ThirdSuccssHitCoord = currentCoord;
                    }
                }
            }
        }
    }
}
