using Battleship.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GlobalExceptionForm gef = new GlobalExceptionForm();
            try
            {
                Application.Run(new MenuForm());
            }
            catch(Exception globalEx)
            {
                gef.DisplayExceptionData(globalEx);
            }
        }
    }
}
