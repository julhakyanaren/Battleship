﻿using Octokit;
using Octokit.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public static class Options
    {
        public static bool SingleplayerMode = true;
        public static string SP_PlayerName = "Player";
        public static int Difficulty = 0;
        public static string GameMode = "Education";
        public static int GameModeInt = 0;
        public static string AppVersion;

        public static string[] Stages = { "InDev", "Alpha", "Beta", "Pre-Release", "Release", "Debug" };
        public static int V_Stage;
        public static string V_StageName;
        public static int V_Release = 0;
        public static int V_Assembly = 7;
        public static int V_Edition = 3;

        public static bool GameOver = false;
    }
}
