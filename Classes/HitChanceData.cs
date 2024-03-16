using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Classes
{
    public static class HitChanceData
    {
        public static Button SelectedCell = null;
        public static List<Button> CurrentMap = new List<Button>();
        
        public static bool FormClosed = true;
        public static bool ExampleCraeted = false;
        public static bool CanOpenForm = false;
        public static bool CanResetMap = true;
        public static bool ManualMode = false;
    }
}
