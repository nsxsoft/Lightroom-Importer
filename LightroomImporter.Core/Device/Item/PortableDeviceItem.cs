
namespace LightroomImporter.Core.Device.Item
{
    public class PortableDeviceItem : IDevice
    {
        private WindowsPortableDeviceNet.Model.Device Device { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public DeviceType Type { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsConnected { get; set; }

        public PortableDeviceItem(WindowsPortableDeviceNet.Model.Device device)
        {
            Device = device;
            Id = Device.SerialNumber.Value;
            Name = Device.Name.Value;
            Type = DeviceType.WindowsPortableDevice;
        }

        public void TransferData(string destinationPath, bool isKeepFolderStructure)
        {
            // TODO: Testing is still to be done.

            //Device.TransferData(destinationPath, isKeepFolderStructure);
        }

        public void Update(IDevice item)
        {
            // TODO: Testing is still to be done.

            //if ((!(item is PortableDeviceItem)) || (Id != item.Id) || (Name != item.Name)) return;
            //Device.Refresh(item.Id);
        }
    }
}
