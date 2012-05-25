
namespace LightroomImporter.Core.Device.Item
{
    public class PortableDeviceItem : IDevice
    {
        private WindowsPortableDeviceNet.Model.Device Device { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public bool IsCurrentlyConnected { get; set; }
        public bool IsTransferedData { get; set; }

        public PortableDeviceItem()
        {
            Device = null;
        }

        public PortableDeviceItem(WindowsPortableDeviceNet.Model.Device device)
        {
            Device = device;
            Id = Device.SerialNumber.Value;
            Name = Device.Name.Value;
            IsCurrentlyConnected = true;
            IsTransferedData = false;
        }

        public void TransferData(string destinationPath, bool isKeepFolderStructure)
        {
            Device.TransferData(destinationPath, isKeepFolderStructure);
            IsTransferedData = true;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Id: {1}, Device: {2}",
                                 Name,
                                 Id,
                                 Device);
        }
    }
}
