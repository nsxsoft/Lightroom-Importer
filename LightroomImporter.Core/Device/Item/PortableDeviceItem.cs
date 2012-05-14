
namespace LightroomImporter.Core.Device.Item
{
    public class PortableDeviceItem : BaseDevice
    {
        private WindowsPortableDeviceNet.Model.Device Device { get; set; }

        public PortableDeviceItem()
        {
            Device = null;
            Type = DeviceType.Unknown;
        }

        public PortableDeviceItem(WindowsPortableDeviceNet.Model.Device device)
        {
            Device = device;
            Id = Device.SerialNumber.Value;
            Name = Device.Name.Value;
            Type = DeviceType.WindowsPortableDevice;
        }

        public override void TransferData(string destinationPath, bool isKeepFolderStructure)
        {
            Device.TransferData(destinationPath, isKeepFolderStructure);
        }

        public override void Update(BaseDevice item)
        {
            // TODO: Testing is still to be done.

            //if ((!(item is PortableBaseDeviceItem)) || (Id != item.Id) || (Name != item.Name)) return;
            //Device.Refresh(item.Id);
        }
    }
}
