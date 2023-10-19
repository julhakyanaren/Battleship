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
            this.CHB_UseUsername = new System.Windows.Forms.CheckBox();
            this.BS_ApplyPlayerData = new System.Windows.Forms.Button();
            this.L_Info_DifficultyStatus = new System.Windows.Forms.Label();
            this.L_Info_Difficulty = new System.Windows.Forms.Label();
            this.CB_Difficulty = new System.Windows.Forms.ComboBox();
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
            this.TLP_PO_Main.Size = new System.Drawing.Size(378, 338);
            this.TLP_PO_Main.TabIndex = 0;
            // 
            // PNL_PO_Main
            // 
            this.PNL_PO_Main.BackColor = System.Drawing.Color.Black;
            this.PNL_PO_Main.Controls.Add(this.CHB_UseUsername);
            this.PNL_PO_Main.Controls.Add(this.BS_ApplyPlayerData);
            this.PNL_PO_Main.Controls.Add(this.L_Info_DifficultyStatus);
            this.PNL_PO_Main.Controls.Add(this.L_Info_Difficulty);
            this.PNL_PO_Main.Controls.Add(this.CB_Difficulty);
            this.PNL_PO_Main.Controls.Add(this.L_Info_PlayerName);
            this.PNL_PO_Main.Controls.Add(this.TB_PlayerName);
            this.PNL_PO_Main.Controls.Add(this.PB_PO_Logo);
            this.PNL_PO_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_PO_Main.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.PNL_PO_Main.Location = new System.Drawing.Point(3, 3);
            this.PNL_PO_Main.Name = "PNL_PO_Main";
            this.PNL_PO_Main.Size = new System.Drawing.Size(372, 332);
            this.PNL_PO_Main.TabIndex = 0;
            // 
            // CHB_UseUsername
            // 
            this.CHB_UseUsername.AutoSize = true;
            this.CHB_UseUsername.Checked = true;
            this.CHB_UseUsername.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHB_UseUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHB_UseUsername.Location = new System.Drawing.Point(72, 144);
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
            this.BS_ApplyPlayerData.Location = new System.Drawing.Point(114, 235);
            this.BS_ApplyPlayerData.Name = "BS_ApplyPlayerData";
            this.BS_ApplyPlayerData.Size = new System.Drawing.Size(135, 29);
            this.BS_ApplyPlayerData.TabIndex = 43;
            this.BS_ApplyPlayerData.Text = "Apply";
            this.BS_ApplyPlayerData.UseVisualStyleBackColor = true;
            this.BS_ApplyPlayerData.Click += new System.EventHandler(this.BS_ApplyPlayerData_Click);
            // 
            // L_Info_DifficultyStatus
            // 
            this.L_Info_DifficultyStatus.AutoSize = true;
            this.L_Info_DifficultyStatus.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Info_DifficultyStatus.Location = new System.Drawing.Point(124, 311);
            this.L_Info_DifficultyStatus.Name = "L_Info_DifficultyStatus";
            this.L_Info_DifficultyStatus.Size = new System.Drawing.Size(74, 21);
            this.L_Info_DifficultyStatus.TabIndex = 42;
            this.L_Info_DifficultyStatus.Text = "Difficulty:";
            // 
            // L_Info_Difficulty
            // 
            this.L_Info_Difficulty.AutoSize = true;
            this.L_Info_Difficulty.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Info_Difficulty.Location = new System.Drawing.Point(144, 168);
            this.L_Info_Difficulty.Name = "L_Info_Difficulty";
            this.L_Info_Difficulty.Size = new System.Drawing.Size(105, 20);
            this.L_Info_Difficulty.TabIndex = 41;
            this.L_Info_Difficulty.Text = "Difficulty Level";
            // 
            // CB_Difficulty
            // 
            this.CB_Difficulty.BackColor = System.Drawing.Color.Black;
            this.CB_Difficulty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Difficulty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.CB_Difficulty.FormattingEnabled = true;
            this.CB_Difficulty.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard",
            "Extrimal"});
            this.CB_Difficulty.Location = new System.Drawing.Point(72, 191);
            this.CB_Difficulty.Name = "CB_Difficulty";
            this.CB_Difficulty.Size = new System.Drawing.Size(221, 25);
            this.CB_Difficulty.TabIndex = 40;
            this.TT_PO.SetToolTip(this.CB_Difficulty, "Choose game difficulty");
            this.CB_Difficulty.SelectedIndexChanged += new System.EventHandler(this.CB_Difficulty_SelectedIndexChanged_1);
            // 
            // L_Info_PlayerName
            // 
            this.L_Info_PlayerName.AutoSize = true;
            this.L_Info_PlayerName.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Info_PlayerName.Location = new System.Drawing.Point(144, 86);
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
            this.TB_PlayerName.Location = new System.Drawing.Point(72, 109);
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
            this.ClientSize = new System.Drawing.Size(378, 338);
            this.Controls.Add(this.TLP_PO_Main);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PlayerOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Data";
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
        private System.Windows.Forms.ComboBox CB_Difficulty;
        private System.Windows.Forms.Label L_Info_Difficulty;
        private System.Windows.Forms.Label L_Info_DifficultyStatus;
        private System.Windows.Forms.Button BS_ApplyPlayerData;
        private System.Windows.Forms.CheckBox CHB_UseUsername;
    }
}