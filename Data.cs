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
        public static int Turn;
        public static string ShipPlaceMode = "N";
        public static string Orientation = "Null";
        public static bool CanRaplaceShip;
        public static bool ShipPlaced;

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
        public static char[] ButtonsMapToCharArray(Button[,] allButtons, int index)
        {
            Button[] buttonInWork = new Button[0];
            char[] buttonsChar = new char[buttonInWork.Length];
            if (index == 0)
            {
                buttonInWork = sp.GetPlayerButtons(allButtons);
                buttonsChar = new char[buttonInWork.Length];
            }
            else
            {
                buttonInWork = sp.GetEnemyButtons(allButtons);
                buttonsChar = new char[buttonInWork.Length];
            }
            for (int b = 0; b < buttonInWork.Length; b++)
            {
                buttonsChar[b] = cm.SetCharThrowColor(index, buttonInWork[b].BackColor);
            }
            return buttonsChar;
        }
        public static Button[] CharArrayToButtonsMap(char[] buttonsChar, int index)
        {
            Button[] resultButtons = new Button[buttonsChar.Length];
            for (int b = 0; b < resultButtons.Length; b++)
            {
                resultButtons[b].BackColor = cm.SetColorThrowChar(buttonsChar[b]);
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

    }
}
