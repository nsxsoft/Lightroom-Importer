using System;
using System.Collections.Generic;
using System.IO;
using CommonMonkeys.Xml;
using LightroomImporter.Core.Device.Item;

namespace LightroomImporter.Core.Device
{
    public class RegisteredDeviceManager
    {
        public string RegisteredDeviceFile { get; set; }

        public RegisteredDeviceManager()
        {
            RegisteredDeviceFile = String.Empty;
        }

        public List<BaseDevice> GetRegisteredDevices()
        {
            if (!File.Exists(RegisteredDeviceFile)) return new List<BaseDevice>();

            StreamReader streamReader = new StreamReader(RegisteredDeviceFile);
            string xml = streamReader.ReadToEnd();
            streamReader.Close();

            return XmlUtility.Deserialise<List<BaseDevice>>(xml);
        }

        public string Save(List<BaseDevice> registeredDevices)
        {
            return XmlUtility.Serialise(registeredDevices);
        }
    }
}
