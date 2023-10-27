namespace Battleship.Forms
{
    partial class HitStatus
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
            this.PB_HS_HitStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_HS_HitStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_HS_HitStatus
            // 
            this.PB_HS_HitStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PB_HS_HitStatus.Image = global::Battleship.Properties.Resources.Hit_Status_YouMissed;
            this.PB_HS_HitStatus.Location = new System.Drawing.Point(0, 0);
            this.PB_HS_HitStatus.Name = "PB_HS_HitStatus";
            this.PB_HS_HitStatus.Size = new System.Drawing.Size(582, 253);
            this.PB_HS_HitStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PB_HS_HitStatus.TabIndex = 0;
            this.PB_HS_HitStatus.TabStop = false;
            // 
            // HitStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(582, 253);
            this.Controls.Add(this.PB_HS_HitStatus);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HitStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HitStatus";
            this.Load += new System.EventHandler(this.HitStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PB_HS_HitStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_HS_HitStatus;
    }
}