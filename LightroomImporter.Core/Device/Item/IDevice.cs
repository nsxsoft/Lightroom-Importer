
namespace LightroomImporter.Core.Device.Item
{
    public interface IDevice
    {
        string Name { get; set; }
        string Id { get; set; }
        void TransferData(string destinationPath, bool isKeepFolderStructure);
    }
}
