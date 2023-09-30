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
                    button.MouseHover += Button_MouseHover;
                    button.MouseLeave += Button_MouseLeave;
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
        public void ClearOldMarking()
        {
            char[] playerMap = Support.CharArrayRedimension(Map.MapPlayer);
            for (int b = 0; b < MapButtons.GetLength(1); b++)
            {
                MapButtons[0, b].BackColor = ColorMethods.SetColorThrowChar(playerMap[b]);
                MapButtons[0, b].FlatAppearance.BorderColor = Color.Black;
            }
        }
        private async void Button_MouseEnter(object sender, EventArgs e)
        {
            await Task.Delay(0);
            bool orientationChanged = false;
            Button selectedButton = sender as Button;
            string tip = Position.GetButtonTextCoords(selectedButton, out int playerID);
            string tag = Support.GetTagFromButton(selectedButton);
            int delta;
            switch (playerID - 1)
            {
                case 0:
                    {
                        Button[] playerButtons = Support.GetPlayerButtons(MapButtons);
                        BS_PlayerSchema_Index.Text = tip;
                        if (Data.ShipPlaceMode == "Frigate" || Data.ShipPlaceMode == "None")
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
                            ClearOldMarking();
                        }
                        switch (Data.ShipPlaceMode)
                        {
                            case "Frigate":
                                {
                                    selectedButton.BackColor = Design.SelectedColorPlayer[0];
                                    selectedButton.ForeColor = Design.SelectedColorPlayer[1];
                                    selectedButton.FlatAppearance.BorderColor = Design.BorderColor[playerID - 1];
                                    break;
                                }
                            case "Destroyer":
                                {
                                    selectedButton.BackColor = Design.MouseOverColor[playerID - 1];
                                    selectedButton.FlatAppearance.BorderColor = Design.BorderColor[playerID - 1];
                                    string position = Position.GetCellPosition(tag);
                                    switch (position)
                                    {
                                        case "center":
                                            {
                                                if (Support.StringToInt(tag, out int currentTag))
                                                {
                                                    switch (Data.Orientation)
                                                    {
                                                        case "H":
                                                            {
                                                                delta = 10;
                                                                break;
                                                            }
                                                        case "V":
                                                            {
                                                                delta = -1;
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                delta = 0;
                                                                break;
                                                            }
                                                    }
                                                    int nextTag1 = currentTag + delta;
                                                    foreach (Button button in playerButtons)
                                                    {
                                                        if ((int)button.Tag == nextTag1)
                                                        {
                                                            int index = Array.IndexOf(playerButtons, button);
                                                            playerButtons[index].BackColor = Design.MouseOverColor[playerID - 1];
                                                            playerButtons[index].FlatAppearance.BorderColor = Design.BorderColor[playerID - 1];
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //Error_Catch
                                                }
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case "Cruiser":
                                {
                                    selectedButton.BackColor = Design.MouseOverColor[playerID - 1];
                                    selectedButton.FlatAppearance.BorderColor = Design.BorderColor[playerID - 1];
                                    string position = Position.GetCellPosition(tag);
                                    switch (position)
                                    {
                                        case "center":
                                            {
                                                if (Support.StringToInt(tag, out int currentTag))
                                                {
                                                    switch (Data.Orientation)
                                                    {
                                                        case "H":
                                                            {
                                                                delta = 10;
                                                                break;
                                                            }
                                                        case "V":
                                                            {
                                                                delta = -1;
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                delta = 0;
                                                                break;
                                                            }
                                                    }
                                                    int nextTag1 = currentTag + delta;
                                                    int nextTag2 = currentTag + (2 * delta);
                                                    if (Position.IsValidShipPosition(position,Data.ShipPlaceMode,Data.Orientation, tag))
                                                    {
                                                        foreach (Button button in playerButtons)
                                                        {
                                                            if ((int)button.Tag == nextTag1)
                                                            {
                                                                int index = Array.IndexOf(playerButtons, button);
                                                                playerButtons[index].BackColor = Design.MouseOverColor[playerID - 1];
                                                                playerButtons[index].FlatAppearance.BorderColor = Design.BorderColor[playerID - 1];
                                                            }
                                                            if ((int)button.Tag == nextTag2)
                                                            {
                                                                int index = Array.IndexOf(playerButtons, button);
                                                                playerButtons[index].BackColor = Design.MouseOverColor[playerID - 1];
                                                                playerButtons[index].FlatAppearance.BorderColor = Design.BorderColor[playerID - 1];
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //Error_Catch
                                                }
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case "Battleship":
                                {
                                    selectedButton.BackColor = Design.MouseOverColor[playerID - 1];
                                    selectedButton.FlatAppearance.BorderColor = Design.BorderColor[playerID - 1];
                                    string position = Position.GetCellPosition(tag);
                                    switch (position)
                                    {
                                        case "center":
                                            {
                                                if (Support.StringToInt(tag, out int currentTag))
                                                {
                                                    switch (Data.Orientation)
                                                    {
                                                        case "H":
                                                            {
                                                                delta = 10;
                                                                break;
                                                            }
                                                        case "V":
                                                            {
                                                                delta = -1;
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                delta = 0;
                                                                break;
                                                            }
                                                    }
                                                    int nextTag1 = currentTag + delta;
                                                    int nextTag2 = currentTag + (2 * delta);
                                                    int nextTag3 = currentTag + (3 * delta);
                                                    if (Position.IsValidShipPosition(position,Data.ShipPlaceMode, Data.Orientation, tag))
                                                    {
                                                        foreach (Button button in playerButtons)
                                                        {
                                                            if ((int)button.Tag == nextTag1)
                                                            {
                                                                int index = Array.IndexOf(playerButtons, button);
                                                                playerButtons[index].BackColor = Design.MouseOverColor[playerID - 1];
                                                                playerButtons[index].FlatAppearance.BorderColor = Design.BorderColor[playerID - 1];
                                                            }
                                                            if ((int)button.Tag == nextTag2)
                                                            {
                                                                int index = Array.IndexOf(playerButtons, button);
                                                                playerButtons[index].BackColor = Design.MouseOverColor[playerID - 1];
                                                                playerButtons[index].FlatAppearance.BorderColor = Design.BorderColor[playerID - 1];
                                                            }
                                                            if ((int)button.Tag == nextTag3)
                                                            {
                                                                int index = Array.IndexOf(playerButtons, button);
                                                                playerButtons[index].BackColor = Design.MouseOverColor[playerID - 1];
                                                                playerButtons[index].FlatAppearance.BorderColor = Design.BorderColor[playerID - 1];
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //Error_Catch
                                                }
                                                break;
                                            }
                                    }
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }
                case 1:
                    {
                        BS_EnemySchema_Index.Text = tip;
                        break;
                    }
                default:
                    {
                        BS_PlayerSchema_Index.Text = null;
                        BS_EnemySchema_Index.Text = null;
                        break;
                    }
            }
        }
        private async void Button_MouseLeave(object sender, EventArgs e)
        {
            await Task.Delay(0);
            BS_PlayerSchema_Index.Text = null;
            BS_EnemySchema_Index.Text = null;
            Button unselectedButton = sender as Button;
            unselectedButton.BackColor = Color.White;
            unselectedButton.ForeColor = Color.Black;
            unselectedButton.FlatAppearance.BorderColor = Color.Black;
            string tip = Position.GetButtonTextCoords(unselectedButton, out int playerID);
            string tag = Support.GetTagFromButton(unselectedButton);
            string position = Position.GetCellPosition(tag);
            int delta;
            switch (playerID - 1)
            {
                case 0:
                    {
                        Button[] playerButtons = Support.GetPlayerButtons(MapButtons);
                        BS_PlayerSchema_Index.Text = tip;
                        if (Data.ShipPlaceMode == "Frigate" || Data.ShipPlaceMode == "None")
                        {
                            Data.Orientation = "N";
                        }
                        else
                        {
                            if (ModifierKeys == Keys.Shift)
                            {
                                Data.Orientation = "V";
                            }
                            else
                            {
                                Data.Orientation = "H";
                            }
                        }
                        switch (Data.ShipPlaceMode)
                        {
                            case "Destroyer":
                                {
                                    switch (position)
                                    {
                                        case "center":
                                            {
                                                if (Support.StringToInt(tag, out int currentTag))
                                                {
                                                    switch (Data.Orientation)
                                                    {
                                                        case "H":
                                                            {
                                                                delta = 10;
                                                                break;
                                                            }
                                                        case "V":
                                                            {
                                                                delta = -1;
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                delta = 0;
                                                                break;
                                                            }
                                                    }
                                                    int nextTag1 = currentTag + delta;
                                                    foreach (Button button in playerButtons)
                                                    {
                                                        if ((int)button.Tag == nextTag1)
                                                        {
                                                            int index = Array.IndexOf(playerButtons, button);
                                                            playerButtons[index].BackColor = Color.White;
                                                            unselectedButton.BackColor = Color.White;
                                                            playerButtons[index].FlatAppearance.BorderColor = Color.Black;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //Error_Catch
                                                }
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case "Cruiser":
                                {
                                    switch (position)
                                    {
                                        case "center":
                                            {
                                                if (Support.StringToInt(tag, out int currentTag))
                                                {
                                                    switch (Data.Orientation)
                                                    {
                                                        case "H":
                                                            {
                                                                delta = 10;
                                                                break;
                                                            }
                                                        case "V":
                                                            {
                                                                delta = -1;
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                delta = 0;
                                                                break;
                                                            }
                                                    }
                                                    int nextTag1 = currentTag + delta;
                                                    int nextTag2 = currentTag + (2 * delta);
                                                    if (Position.IsValidShipPosition(position, Data.ShipPlaceMode, Data.Orientation, tag))
                                                    {
                                                        foreach (Button button in playerButtons)
                                                        {
                                                            if ((int)button.Tag == nextTag1)
                                                            {
                                                                int index = Array.IndexOf(playerButtons, button);
                                                                playerButtons[index].BackColor = Color.White; //ChangeThis
                                                                playerButtons[index].FlatAppearance.BorderColor = Color.Black;
                                                            }
                                                            if ((int)button.Tag == nextTag2)
                                                            {
                                                                int index = Array.IndexOf(playerButtons, button);
                                                                playerButtons[index].BackColor = Color.White; //ChangeThis
                                                                playerButtons[index].FlatAppearance.BorderColor = Color.Black;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //Error_Catch
                                                }
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case "Battleship":
                                {
                                    unselectedButton.BackColor = Color.White; //Change This
                                    unselectedButton.FlatAppearance.BorderColor = Color.Black;
                                    switch (position)
                                    {
                                        case "center":
                                            {
                                                if (Support.StringToInt(tag, out int currentTag))
                                                {
                                                    switch (Data.Orientation)
                                                    {
                                                        case "H":
                                                            {
                                                                delta = 10;
                                                                break;
                                                            }
                                                        case "V":
                                                            {
                                                                delta = -1;
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                delta = 0;
                                                                break;
                                                            }
                                                    }
                                                    int nextTag1 = currentTag + delta;
                                                    int nextTag2 = currentTag + (2 * delta);
                                                    int nextTag3 = currentTag + (3 * delta);
                                                    if (Position.IsValidShipPosition(position, Data.ShipPlaceMode, Data.Orientation, tag))
                                                    {
                                                        foreach (Button button in playerButtons)
                                                        {
                                                            if ((int)button.Tag == nextTag1)
                                                            {
                                                                int index = Array.IndexOf(playerButtons, button);
                                                                playerButtons[index].BackColor = Color.White;
                                                                playerButtons[index].FlatAppearance.BorderColor = Color.Black;
                                                            }
                                                            if ((int)button.Tag == nextTag2)
                                                            {
                                                                int index = Array.IndexOf(playerButtons, button);
                                                                playerButtons[index].BackColor = Color.White;
                                                                playerButtons[index].FlatAppearance.BorderColor = Color.Black;
                                                            }
                                                            if ((int)button.Tag == nextTag3)
                                                            {
                                                                int index = Array.IndexOf(playerButtons, button);
                                                                playerButtons[index].BackColor = Color.White;
                                                                playerButtons[index].FlatAppearance.BorderColor = Color.Black;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //Error_Catch
                                                }
                                                break;
                                            }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case 1:
                    {
                        break;
                    }
            }
        }
        private async void Button_MouseHover(object sender, EventArgs e)
        {
            await Task.Delay(0);
            Button selectedButton = sender as Button;
            string tip = Position.GetButtonTextCoords(selectedButton, out int playerID);
            selectedButton.BackColor = Design.MouseOverColor[playerID - 1];
            GPO_ToolTip.SetToolTip(selectedButton, $"{tip}");
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
                        SettingsForm SF = new SettingsForm();
                        SF.Show();
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