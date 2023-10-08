using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class MapCreate : Form
    {
        Support sp = new Support();
        Position ps = new Position();
        public MapCreate()
        {
            InitializeComponent();
        }
        Button[] ExampleButtons = new Button[5];
        Button[] Buttons = new Button[100];
        Button[] ShowButtons = new Button[100];
        Button[] ShipPlaceMap = new Button[100];
        bool ShowExampleInMap = false;
        private void MapCreate_FormClosed(object sender, FormClosedEventArgs e)
        {
            DebugTools.MCF.Opened = false;
        }
        private void MapCreate_Load(object sender, EventArgs e)
        {
            DebugTools.MCF.Opened = true;
            GenerateButtons();
            CB_Coord_Letter.SelectedItem = 0;
            CB_Coord_Number.SelectedItem = 0;
        }
        int[,] GenerateButtonsTags()
        {
            int tag;
            int index;
            int[,] tags = new int[2, 100];
            for (int f = 3; f <= 4; f++)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        tag = Convert.ToInt32(Convert.ToString($"{f}{j}{i}"));
                        index = Convert.ToInt32(Convert.ToString($"{i}{j}"));
                        tags[f - 3, index] = tag;
                    }
                }
            }
            return tags;
        }
        public void GenerateButtons()
        {
            int[,] tags = GenerateButtonsTags();
            int x;
            int y;
            string[] name = { "BS_MC_", "BS_ShipPlace_" };
            TableLayoutPanel[] tlp = { TLP_MC_Schema, TLP_ShipPlaceMap };
            for (int f = 0; f < 2; f++)
            {
                for (int b = 0; b < 100; b++)
                {
                    x = b / 10;
                    y = (b % 10 - 1) * 60 + 1;
                    Button button = new Button
                    {
                        Name = name[f],
                        Location = new Point(x, y),
                        Dock = DockStyle.Fill
                    };
                    tlp[f].Controls.Add(button);
                    button.FlatStyle = FlatStyle.Flat;
                    button.ForeColor = Color.Black;
                    button.BackColor = Color.White;
                    button.Tag = tags[f, b];
                    button.Margin = new Padding(0);
                    if (f == 0)
                    {
                        Buttons[b] = button;
                    }
                    else
                    {
                        ShipPlaceMap[b] = button;
                    }
                }
            }
        }
        public void ShowExample()
        {
            Random random = new Random();
            ExampleButtons[0] = BS_Example_1;
            ExampleButtons[1] = BS_Example_2;
            ExampleButtons[2] = BS_Example_3;
            ExampleButtons[3] = BS_Example_4;
            ExampleButtons[4] = BS_Example_5;
            for (int b = 0; b < ExampleButtons.Length; b++)
            {
                ExampleButtons[b].BackColor = Color.White;
            }
            switch (ShipData.ChoosenShipType)
            {
                case 1:
                    {
                        int num = random.Next(0, 5);
                        ExampleButtons[num].BackColor = Color.Gray;
                        break;
                    }
                case 2:
                    {
                        int num = random.Next(0, 4);
                        for (int i = num; i <= num + 1; i++)
                        {
                            ExampleButtons[i].BackColor = Color.Gray;
                        }
                        break;
                    }
                case 3:
                    {
                        int num = random.Next(0, 3);
                        for (int i = num; i <= num + 2; i++)
                        {
                            ExampleButtons[i].BackColor = Color.Gray;
                        }
                        break;
                    }
                case 4:
                    {
                        int num = random.Next(0, 2);
                        for (int i = num; i <= num + 3; i++)
                        {
                            ExampleButtons[i].BackColor = Color.Gray;
                        }
                        break;
                    }
            }
        }
        private void RB_ShipType_Frigate_CheckedChanged(object sender, EventArgs e)
        {
            string[] orientations = { "None", "Horizontal", "Vertical" };
            RadioButton checkedRadioButton = sender as RadioButton;
            ShipData.ChoosenShipType = Convert.ToInt32(checkedRadioButton.Tag);
            TB_ShipSize.Text = ShipData.ChoosenShipType.ToString();
            CB_Orientation.Enabled = false;
            CB_Orientation.Items.Clear();
            if (ShipData.ChoosenShipType == 1)
            {
                CB_Orientation.Items.Add(orientations[0]);
            }
            else if (ShipData.ChoosenShipType > 1)
            {
                for (int i = 1; i < 3; i++)
                {
                    CB_Orientation.Items.Add(orientations[i]);
                }
                CB_Orientation.Enabled = true;
            }
            CB_Orientation.SelectedIndex = 0;
            switch (ShipData.ChoosenShipType)
            {
                case 1:
                    {
                        TB_MaxCount.Text = ShipData.FrigateCount.ToString();
                        break;
                    }
                case 2:
                    {
                        TB_MaxCount.Text = ShipData.DestroyerCount.ToString();
                        break;
                    }
                case 3:
                    {
                        TB_MaxCount.Text = ShipData.CruiserCount.ToString();
                        break;
                    }
                case 4:
                    {
                        TB_MaxCount.Text = ShipData.BattleshipCount.ToString();
                        break;
                    }
                default:
                    {
                        TB_MaxCount.Text = "";
                        break;
                    }
            }
            if (ShowExampleInMap)
            {
                ShowExample();
                SetExample();
            }
        }
        public void SetExample()
        {
            switch (ShipData.ChoosenShipType)
            {
                case 1:
                    {
                        if (ShowExampleInMap)
                        {
                            for (int i = 0; i < 100; i++)
                            {
                                Button button = Buttons[i];
                                button.BackColor = Color.LightGreen;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            Button button = Buttons[i];
                            ps.GetCoordsFromTag(sp.GetTagFromButton(button), out int x, out int y, out int p);
                            if (x == 9)
                            {
                                if (y == 0)
                                {
                                    button.BackColor = Color.Firebrick;
                                }
                                else
                                {
                                    button.BackColor = Color.Khaki;
                                }
                            }
                            else
                            {
                                if (y == 0)
                                {
                                    button.BackColor = Color.SkyBlue;
                                }
                                else
                                {
                                    button.BackColor = Color.LightGreen;
                                }
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            Button button = Buttons[i];
                            ps.GetCoordsFromTag(sp.GetTagFromButton(button), out int x, out int y, out int p);
                            if (x >= 8)
                            {
                                if (y <= 1)
                                {
                                    button.BackColor = Color.Firebrick;
                                }
                                else
                                {
                                    button.BackColor = Color.Khaki;
                                }
                            }
                            else
                            {
                                if (y <= 1)
                                {
                                    button.BackColor = Color.SkyBlue;
                                }
                                else
                                {
                                    button.BackColor = Color.LightGreen;
                                }
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            Button button = Buttons[i];
                            ps.GetCoordsFromTag(sp.GetTagFromButton(button), out int x, out int y, out int p);
                            if (x >= 7)
                            {
                                if (y <= 2)
                                {
                                    button.BackColor = Color.Firebrick;
                                }
                                else
                                {
                                    button.BackColor = Color.Khaki;
                                }
                            }
                            else
                            {
                                if (y <= 2)
                                {
                                    button.BackColor = Color.SkyBlue;
                                }
                                else
                                {
                                    button.BackColor = Color.LightGreen;
                                }
                            }
                        }
                        break;
                    }
            }
        }
        private async void CHB_ShowExample_CheckedChanged(object sender, EventArgs e)
        {
            await Task.Delay(0);
            CHB_ShowExample.Enabled = false;
            ShowExampleInMap = CHB_ShowExample.Checked;
            switch (ShowExampleInMap)
            {
                case true:
                    {
                        PNL_Example.Visible = true;
                        for (int b = 0; b < ShowButtons.Length; b++)
                        {
                            int x;
                            int y;
                            x = b / 10;
                            y = (b % 10 - 1) * 60 + 1;
                            Button button = new Button
                            {
                                Name = $"BS_MC_Example_{b}",
                                Location = new Point(x, y),
                                Dock = DockStyle.Fill
                            };
                            TLP_Example.Controls.Add(button);
                            button.FlatStyle = FlatStyle.Flat;
                            button.ForeColor = Color.Black;
                            button.BackColor = Color.White;
                            button.Tag = b + 100;
                            button.Margin = new Padding(0);
                            button.MouseHover += ShowButtons_MouseHover;
                            Buttons[b] = button;
                        }
                        SetExample();
                        break;
                    }
                case false:
                    {
                        PNL_Example.Visible = false;
                        for (int b = 0; b < ShowButtons.Length; b++)
                        {
                            Button button = Buttons[b];
                            if (button != null)
                            {
                                TLP_Example.Controls.Remove(button);
                                button.Dispose();
                                Buttons[b] = null;
                            }
                        }
                        break;
                    }
            }
            CHB_ShowExample.Enabled = true;
        }
        private void ShowButtons_MouseHover(object sender, EventArgs e)
        {
            Button selectedButton = sender as Button;
            string tip = "";
            if (selectedButton.BackColor == Color.Firebrick)
            {
                tip = "Can't place";
            }
            else if (selectedButton.BackColor == Color.SkyBlue)
            {
               tip = "Can place only \"Horizontal\"";
            }
            else if (selectedButton.BackColor == Color.Khaki)
            {
                tip = "Can place only \"Vertical\"";
            }
            else if (selectedButton.BackColor == Color.LightGreen)
            {
                tip = "Can place \"Horizontar\" & \"Vertical\"";
            }
            TT_MapCreate.Show(tip, selectedButton);
        }
        private void BS_ResetMap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Button button = ShipPlaceMap[i];
                button.BackColor = Color.White;
            }
        }
        private void CB_Coord_Letter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.FirstCoord_Letter = CB_Coord_Letter.Text;
            Data.FirstCoord_Final = $"{Data.FirstCoord_Letter}{Data.FirstCoord_Number}";
            TB_Coords.Text = Data.FirstCoord_Final;
        }
        private void CB_Coord_Number_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.FirstCoord_Number = Convert.ToInt32(CB_Coord_Number.Text);
            Data.FirstCoord_Final = $"{Data.FirstCoord_Letter}{Data.FirstCoord_Number}";
            TB_Coords.Text = Data.FirstCoord_Final;
        }
        public bool CanShipPlace(string tag, string orientation, int shipType)
        {
            string pos = ps.GetCellPosition(tag);
            ps.GetCoordsFromTag(tag, out int x, out int y, out int playerID);
            switch (pos)
            {
                case "center":
                    {
                        switch (shipType)
                        {
                            case 1:
                            case 2:
                                {
                                    return true;
                                }
                            case 3:
                                {
                                    switch (orientation)
                                    {
                                        case "V":
                                            {
                                                if (x >= 2)
                                                {
                                                    return true;
                                                }
                                                return false;
                                            }
                                        case "H":
                                            {
                                                if (y <= 7)
                                                {
                                                    return true;
                                                }
                                                return false;
                                            }
                                        default:
                                            {
                                                return false;
                                            }
                                    }
                                }
                            case 4:
                                {
                                    switch (orientation)
                                    {
                                        case "V":
                                            {
                                                if (x >= 3)
                                                {
                                                    return true;
                                                }
                                                return false;
                                            }
                                        case "H":
                                            {
                                                if (y <= 6)
                                                {
                                                    return true;
                                                }
                                                return false;
                                            }
                                        default:
                                            {
                                                return false;
                                            }
                                    }
                                }
                        }
                        break;
                    }
                case "top":
                    {
                        switch (shipType)
                        {
                            case 1:
                                {
                                    return true;
                                }
                            case 2:
                                {
                                    if (orientation == "H" && y <= 8)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            case 3:
                                {
                                    if (orientation == "H" && y <= 7)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            case 4:
                                {
                                    if (orientation == "H" && y <= 6)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                        }
                        break;
                    }
                case "bottom":
                    {
                        switch (shipType)
                        {
                            case 1:
                                {
                                    return true;
                                }
                            case 2:
                                {
                                    return true;
                                }
                            case 3:
                                {
                                    if (orientation == "V")
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        if (y <= 7)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                }
                            case 4:
                                {
                                    if (orientation == "V")
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        if (y <= 6)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                }
                            default:
                                {
                                    return false;
                                }
                        }
                    }
                case "left":
                    {
                        if (orientation == "H")
                        {
                            return true;
                        }
                        else
                        {
                            switch (shipType)
                            {
                                case 1:
                                    {
                                        return true;
                                    }
                                case 2:
                                    {
                                        if (x >= 1)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                case 3:
                                    {
                                        if (x >= 2)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                case 4:
                                    {
                                        if (x >= 3)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                default:
                                    {
                                        return false;
                                    }
                            }
                        }
                    }
                case "right":
                    {
                        if (shipType == 1)
                        {
                            return true;
                        }
                        else
                        {
                            switch (orientation)
                            {
                                case "H":
                                    {
                                        if (shipType != 1)
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }
                                case "V":
                                    {
                                        if (x >= 1)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                default:
                                    {
                                        return false;
                                    }
                            }
                        }
                    }
                case "corner1":
                    {
                        if (shipType == 1)
                        {
                            return true;
                        }
                        else
                        {
                            if (orientation == "H")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                case "corner2":
                    {
                        if (shipType == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case "corner3":
                    {
                        if (shipType == 1)
                        {
                            return true;
                        }
                        else
                        {
                            if (orientation == "V")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                case "corner4":
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
            return false;
        }
        public bool EmtyShipCell(string MapTag, string tag)
        {
            return true; //
        }
        private void BS_Coords_Check_Click(object sender, EventArgs e)
        {
            int[] deltas = new int[0];
            if (CB_Coord_Letter.Text != null && CB_Coord_Number.Text != null)
            {
                ps.TextCoordToPosition(Data.FirstCoord_Final, out int halfTag);
                string tag = $"{halfTag + 400}";
                string mapTag = $"{halfTag + 300}";
                ps.GetCoordsFromTag(tag, out int x, out int y, out int playerID);
                if (CanShipPlace(tag, ShipData.Orientation, ShipData.ChoosenShipType))
                {
                    Array.Resize(ref deltas, ShipData.ChoosenShipType);
                    for (int d = 0; d < deltas.Length; d++)
                    {
                        switch (ShipData.Orientation)
                        {
                            case "H":
                                {
                                    deltas[d] = (d + 1) * 10;
                                    break;
                                }
                            case "V":
                                {
                                    deltas[d] = (d + 1) * (-1);
                                    break;
                                }
                            default:
                                {
                                    deltas[d] = 0;
                                    break;
                                }
                        }
                    }
                    Button[] exampleButtons = ShipPlaceMap;
                    switch (ShipData.ChoosenShipType)
                    {
                        case 1:
                            {
                                foreach (Button ex_Button in exampleButtons)
                                {
                                    if (ex_Button.Tag.ToString() == tag)
                                    {
                                        ex_Button.BackColor = Color.Khaki;
                                        break;
                                    }
                                }
                                break;
                            }
                        case 2:
                            {
                                
                                foreach (Button ex_Button in exampleButtons)
                                {
                                    for (int nt = 0; nt < deltas.Length; nt++)
                                    {
                                        if (ex_Button.Tag.ToString() == tag)
                                        {
                                            ex_Button.BackColor = Color.Khaki;
                                        }
                                    }
                                }
                                break;
                            }
                    }
                }
            }
        }

        private void CB_Orientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orientation = CB_Orientation.SelectedItem.ToString();
            switch (orientation)
            {
                case "None":
                    {
                        ShipData.Orientation = "N";
                        break;
                    }
                case "Horizontal":
                    {
                        ShipData.Orientation = "H";
                        break;
                    }
                case "Vertical":
                    {
                        ShipData.Orientation = "V";
                        break;
                    }
            }
        }
    }
}
