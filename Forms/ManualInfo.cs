using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
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
        public void ShowPDF()
        {
            string filename = Application.StartupPath;

            filename = Path.GetFullPath(

                Path.Combine(filename, ".\\Manual.pdf"));

            webBrowser1.Navigate(filename);
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
                    DialogResult = MessageBox.Show("Manual Completed", "File Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (DialogResult == DialogResult.OK)
                    {
                        PGB_Progress.Value = 0;
                        L_Info_DownloadPDF.Text = "0% complete";
                        webBrowser1.Visible = true;
                        ShowPDF();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowPDF();
        }
    }
}
