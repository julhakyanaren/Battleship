using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Net.Http.Headers;
using System.Resources;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Battleship
{
    public static class ShipData
    {
        public static int HitedDeckCount = 0;
        public static int ChoosenShipType = 0;
        public static int FrigateCount = 4;
        public static int DestroyerCount = 3;
        public static int CruiserCount = 2;
        public static int BattleshipCount = 1;
        public static int MaximumDeckCount = 20;
        public static int[] ShipsCount = { FrigateCount, DestroyerCount, CruiserCount, BattleshipCount };

        public static string Orientation = "N";

        public static bool MapAutoUpdate = false;
        public static bool AllShipPlaced = false;

        public static bool[] RadioButtonsState = { false, false, false, false };
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
                                        //Changed (shipType + 5)
                                        switch (shipType)
                                        {
                                            case 2:
                                                {
                                                    return 7;
                                                }
                                            case 3:
                                                {
                                                    return 9;
                                                }
                                            case 4:
                                                {
                                                    return 11;
                                                }
                                            default:
                                                {
                                                    return -1;
                                                }
                                        }
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
        public static int[] MineTagsFill(int[] mineTags, string cellPos, int shipSize, int tag, string orientation)
        {
            Position pos = new Position();
            int size = mineTags.Length;
            pos.GetCoordsFromTag(tag.ToString(), out int x, out int y, out int playerID);
            switch (shipSize)
            {
                case 1:
                    {
                        switch (cellPos)
                        {
                            case "corner1":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dy: 1);
                                    mineTags[1] = pos.NewTagBuilder(tag, dx: 1);
                                    mineTags[2] = pos.NewTagBuilder(tag, 1, 1);
                                    return mineTags;
                                }
                            case "top":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                    mineTags[1] = pos.NewTagBuilder(tag, dy: 1);
                                    mineTags[2] = pos.NewTagBuilder(tag, dx: 1);
                                    mineTags[3] = pos.NewTagBuilder(tag, 1, -1);
                                    mineTags[4] = pos.NewTagBuilder(tag, 1, 1);
                                    return mineTags;
                                }
                            case "corner2":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dy:-1);
                                    mineTags[1] = pos.NewTagBuilder(tag, dx: 1);
                                    mineTags[2] = pos.NewTagBuilder(tag, 1, -1);
                                    return mineTags;
                                }
                            case "left":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dx: -1);
                                    mineTags[1] = pos.NewTagBuilder(tag, dx: 1);
                                    mineTags[2] = pos.NewTagBuilder(tag, dy: 1);
                                    mineTags[3] = pos.NewTagBuilder(tag, -1, 1);
                                    mineTags[4] = pos.NewTagBuilder(tag, 1, 1);
                                    return mineTags;
                                }
                            case "center":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dx: -1);
                                    mineTags[1] = pos.NewTagBuilder(tag, dx: 1);
                                    mineTags[2] = pos.NewTagBuilder(tag, dy: -1);
                                    mineTags[3] = pos.NewTagBuilder(tag, dy: 1);
                                    mineTags[4] = pos.NewTagBuilder(tag, -1, -1);
                                    mineTags[5] = pos.NewTagBuilder(tag, -1, 1);
                                    mineTags[6] = pos.NewTagBuilder(tag, 1, 1);
                                    mineTags[7] = pos.NewTagBuilder(tag, 1, -1);
                                    return mineTags;
                                }
                            case "right":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dx: -1);
                                    mineTags[1] = pos.NewTagBuilder(tag, dx: 1);
                                    mineTags[2] = pos.NewTagBuilder(tag, dy: -1);
                                    mineTags[3] = pos.NewTagBuilder(tag, -1, -1);
                                    mineTags[4] = pos.NewTagBuilder(tag, 1, -1);
                                    return mineTags;
                                }
                            case "corner3":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dx: -1);
                                    mineTags[1] = pos.NewTagBuilder(tag, dy: -1);
                                    mineTags[2] = pos.NewTagBuilder(tag, -1, -1);
                                    return mineTags;
                                }
                            case "bottom":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                    mineTags[1] = pos.NewTagBuilder(tag, dy: 1);
                                    mineTags[2] = pos.NewTagBuilder(tag, dx: -1);
                                    mineTags[3] = pos.NewTagBuilder(tag, -1, -1);
                                    mineTags[4] = pos.NewTagBuilder(tag, -1, 1);
                                    return mineTags;
                                }
                            case "corner4":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dx: -1);
                                    mineTags[1] = pos.NewTagBuilder(tag, dy: 1);
                                    mineTags[2] = pos.NewTagBuilder(tag, -1, 1);
                                    return mineTags;
                                }
                        }
                        break;
                    }
                case 2:
                    {
                        switch (cellPos)
                        {
                            case "corner1":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dx: 1);
                                    mineTags[1] = pos.NewTagBuilder(tag, dy: 2);
                                    mineTags[2] = pos.NewTagBuilder(tag, 1, 1);
                                    mineTags[3] = pos.NewTagBuilder(tag, 1, 2);
                                    return mineTags;
                                }
                            case "top":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                    mineTags[1] = pos.NewTagBuilder(tag, dy: 2);
                                    mineTags[2] = pos.NewTagBuilder(tag, 1, -1);
                                    mineTags[3] = pos.NewTagBuilder(tag, dx: 1);
                                    mineTags[4] = pos.NewTagBuilder(tag, 1, 1);
                                    mineTags[5] = pos.NewTagBuilder(tag, 1, 2);
                                    return mineTags;
                                }
                            case "left":
                                {
                                    if (orientation == "V")
                                    {
                                        if (x > 1)
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[1] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dy: 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, -2, 1);
                                            mineTags[5] = pos.NewTagBuilder(tag, dx: -2);
                                            return mineTags;
                                        }
                                        else
                                        {

                                            mineTags[0] = pos.NewTagBuilder(tag, dy: 1);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, 1, 1);
                                            return mineTags;
                                        }
                                    }
                                    else
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dx: -1);
                                        mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                        mineTags[2] = pos.NewTagBuilder(tag, -1, 2);
                                        mineTags[3] = pos.NewTagBuilder(tag, dy: 2);
                                        mineTags[4] = pos.NewTagBuilder(tag, 1, 2);
                                        mineTags[5] = pos.NewTagBuilder(tag, 1, 1);
                                        mineTags[6] = pos.NewTagBuilder(tag, dx: 1);
                                    }
                                    return mineTags;
                                }
                            case "center":
                                {
                                    if (orientation == "H")
                                    {
                                        if (y == 8)
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[1] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[2] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[5] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[6] = pos.NewTagBuilder(tag, dy: -1);
                                        }
                                        else
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[1] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[2] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, 2);
                                            mineTags[4] = pos.NewTagBuilder(tag, dy: 2);
                                            mineTags[5] = pos.NewTagBuilder(tag, 1, 2);
                                            mineTags[6] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[7] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[8] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[9] = pos.NewTagBuilder(tag, dy: -1);
                                        }
                                    }
                                    else
                                    {
                                        if (x == 1)
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[1] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[2] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[3] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[5] = pos.NewTagBuilder(tag, dy: 1);
                                            mineTags[6] = pos.NewTagBuilder(tag, -1, 1);
                                        }
                                        else
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[1] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[2] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[3] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[5] = pos.NewTagBuilder(tag, dy: 1);
                                            mineTags[6] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[7] = pos.NewTagBuilder(tag, -2, 1);
                                            mineTags[8] = pos.NewTagBuilder(tag, dx: -2);
                                            mineTags[9] = pos.NewTagBuilder(tag, -2, -1);
                                        }
                                    }
                                    return mineTags;
                                }
                            case "right":
                                {
                                    if (orientation == "V")
                                    {
                                        if (x == 1)
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[1] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, -1);
                                        }
                                        else
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[1] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[4] = pos.NewTagBuilder(tag, -2, -1);
                                            mineTags[5] = pos.NewTagBuilder(tag, dx: -2);
                                        }
                                    }
                                    return mineTags;
                                }
                            case "corner3":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                    mineTags[1] = pos.NewTagBuilder(tag, -1, -1);
                                    mineTags[2] = pos.NewTagBuilder(tag, -2, -1);
                                    mineTags[3] = pos.NewTagBuilder(tag, dx: -2);
                                    return mineTags;
                                }
                            case "bottom":
                                {
                                    if (orientation == "H")
                                    {
                                        if (y == 8)
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, 1);
                                        }
                                        else
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, -1, 2);
                                            mineTags[5] = pos.NewTagBuilder(tag, dy: 2);
                                        }
                                    }
                                    else
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                        mineTags[1] = pos.NewTagBuilder(tag, -1, -1);
                                        mineTags[2] = pos.NewTagBuilder(tag, -2, -1);
                                        mineTags[3] = pos.NewTagBuilder(tag, dx: -2);
                                        mineTags[4] = pos.NewTagBuilder(tag, -2, 1);
                                        mineTags[5] = pos.NewTagBuilder(tag, -1, 1);
                                        mineTags[6] = pos.NewTagBuilder(tag, dy: 1);
                                    }
                                    return mineTags;
                                }
                            case "corner4":
                                {
                                    if (orientation == "H")
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dx: -1);
                                        mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                        mineTags[2] = pos.NewTagBuilder(tag, -1, 2);
                                        mineTags[3] = pos.NewTagBuilder(tag, dy: 2);
                                    }
                                    else
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dx: -2);
                                        mineTags[1] = pos.NewTagBuilder(tag, -2, 1);
                                        mineTags[2] = pos.NewTagBuilder(tag, -1, 1);
                                        mineTags[3] = pos.NewTagBuilder(tag, dy: 1);
                                    }
                                    return mineTags;
                                }
                            default:
                                {
                                    return mineTags;
                                }
                        }
                    }
                case 3:
                    {
                        switch (cellPos)
                        {
                            case "corner1":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dx: 1);
                                    mineTags[1] = pos.NewTagBuilder(tag, 1, 1);
                                    mineTags[2] = pos.NewTagBuilder(tag, 1, 2);
                                    mineTags[3] = pos.NewTagBuilder(tag, 1, 3);
                                    mineTags[4] = pos.NewTagBuilder(tag, dy: 3);
                                    return mineTags;
                                }
                            case "top":
                                {
                                    if (y == 7)
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                        mineTags[1] = pos.NewTagBuilder(tag, 1, -1);
                                        mineTags[2] = pos.NewTagBuilder(tag, dx: 1);
                                        mineTags[3] = pos.NewTagBuilder(tag, 1, 1);
                                        mineTags[4] = pos.NewTagBuilder(tag, 1, 2);
                                    }
                                    else
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                        mineTags[1] = pos.NewTagBuilder(tag, 1, -1);
                                        mineTags[2] = pos.NewTagBuilder(tag, dx: 1);
                                        mineTags[3] = pos.NewTagBuilder(tag, 1, 1);
                                        mineTags[4] = pos.NewTagBuilder(tag, 1, 2);
                                        mineTags[5] = pos.NewTagBuilder(tag, 1, 3);
                                        mineTags[6] = pos.NewTagBuilder(tag, dy: 3);
                                    }
                                    return mineTags;
                                }
                            case "left":
                                {
                                    if (orientation == "V")
                                    {
                                        if (x == 2)
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dy: 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, 2, 1);
                                        }
                                        else
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, dx: +1);
                                            mineTags[1] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dy: 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, -2, 1);
                                            mineTags[5] = pos.NewTagBuilder(tag, -3, 1);
                                            mineTags[6] = pos.NewTagBuilder(tag, dx: -3);
                                        }
                                    }
                                    else
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dx: -1);
                                        mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                        mineTags[2] = pos.NewTagBuilder(tag, -1, 2);
                                        mineTags[3] = pos.NewTagBuilder(tag, -1, 3);
                                        mineTags[4] = pos.NewTagBuilder(tag, dy: 3);
                                        mineTags[5] = pos.NewTagBuilder(tag, 1, 3);
                                        mineTags[6] = pos.NewTagBuilder(tag, 1, 2);
                                        mineTags[7] = pos.NewTagBuilder(tag, 1, 1);
                                        mineTags[8] = pos.NewTagBuilder(tag, dx: 1);
                                    }
                                    return mineTags;
                                }
                            case "center":
                                {
                                    if (orientation == "V")
                                    {
                                        if (x == 2)
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, -2, 1);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dy: 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[5] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[6] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[7] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[8] = pos.NewTagBuilder(tag, -2, -1);
                                        }
                                        else
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, -2, 1);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dy: 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[5] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[6] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[7] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[8] = pos.NewTagBuilder(tag, -2, -1);
                                            mineTags[9] = pos.NewTagBuilder(tag, -3, -1);
                                            mineTags[10] = pos.NewTagBuilder(tag, dx: -3);
                                            mineTags[11] = pos.NewTagBuilder(tag, -3, 1);
                                        }
                                    }
                                    else
                                    {
                                        if (y == 7)
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, -1, 2);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[4] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[5] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[6] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[7] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[8] = pos.NewTagBuilder(tag, 1, 2);
                                        }
                                        else
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, -1, 2);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[4] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[5] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[6] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[7] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[8] = pos.NewTagBuilder(tag, 1, 2);
                                            mineTags[9] = pos.NewTagBuilder(tag, 1, 3);
                                            mineTags[10] = pos.NewTagBuilder(tag, dy: 3);
                                            mineTags[11] = pos.NewTagBuilder(tag, -1, 3);
                                        }
                                    }
                                    return mineTags;
                                }
                            case "right":
                                {
                                    if (x == 2)
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dx: 1);
                                        mineTags[1] = pos.NewTagBuilder(tag, 1, -1);
                                        mineTags[2] = pos.NewTagBuilder(tag, dy: -1);
                                        mineTags[3] = pos.NewTagBuilder(tag, -1, -1);
                                        mineTags[4] = pos.NewTagBuilder(tag, -2, -1);
                                    }
                                    else
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dx: 1);
                                        mineTags[1] = pos.NewTagBuilder(tag, 1, -1);
                                        mineTags[2] = pos.NewTagBuilder(tag, dy: -1);
                                        mineTags[3] = pos.NewTagBuilder(tag, -1, -1);
                                        mineTags[4] = pos.NewTagBuilder(tag, -2, -1);
                                        mineTags[5] = pos.NewTagBuilder(tag, -3, -1);
                                        mineTags[6] = pos.NewTagBuilder(tag, dx: -3);
                                    }
                                    return mineTags;
                                }
                            case "corner3":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                    mineTags[1] = pos.NewTagBuilder(tag, -1, -1);
                                    mineTags[2] = pos.NewTagBuilder(tag, -2, -1);
                                    mineTags[3] = pos.NewTagBuilder(tag, -3, -1);
                                    mineTags[4] = pos.NewTagBuilder(tag, dx: -3);
                                    return mineTags;
                                }
                            case "bottom":
                                {
                                    if (orientation == "H")
                                    {
                                        if (y == 7)
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, -1, 2);
                                        }
                                        else
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, -1, 2);
                                            mineTags[5] = pos.NewTagBuilder(tag, -1, 3);
                                            mineTags[6] = pos.NewTagBuilder(tag, dy: 3);
                                        }
                                    }
                                    else
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                        mineTags[1] = pos.NewTagBuilder(tag, -1, -1);
                                        mineTags[2] = pos.NewTagBuilder(tag, -2, -1);
                                        mineTags[3] = pos.NewTagBuilder(tag, -3, -1);
                                        mineTags[4] = pos.NewTagBuilder(tag, dx: -3);
                                        mineTags[5] = pos.NewTagBuilder(tag, -3, 1);
                                        mineTags[6] = pos.NewTagBuilder(tag, -2, 1);
                                        mineTags[7] = pos.NewTagBuilder(tag, -1, 1);
                                        mineTags[8] = pos.NewTagBuilder(tag, dy: 1);
                                    }
                                    return mineTags;
                                }
                            case "corner4":
                                {
                                    if (orientation == "H")
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dx: -1);
                                        mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                        mineTags[2] = pos.NewTagBuilder(tag, -1, 2);
                                        mineTags[3] = pos.NewTagBuilder(tag, -1, 3);
                                        mineTags[4] = pos.NewTagBuilder(tag, dy: 3);
                                    }
                                    else
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dy: 1);
                                        mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                        mineTags[2] = pos.NewTagBuilder(tag, -2, 1);
                                        mineTags[3] = pos.NewTagBuilder(tag, -3, 1);
                                        mineTags[4] = pos.NewTagBuilder(tag, dx: -3);
                                    }
                                    return mineTags;
                                }
                            default:
                                {
                                    return mineTags;
                                }
                        }
                    }
                case 4:
                    {
                        switch (cellPos)
                        {
                            case "corner1":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dx: 1);
                                    mineTags[1] = pos.NewTagBuilder(tag, 1, 1);
                                    mineTags[2] = pos.NewTagBuilder(tag, 1, 2);
                                    mineTags[3] = pos.NewTagBuilder(tag, 1, 3);
                                    mineTags[4] = pos.NewTagBuilder(tag, 1, 4);
                                    mineTags[5] = pos.NewTagBuilder(tag, dy: 4);
                                    return mineTags;
                                }
                            case "top":
                                {
                                    if (y == 6)
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                        mineTags[1] = pos.NewTagBuilder(tag, 1, -1);
                                        mineTags[2] = pos.NewTagBuilder(tag, dx: 1);
                                        mineTags[3] = pos.NewTagBuilder(tag, 1, 1);
                                        mineTags[4] = pos.NewTagBuilder(tag, 1, 2);
                                    }
                                    else
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                        mineTags[1] = pos.NewTagBuilder(tag, 1, -1);
                                        mineTags[2] = pos.NewTagBuilder(tag, dx: 1);
                                        mineTags[3] = pos.NewTagBuilder(tag, 1, 1);
                                        mineTags[4] = pos.NewTagBuilder(tag, 1, 2);
                                        mineTags[5] = pos.NewTagBuilder(tag, 1, 3);
                                        mineTags[6] = pos.NewTagBuilder(tag, 1, 4);
                                        mineTags[7] = pos.NewTagBuilder(tag, dy: 4);
                                    }
                                    return mineTags;
                                }
                            case "left":
                                {
                                    if (orientation == "V")
                                    {
                                        if (x == 3)
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dy: 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, 2, 1);
                                            mineTags[5] = pos.NewTagBuilder(tag, 3, 1);
                                        }
                                        else
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[1] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dy: 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, -2, 1);
                                            mineTags[5] = pos.NewTagBuilder(tag, -3, 1);
                                            mineTags[6] = pos.NewTagBuilder(tag, -4, 1);
                                            mineTags[7] = pos.NewTagBuilder(tag, dx: -4);
                                        }
                                    }
                                    else
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dx: -1);
                                        mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                        mineTags[2] = pos.NewTagBuilder(tag, -1, 2);
                                        mineTags[3] = pos.NewTagBuilder(tag, -1, 3);
                                        mineTags[4] = pos.NewTagBuilder(tag, -1, 4);
                                        mineTags[5] = pos.NewTagBuilder(tag, dy: 4);
                                        mineTags[6] = pos.NewTagBuilder(tag, 1, 4);
                                        mineTags[7] = pos.NewTagBuilder(tag, 1, 3);
                                        mineTags[8] = pos.NewTagBuilder(tag, 1, 2);
                                        mineTags[9] = pos.NewTagBuilder(tag, 1, 1);
                                        mineTags[10] = pos.NewTagBuilder(tag, dx: 1);
                                    }
                                    return mineTags;
                                }
                            case "center":
                                {
                                    if (orientation == "V")
                                    {
                                        if (x == 3)
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, -3, 1);
                                            mineTags[1] = pos.NewTagBuilder(tag, -2, 1);
                                            mineTags[2] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, dy: 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[5] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[6] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[7] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[8] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[9] = pos.NewTagBuilder(tag, -2, -1);
                                            mineTags[10] = pos.NewTagBuilder(tag, -3, -1);
                                        }
                                        else
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, -3, 1);
                                            mineTags[1] = pos.NewTagBuilder(tag, -2, 1);
                                            mineTags[2] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, dy: 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[5] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[6] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[7] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[8] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[9] = pos.NewTagBuilder(tag, -2, -1);
                                            mineTags[10] = pos.NewTagBuilder(tag, -3, -1);
                                            mineTags[11] = pos.NewTagBuilder(tag, -4, -1);
                                            mineTags[12] = pos.NewTagBuilder(tag, dx: -4);
                                            mineTags[13] = pos.NewTagBuilder(tag, -4, 1);
                                        }
                                    }
                                    else
                                    {
                                        if (y == 6)
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, -1, 3);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, 2);
                                            mineTags[2] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[4] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[5] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[6] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[7] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[8] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[9] = pos.NewTagBuilder(tag, 1, 2);
                                            mineTags[10] = pos.NewTagBuilder(tag, 1, 3);;
                                        }
                                        else
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, -1, 3);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, 2);
                                            mineTags[2] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[3] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[4] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[5] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[6] = pos.NewTagBuilder(tag, 1, -1);
                                            mineTags[7] = pos.NewTagBuilder(tag, dx: 1);
                                            mineTags[8] = pos.NewTagBuilder(tag, 1, 1);
                                            mineTags[9] = pos.NewTagBuilder(tag, 1, 2);
                                            mineTags[10] = pos.NewTagBuilder(tag, 1, 3);
                                            mineTags[11] = pos.NewTagBuilder(tag, 1, 4);
                                            mineTags[12] = pos.NewTagBuilder(tag, dy: 4);
                                            mineTags[13] = pos.NewTagBuilder(tag, -1, 4);
                                        }
                                    }
                                    return mineTags;
                                }
                            case "right":
                                {
                                    if (x == 3)
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dx: 1);
                                        mineTags[1] = pos.NewTagBuilder(tag, 1, -1);
                                        mineTags[2] = pos.NewTagBuilder(tag, dy: -1);
                                        mineTags[3] = pos.NewTagBuilder(tag, -1, -1);
                                        mineTags[4] = pos.NewTagBuilder(tag, -2, -1);
                                        mineTags[5] = pos.NewTagBuilder(tag, -3, -1);
                                    }
                                    else
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dx: 1);
                                        mineTags[1] = pos.NewTagBuilder(tag, 1, -1);
                                        mineTags[2] = pos.NewTagBuilder(tag, dy: -1);
                                        mineTags[3] = pos.NewTagBuilder(tag, -1, -1);
                                        mineTags[4] = pos.NewTagBuilder(tag, -2, -1);
                                        mineTags[5] = pos.NewTagBuilder(tag, -3, -1);
                                        mineTags[6] = pos.NewTagBuilder(tag, -4, -1);
                                        mineTags[7] = pos.NewTagBuilder(tag, dx: -4);
                                    }
                                    return mineTags;
                                }
                            case "corner3":
                                {
                                    mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                    mineTags[1] = pos.NewTagBuilder(tag, -1, -1);
                                    mineTags[2] = pos.NewTagBuilder(tag, -2, -1);
                                    mineTags[3] = pos.NewTagBuilder(tag, -3, -1);
                                    mineTags[4] = pos.NewTagBuilder(tag, -4, -1);
                                    mineTags[5] = pos.NewTagBuilder(tag, dx: -4);
                                    return mineTags;
                                }
                            case "bottom":
                                {
                                    if (orientation == "H")
                                    {
                                        if (y == 6)
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, -1, 2);
                                            mineTags[5] = pos.NewTagBuilder(tag, -1, 3);
                                        }
                                        else
                                        {
                                            mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                            mineTags[1] = pos.NewTagBuilder(tag, -1, -1);
                                            mineTags[2] = pos.NewTagBuilder(tag, dx: -1);
                                            mineTags[3] = pos.NewTagBuilder(tag, -1, 1);
                                            mineTags[4] = pos.NewTagBuilder(tag, -1, 2);
                                            mineTags[5] = pos.NewTagBuilder(tag, -1, 3);
                                            mineTags[6] = pos.NewTagBuilder(tag, -1, 4);
                                            mineTags[7] = pos.NewTagBuilder(tag, dy: 4);
                                        }
                                    }
                                    else
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dy: -1);
                                        mineTags[1] = pos.NewTagBuilder(tag, -1, -1);
                                        mineTags[2] = pos.NewTagBuilder(tag, -2, -1);
                                        mineTags[3] = pos.NewTagBuilder(tag, -3, -1);
                                        mineTags[4] = pos.NewTagBuilder(tag, -4, -1);
                                        mineTags[5] = pos.NewTagBuilder(tag, dx: -4);
                                        mineTags[6] = pos.NewTagBuilder(tag, -4, 1);
                                        mineTags[7] = pos.NewTagBuilder(tag, -3, 1);
                                        mineTags[8] = pos.NewTagBuilder(tag, -2, 1);
                                        mineTags[9] = pos.NewTagBuilder(tag, -1, 1);
                                        mineTags[10] = pos.NewTagBuilder(tag, dy: 1);
                                    }
                                    return mineTags;
                                }
                            case "corner4":
                                {
                                    if (orientation == "H")
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dx: -1);
                                        mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                        mineTags[2] = pos.NewTagBuilder(tag, -1, 2);
                                        mineTags[3] = pos.NewTagBuilder(tag, -1, 3);
                                        mineTags[4] = pos.NewTagBuilder(tag, -1, 4);
                                        mineTags[5] = pos.NewTagBuilder(tag, dy: 4);
                                    }
                                    else
                                    {
                                        mineTags[0] = pos.NewTagBuilder(tag, dy: 1);
                                        mineTags[1] = pos.NewTagBuilder(tag, -1, 1);
                                        mineTags[2] = pos.NewTagBuilder(tag, -2, 1);
                                        mineTags[3] = pos.NewTagBuilder(tag, -3, 1);
                                        mineTags[4] = pos.NewTagBuilder(tag, -4, 1);
                                        mineTags[5] = pos.NewTagBuilder(tag, dx: -4);
                                    }
                                    return mineTags;
                                }
                            default:
                                {
                                    return mineTags;
                                }
                        }
                    }
                default:
                    {
                        return mineTags;
                    }
            }
            return mineTags;
        }
    }
}
