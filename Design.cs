using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public static class Design
    {
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
        public static Color[] BorderColor = { Color.Orange, Color.Red };

        public static Color[] MouseOverColorDefault =
        {
            Color.White,
            Color.FromArgb(255, 128, 128)
        };
    }
}
