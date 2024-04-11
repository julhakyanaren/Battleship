namespace Battleship.Forms
{
    partial class PlayerOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerOptions));
            this.TLP_PO_Main = new System.Windows.Forms.TableLayoutPanel();
            this.PNL_PO_Main = new System.Windows.Forms.Panel();
            this.CHB_MoreInfo = new System.Windows.Forms.CheckBox();
            this.L_GameModeText = new System.Windows.Forms.Label();
            this.L_Info_GameMode = new System.Windows.Forms.Label();
            this.CB_GameMode = new System.Windows.Forms.ComboBox();
            this.CHB_UseUsername = new System.Windows.Forms.CheckBox();
            this.BS_ApplyPlayerData = new System.Windows.Forms.Button();
            this.L_Info_PlayerName = new System.Windows.Forms.Label();
            this.TB_PlayerName = new System.Windows.Forms.TextBox();
            this.PB_PO_Logo = new System.Windows.Forms.PictureBox();
            this.TT_PO = new System.Windows.Forms.ToolTip(this.components);
            this.TLP_PO_Main.SuspendLayout();
            this.PNL_PO_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_PO_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP_PO_Main
            // 
            this.TLP_PO_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.TLP_PO_Main.ColumnCount = 1;
            this.TLP_PO_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_PO_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_PO_Main.Controls.Add(this.PNL_PO_Main, 0, 0);
            this.TLP_PO_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_PO_Main.ForeColor = System.Drawing.Color.Black;
            this.TLP_PO_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_PO_Main.Name = "TLP_PO_Main";
            this.TLP_PO_Main.RowCount = 1;
            this.TLP_PO_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_PO_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 295F));
            this.TLP_PO_Main.Size = new System.Drawing.Size(378, 388);
            this.TLP_PO_Main.TabIndex = 0;
            // 
            // PNL_PO_Main
            // 
            this.PNL_PO_Main.BackColor = System.Drawing.Color.Black;
            this.PNL_PO_Main.Controls.Add(this.CHB_MoreInfo);
            this.PNL_PO_Main.Controls.Add(this.L_GameModeText);
            this.PNL_PO_Main.Controls.Add(this.L_Info_GameMode);
            this.PNL_PO_Main.Controls.Add(this.CB_GameMode);
            this.PNL_PO_Main.Controls.Add(this.CHB_UseUsername);
            this.PNL_PO_Main.Controls.Add(this.BS_ApplyPlayerData);
            this.PNL_PO_Main.Controls.Add(this.L_Info_PlayerName);
            this.PNL_PO_Main.Controls.Add(this.TB_PlayerName);
            this.PNL_PO_Main.Controls.Add(this.PB_PO_Logo);
            this.PNL_PO_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_PO_Main.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.PNL_PO_Main.Location = new System.Drawing.Point(3, 3);
            this.PNL_PO_Main.Name = "PNL_PO_Main";
            this.PNL_PO_Main.Size = new System.Drawing.Size(372, 382);
            this.PNL_PO_Main.TabIndex = 0;
            // 
            // CHB_MoreInfo
            // 
            this.CHB_MoreInfo.AutoSize = true;
            this.CHB_MoreInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHB_MoreInfo.Location = new System.Drawing.Point(72, 210);
            this.CHB_MoreInfo.Name = "CHB_MoreInfo";
            this.CHB_MoreInfo.Size = new System.Drawing.Size(178, 21);
            this.CHB_MoreInfo.TabIndex = 48;
            this.CHB_MoreInfo.Text = "More info about Education Mode";
            this.CHB_MoreInfo.UseVisualStyleBackColor = true;
            this.CHB_MoreInfo.CheckedChanged += new System.EventHandler(this.CHB_MoreInfo_CheckedChanged);
            // 
            // L_GameModeText
            // 
            this.L_GameModeText.AutoSize = true;
            this.L_GameModeText.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_GameModeText.Location = new System.Drawing.Point(69, 234);
            this.L_GameModeText.Name = "L_GameModeText";
            this.L_GameModeText.Size = new System.Drawing.Size(232, 51);
            this.L_GameModeText.TabIndex = 47;
            this.L_GameModeText.Text = "In \"Adventure Mode\" you will not receive\r\ninformation about the chances of hittin" +
    "g.\r\nDesigned for casual play.";
            this.L_GameModeText.Visible = false;
            // 
            // L_Info_GameMode
            // 
            this.L_Info_GameMode.AutoSize = true;
            this.L_Info_GameMode.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Info_GameMode.Location = new System.Drawing.Point(144, 156);
            this.L_Info_GameMode.Name = "L_Info_GameMode";
            this.L_Info_GameMode.Size = new System.Drawing.Size(87, 20);
            this.L_Info_GameMode.TabIndex = 46;
            this.L_Info_GameMode.Text = "Game mode";
            // 
            // CB_GameMode
            // 
            this.CB_GameMode.BackColor = System.Drawing.Color.Black;
            this.CB_GameMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_GameMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.CB_GameMode.FormattingEnabled = true;
            this.CB_GameMode.Items.AddRange(new object[] {
            "Education Mode",
            "Classic Mode"});
            this.CB_GameMode.Location = new System.Drawing.Point(72, 179);
            this.CB_GameMode.Name = "CB_GameMode";
            this.CB_GameMode.Size = new System.Drawing.Size(221, 25);
            this.CB_GameMode.TabIndex = 45;
            this.CB_GameMode.Text = "Education Mode";
            this.CB_GameMode.SelectedIndexChanged += new System.EventHandler(this.CB_GameMode_SelectedIndexChanged);
            // 
            // CHB_UseUsername
            // 
            this.CHB_UseUsername.AutoSize = true;
            this.CHB_UseUsername.Checked = true;
            this.CHB_UseUsername.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHB_UseUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHB_UseUsername.Location = new System.Drawing.Point(72, 132);
            this.CHB_UseUsername.Name = "CHB_UseUsername";
            this.CHB_UseUsername.Size = new System.Drawing.Size(140, 21);
            this.CHB_UseUsername.TabIndex = 44;
            this.CHB_UseUsername.Text = "Use computer username";
            this.CHB_UseUsername.UseVisualStyleBackColor = true;
            this.CHB_UseUsername.CheckedChanged += new System.EventHandler(this.CHB_UseUsername_CheckedChanged);
            // 
            // BS_ApplyPlayerData
            // 
            this.BS_ApplyPlayerData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_ApplyPlayerData.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_ApplyPlayerData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.BS_ApplyPlayerData.Location = new System.Drawing.Point(72, 344);
            this.BS_ApplyPlayerData.Name = "BS_ApplyPlayerData";
            this.BS_ApplyPlayerData.Size = new System.Drawing.Size(221, 29);
            this.BS_ApplyPlayerData.TabIndex = 43;
            this.BS_ApplyPlayerData.Text = "Apply";
            this.BS_ApplyPlayerData.UseVisualStyleBackColor = true;
            this.BS_ApplyPlayerData.Click += new System.EventHandler(this.BS_ApplyPlayerData_Click);
            // 
            // L_Info_PlayerName
            // 
            this.L_Info_PlayerName.AutoSize = true;
            this.L_Info_PlayerName.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Info_PlayerName.Location = new System.Drawing.Point(144, 78);
            this.L_Info_PlayerName.Name = "L_Info_PlayerName";
            this.L_Info_PlayerName.Size = new System.Drawing.Size(89, 20);
            this.L_Info_PlayerName.TabIndex = 39;
            this.L_Info_PlayerName.Text = "Player name";
            // 
            // TB_PlayerName
            // 
            this.TB_PlayerName.BackColor = System.Drawing.Color.Black;
            this.TB_PlayerName.Font = new System.Drawing.Font("Franklin Gothic Demi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_PlayerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.TB_PlayerName.Location = new System.Drawing.Point(72, 101);
            this.TB_PlayerName.Name = "TB_PlayerName";
            this.TB_PlayerName.Size = new System.Drawing.Size(221, 25);
            this.TB_PlayerName.TabIndex = 28;
            this.TB_PlayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_PlayerName.MouseHover += new System.EventHandler(this.TB_PlayerName_MouseHover);
            // 
            // PB_PO_Logo
            // 
            this.PB_PO_Logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PB_PO_Logo.Image = global::Battleship.Properties.Resources.Logo;
            this.PB_PO_Logo.Location = new System.Drawing.Point(0, 0);
            this.PB_PO_Logo.Name = "PB_PO_Logo";
            this.PB_PO_Logo.Size = new System.Drawing.Size(372, 75);
            this.PB_PO_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_PO_Logo.TabIndex = 0;
            this.PB_PO_Logo.TabStop = false;
            // 
            // PlayerOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(378, 388);
            this.Controls.Add(this.TLP_PO_Main);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "PlayerOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerOptions_FormClosing);
            this.Load += new System.EventHandler(this.PlayerOptions_Load);
            this.TLP_PO_Main.ResumeLayout(false);
            this.PNL_PO_Main.ResumeLayout(false);
            this.PNL_PO_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_PO_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_PO_Main;
        private System.Windows.Forms.Panel PNL_PO_Main;
        private System.Windows.Forms.PictureBox PB_PO_Logo;
        public System.Windows.Forms.TextBox TB_PlayerName;
        private System.Windows.Forms.Label L_Info_PlayerName;
        private System.Windows.Forms.ToolTip TT_PO;
        private System.Windows.Forms.Button BS_ApplyPlayerData;
        private System.Windows.Forms.CheckBox CHB_UseUsername;
        private System.Windows.Forms.ComboBox CB_GameMode;
        private System.Windows.Forms.Label L_Info_GameMode;
        private System.Windows.Forms.Label L_GameModeText;
        private System.Windows.Forms.CheckBox CHB_MoreInfo;
    }
}