using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        public async void DownloadPDF()
        {
            SFD_ManualInfo.Filter = "MS Word|*.docx";
            SFD_ManualInfo.FileName = Data.ManualName;
            if (SFD_ManualInfo.ShowDialog() == DialogResult.OK)
            {
                string savePath = SFD_ManualInfo.FileName;
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(Data.ManualUrl).Result;
                    var totalBytes = response.Content.Headers.ContentLength ?? -1;
                    var readBytes = 0;
                    using (FileStream fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        byte[] buffer = new byte[8192];
                        using (var contentStream = await response.Content.ReadAsStreamAsync())
                        {
                            int bytesRead;
                            while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                fileStream.Write(buffer, 0, bytesRead);
                                readBytes += bytesRead;
                                if (totalBytes > 0)
                                {
                                    int percenentage = (int)((double)readBytes / totalBytes * 100);
                                    UpdateProgressBar(percenentage);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void UpdateProgressBar(int percenentage)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateProgressBar), percenentage);
            }
            else
            {
                PGB_Progress.Value = percenentage;
                L_Info_Progress.Text = $"{percenentage}% complete";
            }
        }

        private void PB_IMB_DownloadPDF_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Download manual?", "File Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                try
                {
                    DownloadPDF();
                }
                catch
                {
                    //Error_Catch
                }
                finally
                {
                    PGB_Progress.Value = 0;
                }
            }
        }
    }
}
