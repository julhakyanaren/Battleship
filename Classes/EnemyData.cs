﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static int[] ShipsCount = { FrigatesCountCurrent, DestroyersCountCurrent, CruiserCountCurrent, BattleshipCountCurrent };
        
        public static int Score;

        public static char[] Map;

        public static int[,] FrigateCoords = new int[4, 1];
        public static int[,] DestroyerCoords = new int[3, 2];
        public static int[,] CruiserCoords = new int[2, 3];
        public static int[,] BattleshipCoords = new int[1, 4];
        public static int[][,] ShipsCoords = { FrigateCoords, DestroyerCoords, CruiserCoords, BattleshipCoords };

        public static void ResetShipsCount()
        {
            FrigatesCountCurrent = 0;
            DestroyersCountCurrent = 0;
            CruiserCountCurrent = 0;
            BattleshipCountCurrent = 0;
        }
        public static void ResetData()
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
    }
}