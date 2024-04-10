namespace Battleship.Forms
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            this.TLP_CHF_Main = new System.Windows.Forms.TableLayoutPanel();
            this.CRT_ChanceChange = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TLP_CHF_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CRT_ChanceChange)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP_CHF_Main
            // 
            this.TLP_CHF_Main.ColumnCount = 1;
            this.TLP_CHF_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.50385F));
            this.TLP_CHF_Main.Controls.Add(this.CRT_ChanceChange, 0, 0);
            this.TLP_CHF_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_CHF_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_CHF_Main.Name = "TLP_CHF_Main";
            this.TLP_CHF_Main.RowCount = 2;
            this.TLP_CHF_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.36597F));
            this.TLP_CHF_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.63403F));
            this.TLP_CHF_Main.Size = new System.Drawing.Size(649, 429);
            this.TLP_CHF_Main.TabIndex = 0;
            // 
            // CRT_ChanceChange
            // 
            this.CRT_ChanceChange.BackColor = System.Drawing.Color.Black;
            this.CRT_ChanceChange.BorderlineColor = System.Drawing.Color.DeepSkyBlue;
            this.CRT_ChanceChange.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.CRT_ChanceChange.BorderlineWidth = 2;
            this.CRT_ChanceChange.BorderSkin.BackColor = System.Drawing.SystemColors.HighlightText;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F);
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.DeepSkyBlue;
            chartArea1.AxisX.LineColor = System.Drawing.Color.DeepSkyBlue;
            chartArea1.AxisX.LineWidth = 4;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Aqua;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Empty;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Empty;
            chartArea1.AxisX.Title = "Move Number";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.Aqua;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DeepSkyBlue;
            chartArea1.AxisY.LineColor = System.Drawing.Color.DeepSkyBlue;
            chartArea1.AxisY.LineWidth = 4;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Aqua;
            chartArea1.AxisY.Title = "Probobility";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F);
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.Aqua;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.CRT_ChanceChange.ChartAreas.Add(chartArea1);
            this.CRT_ChanceChange.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            legend1.TitleBackColor = System.Drawing.Color.Lavender;
            legend1.TitleFont = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CRT_ChanceChange.Legends.Add(legend1);
            this.CRT_ChanceChange.Location = new System.Drawing.Point(3, 3);
            this.CRT_ChanceChange.Name = "CRT_ChanceChange";
            series1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Lime;
            series1.Font = new System.Drawing.Font("Franklin Gothic Demi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.Legend = "Legend1";
            series1.LegendText = "Independent chance";
            series1.Name = "Chance_Series";
            series1.YValuesPerPoint = 2;
            this.CRT_ChanceChange.Series.Add(series1);
            this.CRT_ChanceChange.Size = new System.Drawing.Size(643, 283);
            this.CRT_ChanceChange.TabIndex = 0;
            this.CRT_ChanceChange.Text = "chart1";
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(649, 429);
            this.Controls.Add(this.TLP_CHF_Main);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(233)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ChartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chance changing";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.TLP_CHF_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CRT_ChanceChange)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_CHF_Main;
        public System.Windows.Forms.DataVisualization.Charting.Chart CRT_ChanceChange;
    }
}