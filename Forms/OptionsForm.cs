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
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void CHB_OP_GameModeClassic_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_OP_GameModeClassic.Checked == false && CHB_OP_GameModeEducation.Checked == false)
            {
                Options.GameMode = "None";
                TB_OF_GameMode.Text = "Not Selected";
                TB_OF_GameMode.ForeColor = Color.Red;
            }
            else
            {
                CheckBox chb = (CheckBox)sender;
                switch (chb.Name)
                {
                    case "CHB_OP_GameModeClassic":
                        {
                            if (chb.Checked)
                            {
                                CHB_OP_GameModeEducation.Checked = false;
                                Options.GameMode = "Classic";
                            }
                            break;
                        }
                    case "CHB_OP_GameModeEducation":
                        {
                            if (chb.Checked)
                            {
                                CHB_OP_GameModeClassic.Checked = false;
                                Options.GameMode = "Education";
                            }
                            break;
                        }
                }
                TB_OF_GameMode.Text = Options.GameMode;
                TB_OF_GameMode.ForeColor = Design.DefaultForeColor;
            }
        }

        private async void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuForm mf = new MenuForm();
            mf.Opacity = 0;
            mf.Show();
            for (double o = 0; o < 1; o += 0.04)
            {
                await Task.Delay(1);
                mf.Opacity = o;
            }
            mf.Opacity = 1;
            Dispose();
        }
    }
}
