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

        public Button[,] MapButtons = new Button[2, 100];

        public bool[,] ShipsSunken = new bool [2, 4];
        public bool[] AllShipSunken = {false, false};
        public GameForm()
        {
            InitializeComponent();
        }
        private void SetFormAllwaysOnTop(object sender, EventArgs e)
        {
            TopMost = TSMI_AllwaysOnTop.Checked;
        }//
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
        }//
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
                    button.MouseEnter += CellEnter;
                    button.MouseClick += ClickOnCell;
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
                MapButtons[1, vb].Visible = true;
            }
            TSMI_Map.Enabled = true;
        }//
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
            SetComponentCustomParamaters();
            if (Fight.UnusedCoords.Count == 0)
            {
                Fight.SetUnusedCoord();
            }
            Text = $"Battleship  {DebugTools.Version}.{DebugTools.RunsCount}";
        }
        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        DialogResult GameOverMessages(bool playerLose)
        {
            if (playerLose)
            {
                return MessageBox.Show("All your ships are destroyed, and the enemy has surviving ships.\r\nGame over. You lose!", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return MessageBox.Show("All enemy ships are destroyed, and you have surviving ships.\r\nGame over. You Win!", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void ShowEnemyMapAfterGame()
        {
            for (int i = 0; i < MapButtons.GetLength(1); i++)
            {
                if (MapButtons[1, i].BackColor != Color.White)
                {
                    continue;
                }
                char mapChar = Char.ToLower(EnemyData.Map[i]);
                if (mapChar == 'e' || mapChar == 'n')
                {
                    continue;
                }
                MapButtons[1, i].BackColor = Color.Green;
            }
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
                        Options.GameOver = true;
                        return "Game Over";
                    }
                default:
                    {
                        return "ERROR";
                    }
            }
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
                if (GameOverMessages(true) == DialogResult.OK)
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
                if (GameOverMessages(false) == DialogResult.OK)
                {
                    ShowPlayerMapAfterGame();
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
        private void Frigates_TB_Change(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (Support.StringToInt(textBox.Text, out int value))
            {
                Design.SetTextBoxValues(textBox, value, 0, 4);
            }
            else
            {
                MessageBox.Show($"Error Code: E20M9L4\r\n{textBox.Text} String type to Int32 type converting error", $"{Handlers.Manager[9]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void Destroyers_TB_Change(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (Support.StringToInt(textBox.Text, out int value))
            {
                Design.SetTextBoxValues(textBox, value, 0, 3);
            }
            else
            {
                MessageBox.Show($"Error Code: E21M9L4\r\n{textBox.Text} String type to Int32 type converting error", $"{Handlers.Manager[9]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void Cruisers_TB_Change(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (Support.StringToInt(textBox.Text, out int value))
            {
                Design.SetTextBoxValues(textBox, value, 0, 2);
            }
            else
            {
                MessageBox.Show($"Error Code: E22M9L4\r\n{textBox.Text} String type to Int32 type converting error", $"{Handlers.Manager[9]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void Battleships_TB_Change(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (Support.StringToInt(textBox.Text, out int value))
            {
                Design.SetTextBoxValues(textBox, value, 0, 1);
            }
            else
            {
                MessageBox.Show($"Error Code: E23M9L4\r\n{textBox.Text} String type to Int32 type converting error", $"{Handlers.Manager[9]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void Miss_TB_Change(object sender, EventArgs e)
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
                MessageBox.Show($"Error Code: E24M9L4\r\n{textBox.Text} String type to Int32 type converting error", $"{Handlers.Manager[9]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Hit_TB_Change(object sender, EventArgs e)
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
                MessageBox.Show($"Error Code: E25M9L4\r\n{textBox.Text} String type to Int32 type converting error", $"{Handlers.Manager[9]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        string position = Position.GetCellPosition(Fight.FindCorrectTagCoord(index, true).ToString());
                        Fight.GenerateBlockedCoords(position, index);
                        for (int bl = 0; bl < EnemyData.BlockedCoords.Count; bl++)
                        {
                            EnemyData.Map[EnemyData.BlockedCoords[bl]] = 'M';
                        }
                        PlayerData.HitCountCurrent++;
                    }
                    if (sunkenFrigate)
                    {
                        string position = Position.GetCellPosition(Fight.FindCorrectTagCoord(index, true).ToString());
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
                    MessageBox.Show($"Error Code: E19M9L4\r\n{buttonTag} String type to Int32 type converting error", $"{Handlers.Manager[9]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        async Task NotAvailableMove(int index, int size = 1, int steps = 5, int colorIndex = 0, int duration = 120, bool changeStatus = false, string statusText = null)
        {
            int defaultSize = 1;
            int changedSize = defaultSize + size;
            string oldText = TB_TurnStatus.Text;
            Color oldColor = TB_TurnStatus.ForeColor;
            Color defaultColor = Color.Black;
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
            else
            {
                MessageBox.Show($"Error Code: E29M9L4\r\n{index} String type to Int32 type converting error", $"{Handlers.Manager[9]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return -1;
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
                        MessageBox.Show($"Error Code: E16M4L1\r\nUncertain next move", $"{Handlers.Manager[4]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        TB_Turn.Text = SetTurnText();
                    }
                }
            }
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
                        MessageBox.Show($"Error Code: E17M4L1\r\nUncertain next move", $"{Handlers.Manager[4]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        TB_Turn.Text = SetTurnText();
                    }
                }
                catch
                {
                    MessageBox.Show($"Error Code: E18M4L3\r\nColor scheme updating error", $"{Handlers.Manager[4]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (ShipData.HitedDeckCount == 20)
            {
                Options.GameOver = true;
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
                    forbidden.Add(i);
                }
            }
            Fight.ForbiddenCoords = new List<int>(forbidden);
            count[1] = Fight.ForbiddenCoords.Count;
            if (count[0] == count[1])
            {
                MessageBox.Show("Forbidden coords data error", "Battleship", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                TB_TurnStatus.Text = "The map has not yet been built";
                TB_TurnStatus.ForeColor = Color.OrangeRed;
            }
        }
        private async void ClickOnCell(object sender, MouseEventArgs e)
        {
            if (!Options.GameOver)
            {
                Button clickedButton = sender as Button;
                int playerID;
                string coord = Position.GetButtonTextCoords(clickedButton, out playerID);
                if (Support.StringToInt(clickedButton.Tag.ToString(), out int tagCB))
                {
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
                else
                {
                    MessageBox.Show($"Error Code: E26M9L4\r\n{clickedButton.Tag} String type to Int32 type converting error", $"{Handlers.Manager[9]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void CellEnter(object sender, EventArgs e)
        {
            await Task.Delay(0);
            Button selectedButton = sender as Button;
            string tagButton = Support.GetTagFromButton(selectedButton);
            Position.GetCoordsFromTag(tagButton, out int x, out int y, out int playerID);
            string textID = Position.GetButtonTextCoords(selectedButton, out playerID);
            int index = playerID - 1;
            Button[] targetButtons = new Button[MapButtons.GetLength(1)];
            switch (index)
            {
                case 0:
                    {
                        targetButtons = Support.GetPlayerButtons(MapButtons);
                        BS_PlayerSchema_Index.Text = textID;
                        PlayerData.Map = Data.TargetButtonsToCharArray(targetButtons, playerID);
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
        public void ResetEnemyMap(Button[,] buttons)
        {
            Button[] enemyButtons = Support.GetEnemyButtons(buttons);
            for (int b = 0; b < enemyButtons.Length; b++)
            {
                enemyButtons[b].BackColor = Color.White;
            }
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
        private void TSMI_GenerationType_CheckedChanged(object sender, EventArgs e)
        {
            switch (TSMI_GenerationType.Checked)
            {
                case true:
                    {
                        TSMI_TB_GenType.Text = "Generate random map";
                        break;
                    }
                case false:
                    {
                        TSMI_TB_GenType.Text = "Generate with schematic";
                        break;
                    }
            }
            Data.RandomMap = TSMI_GenerationType.Checked;
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
                            MessageBox.Show("   ", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        private void BS_HitMoreInfo_Click(object sender, EventArgs e)
        {
            OpenHitChanceForm();
        }
        private void TSMI_GF_OpenManual_Click(object sender, EventArgs e)
        {
            ManualInfo mi = new ManualInfo();
            mi.Show();
        }
        private void TSMI_OpenMapEditor_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Open 'Map Editor'?", "Map Editor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && !MCF.Opened)
            {
                MapCreate MCF = new MapCreate();
                Design.OpenNewForm(MCF, 1, 6);
            }
        }
        public async void StartBattleShip()
        {
            GenerateEnemyRandomMap();
            for (int i = 0; i < MapButtons.GetLength(1); i++)
            {
                Button targetButton = MapButtons[1, i];
                Array.Resize(ref EnemyData.Map, MapButtons.GetLength(1));
                EnemyData.Map[i] = ColorMethods.SetCharViaColor(1, targetButton.BackColor);
            }
            string pm = new string(PlayerData.Map).Replace('N', 'E');
            string em = new string(EnemyData.Map).Replace('n', 'e');
            PlayerData.Map = pm.ToCharArray();
            EnemyData.Map = em.ToCharArray();
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
                            Fight.Turn = 0;
                            break;
                        }
                    case 1:
                        {
                            TB_Turn.Text = "Enemy";
                            Fight.FirstTurn = true;
                            Fight.Turn = 1;
                            do
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
                            while (Fight.Turn == 1);                            
                            break;
                        }
                    default:
                        {
                            TB_Turn.Text = "Error";
                            break;
                        }
                }
            }
        }
        private void TSMI_StartBattleShip_Click(object sender, EventArgs e)
        {
            StartBattleShip();
            Button targetButton;
            for (int i = 0; i < MapButtons.GetLength(1); i++)
            {
                targetButton = MapButtons[1, i];
                targetButton.BackColor = Color.White;
                targetButton.FlatAppearance.MouseOverBackColor = Color.Orange;
            }
            TSMI_RestartGame.Visible = true;
            TSMI_Map.Enabled = false;
            TSMI_StartBattleShip.Visible = false;
        }
        private async void TSMI_StartNewGame_Click(object sender, EventArgs e)
        {
            TSMI_StartNewGame.Enabled = false;
            if (PlayerData.Map == null)
            {
                try
                {
                    await GenerateButtons();
                    TSMI_Map.Enabled = true;
                    TSMI_OpenMapEditor.Enabled = true;
                    TSMI_RestartGame.Enabled = true;
                    HitChanceData.CanOpenForm = true;
                    TSMI_StartNewGame.Visible = false;
                    TSMI_StartBattleShip.Visible = true;
                }
                catch
                {
                    MessageBox.Show($"Error Code: E34M4L5\r\nGame map creating error", $"{Handlers.Manager[4]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TSMI_StartNewGame.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Maps allready created!", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }                        
        private void TSMI_GenerateMap_Click(object sender, EventArgs e)
        {
            bool playerMapCreated = true;
            if (Data.RandomMap == true)
            {
                try
                {
                    GeneratePlayerRandomMap();
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
                    if (!Data.CorrectSchematic)
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
                        Data.SchematicMap = Data.SchematicMap.Replace('M', 'E');
                        char[] schematicMapEditor = Data.SchematicMap.ToCharArray();
                        for (int c = 0; c < schematicMapEditor.Length; c++)
                        {
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
                            Button targetButton = MapButtons[0, c];
                            targetButton.BackColor = buttonColor;
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
                if (MessageBox.Show("Start fight?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    StartBattleShip();
                    SetAllShipsTextBoxesValues();
                    for (int i = 0; i < MapButtons.GetLength(1); i++)
                    {
                        Button targetButton = MapButtons[1, i];
                        targetButton.BackColor = Color.White;
                        //targetButton.Text = $"\"{EnemyData.Map[i]}\" - {i}";
                        targetButton.FlatAppearance.MouseOverBackColor = Color.Orange;
                    }
                    TSMI_RestartGame.Visible = true;
                    TSMI_Map.Enabled = false;
                    TSMI_StartBattleShip.Visible = false;
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
        async Task ResetMapVisual()
        {
            Button[,] buttons = MapButtons;
            for (int b = buttons.GetLength(1) - 1; b >= 0; b--)
            {
                await Task.Delay(1);
                buttons[0, b].BackColor = Color.Black;
                await Task.Delay(0);
                buttons[0, b].Dispose();
                await Task.Delay(1);
                buttons[1, b].BackColor = Color.Black;
                await Task.Delay(0);
                buttons[1, b].Dispose();
            }
            await GenerateButtons();
        }
        void ResetMapFunctional()
        {
            PlayerData.IndependentChances.Clear();
            EnemyData.IndependentChances.Clear();
            Fight.ForbiddenCoords.Clear();
            Fight.UnusedCoords.Clear();
            Fight.SetUnusedCoord();
        }
        public async Task RestartGame()
        {
            TSMI_RestartGame.Enabled = false;
            await ResetMapVisual();
            ResetMapFunctional();
            TSMI_Map.Enabled = true;
        }
        private async void TSMI_RestartGame_Click(object sender, EventArgs e)
        {
           await RestartGame();
        }
    }
}