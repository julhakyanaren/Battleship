using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static List<float> HitChanceChanges = new List<float>();
        public static string[] EfficientyDataString = { "Forbidden", "Very Low", "Low", "Average", "High", "Very High", "Guaranteed" };
        public static Color[] EfficientyDataColor = { Color.Firebrick, Color.Red, Color.OrangeRed, Color.DarkOrange, Color.Yellow, Color.YellowGreen, Color.Lime };
        public static double HitProbobility = 0.0f;
        
        public static bool FormClosed = true;
        public static bool ExampleCraeted = false;
        public static bool CanOpenForm = false;
        public static bool CanResetMap = true;
        public static bool ManualMode = false;

    }
}
