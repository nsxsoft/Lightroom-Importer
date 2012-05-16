using System.Collections.Generic;
using LightroomImporter.Core.Configuration;
using LightroomImporter.Core.Device.ConnectivityManager;
using LightroomImporter.Core.Device.Item;

namespace LightroomImporter.Core.Device
{
    public class DeviceListManager
    {
        public List<PortableDeviceItem> Devices { get; private set; }
        private ConfigurationManager ConfigurationManager { get; set; }
        private PortableDeviceConnectivityManager PortableDeviceConnectivityManager { get; set; }

        public DeviceListManager(ConfigurationManager configurationManager)
        {
            Devices = new List<PortableDeviceItem>();
            ConfigurationManager = configurationManager;

            PortableDeviceConnectivityManager = new PortableDeviceConnectivityManager();
        }

        public void GetConnectedDevices()
        {
            foreach (PortableDeviceItem connectedDevice in PortableDeviceConnectivityManager.GetConnectedDevices())
            {
                AddConnectedDevices(connectedDevice);
            }
        }

        public void AddConnectedDevices(PortableDeviceItem device)
        {
            Devices.Add(device);
        }

        public void CopyFiles()
        {
            foreach (var item in Devices)
            {
                PortableDeviceItem device = item;

                device.TransferData(
                    ConfigurationManager.ImageDestinationPath, 
                    ConfigurationManager.IsKeepFolderStructure);
            }
        }
    }
}
