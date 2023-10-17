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
        public static void ChangeButtonEnabledDesign(Button inputButton, int mode)
        {
            Color old_ForeColor = inputButton.ForeColor;
            Color old_BackColor = inputButton.BackColor;
            Color new_BackColor = old_BackColor;
            Color new_ForeColor = old_ForeColor;
            switch (mode)
            {
                case 0:
                    {
                        new_BackColor = old_ForeColor;
                        new_ForeColor = old_BackColor;
                        inputButton.Enabled = Convert.ToBoolean(mode);
                        break;
                    }
                case 1:
                    {
                        new_BackColor = old_ForeColor;
                        new_ForeColor = old_BackColor;
                        inputButton.Enabled = Convert.ToBoolean(mode);
                        break;
                    }
                default:
                    {
                        new_ForeColor = old_ForeColor;
                        new_BackColor = old_BackColor;
                        break;
                    }
            }
            inputButton.ForeColor = new_ForeColor;
            inputButton.BackColor = new_BackColor;
        }
        public static void SetComponentLocation(Control control, Panel panel)
        {
            control.Location = new Point((panel.Width - control.Width) / 2, control.Location.Y);
        }
    }
}
