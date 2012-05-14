﻿using LightroomImporter.Core.Configuration;
using LightroomImporter.Core.Device;
using NUnit.Framework;

namespace LightroomImporter.Test.Device
{
    [TestFixture]
    public class DeviceListManagerTestSuite : BaseTest
    {
        [Test]
        [Category("Manual")]
        public void GetConnectedDevices_NoConnectedDevices_NoDevicesInDeviceList()
        {
            AskManualTestToBeRunQuestion("Please ensure that no devices are connected for this manual test.");
            var deviceListManager = CreateDeviceListManager();
            deviceListManager.GetConnectedDevices();
            Assert.That(deviceListManager.Devices.Count, Is.EqualTo(0));
        }

        [Test]
        [Category("Manual")]
        public void CopyFiles_()
        {
            AskManualTestToBeRunQuestion("Please ensure that a device is connected for this manual test.");
            var configurationManager = CreateConfigurationManager();
            configurationManager.ImageDestinationPath = "C:\temp";
            var deviceListManager = CreateDeviceListManager(configurationManager);
            deviceListManager.GetConnectedDevices();
            
            deviceListManager.CopyFiles();
        }

        private DeviceListManager CreateDeviceListManager()
        {
            return CreateDeviceListManager(CreateConfigurationManager());
        }

        private DeviceListManager CreateDeviceListManager(ConfigurationManager configurationManager)
        {
            return new DeviceListManager(configurationManager);
        }

        private ConfigurationManager CreateConfigurationManager()
        {
            var registeredDeviceManager = new RegisteredDeviceManager();
            return new ConfigurationManager(registeredDeviceManager);
        }
    }
}
