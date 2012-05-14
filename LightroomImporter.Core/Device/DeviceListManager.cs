using System.Collections.Generic;
using LightroomImporter.Core.Configuration;
using LightroomImporter.Core.Device.ConnectivityManager;
using LightroomImporter.Core.Device.Item;

namespace LightroomImporter.Core.Device
{
    public class DeviceListManager
    {
        private const string RemovableDiskRemovedWatcherQuery = "SELECT * FROM __InstanceDeletionEvent WITHIN 10 WHERE TargetInstance ISA \"Win32_LogicalDisk\"";
        private const string RemovableDiskAddedWatcherQuery = "SELECT * FROM __InstanceCreationEvent WITHIN 10 WHERE TargetInstance ISA \"Win32_LogicalDisk\"";

        public Dictionary<string, BaseDevice> Devices { get; private set; }
        private ConfigurationManager ConfigurationManager { get; set; }
        private RemovableDiskConnectivityManager RemovableDiskConnectivityManager { get; set; }
        private PortableDeviceConnectivityManager PortableDeviceConnectivityManager { get; set; }

        public DeviceListManager(ConfigurationManager configurationManager)
        {
            Devices = new Dictionary<string, BaseDevice>();
            ConfigurationManager = configurationManager;

            RemovableDiskConnectivityManager = new RemovableDiskConnectivityManager();
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
            Devices.Add(device.Id, device);
        }

        public void AddConnectedDevices(RemovableDiskDeviceItem device)
        {
            Devices.Add(device.Serial, device);
        }

        public void CopyFiles()
        {
            foreach (var item in Devices)
            {
                BaseDevice device = item.Value;
                if (!device.IsConnected) continue;

                device.TransferData(
                    ConfigurationManager.ImageDestinationPath, 
                    ConfigurationManager.IsKeepFolderStructure);
            }
        }
    }
}
