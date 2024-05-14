using Battleship.Classes;
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
        public static void SetElementLocation(int loc_x, int loc_y, Control element = null, Control parentControl = null)
        {
            element.Location = new Point(loc_x, loc_y);
        }
        public static void SetElementSize(Control control, int width, int height)
        {
            control.Size = new Size(width, height);
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
        public static void SetComponentRelativelyParent(Control control, Control parent)
        {
            control.Location = new Point((parent.Width - control.Width) / 2, control.Location.Y);
        }
        public static void SetTextBoxValues(TextBox textBox, int value, int minNum, int maxNum)
        {
            if (value == minNum)
            {
                textBox.ForeColor = Color.Red;
            }
            else if (value > minNum && value < maxNum)
            {
                textBox.ForeColor = Color.Yellow;
            }
            else if (value == maxNum)
            {
                textBox.ForeColor = Color.Lime;
            }
            else
            {
                textBox.ForeColor = DefaultBackColor;
            }
        }
        public static async void OpenNewForm(Form newForm, int duration, int step = 1)
        {
            try
            {
                newForm.Opacity = 0;
                newForm.Show();
                for (double o = 0; o < 1; o += 0.01 * step)
                {
                    await Task.Delay(duration);
                    newForm.Opacity = o;
                }
                newForm.Opacity = 1;
            }
            catch
            {
                MessageBox.Show($"Error Code: E01M8L2\r\nFailed to load {newForm.Name} interface", $"{Handlers.Manager[8]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static async void FormSwitching(Form firstForm, Form secondForm, int duration, bool dispose, int step = 1)
        {
            secondForm.Opacity = 0;
            secondForm.Show();
            try
            {
                for (double o = 0; o < 1; o += 0.01 * step)
                {
                    await Task.Delay(duration);
                    firstForm.Opacity = 1 - o;
                }
                firstForm.Hide();
            }
            catch
            {
                MessageBox.Show($"Error Code: E02M8L2\r\nFailed to load {firstForm.Name} interface", $"{Handlers.Manager[8]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                for (double o = 0; o < 1; o += 0.01 * step)
                {
                    await Task.Delay(duration);
                    secondForm.Opacity = o;
                }
                secondForm.Opacity = 1;
            }
            catch
            {
                MessageBox.Show($"Error Code: E03M8L2\r\nFailed to load {secondForm.Name} interface", $"{Handlers.Manager[8]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (dispose)
                {
                    firstForm.Dispose();
                }
            }
            catch
            {
                MessageBox.Show($"Error Code: E04M8L2\r\nFailed to delete {secondForm.Name} UI instance", $"{Handlers.Manager[8]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
