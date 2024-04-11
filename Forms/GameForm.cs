using Battleship.Classes;
using Battleship.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Battleship.DebugTools;

namespace Battleship
{
    public partial class GameForm : Form
    {
        Position Position = new Position();
        Map Map = new Map();
        Support Support = new Support();
        ColorMethods ColorMethods = new ColorMethods();
        public bool[,] ShipsSunken = new bool [2, 4];
        public bool[] AllShipSunken = {false, false};
        void SetShipsSunkenToZero()
        {
            ShipsSunken[0, 0] = false; //Player Frigates
            ShipsSunken[0, 1] = false; //Player Destroyers
            ShipsSunken[0, 2] = false; //Player Cruisers
            ShipsSunken[0, 3] = false; //Player Battleships

            ShipsSunken[1, 0] = false; //Enemy Frigates
            ShipsSunken[1, 1] = false; //Enemy Destroyers
            ShipsSunken[1, 2] = false; //Enemy Cruisers
            ShipsSunken[1, 3] = false; //Enemy Battleships
        }
        void CheckShipsSunkenState()
        {
            for (int s0 = 0; s0 < ShipsSunken.GetLength(0); s0++)
            {
                AllShipSunken[s0] = true;
                for (int p = 0; p < ShipsSunken.GetLength(1); p++)
                {
                    AllShipSunken[s0] &= ShipsSunken[s0, p];
                }
            }
            if (AllShipSunken[0])
            {
                //Player Lose
                if (Information.GameOverMessages(true) == DialogResult.OK)
                {
                    ShowEnemyMapAfterGame();
                }
            }
            else if (AllShipSunken[1])
            {
                //Player Win
                Fight.Turn = 2;
                TB_Turn.Text = SetTurnText();
                TB_Turn.ForeColor = Color.Red;
                if (Information.GameOverMessages(false) == DialogResult.OK)
                {
                    ShowPlayerMapAfterGame();
                }
            }
        }
        public void ShowEnemyMapAfterGame()
        {
            for (int i = 0; i < MapButtons.GetLength(1); i++)
            {
                if (MapButtons[1, i].BackColor != Color.White) continue;
                char mapChar = Char.ToLower(EnemyData.Map[i]);
                if (mapChar == 'e' || mapChar == 'n') continue;
                MapButtons[1, i].BackColor = Color.Green;
            }
        }
        public void ShowPlayerMapAfterGame()
        {
            for (int i = 0; i < MapButtons.GetLength(1); i++)
            {
                if (MapButtons[0, i].BackColor == Color.Silver ||
                    MapButtons[0, i].BackColor == Color.DarkGray ||
                    MapButtons[0, i].BackColor == Color.Gray ||
                    MapButtons[0, i].BackColor == Color.DimGray)
                {
                    MapButtons[0, i].BackColor = Color.Green;
                }
            }
        }
        public GameForm()
        {
            InitializeComponent();
        }
        public Button[,] MapButtons = new Button[2, 100];
        void SetScreenParametersAsMaximized()
        {
            WindowState = FormWindowState.Maximized;
            int width = Width;
            int height = Height;
            Width = width;
            Height = height;
            Location = new Point(0, 0);
            MaximizeBox = false;
        }
        public void SetComponentCustomParamaters()
        {
            Design.SetComponentLocation(L_Info_Turn, PNL_InfoChance);
            Design.SetComponentLocation(TB_Turn, PNL_InfoChance);
            Design.ChangeControlElementsForeColor(this, Design.DefaultForeColor, DefaultBackColor);
            Design.SetElementLocation(3, 20, TB_Turn);
            Design.SetElementLocation(3, 1, L_Info_Turn);
            Design.SetElementSize(TLP_Main, 1028, 400);
            Design.SetElementLocation(3, 20, TB_GameModeType);
            Design.SetElementLocation(3, 1, L_Info_GameMode);
            if (Options.GameModeInt == 0)
            {
                L_Info_PressForInfo.Text = "Press \"C\" for more info about Hit Chance";
                BS_HitMoreInfo.Visible = true;
            }
            else
            {
                L_Info_PressForInfo.Text = "In \"Classic\" mode, the hit chance check is not available.\r\nThe function will become available when you select the “Education” mode\r\non the home screen.";
                L_Info_PressForInfo.Location = new Point(0, (PNL_InfoChance.Height - L_Info_PressForInfo.Height) / 2);
                Design.SetComponentRelativelyParent(L_Info_PressForInfo, PNL_InfoChance);
                BS_HitMoreInfo.Visible = false;
            }
            TB_GameModeType.Text = $"{Options.GameMode} Mode";
            TSMI_GPO_Version.Text = $"Version:  {DebugTools.Version}.{RunsCount}";
            L_Info_TurnStatus.Location = new Point(L_Info_TurnStatus.Location.X, L_Info_GameMode.Location.Y);
            TB_TurnStatus.Location = new Point(TB_TurnStatus.Location.X, TB_Turn.Location.Y);
        }
        private void GamePlayerOne_Load(object sender, EventArgs e)
        {
            SetScreenParametersAsMaximized();
            SetComponentCustomParamaters();
        }
        async Task GenerateButtons()
        {
            int[,] tags = GenerateButtonsTags();
            int x;
            int y;
            string[] nameTamplate = { "BS_GPO_PC", "BS_GPO_EC" };
            TableLayoutPanel[] tlp = { TLP_PlayerSchema, TLP_EnemySchema };
            for (int f = 0; f < 2; f++)
            {
                for (int b = 0; b < 100; b++)
                {
                    x = b / 10;
                    y = (b % 10 - 1) * 60 + 1;
                    Button button = new Button
                    {
                        Name = /*nameTamplate[0] +*/ tags[f, b].ToString(),
                        Location = new Point(x, y),
                        Dock = DockStyle.Fill
                    };
                    tlp[f].Controls.Add(button);
                    button.FlatStyle = FlatStyle.Flat;
                    button.ForeColor = Color.Black;
                    button.BackColor = Color.White;
                    button.Tag = tags[f, b];
                    button.Margin = new Padding(0);
                    button.Visible = false;
                    button.MouseEnter += Button_MouseEnter;
                    button.MouseClick += Button_Click;
                    MapButtons[f, b] = button;
                    button.FlatAppearance.MouseOverBackColor = Design.MouseOverColor[f];
                    if (f == 0)
                    {
                        PlayerData.MapButtons[b] = button;
                    }
                    else
                    {
                        EnemyData.MapButtons[b] = button;
                    }
                }
            }
            for (int id = 0; id < MapButtons.GetLength(0); id++)
            {
                Map.SetShipCharViaColor(id, MapButtons);
            }
            Array.Resize(ref PlayerData.Map, MapButtons.GetLength(1));
            Array.Resize(ref EnemyData.Map, MapButtons.GetLength(1));
            for (int vb = 0; vb < 100; vb++)
            {
                await Task.Delay(1);
                MapButtons[0, vb].Visible = true;
                //MapButtons[0, vb].Text = MapButtons[0, vb].Tag.ToString();
                MapButtons[1, vb].Visible = true;
            }
            TSMI_Map.Enabled = true;

        }
        void PlayerTurn(int playerID, Button clickedButton)
        {
            string tagButton = clickedButton.Tag.ToString();
            if (playerID == 2)
            {
                if (Fight.GameStarted)
                {
                    NextTurn(tagButton);
                    ColorMethods.EnemyMapColor = ColorMethods.SetEnemyButtonsColors(EnemyData.Map);
                    UpdateEnemyMapColor(ColorMethods.EnemyMapColor);
                    if (SetTurnText() == "ERROR")
                    {
                        //Error_Catch
                    }
                    else
                    {
                        TB_Turn.Text = SetTurnText();
                    }
                }
            }
        }
        private async void Button_Click(object sender, MouseEventArgs e)
        {
            if (!Options.GameOver)
            {
                Button clickedButton = sender as Button;
                int playerID;
                string coord = Position.GetButtonTextCoords(clickedButton, out playerID);
                Support.StringToInt(clickedButton.Tag.ToString(), out int tagCB);
                if (clickedButton.BackColor != Color.White)
                {
                    if (tagCB / 100 == 2)
                    {
                        int index = Fight.FindCorrectIndex(Convert.ToInt32(clickedButton.Tag) + 1551, true);
                        await NotAvailableMove(index, 1, 4, 0);
                    }
                }
                if (Fight.ForbiddenCoords.Count != 100)
                {
                    await Turn(playerID, clickedButton);
                }
                else
                {
                    CoordsForcedOverwrite();
                    await Turn(playerID, clickedButton);
                }
            }
        }
        async Task Turn(int playerID, Button clickedButton)
        {
            if (Fight.Turn == 0)
            {
                PlayerTurn(playerID, clickedButton);
                while (Fight.Turn == 1)
                {
                    if (!Options.GameOver)
                    {
                        await EnemyTurn();
                    }
                    else
                    {
                        Fight.Turn = 2;
                        TB_Turn.Text = SetTurnText();
                        TB_Turn.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                SystemSounds.Exclamation.Play();
                int index = Fight.FindCorrectIndex(Convert.ToInt32(clickedButton.Tag) + 1551, true);
                await NotAvailableMove(index, 1, 4, 0, changeStatus: true, statusText: $"Not {Options.SP_PlayerName}'s turn");
            }
        }
        int FindTargetButtonViaIndex()
        {
            if (Support.StringToInt(Fight.TargetButtonTag.ToString(), out int index))
            {
                index -= 1551;
                for (int b = 0; b < 100; b++)
                {
                    if (MapButtons[0, b].Tag.ToString() == $"{index}")
                    {
                        return b;
                    }
                }
            }
            return -1;
        }
        async Task ChangeBorderSize(int duration = 30, int steps = 4)
        {
            int targetIndex = FindTargetButtonViaIndex();
            if (MapButtons[0, targetIndex].BackColor == Color.Red || MapButtons[0, targetIndex].BackColor == Color.Firebrick || MapButtons[0, targetIndex].BackColor == Color.DeepSkyBlue)
            {
                MessageBox.Show("Incorrect Posiotion");
            }
            else if (targetIndex != -1)
            {
                int defaultBorderSize = MapButtons[1, targetIndex].FlatAppearance.BorderSize;
                int customBorderSize = defaultBorderSize * 3;
                for (int a = 0; a <= steps; a++)
                {
                    MapButtons[0, targetIndex].FlatAppearance.BorderSize = customBorderSize;
                    await Task.Delay(duration);
                    MapButtons[0, targetIndex].FlatAppearance.BorderSize = defaultBorderSize;
                    await Task.Delay(duration);
                }
                MapButtons[0, targetIndex].FlatAppearance.BorderSize = defaultBorderSize;
            }
        }
        async Task NotAvailableMove(int index,int size = 1, int steps = 5, int colorIndex = 0, int duration = 120, bool changeStatus = false, string statusText = null)
        {
            int defaultSize = MapButtons[1, index].FlatAppearance.BorderSize;
            int changedSize = defaultSize + size;
            string oldText = TB_TurnStatus.Text;
            Color oldColor = TB_TurnStatus.ForeColor;
            Color defaultColor = MapButtons[1, index].FlatAppearance.BorderColor;
            Color[] changedColors = { Color.DarkRed, Color.Gold };
            if (changeStatus)
            {
                TB_TurnStatus.Text = statusText;
                TB_TurnStatus.ForeColor = Color.Red;
            }
            for (int i = 0; i < steps; i++)
            {
                await Task.Delay(duration);
                MapButtons[1, index].FlatAppearance.BorderColor = changedColors[colorIndex];
                MapButtons[1, index].FlatAppearance.BorderSize = changedSize;
                await Task.Delay(duration);
                MapButtons[1, index].FlatAppearance.BorderColor = defaultColor;
                MapButtons[1, index].FlatAppearance.BorderSize = defaultSize;
                MapButtons[1, index].FlatAppearance.BorderSize = defaultSize;
                MapButtons[1, index].FlatAppearance.BorderColor = defaultColor;
            }
            TB_TurnStatus.Text = oldText;
            TB_TurnStatus.ForeColor = oldColor;
        }
        async Task EnemyTurn()
        {
            bool successshot = false;
            if (ShipData.HitedDeckCount < ShipData.MaximumDeckCount)
            {
                Fight.Shoot(out successshot);
                await ChangeBorderSize(100, 3);
                ColorMethods.PlayerMapColor = ColorMethods.SetButtonColors(PlayerData.Map);
                try
                {
                    UpdatePlayerMapColor(ColorMethods.PlayerMapColor);
                    SetAllShipsTextBoxesValues();
                    Fight.Turn = Fight.ReverseTurn(Fight.Hited);
                    if (SetTurnText() == "ERROR")
                    {
                        //Error_Catch
                    }
                    else
                    {
                        TB_Turn.Text = SetTurnText();
                    }
                }
                catch
                {
                    //Error_Catch
                }
            }
            else if (ShipData.HitedDeckCount == 20)
            {
                Options.GameOver = true;
            }
        }
        void UpdatePlayerMapColor(Color[] colors)
        {
            PlayerData.WhiteCellsCount = 0;
            PlayerData.HitedDecksCount = 0;
            for (int mc = 0; mc < colors.Length; mc++)
            {
                MapButtons[0, mc].BackColor = ColorMethods.PlayerMapColor[mc];
                switch (ColorMethods.PlayerMapColor[mc].Name)
                {
                    case "White":
                        {
                            PlayerData.WhiteCellsCount++;
                            break;
                        }
                    case "Red":
                    case "Firebrick":
                        {
                            PlayerData.HitedDecksCount++;
                            break;
                        }
                }
            }
            PlayerData.AddIndependentChance();
        }
        void UpdateEnemyMapColor(Color[] colors)
        {
            EnemyData.WhiteCellsCount = 0;
            EnemyData.HitedDecksCount = 0;
            for (int mc = 0; mc < colors.Length; mc++)
            {
                MapButtons[1, mc].BackColor = ColorMethods.EnemyMapColor[mc];
                switch (ColorMethods.EnemyMapColor[mc].Name)
                {
                    case "White":
                        {
                            EnemyData.WhiteCellsCount++;
                            break;
                        }
                    case "Red":
                    case "Firebrick":
                        {
                            EnemyData.HitedDecksCount++;
                            break;
                        }
                }
            }
            EnemyData.AddIndependentChance();
        }
        string SetTurnText()
        {
            switch (Fight.Turn)
            {
                case 0:
                    {
                        return Options.SP_PlayerName;
                    }
                case 1:
                    {
                        return "Enemy";
                    }
                case 2:
                    {
                        return "Game Over";
                    }
                default:
                    {
                        return "ERROR";
                    }
            }
        }
        private async void Button_MouseEnter(object sender, EventArgs e)
        {
            await Task.Delay(0);
            Button selectedButton = sender as Button;
            string tagButton = Support.GetTagFromButton(selectedButton);
            Position.GetCoordsFromTag(tagButton, out int x, out int y, out int playerID);
            string textID = Position.GetButtonTextCoords(selectedButton, out playerID);
            int index = playerID - 1;
            Button[] targetButtons = new Button[MapButtons.GetLength(1)];
            string cellPosition = Position.GetCellPosition(tagButton);
            switch (index)
            {
                case 0:
                    {
                        targetButtons = Support.GetPlayerButtons(MapButtons);
                        BS_PlayerSchema_Index.Text = textID;
                        bool orientationChanged = false;
                        PlayerData.Map = Data.TargetButtonsToCharArray(targetButtons, playerID);
                        if (Data.ShipPlaceMode == "Frigate")
                        {
                            Data.Orientation = "N";
                        }
                        else
                        {
                            if (ModifierKeys == Keys.Shift)
                            {
                                Data.Orientation = "V";
                                orientationChanged = true;
                            }
                            else
                            {
                                Data.Orientation = "H";
                                orientationChanged = true;
                            }
                        }
                        if (orientationChanged)
                        {

                        }
                        if (Position.IsValidShipPosition(cellPosition, Data.ShipPlaceMode, Data.Orientation, tagButton))
                        {

                        }
                        break;
                    }
                case 1:
                    {
                        BS_EnemySchema_Index.Text = textID;
                        if (selectedButton != null)
                        {
                            HitChanceData.SelectedCell = selectedButton;
                        }
                        SetStatusTurnText(selectedButton);
                        break;
                    }
                default:
                    {
                        BS_EnemySchema_Index = null;
                        BS_PlayerSchema_Index = null;
                        break;
                    }
            }
        }
        int[,] GenerateButtonsTags()
        {
            int tag;
            int index;
            int[,] tags = new int[2, 100];
            for (int f = 1; f <= 2; f++)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        tag = Convert.ToInt32(Convert.ToString($"{f}{j}{i}"));
                        index = Convert.ToInt32(Convert.ToString($"{i}{j}"));
                        tags[f - 1, index] = tag;
                    }
                }
            }
            return tags;
        }
        private void GamePlayerOne_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        public void GeneratePlayerRandomMap()
        {
            ResetPlayerMap(false, MapButtons);
            char[,] playerMap = Map.GeneratePlayerMap(MapButtons);
            Button[] playerButtons = Support.GetPlayerButtons(MapButtons);
            SetPlayerButtonsColors(playerButtons, playerMap);
        }
        public void GenerateEnemyRandomMap()
        {
            ResetEnemyMap(MapButtons);
            char[,] enemyMap = Map.GenerateEnemyMap(MapButtons);
            Button[] enemyButtons = Support.GetEnemyButtons(MapButtons);
            SetEnemyButtonsColors(enemyButtons, enemyMap);
        }
        public void SetPlayerButtonsColors(Button[] playerButtons, char[,] playerMap)
        {
            PlayerData.ResetShipsCount();
            char[] map = Support.CharArrayRedimension(playerMap);
            Color[] colors = ColorMethods.SetButtonColors(map);
            for (int b = 0; b < playerButtons.Length; b++)
            {
                playerButtons[b].BackColor = colors[b];
            }
            Map.SetShipsCountThrowMap(map);
            PlayerData.DestroyersCountCurrent /= 2;
            PlayerData.CruiserCountCurrent /= 3;
            PlayerData.BattleshipCountCurrent /= 4;
            PlayerData.Map = map;
            TB_PlayerFrigate.Text = $"{PlayerData.FrigatesCountCurrent}";
            TB_PlayerDestroyer.Text = $"{PlayerData.DestroyersCountCurrent}";
            TB_PlayerCruiser.Text = $"{PlayerData.CruiserCountCurrent}";
            TB_PlayerBattleship.Text = $"{PlayerData.BattleshipCountCurrent}";
        }
        public void SetEnemyButtonsColors(Button[] enemyButtons, char[,] enemyMap)
        {
            EnemyData.ResetShipsCount();
            char[] map = Support.CharArrayRedimension(enemyMap);
            Color[] colors = ColorMethods.SetButtonColors(map);
            for (int b = 0; b < enemyButtons.Length; b++)
            {
                enemyButtons[b].BackColor = colors[b];
            }
            Map.SetShipsCountThrowMap(map);
            EnemyData.DestroyersCountCurrent /= 2;
            EnemyData.CruiserCountCurrent /= 3;
            EnemyData.BattleshipCountCurrent /= 4;
            TB_EnemyFrigate.Text = $"{EnemyData.FrigatesCountCurrent}";
            TB_EnemyDestroyer.Text = $"{EnemyData.DestroyersCountCurrent}";
            TB_EnemyCruiser.Text = $"{EnemyData.CruiserCountCurrent}";
            TB_EnemyBattleship.Text = $"{EnemyData.BattleshipCountCurrent}";
        }
        public void ResetEnemyMap(Button[,] buttons)
        {
            Button[] enemyButtons = Support.GetEnemyButtons(buttons);
            for (int b = 0; b < enemyButtons.Length; b++)
            {
                enemyButtons[b].BackColor = Color.White;
            }
        }
        public void ResetPlayerMap(bool gameStarted, Button[,] buttons)
        {
            if (!gameStarted)
            {
                Button[] playerButtons = Support.GetPlayerButtons(buttons);
                for (int b = 0; b < playerButtons.Length; b++)
                {
                    playerButtons[b].BackColor = Color.White;
                }
            }
        }
        public void StartBattleShip()
        {
            GenerateEnemyRandomMap();
            for (int i = 0; i < MapButtons.GetLength(1); i++)
            {
                Button targetButton = MapButtons[1, i];
                Array.Resize(ref EnemyData.Map, MapButtons.GetLength(1));
                EnemyData.Map[i] = ColorMethods.SetCharViaColor(1, targetButton.BackColor);
                if (PlayerData.Map[i] == 'N')
                {
                    PlayerData.Map[i] = 'E';
                }
                if (EnemyData.Map[i] == 'n')
                {
                    EnemyData.Map[i] = 'e';
                }
            }
            Fight.GameStarted = true;
            Data.ResetDataToZero();
            int turn = Fight.WhoStartGame();
            if (Fight.FirstTurn)
            {
                switch (turn)
                {
                    case 0:
                        {
                            TB_Turn.Text = Options.SP_PlayerName;
                            Fight.FirstTurn = false;
                            break;
                        }
                    case 1:
                        {
                            TB_Turn.Text = "Enemy";
                            Fight.FirstTurn = false;
                            break;
                        }
                    default:
                        {
                            TB_Turn.Clear();
                            TB_Turn.Text = "Error";
                            break;
                        }
                }
            }
        }
        public void NextTurn(string buttonTag)
        {
            if (Fight.Turn == 0)
            {
                if (Support.StringToInt(buttonTag, out int index))
                {
                    index %= 100;
                    index = Convert.ToInt32($"{index % 10}{index / 10}");
                    Fight.TargetCoord = index;
                    Fight.PlayerHits = !IsCellWhite(index, out char celChar);
                    Fight.Turn = Fight.ReverseTurn(Fight.PlayerHits);
                    bool sunkenFrigate = false;
                    bool hitedShip = false;
                    if (celChar != 'e')
                    {
                        switch (Char.ToUpper(celChar))
                        {
                            case 'F':
                                {
                                    EnemyData.FrigatesCountCurrent--;
                                    EnemyData.SunkenFrigatesCount++;
                                    EnemyData.FrigatesHited[EnemyData.SunkenFrigatesCount - 1, 0] = true;
                                    EnemyData.Map[index] = 's';
                                    sunkenFrigate = true;
                                    PlayerData.HitCountCurrent++;
                                    break;
                                }
                            case 'D':
                                {
                                    EnemyData.Map[index] = 'h';
                                    bool canBreak = false;
                                    for (int d0 = 0; d0 < 3; d0++)
                                    {
                                        for (int d1 = 0; d1 < 2; d1++)
                                        {
                                            int currentDestroyer = EnemyData.DestroyerCoords[d0, d1];
                                            if (EnemyData.DestroyerCoords[d0, d1] == index)
                                            {
                                                EnemyData.DestroyersHited[d0, d1] = true;
                                                canBreak = true;
                                                break;
                                            }
                                        }
                                        if (canBreak)
                                        {
                                            break;
                                        }
                                    }
                                    EnemyData.DoesDestroyerSunken();
                                    int sunkenDestroyers = 0;
                                    for (int d = 0; d < EnemyData.DestroyersSunken.Length; d++)
                                    {
                                        sunkenDestroyers += Convert.ToInt32(EnemyData.DestroyersSunken[d]);
                                    }
                                    if (sunkenDestroyers - EnemyData.SunkenDestroyersCount == 1)
                                    {
                                        hitedShip = false;
                                        Fight.SetRoundMinesInEnemyMap(3);
                                        PlayerData.HitCountCurrent++;
                                        EnemyData.DestroyersCountCurrent--;
                                    }
                                    else
                                    {
                                        hitedShip = true;
                                    }
                                    EnemyData.SunkenDestroyersCount = sunkenDestroyers;
                                    EnemyData.DestroyersCountCurrent = EnemyData.DestroyersCountMax - EnemyData.SunkenDestroyersCount;
                                    break;
                                }
                            case 'C':
                                {
                                    EnemyData.Map[index] = 'h';
                                    bool canBreak = false;
                                    for (int c0 = 0; c0 < 2; c0++)
                                    {
                                        for (int c1 = 0; c1 < 3; c1++)
                                        {
                                            int currentDestroyer = EnemyData.CruiserCoords[c0, c1];
                                            if (EnemyData.CruiserCoords[c0, c1] == index)
                                            {
                                                EnemyData.CruiserHited[c0, c1] = true;
                                                canBreak = true;
                                                break;
                                            }
                                        }
                                        if (canBreak)
                                        {
                                            break;
                                        }
                                    }
                                    EnemyData.DoesCruiserSunken();
                                    int sunkenCruisers = 0;
                                    for (int c = 0; c < EnemyData.CruisersSunken.Length; c++)
                                    {
                                        sunkenCruisers += Convert.ToInt32(EnemyData.CruisersSunken[c]);
                                    }
                                    if (sunkenCruisers - EnemyData.SunkenCruisersCount == 1)
                                    {
                                        hitedShip = false;
                                        Fight.SetRoundMinesInEnemyMap(2);
                                        PlayerData.HitCountCurrent++;
                                        EnemyData.CruiserCountCurrent--;
                                    }
                                    else
                                    {
                                        hitedShip = true;
                                    }
                                    EnemyData.SunkenCruisersCount = sunkenCruisers;
                                    EnemyData.CruiserCountCurrent = EnemyData.CruiserCountMax - EnemyData.SunkenCruisersCount;
                                    break;
                                }
                            case 'B':
                                {
                                    EnemyData.Map[index] = 'h';
                                    for (int b1 = 0; b1 < 4; b1++)
                                    {
                                        int currentDestroyer = EnemyData.BattleshipCoords[0, b1];
                                        if (EnemyData.BattleshipCoords[0, b1] == index)
                                        {
                                            EnemyData.BattleshipHited[0, b1] = true;
                                            break;
                                        }
                                    }
                                    EnemyData.DoesBattleshipSunken();
                                    int sunkenBattleship = 0;
                                    for (int b = 0; b < EnemyData.BattleshipSunken.Length; b++)
                                    {
                                        sunkenBattleship += Convert.ToInt32(EnemyData.BattleshipSunken[b]); ;
                                    }
                                    if (sunkenBattleship == 1)
                                    {
                                        hitedShip = false;
                                        Fight.SetRoundMinesInEnemyMap(1);
                                        PlayerData.HitCountCurrent++;
                                        EnemyData.BattleshipCountCurrent--;
                                    }
                                    else
                                    {
                                        hitedShip = true;
                                    }
                                    EnemyData.SunkenBattleshipCount = sunkenBattleship;
                                    EnemyData.BattleshipCountCurrent = EnemyData.BattleshipCountMax - EnemyData.SunkenBattleshipCount;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        PlayerData.MissedShotsCount++;
                        EnemyData.Map[index] = 'm';
                        hitedShip = false;
                    }
                    if (hitedShip)
                    {
                        string position = Position.GetCellPosition(Fight.FindCorrectCoord(index, true).ToString());
                        Fight.GenerateBlockedCoords(position, index);
                        for (int bl = 0; bl < EnemyData.BlockedCoords.Count; bl++)
                        {
                            EnemyData.Map[EnemyData.BlockedCoords[bl]] = 'M';
                        }
                        PlayerData.HitCountCurrent++;
                    }
                    if (sunkenFrigate)
                    {
                        string position = Position.GetCellPosition(Fight.FindCorrectCoord(index, true).ToString());
                        Fight.GenerateBlockedCoords(position, index, true);
                        List<int> forbiddenCoords = new List<int>();
                        forbiddenCoords.AddRange(EnemyData.BlockedCoords);
                        forbiddenCoords.AddRange(EnemyData.AllowedCoords);
                        for (int bl = 0; bl < forbiddenCoords.Count; bl++)
                        {
                            EnemyData.Map[forbiddenCoords[bl]] = 'M';
                        }
                        EnemyData.Map[index] = 'S';
                        sunkenFrigate = false;
                    }
                    TB_PlayerHit.Text = PlayerData.HitCountCurrent.ToString();
                    TB_PlayerMiss.Text = PlayerData.MissedShotsCount.ToString();
                    SetAllShipsTextBoxesValues();
                }
                else
                {
                    //Error_Catch
                }
            }
            else if (Fight.Turn == 1)
            {
                //Enemy Shot
            }
            else
            {
                //Error_Catch
            }
        }
        public bool IsCellWhite(int index, out char cellChar)
        {
            if (EnemyData.Map[index] == 'e')
            {
                cellChar = 'e';
                return true;
            }
            else
            {
                cellChar = EnemyData.Map[index];
                return false;
            }
        }
        private async void TSMI_StartNewGame_Click(object sender, EventArgs e)
        {
            if (PlayerData.Map == null)
            {
                try
                {
                    await GenerateButtons();
                    TSMI_Map.Enabled = true;
                    TSMI_OpenMapEditor.Enabled = true;
                    TSMI_RestartGame.Enabled = true;
                    HitChanceData.CanOpenForm = true;
                }
                catch
                {
                    //Error_Catch
                }
            }
            else
            {
                MessageBox.Show("Maps allready created!", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void TSMI_StartBattleShip_Click(object sender, EventArgs e)
        {
            StartBattleShip();
            for (int i = 0; i < MapButtons.GetLength(1); i++)
            {
                Button targetButton = MapButtons[1, i];
                targetButton.BackColor = Color.White;
                targetButton.FlatAppearance.MouseOverBackColor = Color.Orange;
            }
        }
        private void TSMI_GenerationType_CheckedChanged(object sender, EventArgs e)
        {
            switch (TSMI_GenerationType.Checked)
            {
                case true:
                    {
                        TSMI_TB_GenType.Text = "Generate random map";
                        Data.RandomMap = true;
                        break;
                    }
                case false:
                    {
                        TSMI_TB_GenType.Text = "Generate with schematic";
                        Data.RandomMap = false;
                        break;
                    }
            }
        }
        private async void TSMI_GenerateMap_Click(object sender, EventArgs e)
        {
            bool playerMapCreated = true;
            if (Data.RandomMap == true)
            {
                try
                {
                    GeneratePlayerRandomMap();
                    await Task.Delay(1);
                }
                catch
                {
                    playerMapCreated = false;
                }
            }
            else
            {
                try
                {
                    if (!Schematic.CorrectSchematic)
                    {
                        DialogResult = MessageBox.Show("Schematic map not complete generation not possible", "Map Editor", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        if (DialogResult == DialogResult.OK)
                        {
                            playerMapCreated = false;
                        }
                    }
                    else
                    {
                        int[] ships = { 0, 0, 0, 0 };
                        Color buttonColor = Color.White;
                        char[] schematicMapEditor = Schematic.Map.ToCharArray();
                        for (int c = 0; c < schematicMapEditor.Length; c++)
                        {
                            if (schematicMapEditor[c] == 'M')
                            {
                                schematicMapEditor[c] = 'E';
                            }
                            buttonColor = ColorMethods.SetColorViaChar(schematicMapEditor[c]);
                            switch (schematicMapEditor[c])
                            {
                                case 'F':
                                    {
                                        ships[0]++;
                                        break;
                                    }
                                case 'D':
                                    {
                                        ships[1]++;
                                        break;
                                    }
                                case 'C':
                                    {
                                        ships[2]++;
                                        break;
                                    }
                                case 'B':
                                    {
                                        ships[3]++;
                                        break;
                                    }
                            }
                            Button targetButtom = MapButtons[0, c];
                            targetButtom.BackColor = buttonColor;
                            Array.Resize(ref PlayerData.Map, schematicMapEditor.Length);
                            PlayerData.Map[c] = ColorMethods.SetCharViaColor(0, buttonColor);
                        }
                        Data.ResetDataToZero();
                        PlayerData.FrigatesCountCurrent = ships[0];
                        PlayerData.DestroyersCountCurrent = ships[1] / 2;
                        PlayerData.CruiserCountCurrent = ships[2] / 3;
                        PlayerData.BattleshipCountCurrent = ships[3] / 4;
                        SetPlayerShipsTexBoxesValues();
                    }
                }
                catch
                {
                    playerMapCreated = false;
                }
            }
            if (playerMapCreated)
            {
                DialogResult = MessageBox.Show("Start fight?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    StartBattleShip();
                    SetShipsSunkenToZero();
                    SetAllShipsTextBoxesValues();
                    //SET ENEMY BUTTON COLOR TO WHITE
                    for (int i = 0; i < MapButtons.GetLength(1); i++)
                    {
                        Button targetButton = MapButtons[1, i];
                        targetButton.BackColor = Color.White;
                        
                        //targetButton.Text = $"\"{EnemyData.Map[i]}\" - {i}";
                        targetButton.FlatAppearance.MouseOverBackColor = Color.Orange;
                    }
                }
                else
                {
                    TSMI_StartBattleShip.Enabled = true;
                }
            }
            else
            {
                Fight.GameStarted = false;
            }
        }
        private void TSMI_AllwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = TSMI_AllwaysOnTop.Checked;
        }
        private void TB_Turn_TextChanged(object sender, EventArgs e)
        {
            if (TB_Turn.Text == "Enemy")
            {
                TB_Turn.ForeColor = Color.Firebrick;
            }
            else if (TB_Turn.Text == Options.SP_PlayerName)
            {
                TB_Turn.ForeColor = Color.Lime;
            }
            else
            {
                TB_Turn.ForeColor = Design.DefaultForeColor;

            }
        }
        private void TSMI_GPO_OpenManual_Click(object sender, EventArgs e)
        {
            ManualInfo mi = new ManualInfo();
            mi.Show();
        }
        private void TB_PlayerFrigate_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (Support.StringToInt(textBox.Text, out int value))
            {
                Design.SetTextBoxValues(textBox, value, 0, 4);
            }
            else
            {
                //Error_Catch
            }
            if (Fight.GameStarted && textBox.Text == "0")
            {
                switch (textBox.Name)
                {
                    case "TB_PlayerFrigate":
                        {
                            ShipsSunken[0, 0] = true;
                            break;
                        }
                    case "TB_EnemyFrigate":
                        {
                            ShipsSunken[1, 0] = true;
                            break;
                        }
                }
                CheckShipsSunkenState();
            }

        }
        private void TB_PlayerDestroyer_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (Support.StringToInt(textBox.Text, out int value))
            {
                Design.SetTextBoxValues(textBox, value, 0, 3);
            }
            else
            {
                //Error_Catch
            }
            if (Fight.GameStarted && textBox.Text == "0")
            {
                switch (textBox.Name)
                {
                    case "TB_PlayerDestroyer":
                        {
                            ShipsSunken[0, 1] = true;
                            break;
                        }
                    case "TB_EnemyDestroyer":
                        {
                            ShipsSunken[1, 1] = true;
                            break;
                        }
                }
                CheckShipsSunkenState();
            }
        }
        private void TB_EnemyCruiser_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (Support.StringToInt(textBox.Text, out int value))
            {
                Design.SetTextBoxValues(textBox, value, 0, 2);
            }
            else
            {
                //Error_Catch
            }
            if (Fight.GameStarted && textBox.Text == "0")
            {
                switch (textBox.Name)
                {
                    case "TB_PlayerCruiser":
                        {
                            ShipsSunken[0, 2] = true;
                            break;
                        }
                    case "TB_EnemyCruiser":
                        {
                            ShipsSunken[1, 2] = true;
                            break;
                        }
                }
                CheckShipsSunkenState();
            }
        }
        private void TB_PlayerBattleship_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (Support.StringToInt(textBox.Text, out int value))
            {
                Design.SetTextBoxValues(textBox, value, 0, 1);
            }
            else
            {
                //Error_Catch
            }
            if (Fight.GameStarted && textBox.Text == "0")
            {
                switch (textBox.Name)
                {
                    case "TB_PlayerBattleship":
                        {
                            ShipsSunken[0, 3] = true;
                            break;
                        }
                    case "TB_EnemyBattleship":
                        {
                            ShipsSunken[1, 3] = true;
                            break;
                        }
                }
                CheckShipsSunkenState();
            }
        }
        private void TB_EnemyMiss_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (Support.StringToInt(textBox.Text, out int value))
            {
                if (value > 0)
                {
                    textBox.ForeColor = Color.Red;
                }
                else
                {
                    textBox.ForeColor = Color.Lime;
                }
            }
            else
            {
                //Error_Catch
            }
        }
        private void TB_PlayerHit_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (Support.StringToInt(textBox.Text, out int value))
            {
                if (value < 0)
                {
                    textBox.ForeColor = Color.Red;
                }
                else
                {
                    textBox.ForeColor = Color.Lime;
                }
            }
            else
            {
                //Error_Catch
            }
        }
        public async void RestartGame() //Don't Compete
        {
            Button[,] buttons = MapButtons;
            for (int b = 0; b < buttons.GetLength(1); b++)
            {
                await Task.Delay(0);
                buttons[0, b].BackColor = PNL_PlayerMap_Schema.BackColor;
                buttons[1, b].BackColor = PNL_EnemyMap_Schema.BackColor;
                buttons[0, b].Dispose();
                buttons[1, b].Dispose();
            }
            await GenerateButtons();

        }
        private void TSMI_RestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
        private void TSMI_OpenMapEditor_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Open 'Map Editor'", "Map Editor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.OK)
            {
                MapCreate MCF = new MapCreate();
                if (!DebugTools.MCF.Opened)
                {
                    Design.OpenNewForm(MCF, 1, 6);
                }
            }
        }
        void GetEnemyMap(out int count)
        {
            count = 0;
            try
            {
                HitChanceData.CurrentMap.Clear();
                foreach (Control ctrl in TLP_EnemySchema.Controls)
                {
                    if (ctrl is Button)
                    {
                        HitChanceData.CurrentMap.Add((Button)ctrl);
                    }
                }
                count = HitChanceData.CurrentMap.Count;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message:\r\n{ex.Message}\r\n\r\nException:\r\n{ex}", "Exception Manager");
            }
        }
        void OpenHitChanceForm()
        {
            if (Options.GameModeInt == 0)
            {
                if (HitChanceData.CanOpenForm)
                {
                    if (HitChanceData.FormClosed)
                    {
                        GetEnemyMap(out int count);
                        if (count != 100)
                        {
                            MessageBox.Show("Incorrect count", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (!Fight.GameStarted)
                        {
                            DialogResult = MessageBox.Show("The game has not started, open the selected interface?", "Game Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                HitChance hcf = new HitChance();
                                Design.OpenNewForm(hcf, 1, 6);
                            }
                        }
                        else if (Fight.GameStarted)
                        {
                            HitChance hcf = new HitChance();
                            Design.OpenNewForm(hcf, 1, 6);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Map not created", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BS_HitMoreInfo_Click(object sender, EventArgs e)
        {
            OpenHitChanceForm();
        }
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.C:
                    {
                        OpenHitChanceForm();
                        break;
                    }
            }
        }
        void SetPlayerShipsTexBoxesValues()
        {
            TB_PlayerFrigate.Text = PlayerData.FrigatesCountCurrent.ToString();
            TB_PlayerDestroyer.Text = PlayerData.DestroyersCountCurrent.ToString();
            TB_PlayerCruiser.Text = PlayerData.CruiserCountCurrent.ToString();
            TB_PlayerBattleship.Text = PlayerData.BattleshipCountCurrent.ToString();
            TB_PlayerHit.Text = PlayerData.HitCountCurrent.ToString();
            TB_PlayerMiss.Text = PlayerData.MissedShotsCount.ToString();
        }
        void SetEnemyShipsTexBoxesValues()
        {
            TB_EnemyFrigate.Text = EnemyData.FrigatesCountCurrent.ToString();
            TB_EnemyDestroyer.Text = EnemyData.DestroyersCountCurrent.ToString();
            TB_EnemyCruiser.Text = EnemyData.CruiserCountCurrent.ToString();
            TB_EnemyBattleship.Text = EnemyData.BattleshipCountCurrent.ToString();
            TB_EnemyHit.Text = EnemyData.HitCountCurrent.ToString();
            TB_EnemyMiss.Text = EnemyData.MissedShotsCount.ToString();
        }
        void SetAllShipsTextBoxesValues()
        {
            SetEnemyShipsTexBoxesValues();
            SetPlayerShipsTexBoxesValues();
        }
        void CoordsForcedOverwrite()
        {
            int[] count = new int[2];
            count[0] = Fight.ForbiddenCoords.Count;
            Fight.ForbiddenCoords.Clear();
            HashSet<int> forbidden = new HashSet<int>();
            for (int i = 0; i < MapButtons.GetLength(1); i++)
            {
                if ((MapButtons[0, i].BackColor == Color.Red) || (MapButtons[0, i].BackColor == Color.Firebrick) || (MapButtons[0, i].BackColor == Color.DeepSkyBlue))
                {
                    forbidden.Add(PlayerData.Map[i]);
                }
            }
            Fight.ForbiddenCoords = new List<int>(forbidden);
            count[1] = Fight.ForbiddenCoords.Count;
            if (count[0] == count[1])
            {
                MessageBox.Show("Forbidden data error", "Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void SetStatusTurnText(Button selectedButton)
        {
            if (Fight.GameStarted)
            {
                if (Fight.Turn == 1)
                {
                    TB_TurnStatus.Text = "Move not available";
                    TB_TurnStatus.ForeColor = Color.Red;
                }
                else if (Fight.Turn == 0)
                {
                    switch (selectedButton.BackColor.Name.ToString())
                    {
                        case "Red":
                            {
                                TB_TurnStatus.Text = "Hited ship deck";
                                TB_TurnStatus.ForeColor = Color.Yellow;
                                break;
                            }
                        case "Firebrick":
                            {
                                TB_TurnStatus.Text = "Sunken ship";
                                TB_TurnStatus.ForeColor = Color.Orange;
                                break;
                            }
                        case "DeepSkyBlue":
                            {
                                TB_TurnStatus.Text = "Enmpty cell";
                                TB_TurnStatus.ForeColor = Color.DeepSkyBlue;
                                break;
                            }
                        case "White":
                            {
                                TB_TurnStatus.Text = "Available move";
                                TB_TurnStatus.ForeColor = Color.Lime;
                                break;
                            }
                        case "Green":
                            {
                                TB_TurnStatus.Text = "Undiscovered ship";
                                TB_TurnStatus.ForeColor = Color.Lime;
                                break;
                            }
                    }
                }
            }
        }
    }
}