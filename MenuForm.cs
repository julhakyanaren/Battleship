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
            L_Info_Version.Text = "Version: " + DebugTools.Version;
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
        private void BS_MM_NewGame_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Start new game ?","Battleship", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (dr)
            {
                case DialogResult.Yes:
                    {
                        GamePlayerOne GPO = new GamePlayerOne();
                        GPO.Show();
                        Hide();
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
