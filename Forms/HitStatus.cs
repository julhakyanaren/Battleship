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
            SetImage(Math.Abs(Fight.Turn - 1), "Hit", 0);
            Width = 600;
            Height = 300;
            TransparencyKey = Color.Magenta;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            BackColor = Color.Magenta;
        }
        public void SetImage(int playerOrEnemy, string infoType, int sunkenShipType)
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
                            case "Sunken":
                                {
                                    switch (sunkenShipType)
                                    {
                                        case 1:
                                            {
                                                break;
                                            }
                                        case 2:
                                            {
                                                break;
                                            }
                                        case 3:
                                            {
                                                break;
                                            }
                                        case 4:
                                            {
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
                            case "Sunken":
                                {
                                    switch (sunkenShipType)
                                    {
                                        case 1:
                                            {
                                                break;
                                            }
                                        case 2:
                                            {
                                                break;
                                            }
                                        case 3:
                                            {
                                                break;
                                            }
                                        case 4:
                                            {
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
