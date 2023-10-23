namespace Battleship
{
    partial class MenuForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.BS_MM_NewGame = new System.Windows.Forms.Button();
            this.BS_MM_About = new System.Windows.Forms.Button();
            this.PB_MF_MainLogo = new System.Windows.Forms.PictureBox();
            this.L_Info_Version = new System.Windows.Forms.Label();
            this.BS_MM_Options = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_MF_MainLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BS_MM_NewGame
            // 
            this.BS_MM_NewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_MM_NewGame.Font = new System.Drawing.Font("Franklin Gothic Heavy", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_MM_NewGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.BS_MM_NewGame.Location = new System.Drawing.Point(58, 175);
            this.BS_MM_NewGame.Name = "BS_MM_NewGame";
            this.BS_MM_NewGame.Size = new System.Drawing.Size(417, 59);
            this.BS_MM_NewGame.TabIndex = 1;
            this.BS_MM_NewGame.Text = "New Game";
            this.BS_MM_NewGame.UseVisualStyleBackColor = true;
            this.BS_MM_NewGame.Click += new System.EventHandler(this.BS_MM_NewGame_Click);
            // 
            // BS_MM_About
            // 
            this.BS_MM_About.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_MM_About.Font = new System.Drawing.Font("Franklin Gothic Heavy", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_MM_About.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.BS_MM_About.Location = new System.Drawing.Point(58, 336);
            this.BS_MM_About.Name = "BS_MM_About";
            this.BS_MM_About.Size = new System.Drawing.Size(417, 57);
            this.BS_MM_About.TabIndex = 3;
            this.BS_MM_About.Text = "About";
            this.BS_MM_About.UseVisualStyleBackColor = true;
            this.BS_MM_About.Click += new System.EventHandler(this.BS_MM_About_Click);
            // 
            // PB_MF_MainLogo
            // 
            this.PB_MF_MainLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PB_MF_MainLogo.Image = global::Battleship.Properties.Resources.Logo;
            this.PB_MF_MainLogo.Location = new System.Drawing.Point(0, 0);
            this.PB_MF_MainLogo.Name = "PB_MF_MainLogo";
            this.PB_MF_MainLogo.Size = new System.Drawing.Size(531, 155);
            this.PB_MF_MainLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_MF_MainLogo.TabIndex = 4;
            this.PB_MF_MainLogo.TabStop = false;
            // 
            // L_Info_Version
            // 
            this.L_Info_Version.AutoSize = true;
            this.L_Info_Version.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Info_Version.Location = new System.Drawing.Point(219, 434);
            this.L_Info_Version.Name = "L_Info_Version";
            this.L_Info_Version.Size = new System.Drawing.Size(52, 20);
            this.L_Info_Version.TabIndex = 5;
            this.L_Info_Version.Text = "Version";
            // 
            // BS_MM_Options
            // 
            this.BS_MM_Options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_MM_Options.Font = new System.Drawing.Font("Franklin Gothic Heavy", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_MM_Options.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.BS_MM_Options.Location = new System.Drawing.Point(58, 256);
            this.BS_MM_Options.Name = "BS_MM_Options";
            this.BS_MM_Options.Size = new System.Drawing.Size(417, 57);
            this.BS_MM_Options.TabIndex = 2;
            this.BS_MM_Options.Text = "Options";
            this.BS_MM_Options.UseVisualStyleBackColor = true;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(531, 489);
            this.Controls.Add(this.L_Info_Version);
            this.Controls.Add(this.PB_MF_MainLogo);
            this.Controls.Add(this.BS_MM_About);
            this.Controls.Add(this.BS_MM_Options);
            this.Controls.Add(this.BS_MM_NewGame);
            this.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battleship";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PB_MF_MainLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BS_MM_NewGame;
        private System.Windows.Forms.Button BS_MM_About;
        private System.Windows.Forms.PictureBox PB_MF_MainLogo;
        private System.Windows.Forms.Label L_Info_Version;
        private System.Windows.Forms.Button BS_MM_Options;
    }
}

