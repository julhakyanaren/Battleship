using System;
using System.CodeDom;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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
            Location = new Point(0,0);
            MaximizeBox = false;
        }
        private void GamePlayerOne_Load(object sender, EventArgs e)
        {
            SetScreenParametersAsMaximized();
            /**/
            Design.ChangeControlElementsForeColor(this, Design.DefaultForeColor, DefaultBackColor);
            /**/
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
                    button.Click += Button_Click;
                    button.MouseEnter += Button_MouseEnter;
                    MapButtons[f, b] = button;
                    button.FlatAppearance.MouseOverBackColor = Design.MouseOverColor[f];
                }
            }
            for (int id = 0; id < MapButtons.GetLength(0); id++)
            {
                Map.SetShipCharThrowColor(id, MapButtons);
            }
            for (int vb = 0; vb < 100; vb++)
            {
                await Task.Delay(1);
                MapButtons[0, vb].Visible = true;
                MapButtons[1, vb].Visible = true;
            }
            CHB_RandomMapGenerate.Visible = true;
            BS_GeneratePlayerMap.Visible = true;
        }

        private async void Button_MouseEnter(object sender, EventArgs e)
        {
            await Task.Delay(0);
            Button selectedButton = sender as Button;
            if (DebugTools.DebugMode)
            {
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
                            targetButtons = Support.GetEnemyButtons(MapButtons);
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
            else
            {

            }
        }

        public void ClearOldMarking()
        {

            for (int b = 0; b < MapButtons.GetLength(1); b++)
            {
                MapButtons[0, b].BackColor = Color.White;
                MapButtons[0, b].FlatAppearance.BorderColor = Color.Black;
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
        public void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (DebugTools.DebugMode)
            {
                Support.StringToInt(Support.GetTagFromButton(clickedButton), out int tag);
                if (tag / 100 == 1)
                {
                    Button[] playerButtons = Support.GetPlayerButtons(MapButtons);
                    Color shipColor = Design.MouseOverColor[0];
                    foreach (Button button in playerButtons)
                    {
                        switch (Data.ShipPlaceMode)
                        {
                            case "Frigate":
                                {
                                    shipColor = Design.ShipsColor[0];
                                    break;
                                }
                            case "Destroyer":
                                {
                                    shipColor = Design.ShipsColor[1];
                                    break;
                                }
                            case "Cruiser":
                                {
                                    shipColor = Design.ShipsColor[2];
                                    break;
                                }
                            case "Battleship":
                                {
                                    shipColor = Design.ShipsColor[3];
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        if (button.ForeColor == Design.MouseOverColor[0])
                        {
                            button.ForeColor = shipColor;
                            button.FlatAppearance.BorderColor = Color.Black;
                        }
                    }
                }
            }
            else
            {
                if (Support.StringToInt(Support.GetTagFromButton(clickedButton), out int tag) && tag / 100 == 1)
                {
                    MapCreate MCF = new MapCreate();
                    if (!DebugTools.MCF.Opened)
                    {
                        MCF.Show();
                    }
                }
            }

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
            /**/
            TB_PlayerFrigate.Text = $"{PlayerData.FrigatesCountCurrent}";
            TB_PlayerDestroyer.Text = $"{PlayerData.DestroyersCountCurrent}";
            TB_PlayerCruiser.Text = $"{PlayerData.CruiserCountCurrent}";
            TB_PlayerBattleship.Text = $"{PlayerData.BattleshipCountCurrent}";
        }
        public void SetEnemyButtonsColors(Button[] enemyButtons, char[,]enemyMap)
        {
            EnemyData.ResetShipsCount();
            char[] map = Support.CharArrayRedimension(enemyMap);
            Color[] colors = ColorMethods.SetButtonColors(map);
            for (int b = 0; b < enemyButtons.Length; b++)
            {
                enemyButtons[b].BackColor = colors[b];
            }
            Map.SetShipsCountThrowMap(map);
            /**/
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
                for(int b =  0; b < playerButtons.Length; b++)
                {
                    playerButtons[b].BackColor = Color.White;
                }
            }
        }
        private void CHB_RandomMapGenerate_CheckedChanged(object sender, EventArgs e)
        {
            switch (CHB_RandomMapGenerate.Checked)
            {
                case true:
                    {
                        Data.RandomMap = true;
                        BS_GeneratePlayerMap.Text = "Generate random map";
                        break;
                    }
                case false:
                    {
                        BS_GeneratePlayerMap.Text = "Generate map";
                        Data.RandomMap = false;
                        break;
                    }
            }
        }

        private void BS_GeneratePlayerMap_Click(object sender, EventArgs e)
        {
            if (Data.RandomMap == true)
            {
                //Check
                for (int j = 0; j < 2; j++)
                {
                    int i = 1;
                    while (true)
                    {
                        if (i > 0)
                        {
                            GeneratePlayerRandomMap();
                            GenerateEnemyRandomMap();
                            i--;
                        }
                        else
                        {
                            GenerateEnemyRandomMap();
                            break;
                        }
                    }
                }
            }
            else
            {
                if (!Schematic.CorrectSchematic)
                {
                    DialogResult = MessageBox.Show("Schematic map not complete generation not possible", "Map Editor", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {

                }
            }
        }

        private void TSMI_StartNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateButtons();
            }
            catch
            {
                //Error_Catch
            }
        }
    }
}