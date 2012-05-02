using System.IO;

namespace LightroomImporter.Core.Device.Item
{
    public class RemovableDiskDeviceItem : IDevice
    {
        public string DriveLetter { get; set; }
        public string Id { get; set; }
        public bool IsConnected { get; set; }
        public bool IsRegistered { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }
        public DeviceType Type { get; set; }
        public string VolumeName { get; set; }

        public RemovableDiskDeviceItem()
        {
            Type = DeviceType.RemovableDisk;
        }

        public void TransferData(string destinationPath, bool isKeepFolderStructure)
        {
            DirectoryInfo directory = new DirectoryInfo(DriveLetter);
            CopyDirectory(directory, destinationPath, isKeepFolderStructure);
        }

        public void Update(IDevice item)
        {
            if (item is RemovableDiskDeviceItem)
            {
                RemovableDiskDeviceItem updatedItem = (RemovableDiskDeviceItem) item;
                Update(updatedItem);
            }
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
