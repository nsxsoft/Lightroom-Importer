using System.Windows.Forms;
using LightroomImporter.Core.Configuration;
using LightroomImporter.Core.Device;
using NUnit.Framework;

namespace LightroomImporter.Test
{
    [TestFixture]
    public class DeviceListManagerTestSuite
    {
        [Test]
        [Category("Manual")]
        public void GetConnectedDevices_NoConnectedDevices_NoDevicesInDeviceList()
        {
            MessageBox.Show("Please ensure that no devices are connected for this manual test.");
            var deviceListManager = CreateDeviceListManager();
            deviceListManager.GetConnectedDevices();
            Assert.That(deviceListManager.Devices.Count, Is.EqualTo(0));
        }

        private DeviceListManager CreateDeviceListManager()
        {
            return new DeviceListManager(CreateConfigurationManager());
        }

        private Manager CreateConfigurationManager()
        {
            // TODO: 
            return null;
        }
    }
}
