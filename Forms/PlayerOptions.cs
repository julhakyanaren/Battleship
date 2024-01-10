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
            L_Info_DifficultyStatus.ForeColor = Color.Lime;
        }
        public void SetFormComponentsLocations()
        {
            Design.SetComponentLocation(L_Info_PlayerName, PNL_PO_Main);
            Design.SetComponentLocation(TB_PlayerName, PNL_PO_Main);
            Design.SetComponentLocation(CB_Difficulty, PNL_PO_Main);
            Design.SetComponentLocation(L_Info_Difficulty, PNL_PO_Main);
            Design.SetComponentLocation(L_Info_DifficultyStatus, PNL_PO_Main);
            Design.SetComponentLocation(BS_ApplyPlayerData, PNL_PO_Main);
            CHB_UseUsername.Location = new Point(TB_PlayerName.Location.X, CHB_UseUsername.Location.Y);
            TB_PlayerName.Text = $"{Environment.UserName}";
        }
        private void TB_PlayerName_MouseHover(object sender, EventArgs e)
        {
            TextBox hover = sender as TextBox;
            TT_PO.Show("Enter your name", hover);;
        }
        private void CB_Difficulty_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
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
                Options.DifficultyName = CB_Difficulty.Text;
                Options.Difficulty = CB_Difficulty.SelectedIndex;
            }
            GameForm GPO = new GameForm();
            Design.FormSwitching(this, GPO, 1, false, 8);
        }
        private void BS_ApplyPlayerData_Click(object sender, EventArgs e)
        {
            if (CB_Difficulty.SelectedIndex == -1)
            {
                MessageBox.Show("Difficulty level not selected.", "Battleship", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
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
                    DialogResult = MessageBox.Show("Difficulty level not selected\r\nStart game with default username?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void CB_Difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CB_Difficulty.SelectedIndex)
            {
                case 0:
                    {
                        L_Info_DifficultyStatus.Text = "Difficulty: Easy";
                        L_Info_DifficultyStatus.ForeColor = Color.Lime;
                        break;
                    }
                case 1:
                    {
                        L_Info_DifficultyStatus.Text = "Difficulty: Medium";
                        L_Info_DifficultyStatus.ForeColor = Color.Yellow;
                        break;
                    }
                case 2:
                    {
                        L_Info_DifficultyStatus.Text = "Difficulty: Hard";
                        L_Info_DifficultyStatus.ForeColor = Color.Red;
                        break;
                    }
                case 3:
                    {
                        L_Info_DifficultyStatus.Text = "Difficulty: Extrimal";
                        L_Info_DifficultyStatus.ForeColor = Color.DarkRed;

                        break;
                    }
            }
            if (CB_Difficulty.SelectedIndex != 3)
            {
                L_Info_DifficultyStatus.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            else
            {
                L_Info_DifficultyStatus.Font = new Font("Franklin Gothic Demi", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            Design.SetComponentLocation(L_Info_DifficultyStatus, PNL_PO_Main);
        }

        private void PlayerOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Opacity == 1)
            {
                MenuForm mf = new MenuForm();
                Design.FormSwitching(this, mf, 1, false, 8);
                if (CB_Difficulty.SelectedIndex != -1)
                {
                    Dispose();
                }
            }
        }
    }
}
