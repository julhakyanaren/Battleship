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
            this.L_Info_Version = new System.Windows.Forms.Label();
            this.PB_Button_About = new System.Windows.Forms.PictureBox();
            this.PB_Button_Options = new System.Windows.Forms.PictureBox();
            this.PB_Button_NewGame = new System.Windows.Forms.PictureBox();
            this.PB_MF_MainLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Button_About)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Button_Options)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Button_NewGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_MF_MainLogo)).BeginInit();
            this.SuspendLayout();
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
            // PB_Button_About
            // 
            this.PB_Button_About.Image = global::Battleship.Properties.Resources.About_MouseUp;
            this.PB_Button_About.Location = new System.Drawing.Point(58, 338);
            this.PB_Button_About.Name = "PB_Button_About";
            this.PB_Button_About.Size = new System.Drawing.Size(417, 59);
            this.PB_Button_About.TabIndex = 8;
            this.PB_Button_About.TabStop = false;
            this.PB_Button_About.Click += new System.EventHandler(this.PB_Button_About_Click);
            this.PB_Button_About.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_Button_About_MouseDown);
            this.PB_Button_About.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PB_Button_About_MouseUp);
            // 
            // PB_Button_Options
            // 
            this.PB_Button_Options.Image = global::Battleship.Properties.Resources.Options_MouseUp;
            this.PB_Button_Options.Location = new System.Drawing.Point(58, 255);
            this.PB_Button_Options.Name = "PB_Button_Options";
            this.PB_Button_Options.Size = new System.Drawing.Size(417, 59);
            this.PB_Button_Options.TabIndex = 7;
            this.PB_Button_Options.TabStop = false;
            this.PB_Button_Options.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_Button_Options_MouseDown);
            this.PB_Button_Options.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PB_Button_Options_MouseUp);
            // 
            // PB_Button_NewGame
            // 
            this.PB_Button_NewGame.Image = global::Battleship.Properties.Resources.NewGame_MouseUp;
            this.PB_Button_NewGame.Location = new System.Drawing.Point(58, 173);
            this.PB_Button_NewGame.Name = "PB_Button_NewGame";
            this.PB_Button_NewGame.Size = new System.Drawing.Size(417, 59);
            this.PB_Button_NewGame.TabIndex = 6;
            this.PB_Button_NewGame.TabStop = false;
            this.PB_Button_NewGame.Click += new System.EventHandler(this.PB_Button_NewGame_Click);
            this.PB_Button_NewGame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_Button_NewGame_MouseDown);
            this.PB_Button_NewGame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PB_Button_NewGame_MouseUp);
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
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(531, 489);
            this.Controls.Add(this.PB_Button_About);
            this.Controls.Add(this.PB_Button_Options);
            this.Controls.Add(this.PB_Button_NewGame);
            this.Controls.Add(this.L_Info_Version);
            this.Controls.Add(this.PB_MF_MainLogo);
            this.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battleship";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Button_About)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Button_Options)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Button_NewGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_MF_MainLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PB_MF_MainLogo;
        private System.Windows.Forms.Label L_Info_Version;
        private System.Windows.Forms.PictureBox PB_Button_NewGame;
        private System.Windows.Forms.PictureBox PB_Button_Options;
        private System.Windows.Forms.PictureBox PB_Button_About;
    }
}

