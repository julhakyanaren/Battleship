using System;
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
        public bool IsValidShipPosition(string cellPosition,string shipType, string orientation, string tag)
        {
            GetCoordsFromTag(tag, out int x, out int y, out int p);
            if (shipType == "Frigate")
            {
                return true;
            }
            switch (cellPosition)
            {
                case "center":
                    {
                        switch (shipType)
                        {
                            case "Destroyer":
                                {
                                    return true;
                                }
                            case "Cruiser":
                                {
                                    switch (orientation)
                                    {
                                        case "V":
                                            {
                                                if (x >= 2)
                                                {
                                                    return true;
                                                }
                                                return false;
                                            }
                                        case "H":
                                            {
                                                if (y <= 7)
                                                {
                                                    return true;
                                                }
                                                return false;
                                            }
                                        default:
                                            {
                                                return false;
                                            }
                                    }
                                }
                            case "Battleship":
                                {
                                    switch (orientation)
                                    {
                                        case "V":
                                            {
                                                if (x >= 3)
                                                {
                                                    return true;
                                                }
                                                return false;
                                            }
                                        case "H":
                                            {
                                                if (y <= 6)
                                                {
                                                    return true;
                                                }
                                                return false;
                                            }
                                        default:
                                            {
                                                return false;
                                            }
                                    }
                                }
                            default:
                                {
                                    return false;
                                }
                        }
                    }
                case "top":
                    {
                        switch (shipType)
                        {
                            case "Destroyer":
                                {
                                    switch (orientation)
                                    {
                                        case "H":
                                            {
                                                if (y <= 8)
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            }
                                        case "V":
                                            {
                                                return false;
                                            }
                                    }
                                    return false;
                                }
                            case "Cruiser":
                                {
                                    if (orientation == "H" && y <= 7)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            case "Battleship":
                                {
                                    if (orientation == "H" && y <= 6)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                        }
                        break;
                    }
                case "bottom":
                    {
                        switch (shipType)
                        {
                            case "Destroyer":
                                {
                                    return true;
                                }
                            case "Cruiser":
                                {
                                    if (orientation == "V")
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        if (y <= 7)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                }
                            case "Battleship":
                                {
                                    if (orientation == "V")
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        if (y <= 6)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                }
                            case "Firgate":
                                {
                                    return true;
                                }
                            default:
                                {
                                    return false;
                                }
                        }
                    }
                case "left":
                    {
                        if (orientation == "H")
                        {
                            return true;
                        }
                        else
                        {
                            switch (shipType)
                            {
                                case "Destroyer":
                                    {
                                        if (x >= 1)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                case "Cruiser":
                                    {
                                        if (x >= 2)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                case "Battleship":
                                    {
                                        if (x >= 3)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                case "Firgate":
                                    {
                                        return true;
                                    }
                                default:
                                    {
                                        return false;
                                    }
                            }
                        }
                    }
                case "right":
                    {
                        if (shipType == "Frigate")
                        {
                            return true;
                        }
                        else
                        {
                            switch (orientation)
                            {
                                case "H":
                                    {
                                        if (shipType != "Frigate")
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                case "V":
                                    {
                                        if (x >= 1)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                default:
                                    {
                                        return false;
                                    }
                            }
                        }
                    }
                case "corner1":
                    {
                        if (shipType == "Frigate")
                        {
                            return true;
                        }
                        else
                        {
                            if (orientation == "H")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                case "corner2":
                    {
                        if (shipType == "Frigate")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case "corner3":
                    {
                        if (shipType == "Frigate")
                        {
                            return true;
                        }
                        else
                        {
                            if (orientation == "V")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                case "corner4":
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
            return false;
        }
        public int NewTagBuilder(int oldTag, int dx= 0, int dy = 0)
        {
            return oldTag + (10 * dy) + dx;
        }
        public string TextCoordThrowIndex(int index)
        {
            int y = index / 10;
            int x = index % 10;
            return $"{Convert.ToChar(y + 65)}{x+1}";
        }
    }
}
