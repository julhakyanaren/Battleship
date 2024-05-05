namespace Battleship.Forms
{
    partial class GlobalExceptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalExceptionForm));
            this.L_Info_ExceptionType = new System.Windows.Forms.Label();
            this.TB_GE_Type = new System.Windows.Forms.TextBox();
            this.TB_GE_Message = new System.Windows.Forms.TextBox();
            this.L_Info_Message = new System.Windows.Forms.Label();
            this.TB_GE_Info = new System.Windows.Forms.TextBox();
            this.L_Info_ExceptionInfo = new System.Windows.Forms.Label();
            this.TB_GE_StackTrace = new System.Windows.Forms.TextBox();
            this.L_Info_StackTrace = new System.Windows.Forms.Label();
            this.BS_GE_SaveData = new System.Windows.Forms.Button();
            this.TB_GE_DateTime = new System.Windows.Forms.TextBox();
            this.L_Info_DateTime = new System.Windows.Forms.Label();
            this.TB_GE_Method = new System.Windows.Forms.TextBox();
            this.L_Info_Method = new System.Windows.Forms.Label();
            this.TB_GE_Class = new System.Windows.Forms.TextBox();
            this.L_Info_Class = new System.Windows.Forms.Label();
            this.TB_GE_Access = new System.Windows.Forms.TextBox();
            this.L_Info_AccessModifier = new System.Windows.Forms.Label();
            this.TB_GE_IsStatic = new System.Windows.Forms.TextBox();
            this.L_Info_IsStatic = new System.Windows.Forms.Label();
            this.SFD_GE = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // L_Info_ExceptionType
            // 
            this.L_Info_ExceptionType.AutoSize = true;
            this.L_Info_ExceptionType.Location = new System.Drawing.Point(3, 6);
            this.L_Info_ExceptionType.Name = "L_Info_ExceptionType";
            this.L_Info_ExceptionType.Size = new System.Drawing.Size(79, 17);
            this.L_Info_ExceptionType.TabIndex = 0;
            this.L_Info_ExceptionType.Text = "Exception Type";
            // 
            // TB_GE_Type
            // 
            this.TB_GE_Type.BackColor = System.Drawing.Color.Black;
            this.TB_GE_Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_GE_Type.ForeColor = System.Drawing.Color.OrangeRed;
            this.TB_GE_Type.Location = new System.Drawing.Point(6, 26);
            this.TB_GE_Type.Multiline = true;
            this.TB_GE_Type.Name = "TB_GE_Type";
            this.TB_GE_Type.ReadOnly = true;
            this.TB_GE_Type.Size = new System.Drawing.Size(142, 25);
            this.TB_GE_Type.TabIndex = 1;
            // 
            // TB_GE_Message
            // 
            this.TB_GE_Message.BackColor = System.Drawing.Color.Black;
            this.TB_GE_Message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_GE_Message.ForeColor = System.Drawing.Color.OrangeRed;
            this.TB_GE_Message.Location = new System.Drawing.Point(6, 273);
            this.TB_GE_Message.Multiline = true;
            this.TB_GE_Message.Name = "TB_GE_Message";
            this.TB_GE_Message.ReadOnly = true;
            this.TB_GE_Message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_GE_Message.Size = new System.Drawing.Size(515, 75);
            this.TB_GE_Message.TabIndex = 3;
            // 
            // L_Info_Message
            // 
            this.L_Info_Message.AutoSize = true;
            this.L_Info_Message.Location = new System.Drawing.Point(3, 253);
            this.L_Info_Message.Name = "L_Info_Message";
            this.L_Info_Message.Size = new System.Drawing.Size(51, 17);
            this.L_Info_Message.TabIndex = 2;
            this.L_Info_Message.Text = "Message";
            // 
            // TB_GE_Info
            // 
            this.TB_GE_Info.BackColor = System.Drawing.Color.Black;
            this.TB_GE_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_GE_Info.ForeColor = System.Drawing.Color.OrangeRed;
            this.TB_GE_Info.Location = new System.Drawing.Point(6, 74);
            this.TB_GE_Info.Multiline = true;
            this.TB_GE_Info.Name = "TB_GE_Info";
            this.TB_GE_Info.ReadOnly = true;
            this.TB_GE_Info.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_GE_Info.Size = new System.Drawing.Size(515, 75);
            this.TB_GE_Info.TabIndex = 5;
            // 
            // L_Info_ExceptionInfo
            // 
            this.L_Info_ExceptionInfo.AutoSize = true;
            this.L_Info_ExceptionInfo.Location = new System.Drawing.Point(3, 54);
            this.L_Info_ExceptionInfo.Name = "L_Info_ExceptionInfo";
            this.L_Info_ExceptionInfo.Size = new System.Drawing.Size(75, 17);
            this.L_Info_ExceptionInfo.TabIndex = 4;
            this.L_Info_ExceptionInfo.Text = "Exception Info";
            // 
            // TB_GE_StackTrace
            // 
            this.TB_GE_StackTrace.BackColor = System.Drawing.Color.Black;
            this.TB_GE_StackTrace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_GE_StackTrace.ForeColor = System.Drawing.Color.OrangeRed;
            this.TB_GE_StackTrace.Location = new System.Drawing.Point(6, 174);
            this.TB_GE_StackTrace.Multiline = true;
            this.TB_GE_StackTrace.Name = "TB_GE_StackTrace";
            this.TB_GE_StackTrace.ReadOnly = true;
            this.TB_GE_StackTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_GE_StackTrace.Size = new System.Drawing.Size(515, 75);
            this.TB_GE_StackTrace.TabIndex = 7;
            // 
            // L_Info_StackTrace
            // 
            this.L_Info_StackTrace.AutoSize = true;
            this.L_Info_StackTrace.Location = new System.Drawing.Point(3, 154);
            this.L_Info_StackTrace.Name = "L_Info_StackTrace";
            this.L_Info_StackTrace.Size = new System.Drawing.Size(64, 17);
            this.L_Info_StackTrace.TabIndex = 6;
            this.L_Info_StackTrace.Text = "Stack Trace";
            // 
            // BS_GE_SaveData
            // 
            this.BS_GE_SaveData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BS_GE_SaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BS_GE_SaveData.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BS_GE_SaveData.ForeColor = System.Drawing.Color.OrangeRed;
            this.BS_GE_SaveData.Location = new System.Drawing.Point(302, 26);
            this.BS_GE_SaveData.Name = "BS_GE_SaveData";
            this.BS_GE_SaveData.Size = new System.Drawing.Size(216, 25);
            this.BS_GE_SaveData.TabIndex = 48;
            this.BS_GE_SaveData.Text = "Save Exception Data";
            this.BS_GE_SaveData.UseVisualStyleBackColor = true;
            this.BS_GE_SaveData.Visible = false;
            this.BS_GE_SaveData.Click += new System.EventHandler(this.BS_GE_SaveData_Click);
            // 
            // TB_GE_DateTime
            // 
            this.TB_GE_DateTime.BackColor = System.Drawing.Color.Black;
            this.TB_GE_DateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_GE_DateTime.ForeColor = System.Drawing.Color.OrangeRed;
            this.TB_GE_DateTime.Location = new System.Drawing.Point(154, 26);
            this.TB_GE_DateTime.Multiline = true;
            this.TB_GE_DateTime.Name = "TB_GE_DateTime";
            this.TB_GE_DateTime.ReadOnly = true;
            this.TB_GE_DateTime.Size = new System.Drawing.Size(142, 25);
            this.TB_GE_DateTime.TabIndex = 50;
            // 
            // L_Info_DateTime
            // 
            this.L_Info_DateTime.AutoSize = true;
            this.L_Info_DateTime.Location = new System.Drawing.Point(151, 6);
            this.L_Info_DateTime.Name = "L_Info_DateTime";
            this.L_Info_DateTime.Size = new System.Drawing.Size(56, 17);
            this.L_Info_DateTime.TabIndex = 49;
            this.L_Info_DateTime.Text = "Date Time";
            // 
            // TB_GE_Method
            // 
            this.TB_GE_Method.BackColor = System.Drawing.Color.Black;
            this.TB_GE_Method.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_GE_Method.ForeColor = System.Drawing.Color.OrangeRed;
            this.TB_GE_Method.Location = new System.Drawing.Point(309, 377);
            this.TB_GE_Method.Name = "TB_GE_Method";
            this.TB_GE_Method.ReadOnly = true;
            this.TB_GE_Method.Size = new System.Drawing.Size(209, 22);
            this.TB_GE_Method.TabIndex = 52;
            // 
            // L_Info_Method
            // 
            this.L_Info_Method.AutoSize = true;
            this.L_Info_Method.Location = new System.Drawing.Point(306, 357);
            this.L_Info_Method.Name = "L_Info_Method";
            this.L_Info_Method.Size = new System.Drawing.Size(45, 17);
            this.L_Info_Method.TabIndex = 51;
            this.L_Info_Method.Text = "Method";
            // 
            // TB_GE_Class
            // 
            this.TB_GE_Class.BackColor = System.Drawing.Color.Black;
            this.TB_GE_Class.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_GE_Class.ForeColor = System.Drawing.Color.OrangeRed;
            this.TB_GE_Class.Location = new System.Drawing.Point(6, 377);
            this.TB_GE_Class.Name = "TB_GE_Class";
            this.TB_GE_Class.ReadOnly = true;
            this.TB_GE_Class.Size = new System.Drawing.Size(120, 22);
            this.TB_GE_Class.TabIndex = 54;
            // 
            // L_Info_Class
            // 
            this.L_Info_Class.AutoSize = true;
            this.L_Info_Class.Location = new System.Drawing.Point(3, 357);
            this.L_Info_Class.Name = "L_Info_Class";
            this.L_Info_Class.Size = new System.Drawing.Size(34, 17);
            this.L_Info_Class.TabIndex = 53;
            this.L_Info_Class.Text = "Class";
            // 
            // TB_GE_Access
            // 
            this.TB_GE_Access.BackColor = System.Drawing.Color.Black;
            this.TB_GE_Access.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_GE_Access.ForeColor = System.Drawing.Color.OrangeRed;
            this.TB_GE_Access.Location = new System.Drawing.Point(132, 377);
            this.TB_GE_Access.Name = "TB_GE_Access";
            this.TB_GE_Access.ReadOnly = true;
            this.TB_GE_Access.Size = new System.Drawing.Size(89, 22);
            this.TB_GE_Access.TabIndex = 56;
            // 
            // L_Info_AccessModifier
            // 
            this.L_Info_AccessModifier.AutoSize = true;
            this.L_Info_AccessModifier.Location = new System.Drawing.Point(129, 357);
            this.L_Info_AccessModifier.Name = "L_Info_AccessModifier";
            this.L_Info_AccessModifier.Size = new System.Drawing.Size(82, 17);
            this.L_Info_AccessModifier.TabIndex = 55;
            this.L_Info_AccessModifier.Text = "Access Modifier";
            // 
            // TB_GE_IsStatic
            // 
            this.TB_GE_IsStatic.BackColor = System.Drawing.Color.Black;
            this.TB_GE_IsStatic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_GE_IsStatic.ForeColor = System.Drawing.Color.OrangeRed;
            this.TB_GE_IsStatic.Location = new System.Drawing.Point(227, 377);
            this.TB_GE_IsStatic.Name = "TB_GE_IsStatic";
            this.TB_GE_IsStatic.ReadOnly = true;
            this.TB_GE_IsStatic.Size = new System.Drawing.Size(76, 22);
            this.TB_GE_IsStatic.TabIndex = 58;
            // 
            // L_Info_IsStatic
            // 
            this.L_Info_IsStatic.AutoSize = true;
            this.L_Info_IsStatic.Location = new System.Drawing.Point(224, 357);
            this.L_Info_IsStatic.Name = "L_Info_IsStatic";
            this.L_Info_IsStatic.Size = new System.Drawing.Size(47, 17);
            this.L_Info_IsStatic.TabIndex = 57;
            this.L_Info_IsStatic.Text = "Is Static";
            // 
            // GlobalExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(527, 410);
            this.Controls.Add(this.TB_GE_IsStatic);
            this.Controls.Add(this.L_Info_IsStatic);
            this.Controls.Add(this.TB_GE_Access);
            this.Controls.Add(this.L_Info_AccessModifier);
            this.Controls.Add(this.TB_GE_Class);
            this.Controls.Add(this.L_Info_Class);
            this.Controls.Add(this.TB_GE_Method);
            this.Controls.Add(this.L_Info_Method);
            this.Controls.Add(this.TB_GE_DateTime);
            this.Controls.Add(this.L_Info_DateTime);
            this.Controls.Add(this.BS_GE_SaveData);
            this.Controls.Add(this.TB_GE_StackTrace);
            this.Controls.Add(this.L_Info_StackTrace);
            this.Controls.Add(this.TB_GE_Info);
            this.Controls.Add(this.L_Info_ExceptionInfo);
            this.Controls.Add(this.TB_GE_Message);
            this.Controls.Add(this.L_Info_Message);
            this.Controls.Add(this.TB_GE_Type);
            this.Controls.Add(this.L_Info_ExceptionType);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F);
            this.ForeColor = System.Drawing.Color.OrangeRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "GlobalExceptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exception Diagnostic";
            this.Load += new System.EventHandler(this.GlobalExceptionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Info_ExceptionType;
        private System.Windows.Forms.TextBox TB_GE_Type;
        private System.Windows.Forms.TextBox TB_GE_Message;
        private System.Windows.Forms.Label L_Info_Message;
        private System.Windows.Forms.TextBox TB_GE_Info;
        private System.Windows.Forms.Label L_Info_ExceptionInfo;
        private System.Windows.Forms.TextBox TB_GE_StackTrace;
        private System.Windows.Forms.Label L_Info_StackTrace;
        private System.Windows.Forms.Button BS_GE_SaveData;
        private System.Windows.Forms.TextBox TB_GE_DateTime;
        private System.Windows.Forms.Label L_Info_DateTime;
        private System.Windows.Forms.TextBox TB_GE_Method;
        private System.Windows.Forms.Label L_Info_Method;
        private System.Windows.Forms.TextBox TB_GE_Class;
        private System.Windows.Forms.Label L_Info_Class;
        private System.Windows.Forms.TextBox TB_GE_Access;
        private System.Windows.Forms.Label L_Info_AccessModifier;
        private System.Windows.Forms.TextBox TB_GE_IsStatic;
        private System.Windows.Forms.Label L_Info_IsStatic;
        private System.Windows.Forms.SaveFileDialog SFD_GE;
    }
}