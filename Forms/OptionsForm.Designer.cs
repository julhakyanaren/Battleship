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
            this.GB_GameMode.SuspendLayout();
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
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(403, 420);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_GameMode;
        private System.Windows.Forms.CheckBox CHB_OP_GameModeClassic;
        private System.Windows.Forms.CheckBox CHB_OP_GameModeEducation;
        public System.Windows.Forms.TextBox TB_OF_GameMode;
    }
}