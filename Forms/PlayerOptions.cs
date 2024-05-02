using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Forms
{
    public partial class PlayerOptions : Form
    {
        public PlayerOptions()
        {
            InitializeComponent();
        }
        private void PlayerOptions_Load(object sender, EventArgs e)
        {
            Design.ChangeControlElementsForeColor(this, Design.DefaultForeColor, DefaultBackColor);
            SetFormComponentsLocations();
        }
        public void SetFormComponentsLocations()
        {
            Design.SetComponentLocation(L_Info_PlayerName, PNL_PO_Main);
            Design.SetComponentLocation(TB_PlayerName, PNL_PO_Main);
            Design.SetComponentLocation(BS_ApplyPlayerData, PNL_PO_Main);
            CHB_UseUsername.Location = new Point(TB_PlayerName.Location.X, CHB_UseUsername.Location.Y);
            TB_PlayerName.Text = $"{Environment.UserName}";
        }
        private void TB_PlayerName_MouseHover(object sender, EventArgs e)
        {
            TextBox hover = sender as TextBox;
            TT_PO.Show("Enter your name", hover);;
        }
        public void SetOptions()
        {
            if (Options.SingleplayerMode == true)
            {
                if (TB_PlayerName.Text == string.Empty)
                {
                    Options.SP_PlayerName = "Player";
                }
                else
                {
                    Options.SP_PlayerName = TB_PlayerName.Text;
                }
            }
            GameForm GPO = new GameForm();
            Design.FormSwitching(this, GPO, 1, false, 8);
        }
        private void BS_ApplyPlayerData_Click(object sender, EventArgs e)
        {
            if (TB_PlayerName.Text == Environment.UserName)
            {
                DialogResult = MessageBox.Show($"Start game with your computer username: {TB_PlayerName.Text}?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (DialogResult)
                {
                    case DialogResult.Yes:
                        {
                            SetOptions();
                            break;
                        }
                    case DialogResult.No:
                        {
                            TB_PlayerName.Clear();
                            break;
                        }
                }
            }
            else if (TB_PlayerName.Text == string.Empty)
            {
                DialogResult = MessageBox.Show("Start game with default username?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    SetOptions();
                }
            }
            else
            {
                DialogResult = MessageBox.Show("Start game?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    SetOptions();
                }
            }
        }
        private void CHB_UseUsername_CheckedChanged(object sender, EventArgs e)
        {
            switch (CHB_UseUsername.Checked)
            {
                case true:
                    {
                        TB_PlayerName.Text = Environment.UserName;
                        break;
                    }
                case false:
                    {
                        TB_PlayerName.Clear();
                        break;
                    }
            }
        }
        private void PlayerOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Opacity == 1)
            {
                MenuForm mf = new MenuForm();
                Design.FormSwitching(this, mf, 1, false, 8);
            }
        }
        private void CB_GameMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CB_GameMode.SelectedIndex)
            {
                case 0:
                    {
                        CHB_MoreInfo.Text = $"More info about \"{CB_GameMode.SelectedItem}\"";
                        L_GameModeText.Text = $"In the \"{CB_GameMode.SelectedItem}\" you will receive\r\ninformation about the chances of hitting.\r\nBy choosing a specific cell on the map.\r\nDesigned for the study of probability.\r\n";
                        Options.GameModeInt = CB_GameMode.SelectedIndex;
                        Options.GameMode = "Education";
                        break;
                    }
                case 1:
                    {
                        CHB_MoreInfo.Text = $"More info about {CB_GameMode.SelectedItem}";
                        L_GameModeText.Text =  $"In \"{CB_GameMode.SelectedItem}\" you will not receive\r\ninformation about the chances of hitting.\r\nDesigned for casual play.";
                        Options.GameModeInt = CB_GameMode.SelectedIndex;
                        Options.GameMode = "Classic";
                        break;
                    }
            }
        }
        private void CHB_MoreInfo_CheckedChanged(object sender, EventArgs e)
        {
            L_GameModeText.Visible = CHB_MoreInfo.Checked;
        }
    }
}
