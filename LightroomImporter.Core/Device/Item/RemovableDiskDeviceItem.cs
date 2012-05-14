using System;
using System.IO;

namespace LightroomImporter.Core.Device.Item
{
    public class RemovableDiskDeviceItem : BaseDevice
    {
        public string DriveLetter { get; set; }
        public string Serial { get; set; }
        public string VolumeName { get; set; }

        public RemovableDiskDeviceItem()
        {
            Type = DeviceType.RemovableDisk;
        }

        public override void TransferData(string destinationPath, bool isKeepFolderStructure)
        {
            if (!File.Exists(destinationPath)) throw new InvalidOperationException("");
            DirectoryInfo directory = new DirectoryInfo(DriveLetter);
            CopyDirectory(directory, destinationPath, isKeepFolderStructure);
        }

        public override void Update(BaseDevice item)
        {
            if (!(item is RemovableDiskDeviceItem)) return;
            RemovableDiskDeviceItem updatedItem = (RemovableDiskDeviceItem) item;
            Update(updatedItem);
        }

        private void CopyDirectory(
            DirectoryInfo directory, 
            string destinationPath, 
            bool isKeepFolderStructure)
        {
            if (isKeepFolderStructure && !Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {
                CopyDirectory(subDirectory, Path.Combine(destinationPath, subDirectory.Name), isKeepFolderStructure);
            }
            
            foreach (FileInfo file in directory.GetFiles())
            {
                file.CopyTo(Path.Combine(destinationPath, file.Name));
            }
        }

        public void Connect()
        {
            IsConnected = true;
        }

        public void Disconnect()
        {
            IsConnected = false;
        }

        private void Update(RemovableDiskDeviceItem item)
        {
            DriveLetter = item.DriveLetter;
            VolumeName = item.VolumeName;
            Connect();
        }
    }
}
