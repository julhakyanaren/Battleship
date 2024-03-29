using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
