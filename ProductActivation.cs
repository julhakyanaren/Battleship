using Battleship.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class ProductActivation : Form
    {
        public ProductActivation()
        {
            InitializeComponent();
        }
        private void TB_KeyInput_TextChanged(object sender, EventArgs e)
        {

            string keyInput = TB_KeyInput.Text;
            int lenght = keyInput.Length;
            LicenseData ld = new LicenseData();
            if ((lenght - ld.SpacesCount) % 4 == 0 && keyInput.Length < 19)
            {
                ld.SpacesCount = lenght;
                TB_KeyInput.Text += " ";
                TB_KeyInput.SelectionStart = TB_KeyInput.Text.Length;
            }
            if (Regex.IsMatch(keyInput, "^[A-Za-z0-9]$"))
            {
                
            }
        }
    }
}
