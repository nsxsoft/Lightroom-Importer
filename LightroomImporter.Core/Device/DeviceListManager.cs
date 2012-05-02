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

        public Dictionary<string, IDevice> Devices { get; private set; }
        private Manager ConfigurationManager { get; set; }
        private RemovableDiskConnectivityManager RemovableDiskConnectivityManager { get; set; }

        public DeviceListManager(Manager configurationManager)
        {
            Devices = new Dictionary<string, IDevice>();
            ConfigurationManager = configurationManager;

            RemovableDiskConnectivityManager = new RemovableDiskConnectivityManager();
            

            //GetRegisteredDevices();
            //GetConnectedDevices();
        }

        //private void GetRegisteredDevices()
        //{
        //    // TODO:
        //    // Gets list of registered devices from the configuration manager.
        //}

        public void GetConnectedDevices()
        {
            // Get connected removable storage devices.

            foreach (IDevice connectedDevice in RemovableDiskConnectivityManager.GetConnectedDevices())
            {
                AddConnectedDevices(connectedDevice as RemovableDiskDeviceItem);
            }

            // Get connected windows portable devices

        }

        //public void AddConnectedDevices(WindowsPortableDeviceNet.Model.Device device)
        //{
        //    if (Devices.ContainsKey(device.DeviceId))
        //    {
        //    }
        //}

        public void AddConnectedDevices(RemovableDiskDeviceItem device)
        {
            //if (Devices.ContainsKey(device.Serial))
            //{
            //    UpdateConnectedDevice(device);
            //}

            Devices.Add(device.Serial, device);
        }

        //public void UpdateConnectedDevice(RemovableDiskDeviceItem device)
        //{
        //    //Devices[device.Serial].Update(device);

        //    // Run picture import of devices.
        //}
    }
}
