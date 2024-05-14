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
        public static char[] TargetButtonsToCharArray(Button[] targetButton, int playerID)
        {
            char[] resultArray = new char[targetButton.Length];
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = cm.SetCharViaColor(playerID - 1, targetButton[i].BackColor);
            }
            return resultArray;
        }
        public static void ResetDataToZero()
        {
            PlayerData.ResetDataToZero();
            EnemyData.ResetDataToZero();
        }

    }
}
