using System;
using System.Collections.Generic;
using System.Management;
using LightroomImporter.Core.Device.Item;

namespace LightroomImporter.Core.Device.ConnectivityManager
{
    public class RemovableDiskConnectivityManager : IConnectivityManager
    {
        private const string RemovableDiskQuery = "SELECT Caption, VolumeName, VolumeSerialNumber, FileSystem FROM Win32_LogicalDisk WHERE DriveType = 2 OR DriveType = 3";
        private const string CaptionFieldName = "Caption";
        private const string VolumeNameFieldName = "VolumeName";
        private const string VolumeSerialNumberFieldName = "VolumeSerialNumber";
        private const string FileSystemFieldName = "FileSystem";

        public List<BaseDevice> GetConnectedDevices()
        {
            List<BaseDevice> connectedDevices = new List<BaseDevice>();
            ObjectQuery query = new ObjectQuery(RemovableDiskQuery);

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                ManagementObjectCollection removables = searcher.Get();
                foreach (var removable in removables)
                {
                    if (String.IsNullOrEmpty(removable[FileSystemFieldName] as string)) continue;
                    if (removable[CaptionFieldName].ToString().ToUpper() == "C:") continue;
                    if (String.IsNullOrEmpty(removable[VolumeNameFieldName] as string)) continue;
                    //if (String.IsNullOrEmpty(removable[VolumeSerialNumberFieldName] as string)) continue;

                    connectedDevices.Add(new RemovableDiskDeviceItem()
                    {
                        DriveLetter = removable[CaptionFieldName] as string,
                        Serial = removable[VolumeSerialNumberFieldName] as string,
                        VolumeName = removable[VolumeNameFieldName] as string,
                    });
                }
            }

            return connectedDevices;
        }
    }
}
