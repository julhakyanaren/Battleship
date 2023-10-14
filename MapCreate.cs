using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class MapCreate : Form
    {
        Support sp = new Support();
        Position pos = new Position();
        ColorMethods cm = new ColorMethods();
        Map map = new Map();
        public MapCreate()
        {
            InitializeComponent();
        }
        Button[] ExampleButtons = new Button[5];
        Button[] Buttons_MC = new Button[100];
        Button[] ShowButtons = new Button[100];
        Button[] ShipPlaceMap = new Button[100];
        Button[] CanPlaceButton = new Button[100];
        bool ShowExampleInMap = false;
        List<int> Indexes = new List<int>();
        private void MapCreate_FormClosed(object sender, FormClosedEventArgs e)
        {
            DebugTools.MCF.Opened = false;
        }
        private void MapCreate_Load(object sender, EventArgs e)
        {
            DebugTools.MCF.Opened = true;
            GenerateButtons();
            CB_Coord_Letter.Select(0,0);
            CB_Coord_Number.Select(0,0);
            /**/
            Design.ChangeControlElementsForeColor(this, Design.DefaultForeColor, DefaultBackColor);
            /**/
            TB_MC_FrigateCount.ForeColor = Color.Lime;
            TB_MC_DestroyerCount.ForeColor = Color.Lime;
            TB_MC_CruiserCount.ForeColor = Color.Lime;
            TB_MC_BattleshipCount.ForeColor = Color.Lime;
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
                    button.FlatAppearance.BorderColor = Color.Black;
                    button.Tag = tags[f, b];
                    button.Margin = new Padding(0);
                    /**/
                    button.Text = b.ToString();
                    /**/
                    if (f == 0)
                    {
                        Buttons_MC[b] = button;
                        button.Click += MC_Buttons_Click;
                    }
                    else
                    {
                        ShipPlaceMap[b] = button;
                    }
                }
            }
        }

        private void MC_Buttons_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string textCoord = pos.GetButtonTextCoords(clickedButton, out int buttonIndex);
            if (buttonIndex == 3)
            {
                char[] coords = textCoord.ToCharArray();
                string letter = null;
                int number = 0;
                letter = coords[0].ToString();
                if (coords.Length == 3)
                {
                    number = Convert.ToInt32($"{coords[1]}{coords[2]}");
                }
                else
                {
                    number = Convert.ToInt32($"{coords[1]}");
                }
                Data.FirstCoord_Letter = letter;
                Data.FirstCoord_Number = number;
                Data.FirstCoord_Final = $"{letter}{number}";
                CB_Coord_Letter.Text = Data.FirstCoord_Letter;
                CB_Coord_Number.Text = Data.FirstCoord_Number.ToString();
                TB_Coords.Text = Data.FirstCoord_Final;
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
            if (checkedRadioButton.ForeColor == Color.Firebrick)
            {
                checkedRadioButton.Checked = false;
            }
            else
            {
                if (ShipData.ChoosenShipType != 0)
                {
                    GB_PlaceShip.Visible = true;
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
                else
                {
                    GB_PlaceShip.Visible = false;
                }
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
                                Button button = CanPlaceButton[i];
                                button.BackColor = Color.LightGreen;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            Button button = CanPlaceButton[i];
                            pos.GetCoordsFromTag(sp.GetTagFromButton(button), out int x, out int y, out int p);
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
                            Button button = CanPlaceButton[i];
                            pos.GetCoordsFromTag(sp.GetTagFromButton(button), out int x, out int y, out int p);
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
                            Button button = CanPlaceButton[i];
                            pos.GetCoordsFromTag(sp.GetTagFromButton(button), out int x, out int y, out int p);
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
                            button.Tag = b + 500;
                            button.Margin = new Padding(0);
                            button.MouseHover += ShowButtons_MouseHover;
                            CanPlaceButton[b] = button;
                        }
                        SetExample();
                        break;
                    }
                case false:
                    {
                        PNL_Example.Visible = false;
                        for (int b = 0; b < ShowButtons.Length; b++)
                        {
                            Button button = CanPlaceButton[b];
                            if (button != null)
                            {
                                TLP_Example.Controls.Remove(button);
                                button.Dispose();
                                CanPlaceButton[b] = null;
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
        public void RadioButtonsLock(int radioButton_ID)
        {
            RadioButton[] radioButtons = { RB_ShipType_Frigate, RB_ShipType_Destroyer, RB_ShipType_Cruiser, RB_ShipType_Battleship };
            ShipData.RadioButtonsState[radioButton_ID - 1] = true;
            switch (radioButton_ID)
            {
                case 1:
                    {
                        RB_ShipType_Frigate.ForeColor = Color.Firebrick;
                        break;
                    }
                case 2:
                    {
                        RB_ShipType_Destroyer.ForeColor = Color.Firebrick;
                        break;
                    }
                case 3:
                    {
                        RB_ShipType_Cruiser.ForeColor = Color.Firebrick;
                        break;
                    }
                case 4:
                    {
                        RB_ShipType_Battleship.ForeColor = Color.Firebrick;
                        break;
                    }
            }
            ShipData.ChoosenShipType = 0;
            GB_PlaceShip.Visible = false;
            bool allshipPlaced = true;
            for (int r = 0; r < ShipData.RadioButtonsState.Length; r++)
            {
                allshipPlaced &= ShipData.RadioButtonsState[r];
            }
            ShipData.AllShipPlaced = allshipPlaced;
            BS_MC_Apply.Visible = ShipData.AllShipPlaced;
        }
        public void ResetExampleMap()
        {
            for (int i = 0; i < 100; i++)
            {
                Button button = ShipPlaceMap[i];
                button.BackColor = Color.White;
            }
            BS_Coords_Apply.Visible = false;
            BS_Insert.Visible = false;
            TB_Range.Clear();
            TB_ShipType.Clear();
            TB_Status.Clear();
            TB_Status.ForeColor = Color.Lime;
            Indexes.Clear();
        }
        private void BS_ResetMap_Click(object sender, EventArgs e)
        {
            ResetExampleMap();
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
            string cellPos = pos.GetCellPosition(tag);
            this.pos.GetCoordsFromTag(tag, out int x, out int y, out int playerID);
            switch (cellPos)
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
        public bool EmptyShipCell(string mapTargetTag)
        {
            Button[] bmc = Buttons_MC;
            foreach (Button button in bmc)
            {
                if (button.Tag.ToString() == mapTargetTag)
                {
                    if (button.BackColor == Color.White)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void BS_Coords_Check_Click(object sender, EventArgs e)
        {
            int[] deltas = new int[0];
            int[] nextTag = new int[0];
            bool cellPainted = false;
            bool canReplace = true;
            bool successfullPainting = true;
            if (CB_Coord_Letter.Text != null && CB_Coord_Number.Text != null)
            {
                pos.TextCoordToPosition(Data.FirstCoord_Final, out int halfTag);
                string tag = $"{halfTag + 400}";
                string mapTag = $"{halfTag + 300}";
                pos.GetCoordsFromTag(tag, out int x, out int y, out int playerID);
                if (CanShipPlace(tag, ShipData.Orientation, ShipData.ChoosenShipType))
                {
                    if (EmptyShipCell(mapTag))
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
                        Array.Resize(ref nextTag, deltas.Length);
                        Button[] exampleButtons = ShipPlaceMap;
                        try
                        {
                            if (ShipData.ChoosenShipType >= 1)
                            {
                                foreach (Button ex_Button in exampleButtons)
                                {
                                    if (ex_Button.Tag.ToString() == tag)
                                    {
                                        ex_Button.BackColor = Color.Khaki;
                                        int buttonIndex = Array.IndexOf(exampleButtons, ex_Button);
                                        Indexes.Add(buttonIndex);
                                        break;
                                    }
                                }
                            }
                            if (ShipData.ChoosenShipType <= 4)
                            {
                                for (int nb = 0; nb < nextTag.Length - 1; nb++)
                                {
                                    if (successfullPainting)
                                    {
                                        if (sp.StringToInt(tag, out int currentTag))
                                        {
                                            nextTag[nb] = currentTag + deltas[nb];
                                            foreach (Button ex_Button in exampleButtons)
                                            {
                                                if ((int)ex_Button.Tag == nextTag[nb])
                                                {
                                                    int targetMapTag = Convert.ToInt32(ex_Button.Tag.ToString()) - 100;
                                                    int buttonIndex = Array.IndexOf(exampleButtons, ex_Button);
                                                    if (EmptyShipCell($"{targetMapTag}"))
                                                    {
                                                        exampleButtons[buttonIndex].BackColor = Color.Khaki;
                                                        Indexes.Add(buttonIndex);
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        successfullPainting = false;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            cellPainted = true;
                        }
                        catch
                        {
                            cellPainted = false;
                        }
                        finally
                        {
                            canReplace = successfullPainting && cellPainted;
                        }
                    }
                    else
                    {
                        canReplace = false;
                    }
                }
                else
                {
                    canReplace = false;
                }
            }
            switch (canReplace)
            {
                case true:
                    {
                        TB_Status.ForeColor = Color.Lime;
                        TB_Status.Text = "Position is available";
                        BS_Coords_Apply.Visible = true;
                        break;
                    }
                case false:
                    {
                        TB_Status.ForeColor = Color.Red;
                        TB_Status.Text = "Position is not available";
                        BS_Coords_Apply.Visible = false;
                        break;

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
        private void BS_Coords_Apply_Click(object sender, EventArgs e)
        {
            Button[] mapButtons = Buttons_MC;
            bool allCellsEmpty = true;
            for (int i = 0; i < Indexes.Count; i++)
            {
                if (mapButtons[Indexes[i]].BackColor != Color.White)
                {
                    allCellsEmpty = false;
                    break;
                }
            }
            if (allCellsEmpty)
            {
                string shipType;
                switch (ShipData.ChoosenShipType)
                {
                    case 1:
                        {
                            shipType = "Frigate";
                            break;
                        }
                    case 2:
                        {
                            shipType = "Destroyer";
                            break;
                        }
                    case 3:
                        {
                            shipType = "Cruiser";
                            break;
                        }
                    case 4:
                        {
                            shipType = "Battleship";
                            break;
                        }
                    default:
                        {
                            shipType = "Null";
                            break;
                        }
                }
                if (shipType != "Null")
                {
                    string lastCoord = pos.GetButtonTextCoords(mapButtons[Indexes[Indexes.Count - 1]], out int ID);
                    string cellsRange = $"{Data.FirstCoord_Final}:{lastCoord}";
                    TB_Range.Text = cellsRange;
                    TB_ShipType.Text = shipType;
                    BS_Insert.Visible = true;
                }
            }
        }
        private void BS_Insert_Click(object sender, EventArgs e)
        {
            Button[] mapButton = Buttons_MC;
            Color cellColor;
            switch (ShipData.ChoosenShipType)
            {
                case 1:
                    {
                        cellColor = Color.Silver;
                        break;
                    }
                case 2:
                    {
                        cellColor = Color.DarkGray;
                        break;
                    }
                case 3:
                    {
                        cellColor = Color.Gray;
                        break;
                    }
                case 4:
                    {
                        cellColor = Color.DimGray;
                        break;
                    }
                default:
                    {
                        cellColor = Color.White;
                        break;
                    }
            }
            for (int i = 0; i < Indexes.Count; i++)
            {
                mapButton[Indexes[i]].BackColor = cellColor;
            }
            string tag = mapButton[Indexes[0]].Tag.ToString();
            if (sp.StringToInt(tag, out int tagButton))
            {
                string cellPos = pos.GetCellPosition(tag);
                pos.GetCoordsFromTag(tag, out int x, out int y, out int playerID);
                int mineTagsSize = ShipData.GetMineCount(cellPos, ShipData.ChoosenShipType, x, y, ShipData.Orientation);
                if (mineTagsSize != -1)
                {
                    int[] mineTags = new int[mineTagsSize];
                    mineTags = ShipData.MineTagsFill(mineTags, cellPos, ShipData.ChoosenShipType, tagButton, ShipData.Orientation);
                    foreach (Button mineButton in mapButton)
                    {
                        for (int b = 0; b < mineTags.Length; b++)
                        {
                            if (mineButton.Tag.ToString() == mineTags[b].ToString())
                            {
                                int buttonIndex = Array.IndexOf(mapButton, mineButton);
                                mapButton[buttonIndex].BackColor = Color.Aqua;
                                break;
                            }
                        }
                    }
                    if (ShipData.MapAutoUpdate)
                    {
                        GenerateSchematic();
                    }
                    ResetExampleMap();
                    switch (ShipData.ChoosenShipType)
                    {
                        case 1:
                            {
                                TB_MC_FrigateCount.Text = Convert.ToString(Convert.ToInt32(TB_MC_FrigateCount.Text) + 1);
                                break;
                            }
                        case 2:
                            {
                                TB_MC_DestroyerCount.Text = Convert.ToString(Convert.ToInt32(TB_MC_DestroyerCount.Text) + 1);
                                break;
                            }
                        case 3:
                            {
                                TB_MC_CruiserCount.Text = Convert.ToString(Convert.ToInt32(TB_MC_CruiserCount.Text) + 1);
                                break;
                            }
                        case 4:
                            {
                                TB_MC_BattleshipCount.Text = Convert.ToString(Convert.ToInt32(TB_MC_BattleshipCount.Text) + 1);
                                break;
                            }
                    }
                }
            }
        }
        public void GenerateSchematic()
        {
            Button[] all_MC_Buttons = new Button[Buttons_MC.Length];
            Array.Resize(ref Data.MapSchematic, all_MC_Buttons.Length);
            for (int a = 0; a < all_MC_Buttons.Length; a++)
            {
                all_MC_Buttons[a] = Buttons_MC[a];
                Data.MapSchematic[a] = cm.SetCharThrowColor(0, all_MC_Buttons[a].BackColor);
            }
            Data.Schematic = map.GenerateMapSchematic(Data.MapSchematic);
            TB_MapSchematic.Text = Data.Schematic;
        }
        private async void BS_MC_Reset_Click(object sender, EventArgs e)
        {
            Button[] mapCreateButtons = Buttons_MC;
            Color[] buttonColor = { Color.Black, Color.White };
            BS_MC_Reset.Enabled = false;
            for (int c = 0; c < 2; c++)
            {
                for (int mcb = 0; mcb < mapCreateButtons.Length; mcb++)
                {
                    await Task.Delay(4);
                    mapCreateButtons[mcb].BackColor = buttonColor[c];
                }
            }
            BS_MC_Reset.Enabled = true;
            RB_ShipType_Frigate.ForeColor = Design.DefaultForeColor;
            RB_ShipType_Destroyer.ForeColor = Design.DefaultForeColor;
            RB_ShipType_Cruiser.ForeColor = Design.DefaultForeColor;
            RB_ShipType_Battleship.ForeColor = Design.DefaultForeColor;
            RB_ShipType_Frigate.Checked = true;
            TB_MC_FrigateCount.Text = "0";
            TB_MC_DestroyerCount.Text = "0";
            TB_MC_CruiserCount.Text = "0";
            TB_MC_BattleshipCount.Text = "0";
            ShipData.ChoosenShipType = 1;
        }
        private void ShipsCount_TB_TextChanged(object sender, EventArgs e)
        {
            TextBox targetTB = (TextBox)sender;
            targetTB.BackColor = Color.Black;
            string textBoxText = targetTB.Text;
            int shipsCount = 0;
            int shipType;
            switch (targetTB)
            {
                case TextBox target when target == TB_MC_FrigateCount:
                    {
                        shipsCount = Convert.ToInt32(target.Text);
                        shipType = 1;
                        break;
                    }
                case TextBox target when target == TB_MC_DestroyerCount:
                    {
                        shipsCount = Convert.ToInt32(target.Text);
                        shipType = 2;
                        break;
                    }
                case TextBox target when target == TB_MC_CruiserCount:
                    {
                        shipsCount = Convert.ToInt32(target.Text);
                        shipType = 3;
                        break;
                    }
                case TextBox target when target == TB_MC_BattleshipCount:
                    {
                        shipsCount = Convert.ToInt32(target.Text);
                        shipType = 4;
                        break;
                    }
                default:
                    {
                        shipType = 0;
                        break;
                    }
            }
            if (shipType != 0)
            {
                targetTB.BackColor = Color.Black;
                if (shipsCount == ShipData.ShipsCount[shipType - 1])
                {
                    targetTB.ForeColor = Color.Red;
                    RadioButtonsLock(shipType);
                }
                else if (shipsCount < ShipData.ShipsCount[shipType - 1])
                {
                    targetTB.ForeColor = Color.Lime;
                }
                else if (shipsCount > ShipData.ShipsCount[shipType - 1])
                {
                    targetTB.BackColor = Color.Firebrick;
                    targetTB.ForeColor = Color.White;
                }
            }
        }
        private void CHB_MC_AutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            ShipData.MapAutoUpdate = Convert.ToBoolean(CHB_MC_AutoUpdate.Checked);
        }

        private void BS_MC_Update_Click(object sender, EventArgs e)
        {
            GenerateSchematic();
        }
        private void BS_MC_Apply_Click(object sender, EventArgs e)
        {
            
        }
        private void TSMI_MC_AdvancedOptions_CheckedChanged(object sender, EventArgs e)
        {
            GB_MapSchematicOptions.Visible = TSMI_MC_SchematicOptions.Checked;
        }
        private void GB_AdvancedOptions_VisibleChanged(object sender, EventArgs e)
        {
            if (GB_MapSchematicOptions.Visible)
            {
                PNL_AO_ProgressUnit.Height = PNL_AO_ProgressBar.Height;
                PNL_AO_ProgressUnit.Width = 0;
            }
        }
        private void BS_AO_LoadSchematic_Click(object sender, EventArgs e)
        {
            /**/
            ProgressLoad();
            /**/
        }
        public async void ProgressLoad()
        {
            while (PNL_AO_ProgressUnit.Width <= PNL_AO_ProgressBar.Width)
            {
                PNL_AO_ProgressUnit.BackColor = Color.White;
                await Task.Delay(2);
                PNL_AO_ProgressUnit.Width += 1;
            }
            DialogResult = MessageBox.Show("Successfull", "Schematic Manager", MessageBoxButtons.OK);
            if (DialogResult == DialogResult.OK)
            {
                PNL_AO_ProgressUnit.Width = 0;
            }
        }

        private void BS_AO_SaveSchematic_Click(object sender, EventArgs e)
        {
            DialogResult drSave = new DialogResult();
            drSave = MessageBox.Show("SaveSchematic", "Schematic Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void BS_AO_GetMap_Click(object sender, EventArgs e)
        {
            DialogResult drGet = new DialogResult();
            drGet = MessageBox.Show("Get a schematic map?", "File Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drGet == DialogResult.Yes)
            {
                if (TB_MapSchematic.Text.Length > 0)
                {
                    char[] symbols = TB_MapSchematic.Text.ToCharArray();
                    bool allSymbolsEquals = true;
                    for (int s = 0; s < symbols.Length; s++)
                    {
                        if (symbols[s] != 'n')
                        {
                            allSymbolsEquals = false;
                            break;
                        }
                    }
                    if (!allSymbolsEquals)
                    {
                        if (!AllShipsTypeAreCorrect(symbols))
                        {
                            DialogResult = MessageBox.Show("Not all ships have been placed in this schematic map. Are you sure you want to continue?", "File Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (DialogResult == DialogResult.Yes)
                            {
                                TB_AO_MapSchematic.ForeColor = Color.Yellow;
                                TB_AO_MapSchematic.Text = TB_MapSchematic.Text;
                                Schematic.Map = TB_AO_MapSchematic.Text;
                            }
                        }
                        else
                        {
                            TB_AO_MapSchematic.ForeColor = Color.Lime;
                            TB_AO_MapSchematic.Text = TB_MapSchematic.Text;
                            Schematic.Map = TB_AO_MapSchematic.Text;
                        }
                    }
                    else
                    {
                        DialogResult = MessageBox.Show("This schematic map is completely empty, are you sure you want to continue?", "File Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (DialogResult == DialogResult.Yes)
                        {
                            TB_AO_MapSchematic.ForeColor = Color.Yellow;
                            TB_AO_MapSchematic.Text = TB_MapSchematic.Text;
                            Schematic.Map = TB_AO_MapSchematic.Text;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Map schematic is empty!", "File Manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        public bool AllShipsTypeAreCorrect(char[] symbols)
        {
            int f = 4;
            int d = 6;
            int c = 6;
            int b = 4;
            for (int s = 0; s < symbols.Length; s++)
            {
                switch(symbols[s].ToString().ToUpper())
                {
                    case "F":
                        {
                            f--;
                            break;
                        }
                    case "D":
                        {
                            d--;
                            break;
                        }
                    case "C":
                        {
                            c--;
                            break;
                        }
                    case "B":
                        {
                            b--;
                            break;
                        }
                }
            }
            if (f + d + c + b == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void TB_AO_MapSchematic_TextChanged(object sender, EventArgs e)
        {
            if (TB_AO_MapSchematic.Text.Length == 0)
            {
                BS_AO_SaveSchematic.Visible = false;
            }
            else
            {
                BS_AO_SaveSchematic.Visible = true;
            }
        }
    }
}
