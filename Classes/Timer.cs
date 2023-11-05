using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Classes
{
    public static class TimerData
    {
        public static int Seconds;
        public static int Minutes;
        public static int Hours;
        public static bool TimerStarted = false;
        public static bool TimerInPause = false;

        public static int MaxSeconds;
        public static int MaxMinutes;
        public static int MaxHours;

        public static void TimerTick(bool TimerOn ,TextBox secondsTextBox, TextBox minutesTextBox, TextBox hoursTextBox)
        {

        }
    }
}
