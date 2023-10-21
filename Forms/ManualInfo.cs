using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Forms
{
    public partial class ManualInfo : Form
    {
        public ManualInfo()
        {
            InitializeComponent();
        }
        private void ManualInfo_Load(object sender, EventArgs e)
        {
        }

        private void PB_IMB_DownloadPDF_MouseDown(object sender, MouseEventArgs e)
        {
            PB_IMB_DownloadPDF.BorderStyle = BorderStyle.FixedSingle;
            PB_IMB_DownloadPDF.Image = Properties.Resources.Download_PDF_Black;
            PB_IMB_DownloadPDF.BackColor = Color.FromArgb(252,146,0);
        }

        private void PB_IMB_DownloadPDF_MouseUp(object sender, MouseEventArgs e)
        {
            PB_IMB_DownloadPDF.BorderStyle = BorderStyle.None;
            PB_IMB_DownloadPDF.Image = Properties.Resources.Download_PDF;
            PB_IMB_DownloadPDF.BackColor = Color.Black;
        }

        private void PB_IMB_DownloadPDF_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Download manual?", "File Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {

            }
        }
    }
}
