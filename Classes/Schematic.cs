using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public static class Schematic
    {
        public static string Map;
        public static char[] MapSchema = new char[0];
        public static string Path = "C:\\Users\\Admin\\Desktop\\Schematics"; // Change
        public const string FileЕxtension = "msch";
        public static string FileName = $"Name.{FileЕxtension}"; // Change
        public static string FilePath;
        public static bool CorrectSchematic = false;
    }
}
