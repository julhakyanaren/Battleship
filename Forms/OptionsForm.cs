﻿using Battleship.Classes;
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

        private void BS_PO_CheckAccess_Click(object sender, EventArgs e)
        {
            if (TB_OF_DevPass.Text == DeveloperData.DevPass)
            {
                MessageBox.Show("Developer mode on", $"{Handlers.Manager[6]}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DeveloperData.DeveloperModeON = true;
            }
            else
            {
                DeveloperData.AttemptsCount--;
                if (DeveloperData.AttemptsCount >= 0)
                {
                    DialogResult = MessageBox.Show($"Access denied!\r\nAttempts Count: {DeveloperData.AttemptsCount}", $"{Handlers.Manager[6]}", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Security error, the number of attempts to access the developer tools has been exceeded, the program is forced to close.", $"{Handlers.Manager[6]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            if (DeveloperData.DeveloperModeON)
            {
                NUD_AD_Version_Release.Increment = 1;
                NUD_AD_Version_Assembly.Increment = 1;
                NUD_AD_Version_Edition.Increment = 1;
                TB_NoDev_Stage.Visible = false;
                CB_AD_Stage.Enabled = true;
            }
        }
        private void OptionsForm_Load(object sender, EventArgs e)
        {
            CB_AD_Stage.Text = CB_AD_Stage.Items[Array.IndexOf(Options.Stages, Options.V_StageName)].ToString();
            TB_NoDev_Stage.Location = CB_AD_Stage.Location;
            TB_NoDev_Stage.Text = CB_AD_Stage.Text;
            CB_AD_Stage.Enabled = false;
            NUD_AD_Version_Release.Value = Options.V_Release;
            NUD_AD_Version_Assembly.Value = Options.V_Assembly;
            NUD_AD_Version_Edition.Value = Options.V_Edition;
            TB_AD_Version_Launches.Text = DebugTools.RunsCount.ToString();
        }

        private void BS_AD_ApplyChanges_Click(object sender, EventArgs e)
        {
            if (!DeveloperData.DeveloperModeON)
            {
                DeveloperData.AttemptsCount--;
                if (DeveloperData.AttemptsCount >= 0)
                {
                    DialogResult = MessageBox.Show($"Access denied!\r\nAttempts Count: {DeveloperData.AttemptsCount}", $"{Handlers.Manager[6]}", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Security error, the number of attempts to access the developer tools has been exceeded, the program is forced to close.", $"{Handlers.Manager[6]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Accept changes", $"{Handlers.Manager[6]}",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        Options.V_Release = Convert.ToInt32(NUD_AD_Version_Release.Value);
                        Options.V_Assembly = Convert.ToInt32(NUD_AD_Version_Assembly.Value);
                        Options.V_Edition = Convert.ToInt32(NUD_AD_Version_Edition.Value);
                        Options.V_StageName = CB_AD_Stage.Text;
                        Options.V_Stage = Array.IndexOf(Options.Stages, Options.V_StageName);
                        DebugTools.RunsCount = 0;
                        FileManager.WriteAssemblyData();
                    }
                    catch
                    {
                        //Error_Catch
                    }
                }
            }
        }
    }
}
