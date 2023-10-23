using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

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
            return false;
        }
    }
}
