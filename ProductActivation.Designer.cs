namespace Battleship
{
    partial class ProductActivation
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
            this.TB_KeyInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TB_KeyInput
            // 
            this.TB_KeyInput.BackColor = System.Drawing.Color.Black;
            this.TB_KeyInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_KeyInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.TB_KeyInput.Location = new System.Drawing.Point(75, 115);
            this.TB_KeyInput.Name = "TB_KeyInput";
            this.TB_KeyInput.Size = new System.Drawing.Size(550, 25);
            this.TB_KeyInput.TabIndex = 0;
            this.TB_KeyInput.TextChanged += new System.EventHandler(this.TB_KeyInput_TextChanged);
            // 
            // ProductActivation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(684, 344);
            this.Controls.Add(this.TB_KeyInput);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProductActivation";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Activation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_KeyInput;
    }
}