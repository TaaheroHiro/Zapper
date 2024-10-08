using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;

namespace FeatureCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string filePath = "settings.dat";

     
            Console.WriteLine("Enter Settings");
            string settings = Console.ReadLine();
            if (CheckSettings(settings))
            {
                WriteSettingsToFile(filePath, settings);
                string readSettings = ReadSettingsFromFile(filePath);
                Console.WriteLine("Enter setting number to check");
                int setting = Convert.ToInt32(Console.ReadLine());

                bool result = IsFeature(readSettings, setting);
                Console.WriteLine($"Setting enabled is {result}");
            }
            else {
                Console.WriteLine("Only 0 or 1 are accepted and it has to be 8 digits");
            }
            
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void WriteSettingsToFile(string filePath, string settings)
        {
            // Convert the string settings to a byte array then write to file path (global variable)
            byte[] data = new byte[1];
            data[0] = Convert.ToByte(settings, 2); 

            // Write the byte array to the file
            File.WriteAllBytes(filePath, data);
        }

        static string ReadSettingsFromFile(string filePath)
        {
            // Read the byte array from the file then convert to string
            byte[] data = File.ReadAllBytes(filePath);
            return Convert.ToString(data[0], 2).PadLeft(8, '0'); 
        }

        static bool CheckSettings(string settings)
        {
            // Firstt check length of string then check if all characters in the string are either '0' or '1'
            if (settings.Length == 8)
            {
                foreach (char c in settings)
                {
                    if (c != '0' && c != '1')
                    {
                        return false; // Invalid character found
                    }
                }
            }
            else return false;
           
            
            return true; // All characters are valid and the string length is 8.
        }


        public static bool IsFeature(string  settings, int setting) { 
           
            if ((setting >= 1 && setting <= 8))
            {
                return settings[setting-1] == '1';
            }
            else {
                throw new ArgumentOutOfRangeException("Setting must be between 1 and 8 (inclusive) and settings needs to have 8 digits");
            }
            
        }
    }
}
