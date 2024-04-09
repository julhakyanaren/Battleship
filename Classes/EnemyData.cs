using Battleship.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Battleship
{
    public static class EnemyData
    {
        public const int FrigatesCountMax = 4;
        public static int SunkenFrigatesCount = 0;
        public static int FrigatesCountCurrent;

        public const int DestroyersCountMax = 3;
        public static int HitedDestroyersCount = 0;
        public static int SunkenDestroyersCount = 0;
        public static int DestroyersCountCurrent;

        public const int CruiserCountMax = 2;
        public static int HitedCruisersCount = 0;
        public static int SunkenCruisersCount = 0;
        public static int CruiserCountCurrent;

        public const int BattleshipCountMax = 1;
        public static int HitedBattleshipCount = 0;
        public static int SunkenBattleshipCount = 0;
        public static int BattleshipCountCurrent;

        public static int HitCountCurrent = 0;
        public static int SunkenCountCurrent = 0;
        public static int MissedShotsCount = 0;
        public static int WhiteCellsCount = 0;

        public static int[] ShipsCount = { FrigatesCountCurrent, DestroyersCountCurrent, CruiserCountCurrent, BattleshipCountCurrent };
        
        public static int Score;

        public static char[] Map;

        public static int[,] FrigateCoords = new int[4, 1];
        public static int[,] DestroyerCoords = new int[3, 2];
        public static int[,] CruiserCoords = new int[2, 3];
        public static int[,] BattleshipCoords = new int[1, 4];
        public static int[][,] ShipsCoords = { FrigateCoords, DestroyerCoords, CruiserCoords, BattleshipCoords };

        public static bool[,] FrigatesHited = new bool[4, 1];
        public static bool[,] DestroyersHited = new bool[3, 2];
        public static bool[,] CruiserHited = new bool[2, 3];
        public static bool[,] BattleshipHited = new bool[1, 4];
        public static bool[][,] ShipsHited = { FrigatesHited, DestroyersHited, CruiserHited, BattleshipHited };

        public static bool[] FrigatesSunken = { FrigatesHited[0, 0] , FrigatesHited[1, 0], FrigatesHited[2, 0], FrigatesHited[3, 0] };
        public static bool[] DestroyersSunken = new bool[3];
        public static bool[] CruisersSunken = new bool[2];
        public static bool[] BattleshipSunken = new bool[1];
        public static bool[][] ShipsSunkenArray = {FrigatesSunken, DestroyersSunken, CruisersSunken, BattleshipSunken };

        public static List<int> BlockedCoords = new List<int>();
        public static List<int> AllowedCoords = new List<int>();

        public static Dictionary<int, double> IndependentChances = new Dictionary<int, double>();

        public static Button[] MapButtons = new Button[100];
        public static void DoesDestroyerSunken()
        {
            for (int d0 = 0; d0 < DestroyersHited.GetLength(0); d0++)
            {
                DestroyersSunken[d0] = true;
                for (int d1 = 0; d1 < DestroyersHited.GetLength(1); d1++)
                {
                    DestroyersSunken[d0] &= DestroyersHited[d0, d1];
                }
            }
        }
        public static void DoesCruiserSunken()
        {
            for (int c0 = 0; c0 < CruiserHited.GetLength(0); c0++)
            {
                CruisersSunken[c0] = true;
                for (int c1 = 0; c1 < CruiserHited.GetLength(1); c1++)
                {
                    CruisersSunken[c0] &= CruiserHited[c0, c1];
                }
            }
        }
        public static void DoesBattleshipSunken()
        {
            BattleshipSunken[0] = true;
            for (int b1 = 0; b1 < BattleshipHited.GetLength(1); b1++)
            {
                BattleshipSunken[0] &= BattleshipHited[0, b1];
            }
        }
        public static void ResetShipsCount()
        {
            FrigatesCountCurrent = 0;
            DestroyersCountCurrent = 0;
            CruiserCountCurrent = 0;
            BattleshipCountCurrent = 0;
        }
        public static void ResetDataToZero()
        {
            SunkenCountCurrent = 0;
            SunkenFrigatesCount = 0;
            SunkenDestroyersCount = 0;
            SunkenCruisersCount = 0;
            SunkenBattleshipCount = 0;
            HitCountCurrent = 0;
            HitedDestroyersCount = 0;
            HitedDestroyersCount = 0;
            HitedDestroyersCount = 0;
            MissedShotsCount = 0;
        }
        public static void AddIndependentChance()
        {
            if (!Options.GameOver)
            {
                double newChance = Math.Round((double)(20 - ShipData.HitedDeckCount) / (double)WhiteCellsCount, 5);
                IndependentChances.Add(IndependentChances.Count + 1, newChance);
            }
        }
    }
}
