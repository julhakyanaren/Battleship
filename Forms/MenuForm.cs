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
            KeyDown += MenuForm_KeyDown;
        }
        private void MenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            keyBuffer.Add(e.KeyCode);
            if (keyBuffer.Count > secretCode.Length)
                keyBuffer.RemoveAt(0);
            if (keyBuffer.SequenceEqual(secretCode))
            {
                OptionsForm optionsForm = new OptionsForm();
                optionsForm.Show();
            }
        }

        private readonly List<Keys> keyBuffer = new List<Keys>();
        private readonly Keys[] secretCode = new Keys[] { Keys.I, Keys.D, Keys.D, Keys.Q, Keys.D };
        public void SetElementsParameters()
        {
            if (!DebugTools.AlreadyRun)
            {
                FileManager.ReadAssembyData();
                DebugTools.RunsCount++;
                FileManager.WriteAssemblyData();
                DebugTools.AlreadyRun = true;
            }
            L_Info_Version.Text = $"Version: {DebugTools.Version}.{DebugTools.RunsCount}";
            int x = (PB_MF_MainLogo.Size.Width - L_Info_Version.Size.Width) / 2;
            int y = L_Info_Version.Location.Y;
            L_Info_Version.Location = new Point(x, y);
        }
        private void MenuForm_Load(object sender, EventArgs e)
        {
            Design.ChangeControlElementsForeColor(this, Design.DefaultForeColor, DefaultBackColor);
            SetElementsParameters();
        }
        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Opacity == 1)
            {
                if (MessageBox.Show("Are you sure you want to close program ?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
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
        private void PB_Button_NewGame_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Start new game in \"Classic Mode\" with default username?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    {
                        Options.GameMode = "Classic";
                        Options.GameModeInt = 1;
                        GameForm GF = new GameForm();
                        Design.FormSwitching(this, GF, 1, false, 8);                        
                        break;
                    }
            }
            //Unused 19
        }
        private void PB_Button_Options_Click(object sender, EventArgs e)
        {
            PlayerOptions PO = new PlayerOptions();
            Design.FormSwitching(this, PO, 1, false, 8);
        }
        private void PB_Button_About_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Open manual ?", "Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ManualInfo mi = new ManualInfo();
                Design.OpenNewForm(mi, 1, 10);
            }
        }
    }
}
