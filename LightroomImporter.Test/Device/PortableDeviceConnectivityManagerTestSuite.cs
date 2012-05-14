using LightroomImporter.Core.Device.ConnectivityManager;
using NUnit.Framework;

namespace LightroomImporter.Test.Device
{
    [TestFixture]
    public class PortableDeviceConnectivityManagerTestSuite: BaseTest
    {
        [Test]
        public void GetConnectedDevices_NoDevicesConnected_NoDevicesRetrieved()
        {
            var portableDeviceConnectivityManager = CreatePortableDeviceConnectivityManager();
            AskManualTestToBeRunQuestion("Please ensure that no windows portable devices are connected for this manual test.");
            var connectedDeviceList = portableDeviceConnectivityManager.GetConnectedDevices();

            Assert.That(connectedDeviceList.Count, Is.EqualTo(0));
        }

        [Test]
        [Category("Manual")]
        public void Get_PortableDeviceIsConnected_PortableDeviceIsRetrieved()
        {
            var portableDeviceConnectivityManager = CreatePortableDeviceConnectivityManager();
            AskManualTestToBeRunQuestion("Please ensure that at least one windows portable device is connected for this manual test.");
            var connectedDeviceList = portableDeviceConnectivityManager.GetConnectedDevices();

            Assert.That(connectedDeviceList.Count, Is.GreaterThan(0));
        }

        private static PortableDeviceConnectivityManager CreatePortableDeviceConnectivityManager()
        {
            return new PortableDeviceConnectivityManager();
        }
    }
}
