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
            this.TB_OF_DevPass = new System.Windows.Forms.TextBox();
            this.L_Info_OF_Access = new System.Windows.Forms.Label();
            this.BS_PO_CheckAccess = new System.Windows.Forms.Button();
            this.GB_GameMode.SuspendLayout();
            this.GB_OF_DevMode.SuspendLayout();
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
            this.GB_OF_DevMode.Location = new System.Drawing.Point(158, 12);
            this.GB_OF_DevMode.Name = "GB_OF_DevMode";
            this.GB_OF_DevMode.Size = new System.Drawing.Size(155, 105);
            this.GB_OF_DevMode.TabIndex = 44;
            this.GB_OF_DevMode.TabStop = false;
            this.GB_OF_DevMode.Text = "Developer mode";
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
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(323, 420);
            this.Controls.Add(this.GB_OF_DevMode);
            this.Controls.Add(this.GB_GameMode);
            this.Font = new System.Drawing.Font("Franklin Gothic Demi", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.GB_GameMode.ResumeLayout(false);
            this.GB_GameMode.PerformLayout();
            this.GB_OF_DevMode.ResumeLayout(false);
            this.GB_OF_DevMode.PerformLayout();
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
    }
}