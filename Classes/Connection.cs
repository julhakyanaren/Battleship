using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Battleship.Classes
{
    public static class Connection
    {
        public static bool IsInternetAvailable()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    using (var client = new System.Net.WebClient())
                    using (client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show($"Error Code: E35M6L1\r\nNetwork connection error", $"{Handlers.Manager[6]}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
