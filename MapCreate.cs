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
    public partial class MapCreate : Form
    {
        public MapCreate()
        {
            InitializeComponent();
        }

        private void MapCreate_FormClosed(object sender, FormClosedEventArgs e)
        {
            DebugTools.MCF.Opened = false;
        }
        private void MapCreate_Load(object sender, EventArgs e)
        {
            DebugTools.MCF.Opened = true;
        }
    }
}
