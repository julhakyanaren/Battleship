﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Classes
{
    public static class HitChanceData
    {
        static Position Position = new Position();

        public static Button SelectedCell = null;
        public static List<Button> CurrentMap = new List<Button>();

        public static double HitProbobility = 0.0f;

        public static double IndependentChance = 0;

        public static string[] RelativelyStrings = { "Forbidden", "Low", "Average", "High", "Guaranted" };        
        public static string[] IndependenStrings = { "Forbidden", "Very Low", "Low", "Average", "High", "Very High", "Guaranted" };
        public static Color[] RelativelyColors = { Color.Firebrick, Color.OrangeRed, Color.DarkOrange, Color.YellowGreen, Color.Lime };
        public static Color[] IndependentColors = { Color.Firebrick, Color.Red, Color.OrangeRed, Color.DarkOrange, Color.Yellow, Color.YellowGreen, Color.Lime };
      
        
        public static bool FormClosed = true;
        public static bool ExampleCraeted = false;
        public static bool CanOpenForm = false;
        public static bool CanResetMap = true;
        public static bool ManualMode = true;
        public static bool ShowNoveNumber = true;

        public static int DecimalPlacesCount = 1;

        public static List<int> AllowedCoords = new List<int>();
        public static List<int> BlockedCoords = new List<int>();
        public static List<int> PossibleIndexes = new List<int>();
        public static List<int> ForbiddenIndexes = new List<int>();

        public static List<float> HitChanceChanges = new List<float>();

        public static void GenerateNearestCoords(int firstCoord)
        {
            if (firstCoord != 0)
            {
                AllowedCoords.Clear();
                BlockedCoords.Clear();
                string position = Position.GetCellPosition(firstCoord.ToString());
                bool correctPos = true;
                switch (position)
                {
                    case "center":
                        {
                            AllowedCoords.Add(firstCoord - 1);
                            AllowedCoords.Add(firstCoord + 1);
                            AllowedCoords.Add(firstCoord - 10);
                            AllowedCoords.Add(firstCoord + 10);
                            BlockedCoords.Add(firstCoord - 11);
                            BlockedCoords.Add(firstCoord + 11);
                            BlockedCoords.Add(firstCoord - 9);
                            BlockedCoords.Add(firstCoord + 9);
                            break;
                        }
                    case "left":
                        {
                            AllowedCoords.Add(firstCoord - 1);
                            AllowedCoords.Add(firstCoord + 1);
                            AllowedCoords.Add(firstCoord + 10);
                            BlockedCoords.Add(firstCoord + 9);
                            BlockedCoords.Add(firstCoord + 11);
                            break;
                        }
                    case "right":
                        {
                            AllowedCoords.Add(firstCoord - 1);
                            AllowedCoords.Add(firstCoord + 1);
                            AllowedCoords.Add(firstCoord - 10);
                            BlockedCoords.Add(firstCoord - 11);
                            BlockedCoords.Add(firstCoord - 9);
                            break;
                        }
                    case "top":
                        {
                            AllowedCoords.Add(firstCoord - 10);
                            AllowedCoords.Add(firstCoord + 10);
                            AllowedCoords.Add(firstCoord + 1);
                            BlockedCoords.Add(firstCoord - 9);
                            BlockedCoords.Add(firstCoord + 11);
                            break;
                        }
                    case "bottom":
                        {
                            AllowedCoords.Add(firstCoord - 10);
                            AllowedCoords.Add(firstCoord + 10);
                            AllowedCoords.Add(firstCoord - 1);
                            BlockedCoords.Add(firstCoord - 11);
                            BlockedCoords.Add(firstCoord + 9);
                            break;
                        }
                    case "corner1":
                        {
                            AllowedCoords.Add(firstCoord + 10);
                            AllowedCoords.Add(firstCoord + 1);
                            BlockedCoords.Add(firstCoord + 11);
                            break;
                        }
                    case "corner2":
                        {
                            AllowedCoords.Add(firstCoord - 10);
                            AllowedCoords.Add(firstCoord + 1);
                            BlockedCoords.Add(firstCoord - 9);
                            break;
                        }
                    case "corner3":
                        {
                            AllowedCoords.Add(firstCoord - 10);
                            AllowedCoords.Add(firstCoord - 1);
                            BlockedCoords.Add(firstCoord - 11);
                            break;
                        }
                    case "corner4":
                        {
                            AllowedCoords.Add(firstCoord - 1);
                            AllowedCoords.Add(firstCoord + 10);
                            BlockedCoords.Add(firstCoord + 9);
                            break;
                        }
                    default:
                        {
                            correctPos = false;
                            break;
                        }
                }
                if (correctPos)
                {
                    AllowedCoords.Sort();
                    BlockedCoords.Sort();
                }
                else
                {
                    MessageBox.Show($"Error Code: E45M4L4\r\n{position} is incorrect position", $"{Handlers.Manager[4]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
