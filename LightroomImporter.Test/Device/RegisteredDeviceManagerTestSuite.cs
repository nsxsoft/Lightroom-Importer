using System.Collections.Generic;
using LightroomImporter.Core.Device;
using LightroomImporter.Core.Device.Item;
using NUnit.Framework;

namespace LightroomImporter.Test.Device
{
    [TestFixture]
    public class RegisteredDeviceManagerTestSuite
    {
        [Test]
        public void Save_()
        {
            List<BaseDevice> registeredDevices = new List<BaseDevice>
                                                  {
                                                      {CreateMockRemovableDisk("id1", "device 1")},
                                                      {CreateMockRemovableDisk("id2", "device 2")}, 
                                                      {CreateMockRemovableDisk("id3", "device 3")},
                                                      {CreateMockWindowsPortableDevice("id4", "device 4")},
                                                      {CreateMockWindowsPortableDevice("id5", "device 5")},
                                                      {CreateMockRemovableDisk("id6", "device 6")}
                                                  };

            var manager = CreateRegisteredDeviceManager(string.Empty);
            string xml = manager.Save(registeredDevices);

            Assert.That(xml.Length, Is.GreaterThan(0));
        }

        [Test]
        [Category("Integration")]
        public void GetRegisteredDevices_()
        {
            var manager = CreateRegisteredDeviceManager("C:\\Users\\Gav\\Documents\\Visual Studio 2010\\Projects\\LightroomImporter\\LightroomImporter.Test\\Resources\\RegisteredDevices.xml");
            List<BaseDevice> registeredDevices = manager.GetRegisteredDevices();
            Assert.That(registeredDevices.Count, Is.GreaterThan(0));
        }

        private RegisteredDeviceManager CreateRegisteredDeviceManager(string configurationFile)
        {
            return new RegisteredDeviceManager
                       {
                           RegisteredDeviceFile = configurationFile
                       };
        }

        private RemovableDiskDeviceItem CreateMockRemovableDisk(
            string id,
            string name)
        {
            return new RemovableDiskDeviceItem()
                       {
                           Id = id,
                           Name = name,
                           Type = DeviceType.RemovableDisk
                       };
        }

        private BaseDevice CreateMockWindowsPortableDevice(
            string id,
            string name)
        {
            return new PortableDeviceItem
                       {
                           Id = id,
                           Name = name,
                           Type = DeviceType.WindowsPortableDevice
                       };
        }
    }
}
