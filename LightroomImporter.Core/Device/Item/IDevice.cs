
namespace LightroomImporter.Core.Device.Item
{
    public enum DeviceType
    {
        Unknown = 0,
        RemovableDisk,
        WindowsPortableDevice
    }

    public interface IDevice
    {
        string Name { get; set; }
        string Id { get; set; }
        DeviceType Type { get; set; }
        bool IsRegistered { get; set; }
        bool IsConnected { get; set; }
        void TransferData(string destinationPath, bool isKeepFolderStructure);
        void Update(IDevice item);
    }
}
