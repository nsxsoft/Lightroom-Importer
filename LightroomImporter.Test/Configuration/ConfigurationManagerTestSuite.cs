using LightroomImporter.Core.Configuration;
using LightroomImporter.Core.Device;
using LightroomImporter.Core.Device.Item;
using Moq;
using NUnit.Framework;

namespace LightroomImporter.Test.Configuration
{
    [TestFixture]
    public class ConfigurationManagerTestSuite
    {
        [Test]
        public void RetrieveStoredRegisteredDevices_NoDevicesAreRegistered_NoRegisteredDeviceInformationRetrieved()
        {
            var configurationManager = CreateConfigurationManager();
            configurationManager.RetrieveStoredRegisteredDevices();
            Assert.That(configurationManager.RegisteredDevices.Count, Is.EqualTo(0));
        }

        [Test]
        [Category("Integration")]
        public void RetrieveStoredRegisteredDevices_SomeDevicesAreRegistered_SomeRegisteredDeviceInformationRetrieved()
        {
            var configurationManager = CreateConfigurationManagerWithValidRegisteredDeviceFile();
            configurationManager.RetrieveStoredRegisteredDevices();
            Assert.That(configurationManager.RegisteredDevices.Count, Is.GreaterThan(0));
        }

        [Test]
        public void UpdateRegisteredDevicesList_NewDeviceRegistered_RegisteredDeviceCountIncremented()
        {
            var configurationManager = CreateConfigurationManager();
            configurationManager.RetrieveStoredRegisteredDevices();
            var initialCount = configurationManager.RegisteredDevices.Count;
            var newDevice = CreateNewDevice();
            configurationManager.UpdateRegisteredDevices(newDevice);
            
            Assert.That(configurationManager.RegisteredDevices.Count, Is.EqualTo(initialCount + 1));
        }

        [Test]
        public void UpdateRegisteredDevicesList_ExistingDeviceUpdated_()
        {
            Assert.Fail("Not Implemented");
        }

        private static BaseDevice CreateNewDevice()
        {
            var mock = new Mock<BaseDevice>();
            mock.Setup(device => device.Id).Returns("id");

            return mock.Object;
        }

        private static ConfigurationManager CreateConfigurationManager()
        {
            return new ConfigurationManager(CreateMockRegisteredDeviceManager());
        }

        private static ConfigurationManager CreateConfigurationManagerWithValidRegisteredDeviceFile()
        {
            var registeredDeviceManager = CreateRegisteredDeviceManager();
            return new ConfigurationManager(registeredDeviceManager);
        }

        private static RegisteredDeviceManager CreateRegisteredDeviceManager()
        {
            return new RegisteredDeviceManager
                       {
                           RegisteredDeviceFile = "C:\\Users\\Gav\\Documents\\Visual Studio 2010\\Projects\\LightroomImporter\\LightroomImporter.Test\\Resources\\RegisteredDevices.xml"
                       };
        }
        

        private static RegisteredDeviceManager CreateMockRegisteredDeviceManager()
        {
            Mock registeredDeviceManager = new Mock<RegisteredDeviceManager>();
            return (RegisteredDeviceManager)registeredDeviceManager.Object;
        }
    }
}
