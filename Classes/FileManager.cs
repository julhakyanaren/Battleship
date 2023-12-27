using System;
using System.IO;
using System.Messaging;
using System.Windows.Forms;

namespace Battleship.Classes
{
    public static class FileManager
    {
        public static string ManualUrl = "https://raw.githubusercontent.com/julhakyanaren/Battleship/master/Manual.pdf";
        public static string ManualName = "Manual.pdf";
        public static string ManualSavePath;

        public static bool SchematicSaveTool = false;

        public static string COR_Path = "COR.txt";
        public static void COR_Read()
        {
            if (File.Exists(COR_Path))
            {
                string cor = File.ReadAllText(COR_Path);
                try
                {
                    DebugTools.RunsCount = int.Parse(cor);
                    DebugTools.RunsCount++;
                    COR_Write(DebugTools.RunsCount.ToString());
                }
                catch
                {
                    DialogResult dr = MessageBox.Show($"File reading error\r\nFile {COR_Path} does not exist!", "Resource Manager", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (dr == DialogResult.Retry)
                    {
                        COR_Read();
                    }
                }
            }
            else
            {
                File.WriteAllText(COR_Path, "1");
            }
        }
        public static void COR_Write(string rc = "1")
        {
            try
            {
                File.WriteAllText(COR_Path, rc);
            }
            catch
            {
                DialogResult dr = MessageBox.Show($"File record error\r\nFile {COR_Path} does not exist!", "Resource Manager", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                {
                    COR_Write(DebugTools.RunsCount.ToString());
                }
            }
        }
    }
}
