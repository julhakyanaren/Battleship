using System;
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

        public static double[] ProbobilityArray = new double[100];
        public static double IndependentChance = 0;

        public static string[] EfficientyDataString = { "Forbidden", "Very Low", "Low", "Average", "High", "Very High", "Guaranted" };
        public static Color[] EfficientyDataColor = { Color.Firebrick, Color.Red, Color.OrangeRed, Color.DarkOrange, Color.Yellow, Color.YellowGreen, Color.Lime };
        public static double HitProbobility = 0.0f;
        
        public static bool FormClosed = true;
        public static bool ExampleCraeted = false;
        public static bool CanOpenForm = false;
        public static bool CanResetMap = true;
        public static bool ManualMode = true;
        public static bool ShowNoveNumber = true;

        public static List<float> HitChanceChanges = new List<float>();

        public static List<int> AllowedCoords = new List<int>();
        public static List<int> BlockedCoords = new List<int>();
        public static List<int> PossibleIndexes = new List<int>();
        public static List<int> ForbiddenIndexes = new List<int>();

        public static int AllowedCoordsCount = 0;
        public static int BlockedCoordsCount = 0;
        public static int UndiscoveredCells;
        public static int DiscoveredCells;
        public static int DecimalPlacesCount = 1;

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
                    AllowedCoordsCount = AllowedCoords.Count;
                    BlockedCoordsCount = BlockedCoords.Count;
                }
                else
                {
                    MessageBox.Show($"Error Code: E45M4L4\r\n{position} is incorrect position", $"{Handlers.Manager[4]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void ResetDiscoveredCells()
        {
            UndiscoveredCells = 0;
            DiscoveredCells = 0;
        }
        public static void SetProbobilityArrayDefaultValues()
        {
            for (int p = 0; p < ProbobilityArray.Length; p++)
            {
                ProbobilityArray[p] = 0.0f;
            }
        }
        public static List<int> GetNeighbourIndexes(int firstCoord)
        {
            List<int> indexes = new List<int>();
            if (firstCoord != 0)
            {
                string position = Position.GetCellPosition(firstCoord.ToString());
                bool correctPos = true;
                switch (position)
                {
                    case "center":
                        {
                            indexes.Add(firstCoord - 1);
                            indexes.Add(firstCoord + 1);
                            indexes.Add(firstCoord - 10);
                            indexes.Add(firstCoord + 10);
                            break;
                        }
                    case "left":
                        {
                            indexes.Add(firstCoord - 1);
                            indexes.Add(firstCoord + 1);
                            indexes.Add(firstCoord + 10);
                            break;
                        }
                    case "right":
                        {
                            indexes.Add(firstCoord - 1);
                            indexes.Add(firstCoord + 1);
                            indexes.Add(firstCoord - 10);
                            break;
                        }
                    case "top":
                        {
                            indexes.Add(firstCoord - 10);
                            indexes.Add(firstCoord + 10);
                            indexes.Add(firstCoord + 1);
                            break;
                        }
                    case "bottom":
                        {
                            indexes.Add(firstCoord - 10);
                            indexes.Add(firstCoord + 10);
                            indexes.Add(firstCoord - 1);
                            break;
                        }
                    case "corner1":
                        {
                            indexes.Add(firstCoord + 10);
                            indexes.Add(firstCoord + 1);
                            break;
                        }
                    case "corner2":
                        {
                            indexes.Add(firstCoord - 10);
                            indexes.Add(firstCoord + 1);
                            break;
                        }
                    case "corner3":
                        {
                            indexes.Add(firstCoord - 10);
                            indexes.Add(firstCoord - 1);
                            break;
                        }
                    case "corner4":
                        {
                            indexes.Add(firstCoord - 1);
                            indexes.Add(firstCoord + 10);
                            break;
                        }
                    default:
                        {
                            correctPos = false;
                            break;
                        }
                }
                if (!correctPos)
                {
                    indexes = null;
                }
            }
            else
            {
                indexes = null;
            }
            return indexes;
        }
    }
}
