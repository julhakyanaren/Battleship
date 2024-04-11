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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            this.TLP_CHF_Main = new System.Windows.Forms.TableLayoutPanel();
            this.CRT_ChanceChange = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PNL_CHF_Inspector = new System.Windows.Forms.Panel();
            this.GB_CHF_ChartData = new System.Windows.Forms.GroupBox();
            this.CHB_EnemyDataShow = new System.Windows.Forms.CheckBox();
            this.CHB_PlayerDataShow = new System.Windows.Forms.CheckBox();
            this.TB_CHF_Count = new System.Windows.Forms.TextBox();
            this.L_Info_CountValue = new System.Windows.Forms.Label();
            this.BS_CHF_ChartDelete = new System.Windows.Forms.Button();
            this.TB_CHF_AverageValue = new System.Windows.Forms.TextBox();
            this.BS_CHF_ChartDraw = new System.Windows.Forms.Button();
            this.BS_CHF_ChartUpdate = new System.Windows.Forms.Button();
            this.L_Info_AverageValue = new System.Windows.Forms.Label();
            this.TB_CHF_MinValue = new System.Windows.Forms.TextBox();
            this.L_Info_MinValue = new System.Windows.Forms.Label();
            this.TB_CHF_MaxValue = new System.Windows.Forms.TextBox();
            this.L_Info_MaxValue = new System.Windows.Forms.Label();
            this.L_Info_CHF_IndependentChanges = new System.Windows.Forms.Label();
            this.TB_CHF_IndependentChances = new System.Windows.Forms.TextBox();
            this.TB_Info_DrawBoth = new System.Windows.Forms.TextBox();
            this.GB_CHF_SearchData = new System.Windows.Forms.GroupBox();
            this.CB_CHF_SideChoose = new System.Windows.Forms.ComboBox();
            this.L_SideChoose = new System.Windows.Forms.Label();
            this.CB_CHF_MoveNumber = new System.Windows.Forms.ComboBox();
            this.L_Info_MoveNumber = new System.Windows.Forms.Label();
            this.BS_CHF_SearchData = new System.Windows.Forms.Button();
            this.TB_CHF_HitProbobility = new System.Windows.Forms.TextBox();
            this.L_Info_HitProbobility = new System.Windows.Forms.Label();
            this.L_Info_DecimalPlaces = new System.Windows.Forms.Label();
            this.TRB_CHF_DecimalPlaces = new System.Windows.Forms.TrackBar();
            this.L_DecimalPlaces = new System.Windows.Forms.Label();
            this.TLP_CHF_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CRT_ChanceChange)).BeginInit();
            this.PNL_CHF_Inspector.SuspendLayout();
            this.GB_CHF_ChartData.SuspendLayout();
            this.GB_CHF_SearchData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRB_CHF_DecimalPlaces)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP_CHF_Main
            // 
            this.TLP_CHF_Main.ColumnCount = 2;
            this.TLP_CHF_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.50385F));
            this.TLP_CHF_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 268F));
            this.TLP_CHF_Main.Controls.Add(this.CRT_ChanceChange, 0, 0);
            this.TLP_CHF_Main.Controls.Add(this.PNL_CHF_Inspector, 1, 0);
            this.TLP_CHF_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_CHF_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_CHF_Main.Name = "TLP_CHF_Main";
            this.TLP_CHF_Main.RowCount = 1;
            this.TLP_CHF_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.65158F));
            this.TLP_CHF_Main.Size = new System.Drawing.Size(1015, 505);
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
            series1.LegendText = "Player chace dynamic";
            series1.Name = "SeriesPlayer";
            series1.YValuesPerPoint = 2;
            series2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Red;
            series2.Font = new System.Drawing.Font("Franklin Gothic Demi", 9.75F);
            series2.Legend = "Legend1";
            series2.LegendText = "Enemy chace dynamic";
            series2.Name = "SeriesEnemy";
            this.CRT_ChanceChange.Series.Add(series1);
            this.CRT_ChanceChange.Series.Add(series2);
            this.CRT_ChanceChange.Size = new System.Drawing.Size(741, 499);
            this.CRT_ChanceChange.TabIndex = 0;
            this.CRT_ChanceChange.Text = "chart1";
            // 
            // PNL_CHF_Inspector
            // 
            this.PNL_CHF_Inspector.Controls.Add(this.GB_CHF_SearchData);
            this.PNL_CHF_Inspector.Controls.Add(this.GB_CHF_ChartData);
            this.PNL_CHF_Inspector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_CHF_Inspector.Location = new System.Drawing.Point(750, 3);
            this.PNL_CHF_Inspector.Name = "PNL_CHF_Inspector";
            this.PNL_CHF_Inspector.Size = new System.Drawing.Size(262, 499);
            this.PNL_CHF_Inspector.TabIndex = 1;
            // 
            // GB_CHF_ChartData
            // 
            this.GB_CHF_ChartData.Controls.Add(this.TB_Info_DrawBoth);
            this.GB_CHF_ChartData.Controls.Add(this.CHB_EnemyDataShow);
            this.GB_CHF_ChartData.Controls.Add(this.CHB_PlayerDataShow);
            this.GB_CHF_ChartData.Controls.Add(this.TB_CHF_Count);
            this.GB_CHF_ChartData.Controls.Add(this.L_Info_CountValue);
            this.GB_CHF_ChartData.Controls.Add(this.BS_CHF_ChartDelete);
            this.GB_CHF_ChartData.Controls.Add(this.TB_CHF_AverageValue);
            this.GB_CHF_ChartData.Controls.Add(this.BS_CHF_ChartDraw);
            this.GB_CHF_ChartData.Controls.Add(this.BS_CHF_ChartUpdate);
            this.GB_CHF_ChartData.Controls.Add(this.L_Info_AverageValue);
            this.GB_CHF_ChartData.Controls.Add(this.TB_CHF_MinValue);
            this.GB_CHF_ChartData.Controls.Add(this.L_Info_MinValue);
            this.GB_CHF_ChartData.Controls.Add(this.TB_CHF_MaxValue);
            this.GB_CHF_ChartData.Controls.Add(this.L_Info_MaxValue);
            this.GB_CHF_ChartData.Controls.Add(this.L_Info_CHF_IndependentChanges);
            this.GB_CHF_ChartData.Controls.Add(this.TB_CHF_IndependentChances);
            this.GB_CHF_ChartData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GB_CHF_ChartData.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.GB_CHF_ChartData.Location = new System.Drawing.Point(6, 9);
            this.GB_CHF_ChartData.Name = "GB_CHF_ChartData";
            this.GB_CHF_ChartData.Size = new System.Drawing.Size(253, 324);
            this.GB_CHF_ChartData.TabIndex = 49;
            this.GB_CHF_ChartData.TabStop = false;
            this.GB_CHF_ChartData.Text = "Chart datas";
            // 
            // CHB_EnemyDataShow
            // 
            this.CHB_EnemyDataShow.AutoSize = true;
            this.CHB_EnemyDataShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHB_EnemyDataShow.Location = new System.Drawing.Point(129, 30);
            this.CHB_EnemyDataShow.Name = "CHB_EnemyDataShow";
            this.CHB_EnemyDataShow.Size = new System.Drawing.Size(111, 21);
            this.CHB_EnemyDataShow.TabIndex = 78;
            this.CHB_EnemyDataShow.Text = "Show chart Enemy";
            this.CHB_EnemyDataShow.UseVisualStyleBackColor = true;
            this.CHB_EnemyDataShow.CheckedChanged += new System.EventHandler(this.CHB_EnemyDataShow_CheckedChanged);
            // 
            // CHB_PlayerDataShow
            // 
            this.CHB_PlayerDataShow.AutoSize = true;
            this.CHB_PlayerDataShow.Checked = true;
            this.CHB_PlayerDataShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHB_PlayerDataShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHB_PlayerDataShow.Location = new System.Drawing.Point(129, 10);
            this.CHB_PlayerDataShow.Name = "CHB_PlayerDataShow";
            this.CHB_PlayerDataShow.Size = new System.Drawing.Size(109, 21);
            this.CHB_PlayerDataShow.TabIndex = 77;
            this.CHB_PlayerDataShow.Text = "Show chart Player";
            this.CHB_PlayerDataShow.UseVisualStyleBackColor = true;
            this.CHB_PlayerDataShow.CheckedChanged += new System.EventHandler(this.CHB_PlayerDataShow_CheckedChanged);
            // 
            // TB_CHF_Count
            // 
            this.TB_CHF_Count.BackColor = System.Drawing.Color.Black;
            this.TB_CHF_Count.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.TB_CHF_Count.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TB_CHF_Count.Location = new System.Drawing.Point(9, 159);
            this.TB_CHF_Count.Name = "TB_CHF_Count";
            this.TB_CHF_Count.ReadOnly = true;
            this.TB_CHF_Count.Size = new System.Drawing.Size(84, 22);
            this.TB_CHF_Count.TabIndex = 76;
            this.TB_CHF_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // L_Info_CountValue
            // 
            this.L_Info_CountValue.AutoSize = true;
            this.L_Info_CountValue.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_CountValue.Location = new System.Drawing.Point(6, 140);
            this.L_Info_CountValue.Name = "L_Info_CountValue";
            this.L_Info_CountValue.Size = new System.Drawing.Size(37, 17);
            this.L_Info_CountValue.TabIndex = 75;
            this.L_Info_CountValue.Text = "Count";
            // 
            // BS_CHF_ChartDelete
            // 
            this.BS_CHF_ChartDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_CHF_ChartDelete.Location = new System.Drawing.Point(129, 151);
            this.BS_CHF_ChartDelete.Margin = new System.Windows.Forms.Padding(2);
            this.BS_CHF_ChartDelete.Name = "BS_CHF_ChartDelete";
            this.BS_CHF_ChartDelete.Size = new System.Drawing.Size(119, 30);
            this.BS_CHF_ChartDelete.TabIndex = 74;
            this.BS_CHF_ChartDelete.Text = "Clear Chart";
            this.BS_CHF_ChartDelete.UseVisualStyleBackColor = true;
            this.BS_CHF_ChartDelete.Click += new System.EventHandler(this.BS_CHF_ChartDelete_Click);
            // 
            // TB_CHF_AverageValue
            // 
            this.TB_CHF_AverageValue.BackColor = System.Drawing.Color.Black;
            this.TB_CHF_AverageValue.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.TB_CHF_AverageValue.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TB_CHF_AverageValue.Location = new System.Drawing.Point(9, 118);
            this.TB_CHF_AverageValue.Name = "TB_CHF_AverageValue";
            this.TB_CHF_AverageValue.ReadOnly = true;
            this.TB_CHF_AverageValue.Size = new System.Drawing.Size(84, 22);
            this.TB_CHF_AverageValue.TabIndex = 73;
            this.TB_CHF_AverageValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BS_CHF_ChartDraw
            // 
            this.BS_CHF_ChartDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_CHF_ChartDraw.Location = new System.Drawing.Point(129, 116);
            this.BS_CHF_ChartDraw.Margin = new System.Windows.Forms.Padding(2);
            this.BS_CHF_ChartDraw.Name = "BS_CHF_ChartDraw";
            this.BS_CHF_ChartDraw.Size = new System.Drawing.Size(119, 30);
            this.BS_CHF_ChartDraw.TabIndex = 48;
            this.BS_CHF_ChartDraw.Text = "Draw Chart";
            this.BS_CHF_ChartDraw.UseVisualStyleBackColor = true;
            this.BS_CHF_ChartDraw.Click += new System.EventHandler(this.BS_CHF_ChartDraw_Click);
            // 
            // BS_CHF_ChartUpdate
            // 
            this.BS_CHF_ChartUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_CHF_ChartUpdate.Location = new System.Drawing.Point(129, 81);
            this.BS_CHF_ChartUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.BS_CHF_ChartUpdate.Name = "BS_CHF_ChartUpdate";
            this.BS_CHF_ChartUpdate.Size = new System.Drawing.Size(119, 30);
            this.BS_CHF_ChartUpdate.TabIndex = 47;
            this.BS_CHF_ChartUpdate.Text = "Update Chart";
            this.BS_CHF_ChartUpdate.UseVisualStyleBackColor = true;
            this.BS_CHF_ChartUpdate.Click += new System.EventHandler(this.BS_CHF_ChartUpdate_Click);
            // 
            // L_Info_AverageValue
            // 
            this.L_Info_AverageValue.AutoSize = true;
            this.L_Info_AverageValue.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_AverageValue.Location = new System.Drawing.Point(6, 98);
            this.L_Info_AverageValue.Name = "L_Info_AverageValue";
            this.L_Info_AverageValue.Size = new System.Drawing.Size(75, 17);
            this.L_Info_AverageValue.TabIndex = 72;
            this.L_Info_AverageValue.Text = "Аverage value";
            // 
            // TB_CHF_MinValue
            // 
            this.TB_CHF_MinValue.BackColor = System.Drawing.Color.Black;
            this.TB_CHF_MinValue.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.TB_CHF_MinValue.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TB_CHF_MinValue.Location = new System.Drawing.Point(9, 76);
            this.TB_CHF_MinValue.Name = "TB_CHF_MinValue";
            this.TB_CHF_MinValue.ReadOnly = true;
            this.TB_CHF_MinValue.Size = new System.Drawing.Size(84, 22);
            this.TB_CHF_MinValue.TabIndex = 71;
            this.TB_CHF_MinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // L_Info_MinValue
            // 
            this.L_Info_MinValue.AutoSize = true;
            this.L_Info_MinValue.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_MinValue.Location = new System.Drawing.Point(6, 56);
            this.L_Info_MinValue.Name = "L_Info_MinValue";
            this.L_Info_MinValue.Size = new System.Drawing.Size(54, 17);
            this.L_Info_MinValue.TabIndex = 70;
            this.L_Info_MinValue.Text = "Min value";
            // 
            // TB_CHF_MaxValue
            // 
            this.TB_CHF_MaxValue.BackColor = System.Drawing.Color.Black;
            this.TB_CHF_MaxValue.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.TB_CHF_MaxValue.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TB_CHF_MaxValue.Location = new System.Drawing.Point(9, 34);
            this.TB_CHF_MaxValue.Name = "TB_CHF_MaxValue";
            this.TB_CHF_MaxValue.ReadOnly = true;
            this.TB_CHF_MaxValue.Size = new System.Drawing.Size(84, 22);
            this.TB_CHF_MaxValue.TabIndex = 69;
            this.TB_CHF_MaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // L_Info_MaxValue
            // 
            this.L_Info_MaxValue.AutoSize = true;
            this.L_Info_MaxValue.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_MaxValue.Location = new System.Drawing.Point(6, 14);
            this.L_Info_MaxValue.Name = "L_Info_MaxValue";
            this.L_Info_MaxValue.Size = new System.Drawing.Size(56, 17);
            this.L_Info_MaxValue.TabIndex = 68;
            this.L_Info_MaxValue.Text = "Max value";
            // 
            // L_Info_CHF_IndependentChanges
            // 
            this.L_Info_CHF_IndependentChanges.AutoSize = true;
            this.L_Info_CHF_IndependentChanges.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_CHF_IndependentChanges.Location = new System.Drawing.Point(6, 202);
            this.L_Info_CHF_IndependentChanges.Name = "L_Info_CHF_IndependentChanges";
            this.L_Info_CHF_IndependentChanges.Size = new System.Drawing.Size(147, 17);
            this.L_Info_CHF_IndependentChanges.TabIndex = 67;
            this.L_Info_CHF_IndependentChanges.Text = "Independent chance changes";
            // 
            // TB_CHF_IndependentChances
            // 
            this.TB_CHF_IndependentChances.BackColor = System.Drawing.Color.Black;
            this.TB_CHF_IndependentChances.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TB_CHF_IndependentChances.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.TB_CHF_IndependentChances.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TB_CHF_IndependentChances.Location = new System.Drawing.Point(3, 222);
            this.TB_CHF_IndependentChances.Multiline = true;
            this.TB_CHF_IndependentChances.Name = "TB_CHF_IndependentChances";
            this.TB_CHF_IndependentChances.ReadOnly = true;
            this.TB_CHF_IndependentChances.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_CHF_IndependentChances.Size = new System.Drawing.Size(247, 99);
            this.TB_CHF_IndependentChances.TabIndex = 66;
            // 
            // TB_Info_DrawBoth
            // 
            this.TB_Info_DrawBoth.BackColor = System.Drawing.Color.Black;
            this.TB_Info_DrawBoth.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.TB_Info_DrawBoth.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TB_Info_DrawBoth.Location = new System.Drawing.Point(129, 54);
            this.TB_Info_DrawBoth.Name = "TB_Info_DrawBoth";
            this.TB_Info_DrawBoth.ReadOnly = true;
            this.TB_Info_DrawBoth.Size = new System.Drawing.Size(109, 22);
            this.TB_Info_DrawBoth.TabIndex = 79;
            this.TB_Info_DrawBoth.Text = "Draw Both";
            this.TB_Info_DrawBoth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_Info_DrawBoth.Visible = false;
            // 
            // GB_CHF_SearchData
            // 
            this.GB_CHF_SearchData.Controls.Add(this.L_DecimalPlaces);
            this.GB_CHF_SearchData.Controls.Add(this.TRB_CHF_DecimalPlaces);
            this.GB_CHF_SearchData.Controls.Add(this.L_Info_DecimalPlaces);
            this.GB_CHF_SearchData.Controls.Add(this.L_Info_HitProbobility);
            this.GB_CHF_SearchData.Controls.Add(this.TB_CHF_HitProbobility);
            this.GB_CHF_SearchData.Controls.Add(this.BS_CHF_SearchData);
            this.GB_CHF_SearchData.Controls.Add(this.L_Info_MoveNumber);
            this.GB_CHF_SearchData.Controls.Add(this.CB_CHF_MoveNumber);
            this.GB_CHF_SearchData.Controls.Add(this.L_SideChoose);
            this.GB_CHF_SearchData.Controls.Add(this.CB_CHF_SideChoose);
            this.GB_CHF_SearchData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GB_CHF_SearchData.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.GB_CHF_SearchData.Location = new System.Drawing.Point(0, 339);
            this.GB_CHF_SearchData.Name = "GB_CHF_SearchData";
            this.GB_CHF_SearchData.Size = new System.Drawing.Size(262, 160);
            this.GB_CHF_SearchData.TabIndex = 50;
            this.GB_CHF_SearchData.TabStop = false;
            this.GB_CHF_SearchData.Text = "Search Data";
            // 
            // CB_CHF_SideChoose
            // 
            this.CB_CHF_SideChoose.BackColor = System.Drawing.Color.Black;
            this.CB_CHF_SideChoose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CB_CHF_SideChoose.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.CB_CHF_SideChoose.FormattingEnabled = true;
            this.CB_CHF_SideChoose.Items.AddRange(new object[] {
            "Player moves data",
            "Enemy moves data"});
            this.CB_CHF_SideChoose.Location = new System.Drawing.Point(114, 17);
            this.CB_CHF_SideChoose.Name = "CB_CHF_SideChoose";
            this.CB_CHF_SideChoose.Size = new System.Drawing.Size(142, 25);
            this.CB_CHF_SideChoose.TabIndex = 0;
            this.CB_CHF_SideChoose.Text = "Player moves data";
            this.CB_CHF_SideChoose.SelectedIndexChanged += new System.EventHandler(this.CB_CHF_SideChoose_SelectedIndexChanged);
            // 
            // L_SideChoose
            // 
            this.L_SideChoose.AutoSize = true;
            this.L_SideChoose.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_SideChoose.Location = new System.Drawing.Point(6, 20);
            this.L_SideChoose.Name = "L_SideChoose";
            this.L_SideChoose.Size = new System.Drawing.Size(102, 17);
            this.L_SideChoose.TabIndex = 80;
            this.L_SideChoose.Text = "Choose data source";
            // 
            // CB_CHF_MoveNumber
            // 
            this.CB_CHF_MoveNumber.BackColor = System.Drawing.Color.Black;
            this.CB_CHF_MoveNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CB_CHF_MoveNumber.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.CB_CHF_MoveNumber.FormattingEnabled = true;
            this.CB_CHF_MoveNumber.Items.AddRange(new object[] {
            "0"});
            this.CB_CHF_MoveNumber.Location = new System.Drawing.Point(114, 48);
            this.CB_CHF_MoveNumber.Name = "CB_CHF_MoveNumber";
            this.CB_CHF_MoveNumber.Size = new System.Drawing.Size(53, 25);
            this.CB_CHF_MoveNumber.TabIndex = 81;
            this.CB_CHF_MoveNumber.Text = "0";
            // 
            // L_Info_MoveNumber
            // 
            this.L_Info_MoveNumber.AutoSize = true;
            this.L_Info_MoveNumber.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_MoveNumber.Location = new System.Drawing.Point(6, 56);
            this.L_Info_MoveNumber.Name = "L_Info_MoveNumber";
            this.L_Info_MoveNumber.Size = new System.Drawing.Size(73, 17);
            this.L_Info_MoveNumber.TabIndex = 82;
            this.L_Info_MoveNumber.Text = "Move number";
            // 
            // BS_CHF_SearchData
            // 
            this.BS_CHF_SearchData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_CHF_SearchData.Location = new System.Drawing.Point(172, 47);
            this.BS_CHF_SearchData.Margin = new System.Windows.Forms.Padding(2);
            this.BS_CHF_SearchData.Name = "BS_CHF_SearchData";
            this.BS_CHF_SearchData.Size = new System.Drawing.Size(84, 26);
            this.BS_CHF_SearchData.TabIndex = 80;
            this.BS_CHF_SearchData.Text = "Search data";
            this.BS_CHF_SearchData.UseVisualStyleBackColor = true;
            this.BS_CHF_SearchData.Click += new System.EventHandler(this.BS_CHF_SearchData_Click);
            // 
            // TB_CHF_HitProbobility
            // 
            this.TB_CHF_HitProbobility.BackColor = System.Drawing.Color.Black;
            this.TB_CHF_HitProbobility.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.TB_CHF_HitProbobility.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TB_CHF_HitProbobility.Location = new System.Drawing.Point(114, 131);
            this.TB_CHF_HitProbobility.Name = "TB_CHF_HitProbobility";
            this.TB_CHF_HitProbobility.ReadOnly = true;
            this.TB_CHF_HitProbobility.Size = new System.Drawing.Size(142, 22);
            this.TB_CHF_HitProbobility.TabIndex = 83;
            this.TB_CHF_HitProbobility.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // L_Info_HitProbobility
            // 
            this.L_Info_HitProbobility.AutoSize = true;
            this.L_Info_HitProbobility.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_HitProbobility.Location = new System.Drawing.Point(6, 131);
            this.L_Info_HitProbobility.Name = "L_Info_HitProbobility";
            this.L_Info_HitProbobility.Size = new System.Drawing.Size(76, 17);
            this.L_Info_HitProbobility.TabIndex = 84;
            this.L_Info_HitProbobility.Text = "Hit probobility";
            // 
            // L_Info_DecimalPlaces
            // 
            this.L_Info_DecimalPlaces.AutoSize = true;
            this.L_Info_DecimalPlaces.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_Info_DecimalPlaces.Location = new System.Drawing.Point(6, 89);
            this.L_Info_DecimalPlaces.Name = "L_Info_DecimalPlaces";
            this.L_Info_DecimalPlaces.Size = new System.Drawing.Size(80, 17);
            this.L_Info_DecimalPlaces.TabIndex = 85;
            this.L_Info_DecimalPlaces.Text = "Decimal Places";
            // 
            // TRB_CHF_DecimalPlaces
            // 
            this.TRB_CHF_DecimalPlaces.Location = new System.Drawing.Point(151, 80);
            this.TRB_CHF_DecimalPlaces.Maximum = 4;
            this.TRB_CHF_DecimalPlaces.Name = "TRB_CHF_DecimalPlaces";
            this.TRB_CHF_DecimalPlaces.Size = new System.Drawing.Size(105, 45);
            this.TRB_CHF_DecimalPlaces.TabIndex = 86;
            this.TRB_CHF_DecimalPlaces.Value = 2;
            this.TRB_CHF_DecimalPlaces.Scroll += new System.EventHandler(this.TRB_CHF_DecimalPlaces_Scroll);
            // 
            // L_DecimalPlaces
            // 
            this.L_DecimalPlaces.AutoSize = true;
            this.L_DecimalPlaces.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.L_DecimalPlaces.Location = new System.Drawing.Point(111, 89);
            this.L_DecimalPlaces.Name = "L_DecimalPlaces";
            this.L_DecimalPlaces.Size = new System.Drawing.Size(15, 17);
            this.L_DecimalPlaces.TabIndex = 87;
            this.L_DecimalPlaces.Text = "2";
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1015, 505);
            this.Controls.Add(this.TLP_CHF_Main);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ChartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chance changing";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.TLP_CHF_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CRT_ChanceChange)).EndInit();
            this.PNL_CHF_Inspector.ResumeLayout(false);
            this.GB_CHF_ChartData.ResumeLayout(false);
            this.GB_CHF_ChartData.PerformLayout();
            this.GB_CHF_SearchData.ResumeLayout(false);
            this.GB_CHF_SearchData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRB_CHF_DecimalPlaces)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_CHF_Main;
        public System.Windows.Forms.DataVisualization.Charting.Chart CRT_ChanceChange;
        private System.Windows.Forms.Panel PNL_CHF_Inspector;
        private System.Windows.Forms.Button BS_CHF_ChartUpdate;
        private System.Windows.Forms.Button BS_CHF_ChartDraw;
        private System.Windows.Forms.GroupBox GB_CHF_ChartData;
        public System.Windows.Forms.TextBox TB_CHF_IndependentChances;
        private System.Windows.Forms.Label L_Info_CHF_IndependentChanges;
        private System.Windows.Forms.Label L_Info_MaxValue;
        public System.Windows.Forms.TextBox TB_CHF_AverageValue;
        private System.Windows.Forms.Label L_Info_AverageValue;
        public System.Windows.Forms.TextBox TB_CHF_MinValue;
        private System.Windows.Forms.Label L_Info_MinValue;
        public System.Windows.Forms.TextBox TB_CHF_MaxValue;
        private System.Windows.Forms.Button BS_CHF_ChartDelete;
        public System.Windows.Forms.TextBox TB_CHF_Count;
        private System.Windows.Forms.Label L_Info_CountValue;
        private System.Windows.Forms.CheckBox CHB_EnemyDataShow;
        private System.Windows.Forms.CheckBox CHB_PlayerDataShow;
        public System.Windows.Forms.TextBox TB_Info_DrawBoth;
        private System.Windows.Forms.GroupBox GB_CHF_SearchData;
        private System.Windows.Forms.Button BS_CHF_SearchData;
        private System.Windows.Forms.Label L_Info_MoveNumber;
        private System.Windows.Forms.ComboBox CB_CHF_MoveNumber;
        private System.Windows.Forms.Label L_SideChoose;
        private System.Windows.Forms.ComboBox CB_CHF_SideChoose;
        private System.Windows.Forms.Label L_Info_HitProbobility;
        public System.Windows.Forms.TextBox TB_CHF_HitProbobility;
        private System.Windows.Forms.Label L_DecimalPlaces;
        private System.Windows.Forms.TrackBar TRB_CHF_DecimalPlaces;
        private System.Windows.Forms.Label L_Info_DecimalPlaces;
    }
}