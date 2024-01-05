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
using System.Windows.Forms.DataVisualization.Charting;

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
            if (TB_KeyInput.Text.Length != 0)
            {
                if (TB_KeyInput.Text[TB_KeyInput.Text.Length - 1] != ' ')
                {
                    string keyInput = TB_KeyInput.Text;
                    int lenght = keyInput.Length;
                    if ((lenght - LicenseData.SpacesCount) % 4 == 0 && keyInput.Length < 19)
                    {
                        LicenseData.SpacesCount++;
                        TB_KeyInput.Text += " ";
                    }
                    TB_KeyInput.SelectionStart = TB_KeyInput.Text.Length;
                }
            }
        }

        private void ProductActivation_Load(object sender, EventArgs e)
        {
            LicenseData.SpacesCount = 0;
            TB_KeyInput.Location = new Point((Width - TB_KeyInput.Width) / 2, TB_KeyInput.Location.Y);
            L_Info_ProductActivation.Location = new Point((Width - L_Info_ProductActivation.Width) / 2, L_Info_ProductActivation.Location.Y);
            BS_KeyActivate.Location = new Point (TB_KeyInput.Location.X, BS_KeyActivate.Location.Y);
            BS_KeyClear.Location = new Point(BS_KeyActivate.Location.X + BS_KeyActivate.Width + 10, BS_KeyClear.Location.Y);
        }

        private void TB_KeyInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TB_KeyInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || Char.IsDigit(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
            else
            {
                e.Handled = true;
            }
        }

        private void BS_KeyClear_Click(object sender, EventArgs e)
        {
            if (TB_KeyInput.Text.Length != 0)
            {
                DialogResult drClearKey = MessageBox.Show("Clear entered key?", "Security Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drClearKey == DialogResult.Yes)
                {
                    TB_KeyInput.Clear();
                    LicenseData.SpacesCount = 0;
                }
            }
        }

        private void BS_KeyActivate_Click(object sender, EventArgs e)
        {
            DialogResult drActivateKey = new DialogResult();
            if (TB_KeyInput.Text.Length == TB_KeyInput.MaxLength)
            {
                drActivateKey = MessageBox.Show("Check entered key?", "Security Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drActivateKey == DialogResult.Yes)
                {
                    //Waiting for changes
                    LicenseData.EnteredKey = TB_KeyInput.Text;
                    LicenseData.SetFinalKey();
                }
            }
            else
            {
                if (TB_KeyInput.Text.Length == 0)
                {
                    MessageBox.Show("Empty Key!", "Security Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Incorrect key!", "Security Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
