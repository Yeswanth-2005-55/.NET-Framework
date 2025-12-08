// See https://aka.ms/new-console-template for more information
using System;

namespace DeviceMonitor
{
    class TemperatureModule
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("kumaran ...");
            VibrationModule.RunVibrationCheck();
        }
    }

    class VibrationModule
    {
        public static void RunVibrationCheck()
        {
            Console.WriteLine("mathi .");
        }
    }
}

