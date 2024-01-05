using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Classes
{
    public static class LicenseData
    {
        public static int SpacesCount = 0;
        public static string EnteredKey;
        static string FinalKey;

        public static void SetFinalKey()
        {
            string final = null;
            for (int k = 0; k < EnteredKey.Length; k++)
            {
                if (EnteredKey[k] != ' ')
                {
                    final += EnteredKey[k];
                }
                else
                {
                    continue;
                }
            }
            if (final.Length == EnteredKey.Length - 3)
            {
                FinalKey = final;   
            }
        }
    }
}
