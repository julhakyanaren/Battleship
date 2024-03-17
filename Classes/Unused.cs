using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Classes
{
    internal class Unused
    {
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
    }
}
