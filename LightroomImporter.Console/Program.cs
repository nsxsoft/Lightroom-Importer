using LightroomImporter.Core.Configuration;
using LightroomImporter.Core.Device;

namespace LightroomImporter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check what is connected and copy it to the folder.

            RegisteredDeviceManager registeredDeviceManager = new RegisteredDeviceManager();
            ConfigurationManager configurationManager = new ConfigurationManager(registeredDeviceManager);
            DeviceListManager deviceListManager = new DeviceListManager(configurationManager);

            deviceListManager.GetConnectedDevices();
            deviceListManager.CopyFiles();
        }
    }
}
