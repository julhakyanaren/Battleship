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
        public void SetFormComponentsLocations()
        {
            Design.SetComponentLocation(L_Info_PlayerName, PNL_PO_Main);
            Design.SetComponentLocation(TB_PlayerName, PNL_PO_Main);
            Design.SetComponentLocation(BS_ApplyPlayerData, PNL_PO_Main);
            CHB_UseUsername.Location = new Point(TB_PlayerName.Location.X, CHB_UseUsername.Location.Y);
            TB_PlayerName.Text = $"{Environment.UserName}";
        }
        private void PlayerOptions_Load(object sender, EventArgs e)
        {
            Design.ChangeControlElementsForeColor(this, Design.DefaultForeColor, DefaultBackColor);
            SetFormComponentsLocations();
        }
        private void PlayerOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Opacity == 1)
            {
                MenuForm mf = new MenuForm();
                Design.FormSwitching(this, mf, 1, false, 8);
            }
        }
        private void TB_PlayerName_MouseHover(object sender, EventArgs e)
        {
            TextBox hover = sender as TextBox;
            TT_PO.Show("Enter your name", hover);
        }
        private void CB_GameMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CHB_MoreInfo.Text = $"More info about \"{CB_GameMode.SelectedItem}\"";
            Options.GameModeInt = CB_GameMode.SelectedIndex;
            switch (CB_GameMode.SelectedIndex)
            {
                case 0:
                    {
                        
                        L_GameModeText.Text = $"In the \"{CB_GameMode.SelectedItem}\" you will receive\r\ninformation about the chances of hitting.\r\nBy choosing a specific cell on the map.\r\nDesigned for the study of probability.\r\n";
                        Options.GameMode = "Education";
                        break;
                    }
                case 1:
                    { 
                        L_GameModeText.Text = $"In \"{CB_GameMode.SelectedItem}\" you will not receive\r\ninformation about the chances of hitting.\r\nDesigned for casual play.";
                        Options.GameMode = "Classic";
                        break;
                    }
            }
        }
        private void CHB_MoreInfo_CheckedChanged(object sender, EventArgs e)
        {
            L_GameModeText.Visible = CHB_MoreInfo.Checked;
        }
        public void SetOptions()
        {
            if (Options.SingleplayerMode)
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
            GameForm gf = new GameForm();
            Design.FormSwitching(this, gf, 1, false, 8);
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
        private void BS_ApplyPlayerData_Click(object sender, EventArgs e)
        {
            if (TB_PlayerName.Text == Environment.UserName)
            {
                if (MessageBox.Show($"Start game with your computer username: {TB_PlayerName.Text}?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetOptions();
                }
                else
                {
                    TB_PlayerName.Clear();
                }
            }
            else if (TB_PlayerName.Text == string.Empty)
            {
                if (MessageBox.Show("Start game with default username?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetOptions();
                }
            }
            else
            {
                if (MessageBox.Show("Start game?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetOptions();
                }
            }
        }                
    }
}
