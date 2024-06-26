﻿using Battleship.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Battleship
{
    public class Position
    {
        Support Support = new Support();
        ColorMethods ColorMethods = new ColorMethods();
        public void GetCoordsFromTag(string tag, out int x, out int y, out int playerID)
        {
            int tagInt = -1;
            x = -1;
            y = -1;
            playerID = -1;
            if (Support.StringToInt(tag, out tagInt))
            {
                playerID = tagInt / 100;
                tagInt %= 100;
                x = tagInt % 10;
                y = tagInt / 10;
            }
            else
            {
                MessageBox.Show($"Error Code: E33M9L4\r\n{tag} String type to Int32 type converting error", $"{Handlers.Manager[4]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void TextCoordToPosition(string textCoord, out int halfTag)
        {
            char[] textToChar = textCoord.ToCharArray();
            int letter = (int)textToChar[0] - 65;
            if (textToChar.Length == 3)
            {
                halfTag = Convert.ToInt32(textToChar[1].ToString()) * 10 + Convert.ToInt32(textToChar[2].ToString()) - 1;
            }
            else
            {
                halfTag = Convert.ToInt32(textToChar[1].ToString()) - 1;
            }
            halfTag = Convert.ToInt32(Convert.ToString($"{letter}{halfTag}"));
        }
        public string GetButtonTextCoords(Button button, out int id)
        {
            string tag = Support.GetTagFromButton(button);
            GetCoordsFromTag(tag, out int x, out int y, out int playerID);
            char letter = Convert.ToChar(y + 65);
            id = playerID;
            return letter.ToString().ToUpper() + $"{x+1}";
        }
        public string GetCellPosition(string tag)
        {
            int maxX = 9;
            int maxY = 9;
            bool top = false;
            bool bottom = false;
            bool left = false;
            bool right = false;
            string position = "center";
            GetCoordsFromTag(tag, out int x, out int y, out int playerID);
            if (x == 0)
            {
                top = true;
                position = "top";
            }
            if (y == 0)
            {
                left = true;
                position = "left";
            }
            if (x == maxX)
            {
                bottom = true;
                position = "bottom";
            }
            if (y == maxY)
            {
                right = true;
                position = "right";
            }
            if (top && left)
            {
                position = "corner1";
            }
            else if (top & right)
            {
                position = "corner2";
            }
            else if (bottom & right)
            {
                position = "corner3";
            }
            else if (bottom & left)
            {
                position = "corner4";
            }
            else if (!top && !bottom && !right && !left)
            {
                position = "center";
            }
            return position;
        }
        public int NewTagBuilder(int oldTag, int dx= 0, int dy = 0)
        {
            return oldTag + (10 * dy) + dx;
        }
        public List<int> DeleteOutLineCoords(List<int> coordsList, int firstCoord, char line)
        {
            switch (Char.ToLower(line))
            {
                case 'r': //Row
                    {
                        for (int r = 0; r < coordsList.Count; r++)
                        {
                            if (coordsList[r] / 10 != firstCoord / 10)
                            {
                                coordsList.RemoveAt(r);
                            }
                        }
                        break;
                    }
                case 'c': //Column
                    {
                        for (int c = 0; c < coordsList.Count; c++)
                        {
                            if (coordsList[c] % 10 != firstCoord % 10)
                            {
                                coordsList.RemoveAt(c);
                            }
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show($"Error Code: E42M9L4\r\n{line} is unknown line index", $"{Handlers.Manager[1]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return coordsList;
                    }
            }
            coordsList.RemoveAll(x => x >= 100 || x < 0);
            return coordsList;
        }
    }
}
