using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public static class EnemyData
    {
        public const int FirgatesCountMax = 4;
        public static int FrigatesCountCurrent;

        public const int DestroyersCountMax = 3;
        public static int DestroyersCountCurrent;

        public const int CruiserCountMax = 2;
        public static int CruiserCountCurrent;

        public const int BattleshipCountMax = 1;
        public static int BattleshipCountCurrent;

        public static int HitCountCurrent;
        public static int SunkenCountCurrent;

        public static int[] ShipsCount = { FrigatesCountCurrent, DestroyersCountCurrent, CruiserCountCurrent, BattleshipCountCurrent };
        
        public static int Score;

        public static char[] Map;

        public static void ResetShipsCount()
        {
            FrigatesCountCurrent = 0;
            DestroyersCountCurrent = 0;
            CruiserCountCurrent = 0;
            BattleshipCountCurrent = 0;
        }
    }
}
