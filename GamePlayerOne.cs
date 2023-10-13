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

        void GenerateButtons()
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
                    //targetButton.Text = targetButton.Name.ToString();
                    button.Click += Button_Click;
                    //button.MouseLeave += Button_MouseLeave;
                    button.MouseEnter += Button_MouseEnter;
                    MapButtons[f, b] = button;
                    button.FlatAppearance.MouseOverBackColor = Design.MouseOverColor[f];
                }
            }
            for (int id = 0; id < MapButtons.GetLength(0); id++)
            {
                Map.SetShipCharThrowColor(id, MapButtons);
            }
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
        private void BS_Test_Generate_Click(object sender, EventArgs e)
        {
            GenerateButtons();
            BS_Test_Generate.Enabled = false;
        }

        private void GamePlayerOne_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);  
        }
        private void BS_Test_GenerateMap_Click(object sender, EventArgs e)
        {
            ResetEnemyMap(MapButtons);
            char[,] enemyMap = Map.GenerateEnemyMap(MapButtons);
            Button[] enemyButtons = Support.GetEnemyButtons(MapButtons);
            SetEnemyButtonsColors(enemyButtons, enemyMap);
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

        private void SwitchShipPlaceMode(object sender, EventArgs e)
        {
            RadioButton checkedRadioButton = sender as RadioButton;
            if (checkedRadioButton.Checked)
            {
                switch (Convert.ToInt32(checkedRadioButton.Tag))
                {
                    case 1:
                        {
                            Data.ShipPlaceMode = "Frigate";
                            break;
                        }
                    case 2:
                        {
                            Data.ShipPlaceMode = "Destroyer";
                            break;
                        }
                    case 3:
                        {
                            Data.ShipPlaceMode = "Cruiser";
                            break;
                        }
                    case 4:
                        {
                            Data.ShipPlaceMode = "Battleship";
                            break;
                        }
                    default:
                        {
                            Data.ShipPlaceMode = "None";
                            break;
                        }
                }
            }
        }

        private void TSMI_MM_Settings_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Open \'Setting Manager?\'", "Settings Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (dr)
            {
                case DialogResult.Yes:
                    {
                        MessageBox.Show("Plugin don't included", "Settings Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
            }
        }
    }
}