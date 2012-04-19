namespace LightroomImporter.Core.Device
{
    public class DeviceItem
    {
        public string VolumeName { get; set; }
        public string Serial { get; set; }
        public string DriveLetter { get; set; }

        public bool IsConnected { get; private set; }

        public void SetToConnected()
        {
            IsConnected = true;
        }

        public void SetToDisconnected()
        {
            IsConnected = false;
        }

        public void Update(DeviceItem item)
        {
            DriveLetter = item.DriveLetter;
            VolumeName = item.VolumeName;
            SetToConnected();
        }
    }
}
