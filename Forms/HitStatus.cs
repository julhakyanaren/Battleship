using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Forms
{
    public partial class HitStatus : Form
    {
        public HitStatus()
        {
            InitializeComponent();
        }

        private void HitStatus_Load(object sender, EventArgs e)
        {
            TransparencyKey = Color.Magenta;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            BackColor = Color.Magenta;
        }
    }
}
