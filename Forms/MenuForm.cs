using Battleship.Classes;
using Battleship.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }
        public void SetElementsParameters()
        {
            if (!DebugTools.AlreadyRun)
            {
                FileManager.ReadAssembyData();
                DebugTools.AlreadyRun = true;
            }
            L_Info_Version.Text = $"Version: {DebugTools.Version}.{DebugTools.RunsCount}";
            int x = L_Info_Version.Location.X;
            int y = L_Info_Version.Location.Y;
            x = (PB_MF_MainLogo.Size.Width - L_Info_Version.Size.Width) / 2;
            L_Info_Version.Location = new Point(x, y);
        }
        private void MenuForm_Load(object sender, EventArgs e)
        {
            /**/
            Design.ChangeControlElementsForeColor(this, Design.DefaultForeColor, DefaultBackColor);
            /**/
            SetElementsParameters();
        }
        private void BS_MM_About_Click(object sender, EventArgs e)
        {
            
        }

        private void PB_Button_NewGame_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Start new game ?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (dr)
            {
                case DialogResult.Yes:
                    {
                        PlayerOptions PO = new PlayerOptions();
                        Design.FormSwitching(this, PO, 1, false, 8);
                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
            }
        }

        private void PB_Button_NewGame_MouseDown(object sender, MouseEventArgs e)
        {
            PB_Button_NewGame.Image = Properties.Resources.NewGame_MouseDown;
        }

        private void PB_Button_NewGame_MouseUp(object sender, MouseEventArgs e)
        {
            PB_Button_NewGame.Image = Properties.Resources.NewGame_MouseUp;
        }
        private void PB_Button_Options_MouseDown(object sender, MouseEventArgs e)
        {
            PB_Button_Options.Image = Properties.Resources.Options_MouseDown;
        }
        private void PB_Button_Options_MouseUp(object sender, MouseEventArgs e)
        {
            PB_Button_Options.Image = Properties.Resources.Options_MouseUp;
        }
        private void PB_Button_About_MouseDown(object sender, MouseEventArgs e)
        {
            PB_Button_About.Image = Properties.Resources.About_MouseDown;
        }
        private void PB_Button_About_MouseUp(object sender, MouseEventArgs e)
        {
            PB_Button_About.Image = Properties.Resources.About_MouseUp;
        }
        private void PB_Button_About_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Opern manual ?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                ManualInfo mi = new ManualInfo();
                Design.OpenNewForm(mi, 1, 10);
            }
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Opacity == 1)
            {
                DialogResult = MessageBox.Show("Are you sure you want to close programm ?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
            }
        }

        private void PB_Button_Options_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm();
            Design.FormSwitching(this, optionsForm, 1, false, 8);
        }
    }
}
