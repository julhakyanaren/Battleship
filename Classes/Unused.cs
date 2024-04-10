using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Classes
{
    internal class Unused
    {
        //UNUSED 1

        //public static void Shoot(out bool successShoot)
        //{
        //    bool checkedPosition = false;
        //    do
        //    {
        //        successShoot = true;
        //        int target = FindShipCoord(false);
        //        if (NewMove)
        //        {
        //            EnemyShoot(target, out successShoot, out checkedPosition);
        //        }
        //        else
        //        {
        //            if (FirstHitCoord != 0)
        //            {
        //                int newIndex = FirstHitCoord + 1551;
        //                GenerateNearestCoords(newIndex, 1551);
        //                Random randomShoot = new Random();
        //                int nextTarget = randomShoot.Next(1, AllowedCoords.Count + 1);
        //                nextTarget--;
        //                bool allow = true;
        //                for (int s = 0; s < AllowedChars.Length; s++)
        //                {
        //                    allow &= AllowedCoords[nextTarget] - 1551 != AllowedChars[s];
        //                }
        //                if (allow)
        //                {
        //                    EnemyShoot(AllowedCoords[nextTarget], out successShoot, out checkedPosition);
        //                }
        //            }
        //        }
        //    }
        //    while (checkedPosition);
        //}

        //UNUSED 2

        //for (int t = 0; t < ForbiddenCoords.Count; t++)
        //{
        //    if (targetIndex != ForbiddenCoords[t])
        //    {
        //        correctCoord = true;
        //        if (target < ForbiddenCoords[t])
        //        {
        //            correctCoord = false;
        //            break;
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }
        //    else
        //    {
        //        correctCoord = false;
        //        break;
        //    }
        //}

        //UNUSED 3

        //for (int f = 0; f < ForbiddenCoords.Count; f++)
        //{
        //    if (nextTarget != ForbiddenCoords[f])
        //    {
        //        canShot = true;
        //        if (nextTarget < ForbiddenCoords[f])
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }
        //    else
        //    {
        //        canShot = false;
        //        break;
        //    }
        //}

        // UNUSED 5

        //for (int f = 0; f < ForbiddenCoords.Count; f++)
        //{
        //    if (nextTarget != ForbiddenCoords[f])
        //    {
        //        canShot = true;
        //        if (nextTarget < ForbiddenCoords[f])
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }
        //    else
        //    {
        //        canShot = false;
        //        allowedCoords.Remove(nextTarget);
        //        AllowedCoords.Remove(nextTarget);
        //        allowedCoords.Sort();
        //        break;
        //    }
        //}

        //UNUSED 6

        //public static void Shoot_Advanced(out bool successShoot)
        //{
        //    successShoot = true;
        //    bool checkedPosition = false;
        //    if (GuaranteedShot)
        //    {

        //    }
        //    else if (TargetingShoot) //Coment: Еслы первый выстрел был успешным
        //    {
        //        bool canShot = false;
        //        int possibleTarget;
        //        do
        //        {
        //            if (PossibleTargets.Count == 0)
        //            {
        //                GenerateNearestCoords(FirstHitCoord + 1551, 1551);
        //                PossibleTargets = AllowedCoords;
        //            }
        //            Random random = new Random();
        //            int randomIndex = random.Next(0, PossibleTargets.Count);
        //            possibleTarget = PossibleTargets[randomIndex];
        //            if (AllowedValue(possibleTarget, ForbiddenCoords))
        //            {
        //                canShot = true;
        //            }
        //            else
        //            {
        //                PossibleTargets.Remove(possibleTarget);
        //            }
        //        }
        //        while (!canShot);
        //        TargetButtonTag = possibleTarget;
        //        EnemyShoot(possibleTarget, out successShoot, out checkedPosition);
        //        ForbiddenCoords.Add(FindCorrectIndex(possibleTarget));
        //        switch (successShoot)
        //        {
        //            case true:
        //                {
        //                    PossibleTargets = UpdatePossibleCoords(FirstSuccessHitCoord, SecondSuccessHitCoord, ThirdSuccssHitCoord, PossibleTargets, true);
        //                    DeleteForbiddenCoords(PossibleTargets);
        //                    break;
        //                }
        //            case false:
        //                {
        //                    break;
        //                }
        //        }
        //        PossibleTargets.Remove(possibleTarget);
        //        ForbiddenCoords.Add(possibleTarget);
        //    }
        //    else if (NewMove) //Comment: Новый ход 
        //    {
        //        int newTarget;
        //        if (ForbiddenCoords.Count != 0)
        //        {
        //            ForbiddenCoords.Sort();
        //            do
        //            {
        //                bool correctCoord = false;
        //                do
        //                {
        //                    newTarget = FindShipCoord(false);
        //                    if (AllowedValue(newTarget, ForbiddenCoords))
        //                    {
        //                        correctCoord = true;
        //                    }
        //                    else
        //                    {
        //                        continue;
        //                    }
        //                }
        //                while (!correctCoord);
        //                TargetButtonTag = newTarget;
        //                EnemyShoot(newTarget, out successShoot, out checkedPosition);
        //                ForbiddenCoords.Add(FindCorrectIndex(newTarget));
        //            }
        //            while (checkedPosition);
        //        }
        //        else
        //        {
        //            newTarget = FindShipCoord(false);
        //            EnemyShoot(newTarget, out successShoot, out checkedPosition);
        //            ForbiddenCoords.Add(FindCorrectIndex(newTarget));
        //        }
        //    }
        //    ForbiddenCoords = SortUniqueInt(ForbiddenCoords);
        //}

        //UNUSED 7

        //private static List<int> UpdatePossibleCoords(int firstCoord, int secondCoord, int thirdCoord, List<int> inputList, bool clearList = true)
        //{
        //    List<int> updatedCoords = new List<int>();
        //    string secondCellTag;
        //    int delta;
        //    bool[] validCoords = { false, false, false };
        //    if (clearList)
        //    {
        //        inputList.Clear();
        //    }
        //    if (firstCoord != 0)
        //    {
        //        firstCoord = FindCorrectIndex(firstCoord + 1551);
        //        validCoords[0] = true;
        //    }
        //    if (secondCoord != 0)
        //    {
        //        secondCoord = FindCorrectIndex(secondCoord + 1551);
        //        validCoords[1] = true;
        //    }
        //    if (thirdCoord != 0)
        //    {
        //        thirdCoord = FindCorrectIndex(thirdCoord + 1551);
        //        validCoords[2] = true;
        //    }
        //    if (validCoords[0] && validCoords[1])
        //    {
        //        delta = secondCoord - firstCoord;
        //        secondCellTag = FindCorrectCoord(secondCoord).ToString();
        //        if (pos.GetCellPosition(secondCellTag) != "center")
        //        {
        //            updatedCoords.Add(firstCoord + delta);
        //            updatedCoords.Add(firstCoord + (2 * delta));
        //        }
        //        else
        //        {
        //            updatedCoords.Add(firstCoord + delta);
        //            updatedCoords.Add(firstCoord + (2 * delta));
        //            updatedCoords.Add(secondCoord - delta);
        //            if (updatedCoords[updatedCoords.Count - 1] % 10 > updatedCoords[updatedCoords.Count - 2] % 10)
        //            {
        //                updatedCoords.RemoveAt(updatedCoords.Count - 1);
        //            }
        //            updatedCoords.Add(secondCoord - (2 * delta));
        //            if (updatedCoords[updatedCoords.Count - 1] % 10 > updatedCoords[updatedCoords.Count - 2] % 10)
        //            {
        //                updatedCoords.RemoveAt(updatedCoords.Count - 1);
        //            }
        //        }
        //        return updatedCoords;
        //    }
        //    else
        //    {
        //        return inputList;
        //    }
        //}

        //UNUSED 8

        //private static bool AllowedValue(int value, List<int> forbiddenValues)
        //{
        //    forbiddenValues.Sort();
        //    if (value >= forbiddenValues.Count / 2)
        //    {
        //        forbiddenValues.Reverse();
        //        for (int f = forbiddenValues.Count - 1; f >= 0; f--)
        //        {
        //            if (forbiddenValues[f] == value)
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                if (value < forbiddenValues[f])
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //            }
        //        }
        //        return true;
        //    }
        //    else
        //    {
        //        for (int f = 0; f < forbiddenValues.Count; f++)
        //        {
        //            if (forbiddenValues[f] == value)
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                if (value > forbiddenValues[f])
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //            }
        //        }
        //        return true;
        //    }
        //}

        // UNUSED 9

        //for (int l = 0; l < firstCoords.Count; l++)
        //{
        //    string tag = mapButton[firstCoords[l]].Tag.ToString();
        //    if (sp.StringToInt(tag, out int tagButton))
        //    {
        //        string cellPos = pos.GetCellPosition(tag);
        //        pos.GetCoordsFromTag(tag, out int x, out int y, out int playerID);
        //        try
        //        {
        //            int mineTagsSize = ShipData.GetMineCount(cellPos, ShipData.ChoosenShipType, x, y, ShipData.Orientation);
        //            if (mineTagsSize != -1)
        //            {
        //                int[] mineTags = new int[mineTagsSize];
        //                mineTags = ShipData.MineTagsFill(mineTags, cellPos, ShipData.ChoosenShipType, tagButton, ShipData.Orientation);
        //                foreach (Button mineButton in mapButton)
        //                {
        //                    for (int b = 0; b < mineTags.Length; b++)
        //                    {
        //                        if (mineButton.Tag.ToString() == mineTags[b].ToString())
        //                        {
        //                            int buttonIndex = Array.IndexOf(mapButton, mineButton);
        //                            mapButton[buttonIndex].BackColor = Color.Aqua;
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            //Error_Catch
        //        }
        //    }
        //}

        // UNUSED 10

        //public static void Shoot(out bool successShoot)
        //{
        //    int newFoundTarget = -1;
        //    bool checkedPosition = false;
        //    successShoot = true;
        //    if (GuaranteedShot)
        //    {
        //        TargetButtonTag = DefinedCoord;
        //        EnemyShoot(DefinedCoord, out successShoot, out checkedPosition);
        //        GuaranteedShot = !successShoot;
        //    }
        //    else
        //    {
        //        if (ThirdSuccssHitCoord != 0)
        //        {
        //            List<int> lastcoords = FindLastCoord();
        //            DeleteForbiddenCoords(lastcoords);
        //            PossibleTargets.Clear();
        //            PossibleTargets = DeleteForbiddenCoords(lastcoords);
        //            if (PossibleTargets.Count != 0)
        //            {
        //                Random randLastCoord = new Random();
        //                int randomItem = randLastCoord.Next(0, PossibleTargets.Count);
        //                int lastTarget = PossibleTargets[randomItem];
        //                lastTarget = FindCorrectCoord(lastTarget) + 1551;
        //                TargetButtonTag = lastTarget;
        //                EnemyShoot(lastTarget, out successShoot, out checkedPosition);
        //                try
        //                {
        //                    if (!successShoot)
        //                    {
        //                        PossibleTargets.Remove(FindCorrectIndex(lastTarget, codeIndex: "Fight 405"));
        //                        DefinedCoord = FindCorrectCoord(PossibleTargets[0]) + 1551;
        //                        GuaranteedShot = true;
        //                    }
        //                    else
        //                    {
        //                        GuaranteedShot = false;
        //                    }
        //                }
        //                catch (Exception ex)
        //                {

        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Incorrect hit data", "Data Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            do
        //            {
        //                if (DefinedShot)
        //                {
        //                    NewMove = false;
        //                }
        //                if (NewMove)
        //                {
        //                    bool correctCoord = false;
        //                    int target = -1;
        //                    do
        //                    {
        //                        if (ForbiddenCoords.Count != 0)
        //                        {
        //                            ForbiddenCoords.Sort();
        //                            target = FindShipCoord(false);
        //                            int targetIndex = FindCorrectIndex(target, codeIndex: "Fight 442");
        //                            //Unused 2
        //                            correctCoord = !ForbiddenCoords.Contains(targetIndex);
        //                        }
        //                        else
        //                        {
        //                            target = FindShipCoord(false);
        //                            correctCoord = true;
        //                        }
        //                    }
        //                    while (!correctCoord);
        //                    newFoundTarget = target;
        //                    TargetButtonTag = target;
        //                    EnemyShoot(target, out successShoot, out checkedPosition);
        //                }
        //                else if (FirstHitCoord != 0 || DefinedShot)
        //                {
        //                    bool canShot = false;
        //                    int nextTarget = -1;
        //                    int newIndex = -1;
        //                    newIndex = FirstHitCoord + 1551;
        //                    if (!DefinedShot)
        //                    {
        //                        GenerateNearestCoords(newIndex, 1551);
        //                        List<int> allowedCoords = AllowedCoords;
        //                        do
        //                        {
        //                            if (allowedCoords.Count > 0)
        //                            {
        //                                ForbiddenCoords.Sort();
        //                                Random randomShoot = new Random();
        //                                int randomIndex = randomShoot.Next(0, AllowedCoords.Count);
        //                                nextTarget = allowedCoords[randomIndex];
        //                                //Unused 4
        //                                if (ForbiddenCoords.Contains(nextTarget))
        //                                {
        //                                    canShot = false;
        //                                    allowedCoords.Remove(nextTarget);
        //                                    AllowedCoords.Remove(nextTarget);
        //                                    allowedCoords.Sort();
        //                                }
        //                                else
        //                                {
        //                                    canShot = true;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                GenerateSecondPossibleCoords(PossibleTargets);
        //                                PossibleTargets = SortUniqueInt(PossibleTargets);
        //                                allowedCoords = PossibleTargets;
        //                                continue;
        //                            }
        //                        }
        //                        while (!canShot);
        //                        nextTarget = FindCorrectCoord(nextTarget) + 1551;
        //                        PossibleTargets = AllowedCoords;
        //                    }
        //                    if (DefinedShot)
        //                    {
        //                        if (PossibleTargets.Count != 1)
        //                        {
        //                            int counter = -1;
        //                            do
        //                            {
        //                                counter++;
        //                                ForbiddenCoords.Sort();
        //                                PossibleTargets.Sort();
        //                                if (PossibleTargets.Count == 2 && (Math.Abs(PossibleTargets[0] - PossibleTargets[1]) == 10 || Math.Abs(PossibleTargets[0] - PossibleTargets[1]) == 1))
        //                                {
        //                                    if (PossibleTargets.Count >= counter + 1)
        //                                    {
        //                                        nextTarget = PossibleTargets[counter];
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    if (PossibleTargets.Count > 0)
        //                                    {
        //                                        Random randomPT = new Random();
        //                                        int randomIndexPT = randomPT.Next(0, PossibleTargets.Count);
        //                                        nextTarget = PossibleTargets[randomIndexPT];
        //                                    }
        //                                    else
        //                                    {
        //                                        GenerateSecondPossibleCoords(PossibleTargets);
        //                                        if (PossibleTargets.Count == 0)
        //                                        {
        //                                            NewMove = true;
        //                                        }
        //                                        else
        //                                        {
        //                                            Random randomPT = new Random();
        //                                            int randomIndexPT = randomPT.Next(0, PossibleTargets.Count);
        //                                            nextTarget = PossibleTargets[randomIndexPT];
        //                                            break;
        //                                        }
        //                                    }
        //                                }
        //                                canShot = !ForbiddenCoords.Contains(nextTarget);
        //                                //Unused 3
        //                            }
        //                            while (!canShot);
        //                        }
        //                        else
        //                        {
        //                            DefinedCoord = PossibleTargets[0];
        //                            nextTarget = DefinedCoord;
        //                            nextTarget = FindCorrectCoord(nextTarget) + 1551;
        //                        }
        //                    }
        //                    if (nextTarget / 1000 == 0)
        //                    {
        //                        nextTarget = FindCorrectCoord(nextTarget) + 1551;
        //                    }
        //                    TargetButtonTag = nextTarget;
        //                    EnemyShoot(nextTarget, out successShoot, out checkedPosition);
        //                    PossibleTargets = DeleteForbiddenCoords(PossibleTargets); //Check Method
        //                    int usedTarget = nextTarget;
        //                    if (nextTarget / 1000 != 0)
        //                    {
        //                        usedTarget = FindCorrectIndex(nextTarget, codeIndex: "Fight 565");
        //                    }
        //                    if (!successShoot)
        //                    {
        //                        PossibleTargets.Remove(usedTarget);
        //                        ForbiddenCoords.Add(usedTarget);
        //                        DefinedShot = true;
        //                    }
        //                    else
        //                    {
        //                        int firstHitIndex = -1;
        //                        if (FirstSuccessHitCoord != 0)
        //                        {
        //                            firstHitIndex = FindCorrectIndex(FirstSuccessHitCoord + 1551, codeIndex: "Fight 578");
        //                        }
        //                        firstHitIndex = FindCorrectIndex(newFoundTarget, codeIndex: "Fight 580");
        //                        List<int>[] listes = BannForbiddenCoords(usedTarget, firstHitIndex, PossibleTargets, ForbiddenCoords);
        //                        PossibleTargets = listes[0];
        //                        ForbiddenCoords = listes[1];
        //                        PossibleTargets.Remove(usedTarget);
        //                        ForbiddenCoords.Add(usedTarget);
        //                        switch (PossibleTargets.Count)
        //                        {
        //                            case 0:
        //                                {
        //                                    int firstCount = PossibleTargets.Count;
        //                                    PossibleTargets = UpdatePossibleTargets(FirstSuccessHitCoord, SecondSuccessHitCoord);
        //                                    int secondCount = PossibleTargets.Count;
        //                                    if (firstCount == secondCount)
        //                                    {
        //                                        DefinedShot = false;
        //                                    }
        //                                    break;
        //                                }
        //                            case 1:
        //                                {
        //                                    DefinedShot = true;
        //                                    DefinedCoord = PossibleTargets[0];
        //                                    break;
        //                                }
        //                        }
        //                    }
        //                    ForbiddenCoords.Sort();
        //                    PossibleTargets.Sort();
        //                }
        //            }
        //            while (checkedPosition);
        //        }
        //    }
        //}

        // UNUSED 11

        //private static List<int>[] BannForbiddenCoords(int nextTarget, int firstHit, List<int> allowedList, List<int> forbiddenList)
        //{
        //    int delta = Math.Abs(nextTarget - firstHit);
        //    for (int m = 0; m < allowedList.Count; m++)
        //    {
        //        if (Math.Abs(allowedList[m] - firstHit) != delta)
        //        {
        //            forbiddenList.Add(m);
        //            allowedList.Remove(m);
        //        }
        //    }
        //    List<int>[] listArray = {allowedList, forbiddenList};
        //    DeleteForbiddenCoords(allowedList);
        //    return listArray;
        //}

        //UNUSED 12

        //private static List<int> UpdatePossibleTargets(int firstHitCoord, int secondHitCoord)
        //{
        //    List<int> newTargetsList = new List<int>();
        //    firstHitCoord = FindCorrectIndex(firstHitCoord + 1551, codeIndex: "Fight 769");
        //    secondHitCoord = FindCorrectIndex(secondHitCoord + 1551, codeIndex: "Fight 770");
        //    int thirdHitCoord = FindCorrectIndex(ThirdSuccssHitCoord, codeIndex: "Fight 771");
        //    int delta = 0;
        //    if (ThirdSuccssHitCoord != 0)
        //    {
        //        delta = secondHitCoord - thirdHitCoord;
        //        newTargetsList.Add(thirdHitCoord + delta);
        //        ForbiddenCoords.Sort();
        //        newTargetsList.Sort();
        //        HashSet<int> forbidden = new HashSet<int>(ForbiddenCoords);
        //        HashSet<int> possible = new HashSet<int>(newTargetsList);
        //        var intersection = possible.Where(x => forbidden.Contains(x)).ToList();
        //        foreach (var item in intersection)
        //        {
        //            possible.Remove(item);
        //        }
        //        newTargetsList = new List<int>(possible);
        //    }
        //    else
        //    {
        //        delta = firstHitCoord - secondHitCoord;
        //        string secondCellTag = null;
        //        int cyclesCount = 0;
        //        try
        //        {
        //            secondCellTag = FindCorrectCoord(secondHitCoord).ToString();
        //        }
        //        catch
        //        {
        //            secondCellTag = null;
        //        }
        //        if (secondCellTag != null)
        //        {
        //            bool correctTargets = false;
        //            do
        //            {
        //                cyclesCount++;
        //                newTargetsList.Clear();
        //                switch (pos.GetCellPosition(secondCellTag))
        //                {
        //                    case "top":
        //                        {
        //                            if (Math.Abs(delta) == 1)
        //                            {
        //                                newTargetsList.Add(secondHitCoord + (-delta));
        //                                newTargetsList.Add(secondHitCoord + (-delta * 2));
        //                            }
        //                            else
        //                            {
        //                                newTargetsList.Add(firstHitCoord + Math.Abs(delta));
        //                                newTargetsList.Add(firstHitCoord + Math.Abs(delta * 2));
        //                            }
        //                            break;
        //                        }
        //                    case "bottom":
        //                        {
        //                            if (Math.Abs(delta) == 1)
        //                            {
        //                                newTargetsList.Add(secondHitCoord + (-delta));
        //                                newTargetsList.Add(secondHitCoord + (-delta * 2));
        //                            }
        //                            else
        //                            {
        //                                newTargetsList.Add(firstHitCoord - Math.Abs(delta));
        //                                newTargetsList.Add(firstHitCoord - Math.Abs(delta * 2));
        //                            }
        //                            break;
        //                        }
        //                    case "left":
        //                        {
        //                            if (Math.Abs(delta) == 10)
        //                            {
        //                                newTargetsList.Add(secondHitCoord + (-delta));
        //                                newTargetsList.Add(secondHitCoord + (-delta * 2));
        //                            }
        //                            else
        //                            {
        //                                newTargetsList.Add(firstHitCoord + delta);
        //                                newTargetsList.Add(firstHitCoord + (delta * 2));
        //                            }
        //                            break;
        //                        }
        //                    case "right":
        //                        {
        //                            if (Math.Abs(delta) == 10)
        //                            {
        //                                newTargetsList.Add(secondHitCoord + (-delta));
        //                                newTargetsList.Add(secondHitCoord + (-delta * 2));
        //                            }
        //                            else
        //                            {
        //                                newTargetsList.Add(firstHitCoord - Math.Abs(delta));
        //                                newTargetsList.Add(firstHitCoord - Math.Abs(delta * 2));
        //                            }
        //                            break;
        //                        }
        //                    case "center":
        //                        {
        //                            newTargetsList.Add(secondHitCoord + (-delta));
        //                            newTargetsList.Add(secondHitCoord + (-delta * 2));
        //                            if ((newTargetsList[1] % 10) > newTargetsList[0] % 10)
        //                            {
        //                                newTargetsList.RemoveAt(1);
        //                            }
        //                            break;
        //                        }
        //                    case "corner1":
        //                        {
        //                            newTargetsList.Add(firstHitCoord + Math.Abs(delta));
        //                            newTargetsList.Add(firstHitCoord + Math.Abs(delta * 2));
        //                            break;
        //                        }
        //                    case "corner2":
        //                        {
        //                            if (Math.Abs(delta) == 1)
        //                            {
        //                                newTargetsList.Add(firstHitCoord - Math.Abs(delta));
        //                                newTargetsList.Add(firstHitCoord - Math.Abs(delta * 2));
        //                            }
        //                            else
        //                            {
        //                                newTargetsList.Add(firstHitCoord + Math.Abs(delta));
        //                                newTargetsList.Add(firstHitCoord + Math.Abs(delta * 2));
        //                            }
        //                            break;
        //                        }
        //                    case "corner3":
        //                        {
        //                            newTargetsList.Add(firstHitCoord - Math.Abs(delta));
        //                            newTargetsList.Add(firstHitCoord - Math.Abs(delta * 2));
        //                            break;
        //                        }
        //                    case "corner4":
        //                        {
        //                            if (Math.Abs(delta) == 1)
        //                            {
        //                                newTargetsList.Add(firstHitCoord + Math.Abs(delta));
        //                                newTargetsList.Add(firstHitCoord + Math.Abs(delta * 2));
        //                            }
        //                            else
        //                            {
        //                                newTargetsList.Add(firstHitCoord - Math.Abs(delta));
        //                                newTargetsList.Add(firstHitCoord - Math.Abs(delta * 2));
        //                            }
        //                            break;
        //                        }
        //                }
        //                ForbiddenCoords.Sort();
        //                newTargetsList.Sort();
        //                HashSet<int> forbidden = new HashSet<int>(ForbiddenCoords);
        //                HashSet<int> possible = new HashSet<int>(newTargetsList);
        //                var intersection = possible.Where(x => forbidden.Contains(x)).ToList();
        //                foreach (var item in intersection)
        //                {
        //                    possible.Remove(item);
        //                }
        //                newTargetsList = new List<int>(possible);
        //                if (newTargetsList.Count != 0)
        //                {
        //                    correctTargets = true;
        //                    break;
        //                }
        //                else
        //                {
        //                    correctTargets = false;
        //                    TargetsSwap(ref firstHitCoord, ref secondHitCoord);
        //                    continue;
        //                }
        //            }
        //            while (!correctTargets || cyclesCount <= 2);
        //        }
        //        else
        //        {
        //            newTargetsList = PossibleTargets;
        //        }
        //        if (newTargetsList.Count == 0)
        //        {
        //            return PossibleTargets;
        //        }
        //    }
        //    return newTargetsList;
        //}

        //UNUSED 13

        //private static List<int> FindLastCoord()
        //{
        //    int[] coords  = new int[3];
        //    List<int> coordsList = new List<int>();
        //    coords[0] = FindCorrectIndex(FirstSuccessHitCoord + 1551, codeIndex: "Fight 999");
        //    coords[1] = FindCorrectIndex(SecondSuccessHitCoord + 1551, codeIndex: "Fight 1000");
        //    coords[2] = FindCorrectIndex(ThirdSuccssHitCoord + 1551, codeIndex: "Fight 1001");
        //    int max = coords.Max();
        //    int min = coords.Min();
        //    int absDelta = Math.Abs(FindCorrectIndex(FirstSuccessHitCoord + 1551, codeIndex: "Fight 1004-1") - FindCorrectIndex(SecondSuccessHitCoord + 1551, codeIndex: "Fight 1004-2"));
        //    if (Math.Abs(max - min) > (2 * absDelta))
        //    {
        //        coordsList.Add(min + absDelta);
        //        coordsList.Add(min - absDelta);
        //    }
        //    else
        //    {
        //        if (coords[2] - coords[1] != coords[1] - coords[0])
        //        {
        //            TargetsSwap(ref coords[0], ref coords[1]);
        //        }
        //        coordsList.Add(2 * coords[0] - coords[1]);
        //        coordsList.Add(coords[2] + coords[1] - coords[0]);
        //    }
        //    return coordsList;
        //}

        //UNUSED 14

        //private static List<int> GenerateSecondPossibleCoords(List<int> nextCoords)
        //{
        //    if (FirstSuccessHitCoord + SecondSuccessHitCoord != 0)
        //    {
        //        bool correctCoords = false;
        //        int[] hitCoords = new int[2];
        //        hitCoords[0] = FindCorrectIndex(FirstSuccessHitCoord + 1551, codeIndex: "Fight 1029");
        //        hitCoords[1] = FindCorrectIndex(SecondSuccessHitCoord + 1551, codeIndex: "Fight 1030");
        //        do
        //        {
        //            int delta = hitCoords[0] - hitCoords[1];
        //            nextCoords.Add(hitCoords[0] + delta);
        //            nextCoords.Add(hitCoords[0] + (2 * delta));
        //            if (nextCoords[1] % 10 > nextCoords[1] % 10)
        //            {
        //                nextCoords.Remove(nextCoords[1]);
        //            }
        //            HashSet<int> hitSet = new HashSet<int>(hitCoords);
        //            HashSet<int> newSet = new HashSet<int>(nextCoords);
        //            var hitsIntersection = newSet.Where(x => hitSet.Contains(x)).ToList();
        //            foreach (var item in hitsIntersection)
        //            {
        //                TargetsSwap(ref hitCoords[0], ref hitCoords[1]);
        //                correctCoords = false;
        //                nextCoords.Clear();
        //                continue;
        //            }
        //            if (nextCoords.Count != 0)
        //            {
        //                correctCoords = true;
        //            }
        //        }
        //        while (!correctCoords);
        //        HashSet<int> forbidden = new HashSet<int>(ForbiddenCoords);
        //        HashSet<int> possible = new HashSet<int>(nextCoords);
        //        var forbiddenIntersection = possible.Where(x => forbidden.Contains(x)).ToList();
        //        foreach (var item in forbiddenIntersection)
        //        {
        //            possible.Remove(item);
        //        }
        //        nextCoords = new List<int>(possible);
        //        return nextCoords;
        //    }
        //    else
        //    {
        //        return nextCoords;
        //    }
        //}

        //UNUSED 15

        //private static void TargetsSwap(ref int firstTarget, ref int secondTarget)
        //{
        //    (firstTarget, secondTarget) = (secondTarget, firstTarget);
        //}
    }
}
