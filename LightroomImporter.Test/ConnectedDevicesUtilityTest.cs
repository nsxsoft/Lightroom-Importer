using LightroomImporter.Core.Device;
using NUnit.Framework;
using System.Windows.Forms;

namespace LightroomImporter.Test
{
    [TestFixture]
    public class ConnectedDevicesUtilityTest
    {
        [Test]
        [Category("Manual")]
        public void Get_AlreadyConnectedDevicesWhenNoDevicesAreConnected_NoDevicesReturned()
        {
            ConnectedDevicesUtility utility = CreateNewConnectedDevicesUtility();
            MessageBox.Show("Please ensure that no removable disk devices are connected for this manual test.");
            var connectedDevices = utility.Get();
            Assert.AreEqual(0, connectedDevices.Count);
        }

        [Test]
        [Category("Manual")]
        public void Get_1ConnectedDevicesWhenNoDevicesAreConnected_1DeviceIsReturned()
        {
            ConnectedDevicesUtility utility = CreateNewConnectedDevicesUtility();
            MessageBox.Show("Please ensure that only ONE! removable disk device is connected for this manual test.");
            var connectedDevices = utility.Get();
            Assert.AreEqual(1, connectedDevices.Count);
        }

        private static ConnectedDevicesUtility CreateNewConnectedDevicesUtility()
        {
            return new ConnectedDevicesUtility();
        }
    }
}
