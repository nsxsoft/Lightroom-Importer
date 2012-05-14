using System.Collections.Generic;
using LightroomImporter.Core.Device;
using LightroomImporter.Core.Device.Item;

namespace LightroomImporter.Core.Configuration
{
    public class ConfigurationManager
    {
        public static readonly string ImageDestinationPathKeyName = "ImageDestinationPath";
        public static readonly string IsKeepFolderStructureKeyName = "IsKeepFolderStructure";

        public Dictionary<string, BaseDevice> RegisteredDevices { get; set; }
        private RegisteredDeviceManager RegisteredDeviceManager { get; set; }

        public string ImageDestinationPath { get; set; }
        public bool IsKeepFolderStructure { get; set; }

        public ConfigurationManager(RegisteredDeviceManager registeredDeviceManager)
        {
            RegisteredDeviceManager = registeredDeviceManager;
            RegisteredDevices = new Dictionary<string, BaseDevice>();

            ImageDestinationPath = System.Configuration.ConfigurationManager.AppSettings[ImageDestinationPathKeyName];
            IsKeepFolderStructure = SetIsKeepFolderStructure();
        }

        private bool SetIsKeepFolderStructure()
        {
            bool result;
            bool.TryParse(System.Configuration.ConfigurationManager.AppSettings[IsKeepFolderStructureKeyName], out result);
            return result;
        }

        public void RetrieveStoredRegisteredDevices()
        {
            foreach (BaseDevice item in RegisteredDeviceManager.GetRegisteredDevices())
            {
                RegisteredDevices.Add(item.Id, item);
            }
        }

        /// <summary>
        /// This method updates existing registered devices.
        /// If the device does not exist adds it to the registered list.
        /// </summary>
        /// <param name="device"></param>
        public void UpdateRegisteredDevices(BaseDevice device)
        {
            if (RegisteredDevices.ContainsKey(device.Id))
            {
                UpdateRegisteredDevice(device);
            }
            RegisteredDevices.Add(device.Id, device);
        }

        private void UpdateRegisteredDevice(BaseDevice newBaseDevice)
        {
            throw new System.NotImplementedException();
        }
    }
}
