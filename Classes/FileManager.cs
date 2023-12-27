using System;
using System.Diagnostics;
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

        public static string AssemblyPath = "Assembly.txt";
        public static void ReadAssembyData()
        {
            if (File.Exists(AssemblyPath))
            {
                try
                {
                    string[] data = File.ReadAllLines(AssemblyPath);
                    string stage = null;
                    if (data.Length > 5)
                    {
                        string[] parts = data[0].Split('.');
                        if (parts.Length == 1)
                        {
                            stage = Options.Stages[int.Parse(parts[0])];
                            Options.V_Release = int.Parse(parts[1]);
                            Options.V_Assembly = int.Parse(parts[2]);
                            Options.V_Edition = int.Parse(parts[3]);
                            DebugTools.RunsCount = int.Parse(parts[4]);
                        }
                        DebugTools.Version = $"{parts[0]} ";
                        for (int p = 1; p < parts.Length; p++)
                        {
                            DebugTools.Version += parts[p];
                        }
                    }
                }
                catch (Exception ex)
                {
                    DialogResult dr = MessageBox.Show($"File reading error\r\nFile name: {AssemblyPath}\r\nException Message: {ex.Message}\r\nException: {ex}", "File Manager", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (dr == DialogResult.Retry)
                    {
                        ReadAssembyData();
                    }
                }
            }
            else
            {
                try
                {
                    string[] parts = new string[5];
                    parts[0] = Array.IndexOf(Options.Stages, Options.V_Stage).ToString();
                    parts[1] = Options.V_Release.ToString();
                    parts[2] = Options.V_Assembly.ToString();
                    parts[3] = Options.V_Edition.ToString();
                    parts[4] = DebugTools.RunsCount.ToString();
                    string data = string.Join(".", parts);
                    File.WriteAllText(AssemblyPath, data);
                }
                catch
                {
                    DialogResult dr = MessageBox.Show($"File record error\r\nFile {AssemblyPath} does not exist!", "Resource Manager", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (dr == DialogResult.Retry)
                    {
                        WriteAssemblyData();
                    }
                }
            }
        }
        public static void WriteAssemblyData()
        {
            try
            {
                string[] parts = new string[5];
                parts[0] = Array.IndexOf(Options.Stages, Options.V_Stage).ToString();
                parts[1] = Options.V_Release.ToString();
                parts[2] = Options.V_Assembly.ToString();
                parts[3] = Options.V_Edition.ToString();
                parts[4] = DebugTools.RunsCount.ToString();
                string data = string.Join(".", parts);
                string[] lines = { data };
                File.WriteAllLines(AssemblyPath, lines);
            }
            catch
            {
                DialogResult dr = MessageBox.Show($"File record error\r\nFile {AssemblyPath} does not exist!", "Resource Manager", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                {
                    WriteAssemblyData();
                }
            }
        }
    }
}
