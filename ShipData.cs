using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public static class ShipData
    {
        public static int ChoosenShipType = 0;

        public static int FrigateCount = 4;
        public static int DestroyerCount = 3;
        public static int CruiserCount = 2;
        public static int BattleshipCount = 1;

        public static string Orientation = "N";

        public static int GetMineCount(string cellPos, int shipType, int x, int y, string orientation)
        {
            switch (cellPos)
            {
                case "corner1":
                    {
                        return shipType + 2;
                    }
                case "top":
                    {
                        switch (shipType)
                        {
                            case 1:
                                {
                                    return 5;
                                }
                            case 2:
                                {
                                    if (y <= 7)
                                    {
                                        return 6;
                                    }
                                    else
                                    {
                                        return 4;
                                    }
                                }
                            case 3:
                                {
                                    if (y <= 6)
                                    {
                                        return 7;
                                    }
                                    else
                                    {
                                        return 5;
                                    }
                                }
                            case 4:
                                {
                                    if (y <= 5)
                                    {
                                        return 8;
                                    }
                                    else
                                    {
                                        return 6;
                                    }
                                }
                            default:
                                {
                                    return -1;
                                }
                        }
                    }
                case "corner2":
                    {
                        if (shipType == 1)
                        {
                            return 3;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                case "left":
                    {
                        switch (shipType)
                        {
                            case 1:
                                {
                                    return 5;
                                }
                            case 2:
                                {
                                    switch (orientation)
                                    {
                                        case "V":
                                            {
                                                if (x > 1)
                                                {
                                                    return 6;
                                                }
                                                else
                                                {
                                                    return 4;
                                                }
                                            }
                                        case "H":
                                            {
                                                return 7;
                                            }
                                        default:
                                            {
                                                return -1;
                                            }
                                    }
                                }
                            case 3:
                                {
                                    switch (orientation)
                                    {
                                        case "V":
                                            {
                                                if (x > 2)
                                                {
                                                    return 7;
                                                }
                                                else
                                                {
                                                    return 5;
                                                }
                                            }
                                        case "H":
                                            {
                                                return 9;
                                            }
                                        default:
                                            {
                                                return -1;
                                            }
                                    }
                                }
                            case 4:
                                {
                                    switch (orientation)
                                    {
                                        case "V":
                                            {
                                                if (x > 3)
                                                {
                                                    return 8;
                                                }
                                                else
                                                {
                                                    return 6;
                                                }
                                            }
                                        case "H":
                                            {
                                                return 11;
                                            }
                                        default:
                                            {
                                                return -1;
                                            }
                                    }
                                }
                            default:
                                {
                                    return -1;
                                }
                        }
                    }
                case "center":
                    {
                        switch (orientation)
                        {
                            case "N":
                                {
                                    if (shipType == 1)
                                    {
                                        return 8;
                                    }
                                    else
                                    {
                                        return -1;
                                    }
                                }
                            case "H":
                                {
                                    switch (shipType)
                                    {
                                        case 2:
                                            {
                                                if (y == 8)
                                                {
                                                    return 7;
                                                }
                                                else
                                                {
                                                    return 10;
                                                }
                                            }
                                        case 3:
                                            {
                                                if (y == 7)
                                                {
                                                    return 9;
                                                }
                                                else
                                                {
                                                    return 12;
                                                }
                                            }
                                        case 4:
                                            {
                                                if (y == 6)
                                                {
                                                    return 11;
                                                }
                                                else
                                                {
                                                    return 14;
                                                }
                                            }
                                        default:
                                            {
                                                return -1;
                                            }
                                    }
                                }
                            case "V":
                                {
                                    switch (shipType)
                                    {
                                        case 2:
                                            {
                                                if (x == 1)
                                                {
                                                    return 7;
                                                }
                                                else
                                                {
                                                    return 10;
                                                }
                                            }
                                        case 3:
                                            {
                                                if (x == 2)
                                                {
                                                    return 9;
                                                }
                                                else
                                                {
                                                    return 12;
                                                }
                                            }
                                        case 4:
                                            {
                                                if (x == 3)
                                                {
                                                    return 11;
                                                }
                                                else
                                                {
                                                    return 14;
                                                }
                                            }
                                        default:
                                            {
                                                return -1;
                                            }
                                    }
                                }
                            default:
                                {
                                    return -1;
                                }
                        }
                    }
                case "right":
                    {
                        switch (orientation)
                        {
                            case "N":
                                {
                                    if (shipType == 1)
                                    {
                                        return 5;
                                    }
                                    else
                                    {
                                        return -1;
                                    }
                                }
                            case "H":
                                {
                                    return -1;
                                }
                            case "V":
                                {
                                    switch (shipType)
                                    {
                                        case 2:
                                            {
                                                if (x == 1)
                                                {
                                                    return 4;
                                                }
                                                else
                                                {
                                                    return 6;
                                                }
                                            }
                                        case 3:
                                            {
                                                if (x == 2)
                                                {
                                                    return 5;
                                                }
                                                else
                                                {
                                                    return 7;
                                                }
                                            }
                                        case 4:
                                            {
                                                if (x == 3)
                                                {
                                                    return 6;
                                                }
                                                else
                                                {
                                                    return 8;
                                                }
                                            }
                                        default:
                                            {
                                                return -1;
                                            }
                                    }
                                }
                            default:
                                {
                                    return -1;
                                }
                        }
                    }
                case "corner3":
                    {
                        if (orientation == "N" || orientation == "V")
                        {
                            return shipType + 2;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                case "bottom":
                    {
                        switch (orientation)
                        {
                            case "N":
                                {
                                    if (shipType == 1)
                                    {
                                        return 5;
                                    }
                                    else
                                    {
                                        return -1;
                                    }
                                }
                            case "V":
                                {
                                    if (shipType >= 2 && shipType <= 4)
                                    {
                                        return shipType + 5;
                                    }
                                    else
                                    {
                                        return -1;
                                    }
                                }
                            case "H":
                                {
                                    switch (shipType)
                                    {
                                        case 2:
                                            {
                                                if (y == 8)
                                                {
                                                    return 4;
                                                }
                                                else
                                                {
                                                    return 6;
                                                }
                                            }
                                        case 3:
                                            {
                                                if (y == 7)
                                                {
                                                    return 5;
                                                }
                                                else
                                                {
                                                    return 7;
                                                }
                                            }
                                        case 4:
                                            {
                                                if (y == 6)
                                                {
                                                    return 6;
                                                }
                                                else
                                                {
                                                    return 8;
                                                }
                                            }
                                        default:
                                            {
                                                return -1;
                                            }
                                    }
                                }
                            default:
                                {
                                    return -1;
                                }
                        }
                    }
                case "corner4":
                    {
                        if (shipType >= 1 && shipType <= 4)
                        {
                            return shipType + 2;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
        public static int[] MineTagsFill(int[] mineTags, string cellPos, int shipSize, int firstButtonTag, string orientation)
        {
            int size = mineTags.Length;
            /**/
            return mineTags;
            /**/
        }
    }
}
