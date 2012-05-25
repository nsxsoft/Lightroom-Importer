using System;
using LightroomImporter.Core.Configuration;
using LightroomImporter.Core.Device;
using LightroomImporter.Core.Device.ConnectivityManager;

namespace LightroomImporter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(
                "{0}: Starting Program. Please connect a camera.",
                DateTime.Now.ToString("d MMM yyyy HH:mm:ss"));

            ConfigurationManager configurationManager = new ConfigurationManager();
            PortableDeviceConnectivityManager.Instance();
            DeviceListManager deviceListManager = new DeviceListManager(configurationManager);
            deviceListManager.Start();

            System.Console.WriteLine(
                "{0}: Program Closing.",
                DateTime.Now.ToString("d MMM yyyy HH:mm:ss"));
        }
    }
}
