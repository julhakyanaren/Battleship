using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public class Information
    {
        public static DialogResult GameOverMessages(bool playerLose)
        {
            if (playerLose)
            {
                return MessageBox.Show("All your ships are destroyed, and the enemy has surviving ships.\r\nGame over. You lose!", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return MessageBox.Show("All your ships are destroyed, and the enemy has surviving ships.\r\nGame over. You Win!", "Game Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
