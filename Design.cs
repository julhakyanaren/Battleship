using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public static class Design
    {
        public static Color DefaultForeColor = Color.FromArgb(188, 222, 233);
        public static Color DefaultBackColor = Color.Black;
        public static Color[] SelectedColorPlayer =
        {
            Color.FromArgb(255, 255, 128), // 0
            Color.Black                    // 1
        };
        public static Color[] MouseOverColor =
        {
            Color.FromArgb(255, 255, 128),
            Color.FromArgb(255, 128, 128)
        };
        public static Color[] BorderColor = { Color.Orange, Color.Black };

        public static Color[] MouseOverColorDefault =
        {
            Color.White,
            Color.FromArgb(255, 128, 128)
        };

        public static Color[] ShipsColor = { Color.Silver, Color.DarkGray, Color.Gray, Color.DimGray };

        public static void ChangeControlElementsForeColor(Control parentControl, Color selectedForeColor, Color selectedBackColor)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control is Button button && button.BackColor != selectedBackColor)
                {
                    continue;
                }
                control.ForeColor = selectedForeColor;
                if (control.HasChildren)
                {
                    ChangeControlElementsForeColor(control, selectedForeColor, selectedBackColor);
                }
            }
        }
    }
}
