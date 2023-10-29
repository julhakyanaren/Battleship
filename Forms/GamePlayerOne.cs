using Battleship.Forms;
using System;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class GamePlayerOne : Form
    {
        Position Position = new Position();
        Map Map = new Map();
        Support Support = new Support();
        ColorMethods ColorMethods = new ColorMethods();
        public GamePlayerOne()
        {
            InitializeComponent();
        }
        Button[,] MapButtons = new Button[2, 100];
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
            Design.SetComponentLocation(L_Info_Turn, PNL_InfoTurn);
            Design.SetComponentLocation(TB_Turn, PNL_InfoTurn);
            L_Info_PlayerScore.Text = $"Score: {Options.SP_PlayerName}";
            TSMI_Difficulty_Level.Text = Options.DifficultyName;
            TB_DIfficulty.Text = Options.DifficultyName;
            switch (Options.Difficulty)
            {
                case 0:
                    {
                        TB_DIfficulty.ForeColor = Color.Lime;
                        break;
                    }
                case 1:
                    {
                        TB_DIfficulty.ForeColor = Color.Yellow;
                        break;
                    }
                case 2:
                    {
                        TB_DIfficulty.ForeColor = Color.Red;
                        break;
                    }
                case 3:
                    {
                        TB_DIfficulty.ForeColor = Color.DarkRed;
                        break;
                    }
                default:
                    {
                        TB_DIfficulty.ForeColor = Design.DefaultForeColor;
                        break;
                    }
            }
            if (Options.Difficulty != 3)
            {
                TB_DIfficulty.Font = new Font("Franklin Gothic Medium", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
                TSMI_Difficulty_Level.Font = new Font("Franklin Gothic Medium", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            else
            {
                TB_DIfficulty.Font = new Font("Franklin Gothic Demi", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
                TSMI_Difficulty_Level.Font = new Font("Franklin Gothic Demi", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            TSMI_Difficulty_Level.ForeColor = TB_DIfficulty.ForeColor;
            TSMI_ChancePercent.Text = $"{Fight.SuccessThreshold(Options.Difficulty) * 100} %";
            if (DebugTools.DebugMode)
            {
                TSMI_DEBUG.Visible = true;
            }
        }
        private void GamePlayerOne_Load(object sender, EventArgs e)
        {
            SetScreenParametersAsMaximized();
            Design.ChangeControlElementsForeColor(this, Design.DefaultForeColor, DefaultBackColor);
            SetComponentCustomParamaters();
        }
        async void GenerateButtons()
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
                }
            }
            for (int id = 0; id < MapButtons.GetLength(0); id++)
            {
                Map.SetShipCharThrowColor(id, MapButtons);
            }
            Array.Resize(ref PlayerData.Map, MapButtons.GetLength(1));
            Array.Resize(ref EnemyData.Map, MapButtons.GetLength(1));
            for (int vb = 0; vb < 100; vb++)
            {
                await Task.Delay(0);
                MapButtons[0, vb].Visible = true;
                MapButtons[1, vb].Visible = true;
            }
            TSMI_Map.Enabled = true;
        }
        private void Button_Click(object sender, MouseEventArgs e)
        {
            Button clickedButton = sender as Button;
            string tagButton = clickedButton.Tag.ToString();
            Position.GetCoordsFromTag(tagButton, out int x, out int y, out int playerID);
            if (playerID == 2)
            {
                if (Fight.GameStarted)
                {
                    NextTurn(tagButton);
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
                EnemyData.Map[i] = ColorMethods.SetCharThrowColor(1, targetButton.BackColor);
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
            Data.ResetDataToDefault();
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
                            break;
                        }
                }
            }
        }
        public void SetStatusTextBoxesValues()
        {
            TB_PlayerFrigate.Text = PlayerData.FrigatesCountCurrent.ToString();
            TB_EnemyFrigate.Text = EnemyData.FrigatesCountCurrent.ToString();
            TB_PlayerDestroyer.Text = PlayerData.DestroyersCountCurrent.ToString();
            TB_EnemyBattleship.Text = EnemyData.DestroyersCountCurrent.ToString();
            TB_PlayerCruiser.Text = PlayerData.CruiserCountCurrent.ToString();
            TB_EnemyDestroyer.Text = EnemyData.CruiserCountCurrent.ToString();
            TB_PlayerBattleship.Text = PlayerData.BattleshipCountCurrent.ToString();
            TB_EnemyCruiser.Text = EnemyData.BattleshipCountCurrent.ToString();
            TB_PlayerHit.Text = PlayerData.HitCountCurrent.ToString();
            TB_EnemyHit.Text = EnemyData.HitCountCurrent.ToString();
            TB_PlayerMiss.Text = PlayerData.MissedShotsCount.ToString();
            TB_EnemyMiss.Text = EnemyData.MissedShotsCount.ToString();

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
                    Fight.PlayerHited = !IsCellWhite(index, out char celChar);
                    Fight.Turn = Fight.ReverseTurn(Fight.PlayerHited);
                    if (celChar != 'e')
                    {
                        PlayerData.HitCountCurrent++;
                        switch (celChar)
                        {
                            case 'f':
                                {
                                    EnemyData.FrigatesCountCurrent--;
                                    MapButtons[1, index].BackColor = Color.Red;
                                    break;
                                }
                            case 'd':
                                {
                                    MapButtons[1, index].BackColor = Color.Red;
                                    break;
                                }
                            case 'c':
                                {
                                    MapButtons[1, index].BackColor = Color.Red;
                                    break;
                                }
                            case 'b':
                                {
                                    MapButtons[1, index].BackColor = Color.Red;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        PlayerData.MissedShotsCount++;
                        MapButtons[1, index].BackColor = Color.DeepSkyBlue;
                    }
                    SetStatusTextBoxesValues();
                }
                else
                {
                    //Error_Catch
                }
            }
            else if (Fight.Turn == 1)
            {
                if (Fight.EnemyShot(out string targetTag, out bool successShot, out bool alreadyHited))
                {
                    if (successShot)
                    {
                        ShowHitInfo();
                    }
                    else
                    {

                    }
                }
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
        private void TSMI_StartNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateButtons();
                TSMI_MapEditor.Enabled = true;
            }
            catch
            {
                //Error_Catch
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
                            buttonColor = ColorMethods.SetColorThrowChar(schematicMapEditor[c]);
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
                            PlayerData.Map[c] = ColorMethods.SetCharThrowColor(0, buttonColor);
                        }
                        Data.ResetDataToDefault();
                        PlayerData.FrigatesCountCurrent = ships[0];
                        PlayerData.DestroyersCountCurrent = ships[1] / 2;
                        PlayerData.CruiserCountCurrent = ships[2] / 3;
                        PlayerData.BattleshipCountCurrent = ships[3] / 4;
                        SetStatusTextBoxesValues();
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
                    TB_EnemyFrigate.Text = "0";
                    TB_PlayerFrigate.Text = "0";
                    TB_EnemyDestroyer.Text = "0";
                    TB_PlayerDestroyer.Text = "0";
                    TB_EnemyCruiser.Text = "0";
                    TB_PlayerCruiser.Text = "0";
                    TB_EnemyBattleship.Text = "0";
                    TB_PlayerBattleship.Text = "0";
                    TB_EnemyHit.Text = "0";
                    TB_PlayerHit.Text = "0";
                    TB_PlayerMiss.Text = "0";
                    TB_PlayerMiss.Text = "0";
                    StartBattleShip();
                    //SET ENEMY BUTTON COLOR TO WHITE
                    for (int i = 0; i < MapButtons.GetLength(1); i++)
                    {
                        Button targetButton = MapButtons[1, i];
                        //targetButton.BackColor = Color.White;
                        targetButton.Text = $"\"{EnemyData.Map[i]}\" - {i}";
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
        private void TSMI_OpenMapEditor_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Open 'Map Editor'", "Map Editor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.OK)
            {
                MapCreate MCF = new MapCreate();
                if (!DebugTools.MCF.Opened)
                {
                    MCF.Show();
                }
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

        private void TSMI_ShowEnemyShipsCoords_Click(object sender, EventArgs e)
        {
            try
            {
                if (DebugTools.DebugMode)
                {
                    string f_coords = "Frigates:\r\n";
                    string d_coords = "Destroyers:\r\n";
                    string c_coords = "Cruisers:\r\n";
                    string b_coords = "Battleships\r\n";
                    for (int f = 0; f < 4; f++)
                    {
                        f_coords += $"{EnemyData.FrigateCoords[f, 0]}\t";
                        f_coords += Position.TextCoordThrowIndex(EnemyData.FrigateCoords[f, 0]) + "\r\n";
                    }
                    for (int d0 = 0; d0 < 3; d0++)
                    {
                        for (int d1 = 0; d1 < 2; d1++)
                        {
                            d_coords += $"{EnemyData.DestroyerCoords[d0, d1]}\t";
                            d_coords += Position.TextCoordThrowIndex(EnemyData.DestroyerCoords[d0,d1]) + "\r\n";
                        }
                        d_coords += "////\r\n";
                    }
                    for (int c0 = 0; c0 < 2; c0++)
                    {
                        for (int c1 = 0; c1 < 3; c1++)
                        {
                            c_coords += $"{EnemyData.CruiserCoords[c0, c1]}\t";
                            c_coords += Position.TextCoordThrowIndex(EnemyData.CruiserCoords[c0, c1]) + "\r\n";
                        }
                        c_coords += "////\r\n";
                    }
                    for (int b = 0; b < 4; b++)
                    {
                        b_coords += $"{EnemyData.BattleshipCoords[0, b]}\t";
                        b_coords += Position.TextCoordThrowIndex(EnemyData.BattleshipCoords[0, b]) + "\r\n";
                    }
                    string message = $"{f_coords}\r\n{d_coords}\r\n{c_coords}\r\n{b_coords}";
                    MessageBox.Show($"{message}", "Battleship Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex1)
            {
                MessageBox.Show($"{ex1}", "Exception",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void TSMI_GPO_OpenManual_Click(object sender, EventArgs e)
        {
            ManualInfo mi = new ManualInfo();
            mi.Show();
        }
        public async void ShowHitInfo()
        {
            HitStatus hs = new HitStatus();
            hs.Show();
            await Task.Delay(2000);
            hs.Hide();
            hs.Dispose();
        }
        private void TSMI_ShowHitInfo_Click(object sender, EventArgs e)
        {
            ShowHitInfo();
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
    }
}