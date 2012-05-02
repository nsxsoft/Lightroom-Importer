
using LightroomImporter.Core.Device;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightroomImporter.Test
{
    [TestClass]
    public class ConnectedCamerasUtilityTest
    {
        [TestMethod]
        public void Get_1ConnectedCameraDevicesWhenNoDevicesAreConnected_1CameraDeviceIsReturned()
        {
            ConnectedCamerasUtility utility = CreateNewConnectedDevicesUtility();
            Assert.AreEqual(1, utility.Count());
        }

        private static ConnectedCamerasUtility CreateNewConnectedDevicesUtility()
        {
            return new ConnectedCamerasUtility();
        }
    }
}
