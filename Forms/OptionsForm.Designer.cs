namespace Battleship.Forms
{
    partial class OptionsForm
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
            this.GB_GameMode = new System.Windows.Forms.GroupBox();
            this.TB_OF_GameMode = new System.Windows.Forms.TextBox();
            this.CHB_OP_GameModeEducation = new System.Windows.Forms.CheckBox();
            this.CHB_OP_GameModeClassic = new System.Windows.Forms.CheckBox();
            this.GB_OF_DevMode = new System.Windows.Forms.GroupBox();
            this.BS_PO_CheckAccess = new System.Windows.Forms.Button();
            this.L_Info_OF_Access = new System.Windows.Forms.Label();
            this.TB_OF_DevPass = new System.Windows.Forms.TextBox();
            this.GB_Assembly = new System.Windows.Forms.GroupBox();
            this.BS_AD_ApplyChanges = new System.Windows.Forms.Button();
            this.TB_AD_Version_Launches = new System.Windows.Forms.TextBox();
            this.NUD_AD_Version_Edition = new System.Windows.Forms.NumericUpDown();
            this.L_AD_Version_Edition = new System.Windows.Forms.Label();
            this.L_AD_Version_Launches = new System.Windows.Forms.Label();
            this.NUD_AD_Version_Assembly = new System.Windows.Forms.NumericUpDown();
            this.L_AD_Version_Assembly = new System.Windows.Forms.Label();
            this.NUD_AD_Version_Release = new System.Windows.Forms.NumericUpDown();
            this.L_AD_Version_Release = new System.Windows.Forms.Label();
            this.CB_AD_Stage = new System.Windows.Forms.ComboBox();
            this.TB_AD_Stage = new System.Windows.Forms.Label();
            this.TB_NoDev_Stage = new System.Windows.Forms.TextBox();
            this.GB_GameMode.SuspendLayout();
            this.GB_OF_DevMode.SuspendLayout();
            this.GB_Assembly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AD_Version_Edition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AD_Version_Assembly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AD_Version_Release)).BeginInit();
            this.SuspendLayout();
            // 
            // GB_GameMode
            // 
            this.GB_GameMode.BackColor = System.Drawing.Color.Black;
            this.GB_GameMode.Controls.Add(this.TB_OF_GameMode);
            this.GB_GameMode.Controls.Add(this.CHB_OP_GameModeEducation);
            this.GB_GameMode.Controls.Add(this.CHB_OP_GameModeClassic);
            this.GB_GameMode.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GB_GameMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.GB_GameMode.Location = new System.Drawing.Point(3, 12);
            this.GB_GameMode.Name = "GB_GameMode";
            this.GB_GameMode.Size = new System.Drawing.Size(155, 105);
            this.GB_GameMode.TabIndex = 0;
            this.GB_GameMode.TabStop = false;
            this.GB_GameMode.Text = "Game mode";
            // 
            // TB_OF_GameMode
            // 
            this.TB_OF_GameMode.BackColor = System.Drawing.Color.Black;
            this.TB_OF_GameMode.Font = new System.Drawing.Font("Franklin Gothic Demi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_OF_GameMode.ForeColor = System.Drawing.Color.White;
            this.TB_OF_GameMode.Location = new System.Drawing.Point(6, 75);
            this.TB_OF_GameMode.Name = "TB_OF_GameMode";
            this.TB_OF_GameMode.ReadOnly = true;
            this.TB_OF_GameMode.Size = new System.Drawing.Size(143, 22);
            this.TB_OF_GameMode.TabIndex = 43;
            this.TB_OF_GameMode.Text = "Classic Mode";
            this.TB_OF_GameMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CHB_OP_GameModeEducation
            // 
            this.CHB_OP_GameModeEducation.AutoSize = true;
            this.CHB_OP_GameModeEducation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHB_OP_GameModeEducation.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.CHB_OP_GameModeEducation.Location = new System.Drawing.Point(6, 48);
            this.CHB_OP_GameModeEducation.Name = "CHB_OP_GameModeEducation";
            this.CHB_OP_GameModeEducation.Size = new System.Drawing.Size(101, 21);
            this.CHB_OP_GameModeEducation.TabIndex = 42;
            this.CHB_OP_GameModeEducation.Text = "Education mode";
            this.CHB_OP_GameModeEducation.UseVisualStyleBackColor = true;
            this.CHB_OP_GameModeEducation.CheckedChanged += new System.EventHandler(this.CHB_OP_GameModeClassic_CheckedChanged);
            // 
            // CHB_OP_GameModeClassic
            // 
            this.CHB_OP_GameModeClassic.AutoSize = true;
            this.CHB_OP_GameModeClassic.Checked = true;
            this.CHB_OP_GameModeClassic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHB_OP_GameModeClassic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHB_OP_GameModeClassic.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.CHB_OP_GameModeClassic.Location = new System.Drawing.Point(6, 21);
            this.CHB_OP_GameModeClassic.Name = "CHB_OP_GameModeClassic";
            this.CHB_OP_GameModeClassic.Size = new System.Drawing.Size(87, 21);
            this.CHB_OP_GameModeClassic.TabIndex = 41;
            this.CHB_OP_GameModeClassic.Text = "Classic mode";
            this.CHB_OP_GameModeClassic.UseVisualStyleBackColor = true;
            this.CHB_OP_GameModeClassic.CheckedChanged += new System.EventHandler(this.CHB_OP_GameModeClassic_CheckedChanged);
            // 
            // GB_OF_DevMode
            // 
            this.GB_OF_DevMode.BackColor = System.Drawing.Color.Black;
            this.GB_OF_DevMode.Controls.Add(this.BS_PO_CheckAccess);
            this.GB_OF_DevMode.Controls.Add(this.L_Info_OF_Access);
            this.GB_OF_DevMode.Controls.Add(this.TB_OF_DevPass);
            this.GB_OF_DevMode.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GB_OF_DevMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.GB_OF_DevMode.Location = new System.Drawing.Point(3, 123);
            this.GB_OF_DevMode.Name = "GB_OF_DevMode";
            this.GB_OF_DevMode.Size = new System.Drawing.Size(155, 105);
            this.GB_OF_DevMode.TabIndex = 44;
            this.GB_OF_DevMode.TabStop = false;
            this.GB_OF_DevMode.Text = "Developer mode";
            // 
            // BS_PO_CheckAccess
            // 
            this.BS_PO_CheckAccess.BackColor = System.Drawing.Color.Black;
            this.BS_PO_CheckAccess.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BS_PO_CheckAccess.FlatAppearance.BorderSize = 2;
            this.BS_PO_CheckAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_PO_CheckAccess.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_PO_CheckAccess.Location = new System.Drawing.Point(6, 67);
            this.BS_PO_CheckAccess.Name = "BS_PO_CheckAccess";
            this.BS_PO_CheckAccess.Size = new System.Drawing.Size(143, 30);
            this.BS_PO_CheckAccess.TabIndex = 46;
            this.BS_PO_CheckAccess.Text = "Check Access";
            this.BS_PO_CheckAccess.UseVisualStyleBackColor = false;
            this.BS_PO_CheckAccess.Click += new System.EventHandler(this.BS_PO_CheckAccess_Click);
            // 
            // L_Info_OF_Access
            // 
            this.L_Info_OF_Access.AutoSize = true;
            this.L_Info_OF_Access.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Info_OF_Access.Location = new System.Drawing.Point(6, 19);
            this.L_Info_OF_Access.Name = "L_Info_OF_Access";
            this.L_Info_OF_Access.Size = new System.Drawing.Size(91, 17);
            this.L_Info_OF_Access.TabIndex = 45;
            this.L_Info_OF_Access.Text = "Developer Access";
            // 
            // TB_OF_DevPass
            // 
            this.TB_OF_DevPass.BackColor = System.Drawing.Color.Black;
            this.TB_OF_DevPass.Font = new System.Drawing.Font("Franklin Gothic Demi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_OF_DevPass.ForeColor = System.Drawing.Color.White;
            this.TB_OF_DevPass.Location = new System.Drawing.Point(6, 39);
            this.TB_OF_DevPass.Name = "TB_OF_DevPass";
            this.TB_OF_DevPass.PasswordChar = '*';
            this.TB_OF_DevPass.Size = new System.Drawing.Size(143, 22);
            this.TB_OF_DevPass.TabIndex = 44;
            this.TB_OF_DevPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GB_Assembly
            // 
            this.GB_Assembly.BackColor = System.Drawing.Color.Black;
            this.GB_Assembly.Controls.Add(this.TB_NoDev_Stage);
            this.GB_Assembly.Controls.Add(this.BS_AD_ApplyChanges);
            this.GB_Assembly.Controls.Add(this.TB_AD_Version_Launches);
            this.GB_Assembly.Controls.Add(this.NUD_AD_Version_Edition);
            this.GB_Assembly.Controls.Add(this.L_AD_Version_Edition);
            this.GB_Assembly.Controls.Add(this.L_AD_Version_Launches);
            this.GB_Assembly.Controls.Add(this.NUD_AD_Version_Assembly);
            this.GB_Assembly.Controls.Add(this.L_AD_Version_Assembly);
            this.GB_Assembly.Controls.Add(this.NUD_AD_Version_Release);
            this.GB_Assembly.Controls.Add(this.L_AD_Version_Release);
            this.GB_Assembly.Controls.Add(this.CB_AD_Stage);
            this.GB_Assembly.Controls.Add(this.TB_AD_Stage);
            this.GB_Assembly.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GB_Assembly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.GB_Assembly.Location = new System.Drawing.Point(164, 12);
            this.GB_Assembly.Name = "GB_Assembly";
            this.GB_Assembly.Size = new System.Drawing.Size(179, 216);
            this.GB_Assembly.TabIndex = 45;
            this.GB_Assembly.TabStop = false;
            this.GB_Assembly.Text = "Assembly Data";
            // 
            // BS_AD_ApplyChanges
            // 
            this.BS_AD_ApplyChanges.BackColor = System.Drawing.Color.Black;
            this.BS_AD_ApplyChanges.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BS_AD_ApplyChanges.FlatAppearance.BorderSize = 2;
            this.BS_AD_ApplyChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_AD_ApplyChanges.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_AD_ApplyChanges.Location = new System.Drawing.Point(9, 175);
            this.BS_AD_ApplyChanges.Name = "BS_AD_ApplyChanges";
            this.BS_AD_ApplyChanges.Size = new System.Drawing.Size(164, 30);
            this.BS_AD_ApplyChanges.TabIndex = 47;
            this.BS_AD_ApplyChanges.Text = "Apply Changes";
            this.BS_AD_ApplyChanges.UseVisualStyleBackColor = false;
            this.BS_AD_ApplyChanges.Click += new System.EventHandler(this.BS_AD_ApplyChanges_Click);
            // 
            // TB_AD_Version_Launches
            // 
            this.TB_AD_Version_Launches.BackColor = System.Drawing.Color.Black;
            this.TB_AD_Version_Launches.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.TB_AD_Version_Launches.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.TB_AD_Version_Launches.Location = new System.Drawing.Point(122, 147);
            this.TB_AD_Version_Launches.Name = "TB_AD_Version_Launches";
            this.TB_AD_Version_Launches.ReadOnly = true;
            this.TB_AD_Version_Launches.Size = new System.Drawing.Size(51, 22);
            this.TB_AD_Version_Launches.TabIndex = 58;
            // 
            // NUD_AD_Version_Edition
            // 
            this.NUD_AD_Version_Edition.BackColor = System.Drawing.Color.Black;
            this.NUD_AD_Version_Edition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.NUD_AD_Version_Edition.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NUD_AD_Version_Edition.Location = new System.Drawing.Point(122, 121);
            this.NUD_AD_Version_Edition.Name = "NUD_AD_Version_Edition";
            this.NUD_AD_Version_Edition.Size = new System.Drawing.Size(51, 22);
            this.NUD_AD_Version_Edition.TabIndex = 57;
            // 
            // L_AD_Version_Edition
            // 
            this.L_AD_Version_Edition.AutoSize = true;
            this.L_AD_Version_Edition.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_AD_Version_Edition.Location = new System.Drawing.Point(6, 123);
            this.L_AD_Version_Edition.Name = "L_AD_Version_Edition";
            this.L_AD_Version_Edition.Size = new System.Drawing.Size(80, 17);
            this.L_AD_Version_Edition.TabIndex = 56;
            this.L_AD_Version_Edition.Text = "Edition Version";
            // 
            // L_AD_Version_Launches
            // 
            this.L_AD_Version_Launches.AutoSize = true;
            this.L_AD_Version_Launches.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_AD_Version_Launches.Location = new System.Drawing.Point(6, 147);
            this.L_AD_Version_Launches.Name = "L_AD_Version_Launches";
            this.L_AD_Version_Launches.Size = new System.Drawing.Size(94, 17);
            this.L_AD_Version_Launches.TabIndex = 54;
            this.L_AD_Version_Launches.Text = "Program launches";
            // 
            // NUD_AD_Version_Assembly
            // 
            this.NUD_AD_Version_Assembly.BackColor = System.Drawing.Color.Black;
            this.NUD_AD_Version_Assembly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.NUD_AD_Version_Assembly.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NUD_AD_Version_Assembly.Location = new System.Drawing.Point(122, 97);
            this.NUD_AD_Version_Assembly.Name = "NUD_AD_Version_Assembly";
            this.NUD_AD_Version_Assembly.Size = new System.Drawing.Size(51, 22);
            this.NUD_AD_Version_Assembly.TabIndex = 53;
            // 
            // L_AD_Version_Assembly
            // 
            this.L_AD_Version_Assembly.AutoSize = true;
            this.L_AD_Version_Assembly.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_AD_Version_Assembly.Location = new System.Drawing.Point(6, 99);
            this.L_AD_Version_Assembly.Name = "L_AD_Version_Assembly";
            this.L_AD_Version_Assembly.Size = new System.Drawing.Size(90, 17);
            this.L_AD_Version_Assembly.TabIndex = 52;
            this.L_AD_Version_Assembly.Text = "Assembly version";
            // 
            // NUD_AD_Version_Release
            // 
            this.NUD_AD_Version_Release.BackColor = System.Drawing.Color.Black;
            this.NUD_AD_Version_Release.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.NUD_AD_Version_Release.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NUD_AD_Version_Release.Location = new System.Drawing.Point(122, 73);
            this.NUD_AD_Version_Release.Name = "NUD_AD_Version_Release";
            this.NUD_AD_Version_Release.Size = new System.Drawing.Size(51, 22);
            this.NUD_AD_Version_Release.TabIndex = 49;
            // 
            // L_AD_Version_Release
            // 
            this.L_AD_Version_Release.AutoSize = true;
            this.L_AD_Version_Release.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_AD_Version_Release.Location = new System.Drawing.Point(6, 75);
            this.L_AD_Version_Release.Name = "L_AD_Version_Release";
            this.L_AD_Version_Release.Size = new System.Drawing.Size(84, 17);
            this.L_AD_Version_Release.TabIndex = 48;
            this.L_AD_Version_Release.Text = "Release version";
            // 
            // CB_AD_Stage
            // 
            this.CB_AD_Stage.BackColor = System.Drawing.Color.Black;
            this.CB_AD_Stage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_AD_Stage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.CB_AD_Stage.FormattingEnabled = true;
            this.CB_AD_Stage.Items.AddRange(new object[] {
            "InDev",
            "Alpha",
            "Beta",
            "Pre-Release",
            "Release",
            "Debug"});
            this.CB_AD_Stage.Location = new System.Drawing.Point(9, 43);
            this.CB_AD_Stage.Name = "CB_AD_Stage";
            this.CB_AD_Stage.Size = new System.Drawing.Size(164, 25);
            this.CB_AD_Stage.TabIndex = 47;
            this.CB_AD_Stage.Text = "Alpha";
            // 
            // TB_AD_Stage
            // 
            this.TB_AD_Stage.AutoSize = true;
            this.TB_AD_Stage.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_AD_Stage.Location = new System.Drawing.Point(6, 23);
            this.TB_AD_Stage.Name = "TB_AD_Stage";
            this.TB_AD_Stage.Size = new System.Drawing.Size(105, 17);
            this.TB_AD_Stage.TabIndex = 46;
            this.TB_AD_Stage.Text = "Development Stage ";
            // 
            // TB_NoDev_Stage
            // 
            this.TB_NoDev_Stage.BackColor = System.Drawing.Color.Black;
            this.TB_NoDev_Stage.Font = new System.Drawing.Font("Franklin Gothic Demi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_NoDev_Stage.ForeColor = System.Drawing.Color.White;
            this.TB_NoDev_Stage.Location = new System.Drawing.Point(9, 43);
            this.TB_NoDev_Stage.Multiline = true;
            this.TB_NoDev_Stage.Name = "TB_NoDev_Stage";
            this.TB_NoDev_Stage.ReadOnly = true;
            this.TB_NoDev_Stage.Size = new System.Drawing.Size(146, 25);
            this.TB_NoDev_Stage.TabIndex = 59;
            this.TB_NoDev_Stage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(348, 239);
            this.Controls.Add(this.GB_Assembly);
            this.Controls.Add(this.GB_OF_DevMode);
            this.Controls.Add(this.GB_GameMode);
            this.Font = new System.Drawing.Font("Franklin Gothic Demi", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.GB_GameMode.ResumeLayout(false);
            this.GB_GameMode.PerformLayout();
            this.GB_OF_DevMode.ResumeLayout(false);
            this.GB_OF_DevMode.PerformLayout();
            this.GB_Assembly.ResumeLayout(false);
            this.GB_Assembly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AD_Version_Edition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AD_Version_Assembly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AD_Version_Release)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_GameMode;
        private System.Windows.Forms.CheckBox CHB_OP_GameModeClassic;
        private System.Windows.Forms.CheckBox CHB_OP_GameModeEducation;
        public System.Windows.Forms.TextBox TB_OF_GameMode;
        private System.Windows.Forms.GroupBox GB_OF_DevMode;
        public System.Windows.Forms.TextBox TB_OF_DevPass;
        private System.Windows.Forms.Label L_Info_OF_Access;
        private System.Windows.Forms.Button BS_PO_CheckAccess;
        private System.Windows.Forms.GroupBox GB_Assembly;
        private System.Windows.Forms.Label TB_AD_Stage;
        private System.Windows.Forms.ComboBox CB_AD_Stage;
        private System.Windows.Forms.Label L_AD_Version_Release;
        private System.Windows.Forms.NumericUpDown NUD_AD_Version_Release;
        private System.Windows.Forms.NumericUpDown NUD_AD_Version_Edition;
        private System.Windows.Forms.Label L_AD_Version_Edition;
        private System.Windows.Forms.Label L_AD_Version_Launches;
        private System.Windows.Forms.NumericUpDown NUD_AD_Version_Assembly;
        private System.Windows.Forms.Label L_AD_Version_Assembly;
        private System.Windows.Forms.Button BS_AD_ApplyChanges;
        public System.Windows.Forms.TextBox TB_AD_Version_Launches;
        public System.Windows.Forms.TextBox TB_NoDev_Stage;
    }
}