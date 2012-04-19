using System.Collections.Generic;
using System.Management;
using LightroomImporter.Core.Configuration;

namespace LightroomImporter.Core.Device
{
    public class DeviceListManager
    {
        //private const string RemovableDiskQuery = "SELECT Caption, VolumeName, VolumeSerialNumber from Win32_LogicalDisk where DriveType = 2";
        private const string RemovableDiskRemovedWatcherQuery = "SELECT * FROM __InstanceDeletionEvent WITHIN 10 WHERE TargetInstance ISA \"Win32_LogicalDisk\"";
        private const string RemovableDiskAddedWatcherQuery = "SELECT * FROM __InstanceCreationEvent WITHIN 10 WHERE TargetInstance ISA \"Win32_LogicalDisk\"";

        //private const string CaptionFieldName = "Caption";
        //private const string VolumeNameFieldName = "VolumeName";
        //private const string VolumeSerialNumberFieldName = "VolumeSerialNumber";


        public Dictionary<string, DeviceItem> Devices { get; private set; }
        private Manager ConfigurationManager { get; set; }

        public DeviceListManager(Manager configurationManager)
        {
            ConfigurationManager = configurationManager;
            GetRegisteredDevices();
            GetConnectedDevices();
        }

        private void GetRegisteredDevices()
        {
            // TODO:
            // Gets list of registered devices from the configuration manager.
        }

        private void GetConnectedDevices()
        {
            ConnectedDevicesUtility utility = new ConnectedDevicesUtility();
            foreach (var removableDevice in utility.Get())
            {
                AddConnectedDevices(removableDevice);
            }
        }

        public void AddConnectedDevices(DeviceItem device)
        {
            if (Devices.ContainsKey(device.Serial))
            {
                UpdateConnectedDevice(device);
            }

            Devices.Add(device.Serial, device);
        }

        public void UpdateConnectedDevice(DeviceItem device)
        {
            DeviceItem existingDevice = Devices[device.Serial];
            existingDevice.DriveLetter = device.DriveLetter;
            existingDevice.VolumeName = device.VolumeName;
            existingDevice.SetToConnected();

            // Run picture import of devices.
        }
    }
}
