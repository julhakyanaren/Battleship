using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace Battleship
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

        public static async void TimerTick(bool timerSterted)
        {
            if (Options.Difficulty > 3)
            {
                if (timerSterted)
                {
                    await Task.Delay(0);
                    if (Seconds == 59)
                    {
                        Seconds = 0;
                        Minutes++;
                        if (Minutes == 60)
                        {
                            Minutes = 0;
                            Hours++;
                        }
                    }
                    else
                    {
                        Seconds++;
                    }
                }
            }
            else // Extrimal Mode
            {
                if (timerSterted)
                {
                    if (Hours + Minutes + Seconds != 0)
                    {
                        if (Seconds == 0)
                        {
                            if (Minutes > 0)
                            {
                                Minutes--;
                                Seconds = 59;
                            }
                            else if (Hours > 0)
                            {
                                Hours--;
                                Minutes = 59;
                                Seconds = 59;
                            }
                        }
                    }
                    else
                    {
                        Seconds--;
                    }
                }
            }
        }
    }
}
