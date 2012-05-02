using System.Windows.Forms;
using LightroomImporter.Core.Device.ConnectivityManager;
using NUnit.Framework;

namespace LightroomImporter.Test
{
    [TestFixture]
    public class RemovableDiskConnectivityManagerTestSuite
    {
        [Test]
        [Category("Manual")]
        public void GetConnectedDevices_NoDevicesConnected_NoDevicesRetrieved()
        {
            var removableDiskConnectivityManager = CreateRemovableDiskConnectivityManager();
            MessageBox.Show("Please ensure that no removable disk devices are connected for this manual test.");
            var connectedDeviceList = removableDiskConnectivityManager.GetConnectedDevices();

            Assert.That(connectedDeviceList.Count, Is.EqualTo(0));
        }

        [Test]
        [Category("Manual")]
        public void Get_RemovableDiskIsConnected_RemovableDiskIsRetrieved()
        {
            var removableDiskConnectivityManager = CreateRemovableDiskConnectivityManager();
            MessageBox.Show("Please ensure that at least one removable disk device is connected for this manual test.");
            var connectedDeviceList = removableDiskConnectivityManager.GetConnectedDevices();
            Assert.That(connectedDeviceList.Count, Is.GreaterThan(0));
        }

        private static RemovableDiskConnectivityManager CreateRemovableDiskConnectivityManager()
        {
            return new RemovableDiskConnectivityManager();
        }
    }
}
