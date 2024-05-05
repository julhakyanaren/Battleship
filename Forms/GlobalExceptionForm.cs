using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Forms
{
    public partial class GlobalExceptionForm : Form
    {
        DateTime date;
        public GlobalExceptionForm()
        {
            InitializeComponent();
        }

        private void GlobalExceptionForm_Load(object sender, EventArgs e)
        {
            date= DateTime.UtcNow;
        }
        public void DisplayExceptionData(Exception ex)
        {
            date = DateTime.UtcNow;
            TB_GE_DateTime.Text = DateTime.UtcNow.ToString("dd.MM.yyyy HH.mm.ss");
            TB_GE_Type.Text = ex.GetType().Name;
            TB_GE_StackTrace.Text = ex.StackTrace.ToString();
            TB_GE_Info.Text = ex.ToString();
            TB_GE_Message.Text = ex.Message;
            TB_GE_Method.Text = ex.TargetSite.Name;
            TB_GE_Class.Text = ex.TargetSite.DeclaringType.FullName;
            if (ex.TargetSite.IsPublic)
            {
                TB_GE_Access.Text = "Public";
            }
            else
            {
                TB_GE_Access.Text = "Private";
            }
            TB_GE_IsStatic.Text = ex.TargetSite.IsStatic.ToString();
        }
        public void RecordExceptionFile(out bool isEmpty)
        {
            string[] lines = new string[9];
            lines[0] = $"{TB_GE_Type.Text} type Exception found";
            lines[1] = $"Date:\t{TB_GE_DateTime.Text}";
            lines[2] = $"Stack Trace\r\n\r\n{TB_GE_StackTrace.Text}\r\n\r\n";
            lines[3] = $"Exception Message:\r\n\r\n{TB_GE_Message.Text}\r\n\r\n";
            lines[4] = $"Method Data\r\n\r\n";
            lines[5] = $"Class:\t{TB_GE_Class.Text}";
            lines[6] = $"Method name:\t {TB_GE_Method.Text}";
            lines[7] = $"Method access modifier:\t{TB_GE_Access.Text}";
            lines[8] = $"Is Method Static\t{TB_GE_IsStatic}";
            isEmpty = false;
            for (int l = 0; l < lines.Length; l++)
            {
                if (lines[l] != "")
                {
                    isEmpty = true;
                    break;
                }
            }
            if (!isEmpty)
            {
                SFD_GE.Title = "Save exception diagnostic file?";
                SFD_GE.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
                SFD_GE.FileName = $"EDF_{date.ToString("ddMMyyHHmmss")}";
                if (SFD_GE.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllLines(SFD_GE.FileName, lines);
                }
            }
        }

        private void BS_GE_SaveData_Click(object sender, EventArgs e)
        {
            bool recorded = true;
            bool isEmpty = false;
            try
            {
                RecordExceptionFile(out isEmpty);
            }
            catch
            {
                recorded = false;
            }
            finally
            {
                if (isEmpty)
                {
                    MessageBox.Show("One of the fields is empty", "Data Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (recorded)
                {
                    MessageBox.Show("The file was successfully written", "Data Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("File writing failed", "Data Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
