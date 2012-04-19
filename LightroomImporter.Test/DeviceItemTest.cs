using LightroomImporter.Core.Device;
using NUnit.Framework;

namespace LightroomImporter.Test
{
    [TestFixture]
    public class DeviceItemTest
    {
        [Test]
        public void Update_UpdateDeviceWithNewDriveLetter_NewDriveLetterUpdated()
        {
            DeviceItem originalItem = NewOriginalDeviceItem();
            DeviceItem updatedItem = NewUpdatedDeviceItem();
            originalItem.Update(updatedItem);

            Assert.AreEqual(updatedItem.DriveLetter, originalItem.DriveLetter);
        }

        private DeviceItem NewOriginalDeviceItem()
        {
            return new DeviceItem
            {
                DriveLetter = "A:"
            };
        }

        private DeviceItem NewUpdatedDeviceItem()
        {
            return new DeviceItem
            {
                DriveLetter = "F:"
            };
        }
    }
}
