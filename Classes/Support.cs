using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Linq;
using System.Security.Policy;
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
        public string FormateTimeText(int seconds, int minutes, int hours, string timeFormat)
        {
            switch (timeFormat)
            {
                case "HH:MM:SS":
                    {
                        return $"{hours:00}:{minutes:00}:{seconds:00}";
                    }
                case "HH:MM":
                    {
                        return $"{hours:00}:{minutes:00}";
                    }
                case "MM:SS":
                    {
                        return $"{minutes:00}:{seconds:00}";
                    }
                default:
                    {
                        return $"{hours}:{minutes}:{seconds}";
                    }
            }
        }
    }
}
