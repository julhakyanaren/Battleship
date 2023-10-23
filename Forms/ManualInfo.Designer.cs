namespace Battleship.Forms
{
    partial class ManualInfo
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Included");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Map Editor", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Not Included");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Schematic Tools", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Included");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Debug Tools", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Not Included");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Diagnostic Tools", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("In Process");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("AI Module", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Plugins", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6,
            treeNode8,
            treeNode10});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualInfo));
            this.L_MI_OrientationChanger = new System.Windows.Forms.Label();
            this.TB_MI_ChangeOrientation = new System.Windows.Forms.TextBox();
            this.TB_MI_InsertShip = new System.Windows.Forms.TextBox();
            this.L_MI_InsertShip = new System.Windows.Forms.Label();
            this.GB_MI_MapEditor = new System.Windows.Forms.GroupBox();
            this.GB_MI_ShipType = new System.Windows.Forms.GroupBox();
            this.TB_ShipType_Battleship = new System.Windows.Forms.TextBox();
            this.TB_ShipType_Cruiser = new System.Windows.Forms.TextBox();
            this.L_MI_SelectBattleship = new System.Windows.Forms.Label();
            this.L_MI_SelectCruiser = new System.Windows.Forms.Label();
            this.TB_ShipType_Destroyer = new System.Windows.Forms.TextBox();
            this.TB_ShipType_Frigate = new System.Windows.Forms.TextBox();
            this.L_MI_SelectDestroyer = new System.Windows.Forms.Label();
            this.L_MI_SelectFrigate = new System.Windows.Forms.Label();
            this.L_Info_DownloadPDF = new System.Windows.Forms.Label();
            this.SFD_ManualInfo = new System.Windows.Forms.SaveFileDialog();
            this.L_Info_Progress = new System.Windows.Forms.Label();
            this.PNL_MI_ProgressUnit = new System.Windows.Forms.Panel();
            this.PNL_MI_ProgressBar = new System.Windows.Forms.Panel();
            this.GB_MI_Plugins = new System.Windows.Forms.GroupBox();
            this.TV_MI_Pligins = new System.Windows.Forms.TreeView();
            this.PB_IMB_DownloadPDF = new System.Windows.Forms.PictureBox();
            this.BS_MI_CheckPlugins = new System.Windows.Forms.Button();
            this.PNL_MI_ProgressUnit_Plugins = new System.Windows.Forms.Panel();
            this.PNL_MI_ProgressBar_Plugins = new System.Windows.Forms.Panel();
            this.GB_MI_MapEditor.SuspendLayout();
            this.GB_MI_ShipType.SuspendLayout();
            this.PNL_MI_ProgressBar.SuspendLayout();
            this.GB_MI_Plugins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_IMB_DownloadPDF)).BeginInit();
            this.PNL_MI_ProgressBar_Plugins.SuspendLayout();
            this.SuspendLayout();
            // 
            // L_MI_OrientationChanger
            // 
            this.L_MI_OrientationChanger.AutoSize = true;
            this.L_MI_OrientationChanger.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_MI_OrientationChanger.Location = new System.Drawing.Point(6, 18);
            this.L_MI_OrientationChanger.Name = "L_MI_OrientationChanger";
            this.L_MI_OrientationChanger.Size = new System.Drawing.Size(123, 17);
            this.L_MI_OrientationChanger.TabIndex = 0;
            this.L_MI_OrientationChanger.Text = "Change ship orientation";
            // 
            // TB_MI_ChangeOrientation
            // 
            this.TB_MI_ChangeOrientation.BackColor = System.Drawing.Color.Black;
            this.TB_MI_ChangeOrientation.Font = new System.Drawing.Font("Franklin Gothic Demi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_MI_ChangeOrientation.ForeColor = System.Drawing.Color.Orange;
            this.TB_MI_ChangeOrientation.Location = new System.Drawing.Point(159, 13);
            this.TB_MI_ChangeOrientation.Name = "TB_MI_ChangeOrientation";
            this.TB_MI_ChangeOrientation.ReadOnly = true;
            this.TB_MI_ChangeOrientation.Size = new System.Drawing.Size(79, 22);
            this.TB_MI_ChangeOrientation.TabIndex = 1;
            this.TB_MI_ChangeOrientation.Tag = "1";
            this.TB_MI_ChangeOrientation.Text = "Num   /";
            this.TB_MI_ChangeOrientation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_MI_InsertShip
            // 
            this.TB_MI_InsertShip.BackColor = System.Drawing.Color.Black;
            this.TB_MI_InsertShip.Font = new System.Drawing.Font("Franklin Gothic Demi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_MI_InsertShip.ForeColor = System.Drawing.Color.Orange;
            this.TB_MI_InsertShip.Location = new System.Drawing.Point(159, 43);
            this.TB_MI_InsertShip.Name = "TB_MI_InsertShip";
            this.TB_MI_InsertShip.ReadOnly = true;
            this.TB_MI_InsertShip.Size = new System.Drawing.Size(79, 22);
            this.TB_MI_InsertShip.TabIndex = 3;
            this.TB_MI_InsertShip.Tag = "1";
            this.TB_MI_InsertShip.Text = "Insert";
            this.TB_MI_InsertShip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // L_MI_InsertShip
            // 
            this.L_MI_InsertShip.AutoSize = true;
            this.L_MI_InsertShip.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_MI_InsertShip.Location = new System.Drawing.Point(6, 46);
            this.L_MI_InsertShip.Name = "L_MI_InsertShip";
            this.L_MI_InsertShip.Size = new System.Drawing.Size(153, 17);
            this.L_MI_InsertShip.TabIndex = 2;
            this.L_MI_InsertShip.Text = "Insert ship in selected position";
            // 
            // GB_MI_MapEditor
            // 
            this.GB_MI_MapEditor.Controls.Add(this.TB_MI_InsertShip);
            this.GB_MI_MapEditor.Controls.Add(this.L_MI_OrientationChanger);
            this.GB_MI_MapEditor.Controls.Add(this.L_MI_InsertShip);
            this.GB_MI_MapEditor.Controls.Add(this.TB_MI_ChangeOrientation);
            this.GB_MI_MapEditor.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.GB_MI_MapEditor.ForeColor = System.Drawing.Color.Orange;
            this.GB_MI_MapEditor.Location = new System.Drawing.Point(12, 12);
            this.GB_MI_MapEditor.Name = "GB_MI_MapEditor";
            this.GB_MI_MapEditor.Size = new System.Drawing.Size(244, 75);
            this.GB_MI_MapEditor.TabIndex = 4;
            this.GB_MI_MapEditor.TabStop = false;
            this.GB_MI_MapEditor.Text = "Map Editor";
            // 
            // GB_MI_ShipType
            // 
            this.GB_MI_ShipType.Controls.Add(this.TB_ShipType_Battleship);
            this.GB_MI_ShipType.Controls.Add(this.TB_ShipType_Cruiser);
            this.GB_MI_ShipType.Controls.Add(this.L_MI_SelectBattleship);
            this.GB_MI_ShipType.Controls.Add(this.L_MI_SelectCruiser);
            this.GB_MI_ShipType.Controls.Add(this.TB_ShipType_Destroyer);
            this.GB_MI_ShipType.Controls.Add(this.TB_ShipType_Frigate);
            this.GB_MI_ShipType.Controls.Add(this.L_MI_SelectDestroyer);
            this.GB_MI_ShipType.Controls.Add(this.L_MI_SelectFrigate);
            this.GB_MI_ShipType.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.GB_MI_ShipType.ForeColor = System.Drawing.Color.Orange;
            this.GB_MI_ShipType.Location = new System.Drawing.Point(12, 93);
            this.GB_MI_ShipType.Name = "GB_MI_ShipType";
            this.GB_MI_ShipType.Size = new System.Drawing.Size(244, 144);
            this.GB_MI_ShipType.TabIndex = 5;
            this.GB_MI_ShipType.TabStop = false;
            this.GB_MI_ShipType.Text = "Map Editor";
            // 
            // TB_ShipType_Battleship
            // 
            this.TB_ShipType_Battleship.BackColor = System.Drawing.Color.Black;
            this.TB_ShipType_Battleship.Font = new System.Drawing.Font("Franklin Gothic Demi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_ShipType_Battleship.ForeColor = System.Drawing.Color.Orange;
            this.TB_ShipType_Battleship.Location = new System.Drawing.Point(159, 111);
            this.TB_ShipType_Battleship.Name = "TB_ShipType_Battleship";
            this.TB_ShipType_Battleship.ReadOnly = true;
            this.TB_ShipType_Battleship.Size = new System.Drawing.Size(79, 22);
            this.TB_ShipType_Battleship.TabIndex = 12;
            this.TB_ShipType_Battleship.Tag = "1";
            this.TB_ShipType_Battleship.Text = "4";
            this.TB_ShipType_Battleship.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_ShipType_Cruiser
            // 
            this.TB_ShipType_Cruiser.BackColor = System.Drawing.Color.Black;
            this.TB_ShipType_Cruiser.Font = new System.Drawing.Font("Franklin Gothic Demi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_ShipType_Cruiser.ForeColor = System.Drawing.Color.Orange;
            this.TB_ShipType_Cruiser.Location = new System.Drawing.Point(159, 81);
            this.TB_ShipType_Cruiser.Name = "TB_ShipType_Cruiser";
            this.TB_ShipType_Cruiser.ReadOnly = true;
            this.TB_ShipType_Cruiser.Size = new System.Drawing.Size(79, 22);
            this.TB_ShipType_Cruiser.TabIndex = 9;
            this.TB_ShipType_Cruiser.Tag = "1";
            this.TB_ShipType_Cruiser.Text = "3";
            this.TB_ShipType_Cruiser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // L_MI_SelectBattleship
            // 
            this.L_MI_SelectBattleship.AutoSize = true;
            this.L_MI_SelectBattleship.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_MI_SelectBattleship.Location = new System.Drawing.Point(6, 116);
            this.L_MI_SelectBattleship.Name = "L_MI_SelectBattleship";
            this.L_MI_SelectBattleship.Size = new System.Drawing.Size(139, 17);
            this.L_MI_SelectBattleship.TabIndex = 11;
            this.L_MI_SelectBattleship.Text = "Select ship type: Battleship";
            // 
            // L_MI_SelectCruiser
            // 
            this.L_MI_SelectCruiser.AutoSize = true;
            this.L_MI_SelectCruiser.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_MI_SelectCruiser.Location = new System.Drawing.Point(6, 86);
            this.L_MI_SelectCruiser.Name = "L_MI_SelectCruiser";
            this.L_MI_SelectCruiser.Size = new System.Drawing.Size(124, 17);
            this.L_MI_SelectCruiser.TabIndex = 10;
            this.L_MI_SelectCruiser.Text = "Select ship type: Cruiser";
            // 
            // TB_ShipType_Destroyer
            // 
            this.TB_ShipType_Destroyer.BackColor = System.Drawing.Color.Black;
            this.TB_ShipType_Destroyer.Font = new System.Drawing.Font("Franklin Gothic Demi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_ShipType_Destroyer.ForeColor = System.Drawing.Color.Orange;
            this.TB_ShipType_Destroyer.Location = new System.Drawing.Point(159, 53);
            this.TB_ShipType_Destroyer.Name = "TB_ShipType_Destroyer";
            this.TB_ShipType_Destroyer.ReadOnly = true;
            this.TB_ShipType_Destroyer.Size = new System.Drawing.Size(79, 22);
            this.TB_ShipType_Destroyer.TabIndex = 8;
            this.TB_ShipType_Destroyer.Tag = "1";
            this.TB_ShipType_Destroyer.Text = "2";
            this.TB_ShipType_Destroyer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_ShipType_Frigate
            // 
            this.TB_ShipType_Frigate.BackColor = System.Drawing.Color.Black;
            this.TB_ShipType_Frigate.Font = new System.Drawing.Font("Franklin Gothic Demi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_ShipType_Frigate.ForeColor = System.Drawing.Color.Orange;
            this.TB_ShipType_Frigate.Location = new System.Drawing.Point(159, 23);
            this.TB_ShipType_Frigate.Name = "TB_ShipType_Frigate";
            this.TB_ShipType_Frigate.ReadOnly = true;
            this.TB_ShipType_Frigate.Size = new System.Drawing.Size(79, 22);
            this.TB_ShipType_Frigate.TabIndex = 6;
            this.TB_ShipType_Frigate.Tag = "1";
            this.TB_ShipType_Frigate.Text = "1";
            this.TB_ShipType_Frigate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // L_MI_SelectDestroyer
            // 
            this.L_MI_SelectDestroyer.AutoSize = true;
            this.L_MI_SelectDestroyer.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_MI_SelectDestroyer.Location = new System.Drawing.Point(6, 58);
            this.L_MI_SelectDestroyer.Name = "L_MI_SelectDestroyer";
            this.L_MI_SelectDestroyer.Size = new System.Drawing.Size(136, 17);
            this.L_MI_SelectDestroyer.TabIndex = 7;
            this.L_MI_SelectDestroyer.Text = "Select ship type: Destroyer";
            // 
            // L_MI_SelectFrigate
            // 
            this.L_MI_SelectFrigate.AutoSize = true;
            this.L_MI_SelectFrigate.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_MI_SelectFrigate.Location = new System.Drawing.Point(6, 28);
            this.L_MI_SelectFrigate.Name = "L_MI_SelectFrigate";
            this.L_MI_SelectFrigate.Size = new System.Drawing.Size(124, 17);
            this.L_MI_SelectFrigate.TabIndex = 6;
            this.L_MI_SelectFrigate.Text = "Select ship type: Frigate";
            // 
            // L_Info_DownloadPDF
            // 
            this.L_Info_DownloadPDF.AutoSize = true;
            this.L_Info_DownloadPDF.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Info_DownloadPDF.Location = new System.Drawing.Point(130, 307);
            this.L_Info_DownloadPDF.Name = "L_Info_DownloadPDF";
            this.L_Info_DownloadPDF.Size = new System.Drawing.Size(87, 17);
            this.L_Info_DownloadPDF.TabIndex = 6;
            this.L_Info_DownloadPDF.Text = "Downlad Manual";
            // 
            // L_Info_Progress
            // 
            this.L_Info_Progress.AutoSize = true;
            this.L_Info_Progress.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Info_Progress.Location = new System.Drawing.Point(12, 284);
            this.L_Info_Progress.Name = "L_Info_Progress";
            this.L_Info_Progress.Size = new System.Drawing.Size(72, 17);
            this.L_Info_Progress.TabIndex = 47;
            this.L_Info_Progress.Text = "0% complete";
            // 
            // PNL_MI_ProgressUnit
            // 
            this.PNL_MI_ProgressUnit.BackColor = System.Drawing.Color.Orange;
            this.PNL_MI_ProgressUnit.ForeColor = System.Drawing.Color.White;
            this.PNL_MI_ProgressUnit.Location = new System.Drawing.Point(0, 0);
            this.PNL_MI_ProgressUnit.Name = "PNL_MI_ProgressUnit";
            this.PNL_MI_ProgressUnit.Size = new System.Drawing.Size(10, 22);
            this.PNL_MI_ProgressUnit.TabIndex = 45;
            this.PNL_MI_ProgressUnit.Visible = false;
            // 
            // PNL_MI_ProgressBar
            // 
            this.PNL_MI_ProgressBar.Controls.Add(this.PNL_MI_ProgressUnit);
            this.PNL_MI_ProgressBar.Location = new System.Drawing.Point(12, 259);
            this.PNL_MI_ProgressBar.Name = "PNL_MI_ProgressBar";
            this.PNL_MI_ProgressBar.Size = new System.Drawing.Size(244, 22);
            this.PNL_MI_ProgressBar.TabIndex = 48;
            // 
            // GB_MI_Plugins
            // 
            this.GB_MI_Plugins.Controls.Add(this.PNL_MI_ProgressBar_Plugins);
            this.GB_MI_Plugins.Controls.Add(this.BS_MI_CheckPlugins);
            this.GB_MI_Plugins.Controls.Add(this.TV_MI_Pligins);
            this.GB_MI_Plugins.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.GB_MI_Plugins.ForeColor = System.Drawing.Color.Orange;
            this.GB_MI_Plugins.Location = new System.Drawing.Point(262, 12);
            this.GB_MI_Plugins.Name = "GB_MI_Plugins";
            this.GB_MI_Plugins.Size = new System.Drawing.Size(254, 312);
            this.GB_MI_Plugins.TabIndex = 49;
            this.GB_MI_Plugins.TabStop = false;
            this.GB_MI_Plugins.Text = "Plugins Manager";
            // 
            // TV_MI_Pligins
            // 
            this.TV_MI_Pligins.BackColor = System.Drawing.Color.Black;
            this.TV_MI_Pligins.Dock = System.Windows.Forms.DockStyle.Top;
            this.TV_MI_Pligins.ForeColor = System.Drawing.Color.Orange;
            this.TV_MI_Pligins.Location = new System.Drawing.Point(3, 18);
            this.TV_MI_Pligins.Name = "TV_MI_Pligins";
            treeNode1.BackColor = System.Drawing.Color.Black;
            treeNode1.ForeColor = System.Drawing.Color.Lime;
            treeNode1.Name = "TVB_MapEditor_IncludeState";
            treeNode1.Text = "Included";
            treeNode2.BackColor = System.Drawing.Color.Black;
            treeNode2.Checked = true;
            treeNode2.ForeColor = System.Drawing.Color.Orange;
            treeNode2.Name = "TVB_MapEditor";
            treeNode2.Text = "Map Editor";
            treeNode2.ToolTipText = "Map Editor Plugin";
            treeNode3.BackColor = System.Drawing.Color.Black;
            treeNode3.ForeColor = System.Drawing.Color.Red;
            treeNode3.Name = "TVB_SchematicTools_IncludedState";
            treeNode3.Text = "Not Included";
            treeNode4.BackColor = System.Drawing.Color.Black;
            treeNode4.ForeColor = System.Drawing.Color.Orange;
            treeNode4.Name = "TVB_SchematicTools";
            treeNode4.Text = "Schematic Tools";
            treeNode4.ToolTipText = "Schematic Tools Plugin";
            treeNode5.BackColor = System.Drawing.Color.Black;
            treeNode5.ForeColor = System.Drawing.Color.Lime;
            treeNode5.Name = "TVB_DebugTool_IncludedState";
            treeNode5.Text = "Included";
            treeNode6.BackColor = System.Drawing.Color.Black;
            treeNode6.ForeColor = System.Drawing.Color.Orange;
            treeNode6.Name = "TVB_DebugTools";
            treeNode6.Text = "Debug Tools";
            treeNode6.ToolTipText = "Debug Tools Plugin";
            treeNode7.BackColor = System.Drawing.Color.Black;
            treeNode7.ForeColor = System.Drawing.Color.Red;
            treeNode7.Name = "TVB_DiagnosticTools_IncludedState";
            treeNode7.Text = "Not Included";
            treeNode8.BackColor = System.Drawing.Color.Black;
            treeNode8.ForeColor = System.Drawing.Color.Orange;
            treeNode8.Name = "TVB_DiagnosticTools";
            treeNode8.Text = "Diagnostic Tools";
            treeNode8.ToolTipText = "Diagnostic Tools Plugin";
            treeNode9.BackColor = System.Drawing.Color.Black;
            treeNode9.ForeColor = System.Drawing.Color.Yellow;
            treeNode9.Name = "TVB_AI_Module_IncludedState";
            treeNode9.Text = "In Process";
            treeNode10.BackColor = System.Drawing.Color.Black;
            treeNode10.ForeColor = System.Drawing.Color.Orange;
            treeNode10.Name = "TVB_AI_Module";
            treeNode10.Text = "AI Module";
            treeNode10.ToolTipText = "Fight AI Module";
            treeNode11.BackColor = System.Drawing.Color.Black;
            treeNode11.ForeColor = System.Drawing.Color.Orange;
            treeNode11.Name = "TVK_Plugins";
            treeNode11.Text = "Plugins";
            this.TV_MI_Pligins.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11});
            this.TV_MI_Pligins.Size = new System.Drawing.Size(248, 251);
            this.TV_MI_Pligins.TabIndex = 0;
            // 
            // PB_IMB_DownloadPDF
            // 
            this.PB_IMB_DownloadPDF.BackColor = System.Drawing.Color.Black;
            this.PB_IMB_DownloadPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PB_IMB_DownloadPDF.Image = global::Battleship.Properties.Resources.Download_PDF;
            this.PB_IMB_DownloadPDF.Location = new System.Drawing.Point(223, 291);
            this.PB_IMB_DownloadPDF.Name = "PB_IMB_DownloadPDF";
            this.PB_IMB_DownloadPDF.Size = new System.Drawing.Size(33, 33);
            this.PB_IMB_DownloadPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_IMB_DownloadPDF.TabIndex = 6;
            this.PB_IMB_DownloadPDF.TabStop = false;
            this.PB_IMB_DownloadPDF.WaitOnLoad = true;
            this.PB_IMB_DownloadPDF.Click += new System.EventHandler(this.PB_IMB_DownloadPDF_Click);
            this.PB_IMB_DownloadPDF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_IMB_DownloadPDF_MouseDown);
            this.PB_IMB_DownloadPDF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PB_IMB_DownloadPDF_MouseUp);
            // 
            // BS_MI_CheckPlugins
            // 
            this.BS_MI_CheckPlugins.BackColor = System.Drawing.Color.Black;
            this.BS_MI_CheckPlugins.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.BS_MI_CheckPlugins.FlatAppearance.BorderSize = 2;
            this.BS_MI_CheckPlugins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_MI_CheckPlugins.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_MI_CheckPlugins.Location = new System.Drawing.Point(147, 276);
            this.BS_MI_CheckPlugins.Name = "BS_MI_CheckPlugins";
            this.BS_MI_CheckPlugins.Size = new System.Drawing.Size(101, 31);
            this.BS_MI_CheckPlugins.TabIndex = 46;
            this.BS_MI_CheckPlugins.Text = "Check Plugins";
            this.BS_MI_CheckPlugins.UseVisualStyleBackColor = false;
            // 
            // PNL_MI_ProgressUnit_Plugins
            // 
            this.PNL_MI_ProgressUnit_Plugins.BackColor = System.Drawing.Color.Orange;
            this.PNL_MI_ProgressUnit_Plugins.ForeColor = System.Drawing.Color.White;
            this.PNL_MI_ProgressUnit_Plugins.Location = new System.Drawing.Point(0, 0);
            this.PNL_MI_ProgressUnit_Plugins.Name = "PNL_MI_ProgressUnit_Plugins";
            this.PNL_MI_ProgressUnit_Plugins.Size = new System.Drawing.Size(10, 31);
            this.PNL_MI_ProgressUnit_Plugins.TabIndex = 45;
            this.PNL_MI_ProgressUnit_Plugins.Visible = false;
            // 
            // PNL_MI_ProgressBar_Plugins
            // 
            this.PNL_MI_ProgressBar_Plugins.Controls.Add(this.PNL_MI_ProgressUnit_Plugins);
            this.PNL_MI_ProgressBar_Plugins.Location = new System.Drawing.Point(3, 276);
            this.PNL_MI_ProgressBar_Plugins.Name = "PNL_MI_ProgressBar_Plugins";
            this.PNL_MI_ProgressBar_Plugins.Size = new System.Drawing.Size(138, 31);
            this.PNL_MI_ProgressBar_Plugins.TabIndex = 49;
            // 
            // ManualInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(528, 331);
            this.Controls.Add(this.GB_MI_Plugins);
            this.Controls.Add(this.PNL_MI_ProgressBar);
            this.Controls.Add(this.GB_MI_ShipType);
            this.Controls.Add(this.L_Info_Progress);
            this.Controls.Add(this.L_Info_DownloadPDF);
            this.Controls.Add(this.PB_IMB_DownloadPDF);
            this.Controls.Add(this.GB_MI_MapEditor);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Orange;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ManualInfo";
            this.Text = "Manual";
            this.Load += new System.EventHandler(this.ManualInfo_Load);
            this.GB_MI_MapEditor.ResumeLayout(false);
            this.GB_MI_MapEditor.PerformLayout();
            this.GB_MI_ShipType.ResumeLayout(false);
            this.GB_MI_ShipType.PerformLayout();
            this.PNL_MI_ProgressBar.ResumeLayout(false);
            this.GB_MI_Plugins.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_IMB_DownloadPDF)).EndInit();
            this.PNL_MI_ProgressBar_Plugins.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_MI_OrientationChanger;
        public System.Windows.Forms.TextBox TB_MI_ChangeOrientation;
        public System.Windows.Forms.TextBox TB_MI_InsertShip;
        private System.Windows.Forms.Label L_MI_InsertShip;
        private System.Windows.Forms.GroupBox GB_MI_MapEditor;
        private System.Windows.Forms.Label L_MI_SelectFrigate;
        private System.Windows.Forms.GroupBox GB_MI_ShipType;
        public System.Windows.Forms.TextBox TB_ShipType_Battleship;
        public System.Windows.Forms.TextBox TB_ShipType_Cruiser;
        private System.Windows.Forms.Label L_MI_SelectBattleship;
        private System.Windows.Forms.Label L_MI_SelectCruiser;
        public System.Windows.Forms.TextBox TB_ShipType_Destroyer;
        public System.Windows.Forms.TextBox TB_ShipType_Frigate;
        private System.Windows.Forms.Label L_MI_SelectDestroyer;
        private System.Windows.Forms.PictureBox PB_IMB_DownloadPDF;
        private System.Windows.Forms.Label L_Info_DownloadPDF;
        private System.Windows.Forms.SaveFileDialog SFD_ManualInfo;
        private System.Windows.Forms.Label L_Info_Progress;
        private System.Windows.Forms.Panel PNL_MI_ProgressUnit;
        private System.Windows.Forms.Panel PNL_MI_ProgressBar;
        private System.Windows.Forms.GroupBox GB_MI_Plugins;
        private System.Windows.Forms.TreeView TV_MI_Pligins;
        private System.Windows.Forms.Panel PNL_MI_ProgressBar_Plugins;
        private System.Windows.Forms.Panel PNL_MI_ProgressUnit_Plugins;
        private System.Windows.Forms.Button BS_MI_CheckPlugins;
    }
}