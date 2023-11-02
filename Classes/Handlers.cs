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
            "Security Manager"          //7
            };
        public static DialogResult PluginNotIncluded(string message, string manager)
        {
            return MessageBox.Show(message, manager, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
