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

        private void MenuForm_Load(object sender, EventArgs e)
        {
            int w = Width;
            int x = (w - L_MM_Title.Width) / 2;
            L_MM_Title.Location = new Point(x, 6);
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
