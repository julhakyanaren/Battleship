namespace Battleship.Forms
{
    partial class CalculationForm
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
            this.BS_CF_Close = new System.Windows.Forms.Button();
            this.TT_CF_FormulaInfo = new System.Windows.Forms.ToolTip(this.components);
            this.TB_CF_Formula = new System.Windows.Forms.TextBox();
            this.L_Info_MaxDecks = new System.Windows.Forms.Label();
            this.TB_CF_MaxDecks = new System.Windows.Forms.TextBox();
            this.L_Info_Undiscovered = new System.Windows.Forms.Label();
            this.L_Info_Chance = new System.Windows.Forms.Label();
            this.L_Info_HitedDecks = new System.Windows.Forms.Label();
            this.TB_CF_HitedDecks = new System.Windows.Forms.TextBox();
            this.TB_CF_Chance = new System.Windows.Forms.TextBox();
            this.TB_CF_Undiscovered = new System.Windows.Forms.TextBox();
            this.CB_DataSelector = new System.Windows.Forms.ComboBox();
            this.L_Info_SelectDataSource = new System.Windows.Forms.Label();
            this.BS_CF_Update = new System.Windows.Forms.Button();
            this.L_Info_DecimalPlacesCount = new System.Windows.Forms.Label();
            this.NUD_DecimalPlaces = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DecimalPlaces)).BeginInit();
            this.SuspendLayout();
            // 
            // BS_CF_Close
            // 
            this.BS_CF_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BS_CF_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_CF_Close.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_CF_Close.ForeColor = System.Drawing.Color.Aqua;
            this.BS_CF_Close.Location = new System.Drawing.Point(294, 165);
            this.BS_CF_Close.Name = "BS_CF_Close";
            this.BS_CF_Close.Size = new System.Drawing.Size(84, 25);
            this.BS_CF_Close.TabIndex = 71;
            this.BS_CF_Close.Text = "Close";
            this.BS_CF_Close.UseVisualStyleBackColor = true;
            this.BS_CF_Close.Click += new System.EventHandler(this.BS_CF_Close_Click);
            // 
            // TT_CF_FormulaInfo
            // 
            this.TT_CF_FormulaInfo.BackColor = System.Drawing.Color.Yellow;
            this.TT_CF_FormulaInfo.ForeColor = System.Drawing.Color.Black;
            // 
            // TB_CF_Formula
            // 
            this.TB_CF_Formula.BackColor = System.Drawing.Color.Black;
            this.TB_CF_Formula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_CF_Formula.Font = new System.Drawing.Font("Albion", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_CF_Formula.ForeColor = System.Drawing.Color.Aqua;
            this.TB_CF_Formula.Location = new System.Drawing.Point(12, 24);
            this.TB_CF_Formula.Multiline = true;
            this.TB_CF_Formula.Name = "TB_CF_Formula";
            this.TB_CF_Formula.ReadOnly = true;
            this.TB_CF_Formula.Size = new System.Drawing.Size(366, 26);
            this.TB_CF_Formula.TabIndex = 73;
            this.TB_CF_Formula.Text = "(20     -     0)     /     100     =     20%";
            this.TB_CF_Formula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // L_Info_MaxDecks
            // 
            this.L_Info_MaxDecks.AutoSize = true;
            this.L_Info_MaxDecks.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_MaxDecks.Location = new System.Drawing.Point(9, 69);
            this.L_Info_MaxDecks.Name = "L_Info_MaxDecks";
            this.L_Info_MaxDecks.Size = new System.Drawing.Size(115, 17);
            this.L_Info_MaxDecks.TabIndex = 75;
            this.L_Info_MaxDecks.Text = "Decks maximum count";
            // 
            // TB_CF_MaxDecks
            // 
            this.TB_CF_MaxDecks.BackColor = System.Drawing.Color.Black;
            this.TB_CF_MaxDecks.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.TB_CF_MaxDecks.ForeColor = System.Drawing.Color.Aqua;
            this.TB_CF_MaxDecks.Location = new System.Drawing.Point(130, 66);
            this.TB_CF_MaxDecks.Name = "TB_CF_MaxDecks";
            this.TB_CF_MaxDecks.ReadOnly = true;
            this.TB_CF_MaxDecks.Size = new System.Drawing.Size(43, 22);
            this.TB_CF_MaxDecks.TabIndex = 74;
            this.TB_CF_MaxDecks.Text = "20";
            this.TB_CF_MaxDecks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // L_Info_Undiscovered
            // 
            this.L_Info_Undiscovered.AutoSize = true;
            this.L_Info_Undiscovered.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_Undiscovered.Location = new System.Drawing.Point(179, 67);
            this.L_Info_Undiscovered.Name = "L_Info_Undiscovered";
            this.L_Info_Undiscovered.Size = new System.Drawing.Size(99, 17);
            this.L_Info_Undiscovered.TabIndex = 79;
            this.L_Info_Undiscovered.Text = "Undiscovered Cells";
            // 
            // L_Info_Chance
            // 
            this.L_Info_Chance.AutoSize = true;
            this.L_Info_Chance.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_Chance.Location = new System.Drawing.Point(179, 95);
            this.L_Info_Chance.Name = "L_Info_Chance";
            this.L_Info_Chance.Size = new System.Drawing.Size(123, 17);
            this.L_Info_Chance.TabIndex = 83;
            this.L_Info_Chance.Text = "Independent probability";
            // 
            // L_Info_HitedDecks
            // 
            this.L_Info_HitedDecks.AutoSize = true;
            this.L_Info_HitedDecks.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_HitedDecks.Location = new System.Drawing.Point(9, 97);
            this.L_Info_HitedDecks.Name = "L_Info_HitedDecks";
            this.L_Info_HitedDecks.Size = new System.Drawing.Size(93, 17);
            this.L_Info_HitedDecks.TabIndex = 81;
            this.L_Info_HitedDecks.Text = "Hited decks count";
            // 
            // TB_CF_HitedDecks
            // 
            this.TB_CF_HitedDecks.BackColor = System.Drawing.Color.Black;
            this.TB_CF_HitedDecks.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.TB_CF_HitedDecks.ForeColor = System.Drawing.Color.Aqua;
            this.TB_CF_HitedDecks.Location = new System.Drawing.Point(130, 94);
            this.TB_CF_HitedDecks.Name = "TB_CF_HitedDecks";
            this.TB_CF_HitedDecks.ReadOnly = true;
            this.TB_CF_HitedDecks.Size = new System.Drawing.Size(43, 22);
            this.TB_CF_HitedDecks.TabIndex = 80;
            this.TB_CF_HitedDecks.Text = "0";
            this.TB_CF_HitedDecks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_CF_Chance
            // 
            this.TB_CF_Chance.BackColor = System.Drawing.Color.Black;
            this.TB_CF_Chance.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.TB_CF_Chance.ForeColor = System.Drawing.Color.Aqua;
            this.TB_CF_Chance.Location = new System.Drawing.Point(308, 94);
            this.TB_CF_Chance.Name = "TB_CF_Chance";
            this.TB_CF_Chance.ReadOnly = true;
            this.TB_CF_Chance.Size = new System.Drawing.Size(70, 22);
            this.TB_CF_Chance.TabIndex = 85;
            this.TB_CF_Chance.Text = "20%";
            this.TB_CF_Chance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_CF_Undiscovered
            // 
            this.TB_CF_Undiscovered.BackColor = System.Drawing.Color.Black;
            this.TB_CF_Undiscovered.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.TB_CF_Undiscovered.ForeColor = System.Drawing.Color.Aqua;
            this.TB_CF_Undiscovered.Location = new System.Drawing.Point(308, 66);
            this.TB_CF_Undiscovered.Name = "TB_CF_Undiscovered";
            this.TB_CF_Undiscovered.ReadOnly = true;
            this.TB_CF_Undiscovered.Size = new System.Drawing.Size(70, 22);
            this.TB_CF_Undiscovered.TabIndex = 84;
            this.TB_CF_Undiscovered.Text = "100";
            this.TB_CF_Undiscovered.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CB_DataSelector
            // 
            this.CB_DataSelector.BackColor = System.Drawing.Color.Black;
            this.CB_DataSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_DataSelector.ForeColor = System.Drawing.Color.Aqua;
            this.CB_DataSelector.FormattingEnabled = true;
            this.CB_DataSelector.Items.AddRange(new object[] {
            "Player Map",
            "Enemy Map"});
            this.CB_DataSelector.Location = new System.Drawing.Point(109, 165);
            this.CB_DataSelector.Name = "CB_DataSelector";
            this.CB_DataSelector.Size = new System.Drawing.Size(89, 25);
            this.CB_DataSelector.TabIndex = 86;
            this.CB_DataSelector.Text = "Player Map";
            this.CB_DataSelector.SelectedIndexChanged += new System.EventHandler(this.CB_DataSelector_SelectedIndexChanged);
            // 
            // L_Info_SelectDataSource
            // 
            this.L_Info_SelectDataSource.AutoSize = true;
            this.L_Info_SelectDataSource.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_SelectDataSource.Location = new System.Drawing.Point(9, 169);
            this.L_Info_SelectDataSource.Name = "L_Info_SelectDataSource";
            this.L_Info_SelectDataSource.Size = new System.Drawing.Size(100, 17);
            this.L_Info_SelectDataSource.TabIndex = 87;
            this.L_Info_SelectDataSource.Text = "Select Data Source";
            // 
            // BS_CF_Update
            // 
            this.BS_CF_Update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BS_CF_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_CF_Update.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_CF_Update.ForeColor = System.Drawing.Color.Aqua;
            this.BS_CF_Update.Location = new System.Drawing.Point(204, 165);
            this.BS_CF_Update.Name = "BS_CF_Update";
            this.BS_CF_Update.Size = new System.Drawing.Size(84, 25);
            this.BS_CF_Update.TabIndex = 88;
            this.BS_CF_Update.Text = "Update";
            this.BS_CF_Update.UseVisualStyleBackColor = true;
            this.BS_CF_Update.Click += new System.EventHandler(this.BS_CF_Update_Click);
            // 
            // L_Info_DecimalPlacesCount
            // 
            this.L_Info_DecimalPlacesCount.AutoSize = true;
            this.L_Info_DecimalPlacesCount.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_DecimalPlacesCount.Location = new System.Drawing.Point(201, 142);
            this.L_Info_DecimalPlacesCount.Name = "L_Info_DecimalPlacesCount";
            this.L_Info_DecimalPlacesCount.Size = new System.Drawing.Size(109, 17);
            this.L_Info_DecimalPlacesCount.TabIndex = 89;
            this.L_Info_DecimalPlacesCount.Text = "Decimal places count";
            // 
            // NUD_DecimalPlaces
            // 
            this.NUD_DecimalPlaces.BackColor = System.Drawing.Color.Black;
            this.NUD_DecimalPlaces.ForeColor = System.Drawing.Color.Aqua;
            this.NUD_DecimalPlaces.Location = new System.Drawing.Point(316, 137);
            this.NUD_DecimalPlaces.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_DecimalPlaces.Name = "NUD_DecimalPlaces";
            this.NUD_DecimalPlaces.Size = new System.Drawing.Size(62, 22);
            this.NUD_DecimalPlaces.TabIndex = 90;
            this.NUD_DecimalPlaces.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_DecimalPlaces.ValueChanged += new System.EventHandler(this.NUD_DecimalPlaces_ValueChanged);
            // 
            // CalculationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(390, 202);
            this.Controls.Add(this.NUD_DecimalPlaces);
            this.Controls.Add(this.L_Info_DecimalPlacesCount);
            this.Controls.Add(this.BS_CF_Update);
            this.Controls.Add(this.L_Info_SelectDataSource);
            this.Controls.Add(this.CB_DataSelector);
            this.Controls.Add(this.TB_CF_Chance);
            this.Controls.Add(this.TB_CF_Undiscovered);
            this.Controls.Add(this.L_Info_Chance);
            this.Controls.Add(this.L_Info_HitedDecks);
            this.Controls.Add(this.TB_CF_HitedDecks);
            this.Controls.Add(this.L_Info_Undiscovered);
            this.Controls.Add(this.L_Info_MaxDecks);
            this.Controls.Add(this.TB_CF_MaxDecks);
            this.Controls.Add(this.TB_CF_Formula);
            this.Controls.Add(this.BS_CF_Close);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.ForeColor = System.Drawing.Color.Aqua;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CalculationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CalculationForm";
            this.Load += new System.EventHandler(this.CalculationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DecimalPlaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BS_CF_Close;
        private System.Windows.Forms.ToolTip TT_CF_FormulaInfo;
        public System.Windows.Forms.TextBox TB_CF_Formula;
        private System.Windows.Forms.Label L_Info_MaxDecks;
        public System.Windows.Forms.TextBox TB_CF_MaxDecks;
        private System.Windows.Forms.Label L_Info_Undiscovered;
        private System.Windows.Forms.Label L_Info_Chance;
        private System.Windows.Forms.Label L_Info_HitedDecks;
        public System.Windows.Forms.TextBox TB_CF_HitedDecks;
        public System.Windows.Forms.TextBox TB_CF_Chance;
        public System.Windows.Forms.TextBox TB_CF_Undiscovered;
        private System.Windows.Forms.ComboBox CB_DataSelector;
        private System.Windows.Forms.Label L_Info_SelectDataSource;
        private System.Windows.Forms.Button BS_CF_Update;
        private System.Windows.Forms.Label L_Info_DecimalPlacesCount;
        private System.Windows.Forms.NumericUpDown NUD_DecimalPlaces;
    }
}