using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public static class Data
    {
        static Support sp = new Support();
        static ColorMethods cm = new ColorMethods();

        public static string ShipPlaceMode = "N";
        public static string Orientation = "Null";
        public static string SchematicMap;

        public static bool CanRaplaceShip;
        public static bool IsEmptyPosition;
        public static bool ShipPlaced;
        public static bool[] DoesMapChanged = /**/{ false, false };
        public static bool CorrectSchematic = false;

        public static char[] PlayerMap;
        public static char[] EnemyMap;

        public static string FirstCoord_Letter = "A";
        public static int FirstCoord_Number = 1;
        public static string FirstCoord_Final = "A1";

        public static char[] MapSchematic = new char[0];
        public static string Schematic;

        public static bool RandomMap = true;

        public static char[,] SetShipsChars()
        {
            char[,] chars = new char[2, 4];
            chars[0, 0] = 'F';
            chars[0, 1] = 'D';
            chars[0, 2] = 'C';
            chars[0, 3] = 'B';
            for (int i = 0; i < chars.GetLength(1); i++)
            {
                chars[1,i] = Convert.ToChar(Convert.ToString(chars[0,i]).ToLower());
            }
            return chars;
        }
        public static char[] TargetButtonsToCharArray(Button[] targetButton, int playerID)
        {
            char[] resultArray = new char[targetButton.Length];
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = cm.SetCharViaColor(playerID - 1, targetButton[i].BackColor);
            }
            return resultArray;
        }
        public static Button[] CharArrayToButtonsMap(char[] buttonsChar, int index)
        {
            Button[] resultButtons = new Button[buttonsChar.Length];
            for (int b = 0; b < resultButtons.Length; b++)
            {
                resultButtons[b].BackColor = cm.SetColorViaChar(buttonsChar[b]);
            }
            return resultButtons;
        }
        public static Button[,] FinalButtons(char[] playerMap, char[] enemyMap)
        {
            char[][] maps = { playerMap, enemyMap };
            Button[,] finalButtons = new Button[2, 100];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < finalButtons.Length; j++)
                {
                    finalButtons[i, j] = CharArrayToButtonsMap(maps[i], i)[j];
                }
            }
            return finalButtons;
        }

        public static void ResetDataToZero()
        {
            PlayerData.ResetDataToZero();
            EnemyData.ResetDataToZero();
        }

    }
}
