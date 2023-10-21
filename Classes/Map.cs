using System;
using System.Text;
using System.Windows.Forms;

namespace Battleship
{
    public class Map
    {
        Support Support = new Support();
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
        public void SetShipCharThrowColor(int index, Button[,] buttons)
        {
            bool successfull = true;
            switch (index)
            {
                case 0: //Player
                    {
                        Button[] buttonsPlayer = Support.GetPlayerButtons(buttons);
                        char[] mapPlayer = new char[buttonsPlayer.Length];
                        for (int i = 0; i < buttonsPlayer.Length; i++)
                        {
                            mapPlayer[i] = ColorMethods.SetCharThrowColor(index, buttonsPlayer[i].BackColor);
                        }
                        for (int c = 0; c < mapPlayer.Length; c++)
                        {
                            MapPlayer[c % 10, c / 10] = mapPlayer[c]; 
                        }
                        break;
                    }
                case 1: //Enemy
                    {
                        Button[] buttonsEnemy = Support.GetEnemyButtons(buttons);
                        char[] mapEnemy = new char[buttonsEnemy.Length];
                        for (int i = 0; i < buttonsEnemy.Length; i++)
                        {
                            mapEnemy[i] = ColorMethods.SetCharThrowColor(index, buttonsEnemy[i].BackColor);
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
                        break; //Incorrect
                    }
            }
            if (successfull)
            {
                Maps[0] = MapPlayer;
                Maps[1] = MapEnemy;
            }
        }
        static bool HasEmptySpaceAroundShip(char[,] map, int x, int y, int shipShize, int orientation)
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
            if (!HasEmptySpaceAroundShip(map, x, y, shipSize, orientation))
                return false;

            return true;
        }
        static void PlacePlayerShip(char[,] map, char shipSymbol, int shipSize)
        {
            Random random = new Random();
            bool placed = false;
            while (!placed)
            {
                int x = random.Next(10);
                int y = random.Next(10);
                int orientation = random.Next(2);
                if (IsValidPlacement(map, x, y, shipSize, orientation))
                {
                    for (int i = 0; i < shipSize; i++)
                    {
                        if (orientation == 0)
                        {
                            map[x + i, y] = shipSymbol;
                        }
                        else
                        {
                            map[x, y + i] = shipSymbol;
                        }
                    }
                    placed = true;
                }
            }
        }
        static void PlaceEnemyShip(char[,] map, char shipSymbol, int shipSize, int count)
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
                        }
                    }
                    placed = true;
                }
            }
        }
        public char[,] PlaceEnemyShips(char[,] map)
        {
            char[,] ships = Data.SetShipsChars();
            PlaceEnemyShip(map, 'b', 4, 0);
            PlaceEnemyShip(map, 'c', 3, 0);
            PlaceEnemyShip(map, 'c', 3, 1);
            PlaceEnemyShip(map, 'd', 2, 0);
            PlaceEnemyShip(map, 'd', 2, 1);
            PlaceEnemyShip(map, 'd', 2, 2);
            PlaceEnemyShip(map, 'f', 1, 0);
            PlaceEnemyShip(map, 'f', 1, 1);
            PlaceEnemyShip(map, 'f', 1, 2);
            PlaceEnemyShip(map, 'f', 1, 3);
            return map;
        }
        public char[,] PlacePlayerShips(char[,] map)
        {
            char[,] ships = Data.SetShipsChars();
            PlacePlayerShip(map, 'B', 4);
            PlacePlayerShip(map, 'C', 3);
            PlacePlayerShip(map, 'C', 3);
            PlacePlayerShip(map, 'D', 2);
            PlacePlayerShip(map, 'D', 2);
            PlacePlayerShip(map, 'D', 2);
            PlacePlayerShip(map, 'F', 1);
            PlacePlayerShip(map, 'F', 1);
            PlacePlayerShip(map, 'F', 1);
            PlacePlayerShip(map, 'F', 1);
            return map;
        }
        public char[,] GenerateEnemyMap(Button[,] mapButtons)
        {
            SetShipCharThrowColor(1, mapButtons);
            MapEnemy = PlaceEnemyShips(MapEnemy);
            return MapEnemy;
        }
        public char[,] GeneratePlayerMap(Button[,] mapbuttons)
        {
            SetShipCharThrowColor(0, mapbuttons);
            MapPlayer = PlacePlayerShips(MapPlayer);
            return MapPlayer;
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
            PlayerData.DestroyersCountCurrent /= 2;
            EnemyData.DestroyersCountCurrent /= 2;

            PlayerData.CruiserCountCurrent /= 3;
            EnemyData.CruiserCountCurrent /= 3;

            PlayerData.BattleshipCountCurrent /= 4;
            EnemyData.BattleshipCountCurrent /= 4;
        }
    }
}
