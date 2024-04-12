using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Classes
{
    public static class Handlers
    {
        public static string[] Manager =
            {
            "Battleship",               //0
            "File Manager",             //1
            "User Manager",             //2
            "Map Editor",               //3
            "Game Manager",             //4
            "Configuration Manager",    //5
            "Connection Manager",       //6
            "Security Manager",         //7
            "UI Manager",               //8
            "Data Manager"              //9
            };
        public static string[] ErrorLevel =
            {
            "Travial",
            "Low",
            "Medium",
            "Hight",
            "Critical",
            "Blocked"
            };
        public static DialogResult PluginNotIncluded(string message, string manager)
        {
            return MessageBox.Show(message, manager, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public static DialogResult ExceptionMessageTemplate(Exception ex, int managerId, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DateTime dt = DateTime.Now;
            return MessageBox.Show($"Exception encountered\r\n\r\n" +
                $"Date: {dt}" +
                $"Exception Type:\r\n{ex.GetType()}\r\n\r\n" +
                $"Exception Message:\r\n{ex.Message}\r\n\r\n" +
                $"Exception Info:\r\n\r\n{ex}", $"{Manager[managerId]}", buttons, icon);
        }
        public static DialogResult ErrorHandlerStandart(string errorCode, string errorMessage, int managerId, MessageBoxButtons buttons, MessageBoxIcon icon = MessageBoxIcon.Error)
        {
            return MessageBox.Show($"Error detected\r\n\r\n" +
                $"{errorMessage}\r\n\r\n" +
                $"Error Code: {errorCode}", $"{Manager[managerId]}", buttons, icon);
        }
    }
}
