using System;
using System.Collections.Generic;
using System.Management;

namespace LightroomImporter.Core.Device
{
    public class ConnectedDevicesUtility
    {
        private const string RemovableDiskQuery = "SELECT Caption, VolumeName, VolumeSerialNumber, FileSystem FROM Win32_LogicalDisk where DriveType = 2";
        private const string CaptionFieldName = "Caption";
        private const string VolumeNameFieldName = "VolumeName";
        private const string VolumeSerialNumberFieldName = "VolumeSerialNumber";
        private const string FileSystemFieldName = "FileSystem";

        /// <summary>
        /// Get the connected devices.
        /// </summary>
        public List<DeviceItem> Get()
        {
            List<DeviceItem> connectedDevices = new List<DeviceItem>();
            ObjectQuery query = new ObjectQuery(RemovableDiskQuery);

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                ManagementObjectCollection removables = searcher.Get();
                foreach (var removable in removables)
                {
                    if (String.IsNullOrEmpty(removable[FileSystemFieldName] as string)) continue;

                    connectedDevices.Add(new DeviceItem()
                    {
                        DriveLetter = removable[CaptionFieldName] as string,
                        Serial = removable[VolumeSerialNumberFieldName] as string,
                        VolumeName = removable[VolumeNameFieldName] as string,
                        //StopsShutdown = StopList.Contains(removable[VolumeSerialNumberFieldName] as string)
                    });
                }
            }

            return connectedDevices;
        }
    }
}
