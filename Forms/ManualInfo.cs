using Battleship.Classes;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
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
            SFD_ManualInfo.Filter = "PDF|*.pdf";
            SFD_ManualInfo.FileName = FileManager.ManualName;
            if (SFD_ManualInfo.ShowDialog() == DialogResult.OK)
            {
                string savePath = SFD_ManualInfo.FileName;
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(FileManager.ManualUrl).Result;
                    var totalBytes = response.Content.Headers.ContentLength ?? -1;
                    var readBytes = 0;
                    using (FileStream fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        byte[] buffer = new byte[8192];
                        PNL_MI_ProgressUnit.Visible = true;
                        using (var contentStream = await response.Content.ReadAsStreamAsync())
                        {
                            int bytesRead;
                            while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await Task.Delay(10);
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
                L_Info_Progress.Text = $"{percenentage}% complete";
                SetCustomProgressBarValue(percenentage);
            }
        }
        public void ShowPDF()
        {
            string filename = Application.StartupPath;

            filename = Path.GetFullPath(

                Path.Combine(filename, ".\\Manual.pdf"));
        }
        private void PB_IMB_DownloadPDF_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Download manual?", "File Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                if (Connection.IsInternetAvailable())
                {
                    try
                    {
                        DownloadPDF();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Occurred due to a file download error. Code:{ex.HResult}");
                    }
                    finally
                    {
                        DialogResult = MessageBox.Show("Manual Completed", "File Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (DialogResult == DialogResult.OK)
                        {
                            PNL_MI_ProgressUnit.Visible = false;
                            L_Info_DownloadPDF.Text = "0% complete";
                            ShowPDF();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No internet connection", "Connections Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        void SetCustomProgressBarValue(int percentage)
        {
            PNL_MI_ProgressUnit.Width = PNL_MI_ProgressBar.Width * percentage / 100;
        }
    }
}
