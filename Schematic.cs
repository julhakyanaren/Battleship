using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public static class Schematic
    {
        public static string Map;
        public static char[] MapSchema = new char[0];
        public static string Path = "C:\\Users\\Admin\\Desktop"; // Change
        public const string FileЕxtension = "msch";
        public static string FileName = $"Name.{FileЕxtension}"; // Change
        public static string FilePath;
        public static bool CorrectSchematic = false;

        public static Dictionary<string, string> StringMap = new Dictionary<string, string>();
        public static void MapToCharSchematic(string map)
        {
            Array.Resize(ref MapSchema, map.Length);
            MapSchema = map.ToCharArray();
        }
        public static void DictionaryWrite()
        {
            StringMap.Add("key1", "value1");
            StringMap.Add("key2", "value2");
            string filePath = $"{Path}\\{FileName}";
            SaveStringMapToFile(StringMap, filePath);
            FilePath = filePath ;
        }
        private static void SaveStringMapToFile(Dictionary<string, string> stringMap, string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, stringMap);
            }
        }
        public static void DictionaryRead()
        {
            Dictionary<string, string> stringMap = ReadStringMapFromFile(FilePath);
            foreach (var kvp in stringMap)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }
        private static Dictionary<string, string> ReadStringMapFromFile(string filePath)
        {

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return (Dictionary<string, string>)formatter.Deserialize(stream);
            }
        }
    }
}
