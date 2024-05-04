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
    }
}
