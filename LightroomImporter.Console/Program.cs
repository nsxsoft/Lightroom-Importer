using LightroomImporter.Core.Configuration;
using LightroomImporter.Core.Device;
using LightroomImporter.Core.Device.ConnectivityManager;

namespace LightroomImporter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            PortableDeviceConnectivityManager.Instance();
            DeviceListManager deviceListManager = new DeviceListManager(configurationManager);
            deviceListManager.Start();
        }
    }
}
