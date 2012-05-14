using System.Xml.Serialization;

namespace LightroomImporter.Core.Device.Item
{
    public enum DeviceType
    {
        Unknown = 0,
        RemovableDisk,
        WindowsPortableDevice
    }

    [XmlRoot("Device")]
    [XmlInclude(typeof(RemovableDiskDeviceItem))]
    [XmlInclude(typeof(PortableDeviceItem))]
    public abstract class BaseDevice
    {
        public string Name { get; set; }
        public virtual string Id { get; set; }
        public DeviceType Type { get; set; }

        [XmlIgnore]
        public bool IsRegistered { get; set; }

        [XmlIgnore]
        public bool IsConnected { get; set; }

        public abstract void TransferData(string destinationPath, bool isKeepFolderStructure);
        public abstract void Update(BaseDevice item);
    }
}
