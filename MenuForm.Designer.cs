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
            this.L_MM_Title = new System.Windows.Forms.Label();
            this.BS_MM_NewGame = new System.Windows.Forms.Button();
            this.BS_MM_Options = new System.Windows.Forms.Button();
            this.BS_MM_About = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // L_MM_Title
            // 
            this.L_MM_Title.AutoSize = true;
            this.L_MM_Title.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_MM_Title.Location = new System.Drawing.Point(147, 44);
            this.L_MM_Title.Name = "L_MM_Title";
            this.L_MM_Title.Size = new System.Drawing.Size(251, 61);
            this.L_MM_Title.TabIndex = 0;
            this.L_MM_Title.Text = "BATTLESHIP";
            // 
            // BS_MM_NewGame
            // 
            this.BS_MM_NewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_MM_NewGame.Font = new System.Drawing.Font("Franklin Gothic Heavy", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_MM_NewGame.Location = new System.Drawing.Point(58, 175);
            this.BS_MM_NewGame.Name = "BS_MM_NewGame";
            this.BS_MM_NewGame.Size = new System.Drawing.Size(417, 59);
            this.BS_MM_NewGame.TabIndex = 1;
            this.BS_MM_NewGame.Text = "New Game";
            this.BS_MM_NewGame.UseVisualStyleBackColor = true;
            this.BS_MM_NewGame.Click += new System.EventHandler(this.BS_MM_NewGame_Click);
            // 
            // BS_MM_Options
            // 
            this.BS_MM_Options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_MM_Options.Font = new System.Drawing.Font("Franklin Gothic Heavy", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_MM_Options.Location = new System.Drawing.Point(58, 256);
            this.BS_MM_Options.Name = "BS_MM_Options";
            this.BS_MM_Options.Size = new System.Drawing.Size(417, 57);
            this.BS_MM_Options.TabIndex = 2;
            this.BS_MM_Options.Text = "Options";
            this.BS_MM_Options.UseVisualStyleBackColor = true;
            // 
            // BS_MM_About
            // 
            this.BS_MM_About.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_MM_About.Font = new System.Drawing.Font("Franklin Gothic Heavy", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_MM_About.Location = new System.Drawing.Point(58, 336);
            this.BS_MM_About.Name = "BS_MM_About";
            this.BS_MM_About.Size = new System.Drawing.Size(417, 57);
            this.BS_MM_About.TabIndex = 3;
            this.BS_MM_About.Text = "About";
            this.BS_MM_About.UseVisualStyleBackColor = true;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(531, 489);
            this.Controls.Add(this.BS_MM_About);
            this.Controls.Add(this.BS_MM_Options);
            this.Controls.Add(this.BS_MM_NewGame);
            this.Controls.Add(this.L_MM_Title);
            this.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battleship";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_MM_Title;
        private System.Windows.Forms.Button BS_MM_NewGame;
        private System.Windows.Forms.Button BS_MM_Options;
        private System.Windows.Forms.Button BS_MM_About;
    }
}

