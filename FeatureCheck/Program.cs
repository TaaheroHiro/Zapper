using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Settings");
            int settings = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter setting number to check");
            int setting = Convert.ToInt32(Console.ReadLine());
            bool result = IsFeature(settings,setting);
            Console.WriteLine($"Setting enabled is {result}");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        public static bool IsFeature(int settings, int setting) { 
           
            if (Math.Abs(settings).ToString().Length == 8 && (setting >= 1 || setting <= 8))
            {
                return (settings & (1 << (setting - 1))) != 0;
            }
            else {
                throw new ArgumentOutOfRangeException("Setting must be between 1 and 8 (inclusive) and settings needs to have 8 digits");
            }
            
        }
    }
}
