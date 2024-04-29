using Battleship.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Battleship
{
    public class Map
    {
        Support support = new Support();
        ColorMethods ColorMethods = new ColorMethods();
        Position Position = new Position();

        public char[,] MapPlayer = new char[10, 10];
        public char[,] MapEnemy = new char[10, 10];
        public char[][,] Maps = new char[2][,];

        public string GenerateMapSchematic(char[] map)
        {
            string schematic = null;
            for (int s = 0; s < map.Length; s++)
            {
                schematic += map[s].ToString();
            }
            return schematic;
        }
        public void SetShipCharViaColor(int index, Button[,] buttons)
        {
            bool successfull = true;
            switch (index)
            {
                case 0: //Player
                    {
                        Button[] buttonsPlayer = support.GetPlayerButtons(buttons);
                        char[] mapPlayer = new char[buttonsPlayer.Length];
                        for (int i = 0; i < buttonsPlayer.Length; i++)
                        {
                            mapPlayer[i] = ColorMethods.SetCharViaColor(index, buttonsPlayer[i].BackColor);
                        }
                        for (int c = 0; c < mapPlayer.Length; c++)
                        {
                            MapPlayer[c % 10, c / 10] = mapPlayer[c]; 
                        }
                        break;
                    }
                case 1: //Enemy
                    {
                        Button[] buttonsEnemy = support.GetEnemyButtons(buttons);
                        char[] mapEnemy = new char[buttonsEnemy.Length];
                        for (int i = 0; i < buttonsEnemy.Length; i++)
                        {
                            mapEnemy[i] = ColorMethods.SetCharViaColor(index, buttonsEnemy[i].BackColor);
                        }
                        for (int c = 0; c < mapEnemy.Length; c++)
                        {
                            MapEnemy[c % 10, c / 10] = mapEnemy[c]; 
                        }
                        break;
                    }
                default:
                    {
                        successfull = false;
                        break;
                    }
            }
            if (successfull)
            {
                Maps[0] = MapPlayer;
                Maps[1] = MapEnemy;
            }
            else
            {
                MessageBox.Show($"Error Code: E45M5L5\r\nUnknown player index", $"{Handlers.Manager[5]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static bool HasEmptySpaceAroundShip(char[,] map, int x, int y, int shipShize)
        {
            for (int i = x - 1; i <= x + shipShize; i++)
            {
                for (int j = y - 1; j <= y + shipShize; j++)
                {
                    if (i >= 0 && i < 10 && j >= 0 && j < 10)
                    {
                        if (map[i, j] != 'n')
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        static bool IsValidPlacement(char[,] map, int x, int y, int shipSize,  int orientation)
        {
            if (orientation == 0)
            {
                if (x + shipSize > 10)
                    return false;
                for (int i = x; i < x + shipSize; i++)
                {
                    if (map[i, y] != 'n')
                        return false;
                }
            }
            else
            {
                if (y + shipSize > 10)
                    return false;
                for (int i = y; i < y + shipSize; i++)
                {
                    if (map[x, i] != 'n')
                        return false;
                }
            }
            if (!HasEmptySpaceAroundShip(map, x, y, shipSize))
                return false;
            return true;
        }
        static void PlacePlayerShipUnit(char[,] map, char shipSymbol, int shipSize, int count)
        {
            Random random = new Random();
            bool placed = false;
            while (!placed)
            {
                int x = random.Next(10);
                int y = random.Next(10);
                int coord = 0;
                int orientation = random.Next(2);
                if (IsValidPlacement(map, x, y, shipSize, orientation))
                {
                    for (int i = 0; i < shipSize; i++)
                    {
                        if (orientation == 0)
                        {
                            map[x + i, y] = shipSymbol;
                            coord = (x + i) * 10 + y;
                        }
                        else
                        {
                            map[x, y + i] = shipSymbol;
                            coord = (x * 10) + y + i;
                        }
                        Support support = new Support();
                        coord = support.ChangeNumbers(coord);
                        switch (shipSymbol)
                        {
                            case 'F':
                                {
                                    PlayerData.FrigateCoords[count, i] = coord;
                                    break;
                                }
                            case 'D':
                                {
                                    PlayerData.DestroyerCoords[count, i] = coord;
                                    break;
                                }
                            case 'C':
                                {
                                    PlayerData.CruiserCoords[count, i] = coord;
                                    break;
                                }
                            case 'B':
                                {
                                    PlayerData.BattleshipCoords[count, i] = coord;
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show($"Error Code: E07M3L3\r\n{shipSymbol} is incorrect ship size", $"{Handlers.Manager[3]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                        }                    
                    }
                    placed = true;
                }
            }
        }
        static void PlaceEnemyShipUnit(char[,] map, char shipSymbol, int shipSize, int count)
        {
            Random random = new Random();
            bool placed = false;
            while (!placed)
            {
                int x = random.Next(10);
                int y = random.Next(10);
                int coord = 0;
                int orientation = random.Next(2);
                if (IsValidPlacement(map, x, y, shipSize, orientation))
                {
                    for (int i = 0; i < shipSize; i++)
                    {
                        if (orientation == 0)
                        {
                            map[x + i, y] = shipSymbol;
                            coord = (x + i) * 10 + y;
                        }
                        else
                        {
                            map[x, y + i] = shipSymbol;
                            coord = (x * 10) + y + i;
                        }
                        Support support = new Support();
                        coord = support.ChangeNumbers(coord);
                        switch (shipSymbol)
                        {
                            case 'f':
                                {
                                    EnemyData.FrigateCoords[count, i] = coord;
                                    break;
                                }
                            case 'd':
                                {
                                    EnemyData.DestroyerCoords[count, i] = coord;
                                    break;
                                }
                            case 'c':
                                {
                                    EnemyData.CruiserCoords[count, i] = coord;
                                    break;
                                }
                            case 'b':
                                {
                                    EnemyData.BattleshipCoords[count, i] = coord;
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show($"Error Code: E08M3L3\r\n{shipSymbol} is incorrect ship size", $"{Handlers.Manager[3]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                        }
                    }
                    placed = true;
                }
            }
        }
        public char[,] PlacePlayerFleet(char[,] map)
        {
            PlacePlayerShipUnit(map, 'B', 4, 0);
            PlacePlayerShipUnit(map, 'C', 3, 0);
            PlacePlayerShipUnit(map, 'C', 3, 1);
            PlacePlayerShipUnit(map, 'D', 2, 0);
            PlacePlayerShipUnit(map, 'D', 2, 1);
            PlacePlayerShipUnit(map, 'D', 2, 2);
            PlacePlayerShipUnit(map, 'F', 1, 0);
            PlacePlayerShipUnit(map, 'F', 1, 1);
            PlacePlayerShipUnit(map, 'F', 1, 2);
            PlacePlayerShipUnit(map, 'F', 1, 3);
            return map;
        }
        public char[,] PlaceEnemyFleet(char[,] map)
        {
            PlaceEnemyShipUnit(map, 'b', 4, 0);
            PlaceEnemyShipUnit(map, 'c', 3, 0);
            PlaceEnemyShipUnit(map, 'c', 3, 1);
            PlaceEnemyShipUnit(map, 'd', 2, 0);
            PlaceEnemyShipUnit(map, 'd', 2, 1);
            PlaceEnemyShipUnit(map, 'd', 2, 2);
            PlaceEnemyShipUnit(map, 'f', 1, 0);
            PlaceEnemyShipUnit(map, 'f', 1, 1);
            PlaceEnemyShipUnit(map, 'f', 1, 2);
            PlaceEnemyShipUnit(map, 'f', 1, 3);
            return map;
        }
        public char[,] GeneratePlayerMap(Button[,] mapbuttons)
        {
            SetShipCharViaColor(0, mapbuttons);
            MapPlayer = PlacePlayerFleet(MapPlayer);
            return MapPlayer;
        }
        public char[,] GenerateEnemyMap(Button[,] mapButtons)
        {
            SetShipCharViaColor(1, mapButtons);
            MapEnemy = PlaceEnemyFleet(MapEnemy);
            return MapEnemy;
        }
        public void SetShipsCountThrowMap(char[] map)
        {
            for (int c = 0; c < map.Length; c++)
            {
                switch (map[c])
                {
                    case 'b':
                        {
                            EnemyData.BattleshipCountCurrent++;
                            break;
                        }
                    case 'B':
                        {
                            PlayerData.BattleshipCountCurrent++;
                            break;
                        }
                    case 'c':
                        {
                            EnemyData.CruiserCountCurrent++;
                            break;
                        }
                    case 'C':
                        {
                            PlayerData.CruiserCountCurrent++;
                            break;
                        }
                    case 'd':
                        {
                            EnemyData.DestroyersCountCurrent++;
                            break;
                        }
                    case 'D':
                        {
                            PlayerData.DestroyersCountCurrent++;
                            break;
                        }
                    case 'f':
                        {
                            EnemyData.FrigatesCountCurrent++;
                            break;
                        }
                    case 'F':
                        {
                            PlayerData.FrigatesCountCurrent++;
                            break;
                        }
                    case 'h':
                        {
                            EnemyData.HitCountCurrent++;
                            break;
                        }
                    case 'H':
                        {
                            PlayerData.HitCountCurrent++;
                            break;
                        }
                    case 's':
                        {
                            EnemyData.SunkenCountCurrent++;
                            break;
                        }
                    case 'S':
                        {
                            PlayerData.SunkenCountCurrent++;
                            break;
                        }
                }
            }
        }
    }
}
