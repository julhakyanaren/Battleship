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
            this.L_Info_ProductActivation = new System.Windows.Forms.Label();
            this.BS_KeyActivate = new System.Windows.Forms.Button();
            this.BS_KeyClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_KeyInput
            // 
            this.TB_KeyInput.BackColor = System.Drawing.Color.Black;
            this.TB_KeyInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_KeyInput.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_KeyInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.TB_KeyInput.Location = new System.Drawing.Point(67, 33);
            this.TB_KeyInput.MaxLength = 19;
            this.TB_KeyInput.Name = "TB_KeyInput";
            this.TB_KeyInput.Size = new System.Drawing.Size(240, 26);
            this.TB_KeyInput.TabIndex = 0;
            this.TB_KeyInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_KeyInput.TextChanged += new System.EventHandler(this.TB_KeyInput_TextChanged);
            this.TB_KeyInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_KeyInput_KeyDown);
            this.TB_KeyInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyInput_KeyPress);
            // 
            // L_Info_ProductActivation
            // 
            this.L_Info_ProductActivation.AutoSize = true;
            this.L_Info_ProductActivation.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Info_ProductActivation.Location = new System.Drawing.Point(138, 9);
            this.L_Info_ProductActivation.Name = "L_Info_ProductActivation";
            this.L_Info_ProductActivation.Size = new System.Drawing.Size(92, 21);
            this.L_Info_ProductActivation.TabIndex = 34;
            this.L_Info_ProductActivation.Text = "Activation Key";
            // 
            // BS_KeyActivate
            // 
            this.BS_KeyActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_KeyActivate.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_KeyActivate.Location = new System.Drawing.Point(67, 65);
            this.BS_KeyActivate.Name = "BS_KeyActivate";
            this.BS_KeyActivate.Size = new System.Drawing.Size(115, 28);
            this.BS_KeyActivate.TabIndex = 35;
            this.BS_KeyActivate.Text = "Activate";
            this.BS_KeyActivate.UseVisualStyleBackColor = true;
            this.BS_KeyActivate.Click += new System.EventHandler(this.BS_KeyActivate_Click);
            // 
            // BS_KeyClear
            // 
            this.BS_KeyClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_KeyClear.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_KeyClear.Location = new System.Drawing.Point(192, 65);
            this.BS_KeyClear.Name = "BS_KeyClear";
            this.BS_KeyClear.Size = new System.Drawing.Size(115, 28);
            this.BS_KeyClear.TabIndex = 36;
            this.BS_KeyClear.Text = "Clear";
            this.BS_KeyClear.UseVisualStyleBackColor = true;
            this.BS_KeyClear.Click += new System.EventHandler(this.BS_KeyClear_Click);
            // 
            // ProductActivation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(369, 161);
            this.Controls.Add(this.BS_KeyClear);
            this.Controls.Add(this.BS_KeyActivate);
            this.Controls.Add(this.L_Info_ProductActivation);
            this.Controls.Add(this.TB_KeyInput);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProductActivation";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Activation";
            this.Load += new System.EventHandler(this.ProductActivation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_KeyInput;
        private System.Windows.Forms.Label L_Info_ProductActivation;
        private System.Windows.Forms.Button BS_KeyActivate;
        private System.Windows.Forms.Button BS_KeyClear;
    }
}