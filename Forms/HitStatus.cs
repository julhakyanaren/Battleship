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
            SetImage(Math.Abs(Fight.Turn - 1), "Hit");
            Width = 600;
            Height = 300;
            TransparencyKey = Color.Magenta;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            BackColor = Color.Magenta;
        }
        public void SetImage(int playerOrEnemy, string infoType)
        {
            switch (playerOrEnemy)
            {
                case 0:
                    {
                        switch (infoType)
                        {
                            case "Hit":
                                {
                                    PB_HS_HitStatus.Image = Properties.Resources.Hit_Status_YouHit;
                                    break;
                                }
                            case "Miss":
                                {
                                    PB_HS_HitStatus.Image = Properties.Resources.Hit_Status_YouMissed;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }
                case 1:
                    {
                        switch (infoType)
                        {
                            case "Hit":
                                {
                                    PB_HS_HitStatus.Image = Properties.Resources.Hit_Status_EnemyHited;
                                    break;
                                }
                            case "Miss":
                                {
                                    PB_HS_HitStatus.Image = Properties.Resources.Hit_Status_EnemyMissed;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
