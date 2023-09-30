using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public class Support
    {
        Ship Ship = new Ship();
        public bool StringToInt(string inputText, out int result)
        {
            result = 0;
            try
            {
                result = int.Parse(inputText);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string GetTagFromButton(Button Inputbutton)
        {
            return Inputbutton.Tag.ToString();
        }
        public Button[] GetPlayerButtons(Button[,] buttons)
        {
            int size = buttons.GetLength(1);
            Button[] playerButtons = new Button[size];
            for (int i = 0; i < size; i++)
            {
                playerButtons[i] = buttons[0,i];
            }
            return playerButtons;
        }
        public Button[] GetEnemyButtons(Button[,] buttons)
        {
            int size = buttons.GetLength(1);
            Button[] enemyButtons = new Button[size];
            for (int i = 0; i < size; i++)
            {
                enemyButtons[i] = buttons[1,i];
            }
            return enemyButtons;
        }
        public string[] GetButtonsTagPlayer(Button[,] buttons)
        {
            Button[] playerButtons = GetPlayerButtons(buttons);
            string[] tags = new string[playerButtons.Length];
            for (int p = 0; p < playerButtons.Length; p++)
            {
                tags[p] = Convert.ToString(playerButtons[p].Tag);
            }
            return tags;
        }
        public string[] GetButtonsTagEnemy(Button[,] buttons)
        {
            Button[] enemyButtons = GetEnemyButtons(buttons);
            string[] tags = new string[enemyButtons.Length];
            for (int e = 0; e < enemyButtons.Length; e++)
            {
                tags[e] = Convert.ToString(enemyButtons[e].Tag);
            }
            return tags;
        }
        public char GetShipSymbol(Ship ship)
        {
            return (char)ship;
        }
        public int GetShipCount(char shipSymbol)
        {
            switch (shipSymbol.ToString().ToUpper())
            {
                case "F":
                    {
                        return 4;
                    }
                case "D":
                    {
                        return 3;
                    }
                case "C":
                    {
                        return 2;
                    }
                case "B":
                    {
                        return 1;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public int GetShipSize(char shipSymbol)
        {
            int shipCount = GetShipCount(shipSymbol);
            if (shipCount < 0)
            {
                return -1;
            }
            else
            {
                return 5 - shipCount;
            }
        }
        public char[] CharArrayRedimension(char[,] inputArray)
        {
            char[] outputArray = new char[inputArray.GetLength(0) * inputArray.GetLength(1)];
            int index = 0;
            for (int col = 0; col < inputArray.GetLength(1); col++)
            {
                for (int row = 0; row < inputArray.GetLength(0); row++)
                {
                    outputArray[index++] = inputArray[row, col];
                }
            }
            return outputArray;
        }
    }
}
