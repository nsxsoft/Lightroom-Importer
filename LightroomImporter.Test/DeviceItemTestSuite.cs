using LightroomImporter.Core.Device.Item;
using NUnit.Framework;

namespace LightroomImporter.Test
{
    [TestFixture]
    public class DeviceItemTestSuite
    {
        [Test]
        public void Update_UpdateDeviceWithNewDriveLetter_NewDriveLetterUpdated()
        {
            RemovableDiskDeviceItem originalItem = NewOriginalDeviceItem();
            RemovableDiskDeviceItem updatedItem = NewUpdatedDeviceItem();
            originalItem.Update(updatedItem);

            Assert.That(updatedItem.DriveLetter, Is.EqualTo(originalItem.DriveLetter));
        }

        private RemovableDiskDeviceItem NewOriginalDeviceItem()
        {
            return new RemovableDiskDeviceItem
            {
                DriveLetter = "A:"
            };
        }

        private RemovableDiskDeviceItem NewUpdatedDeviceItem()
        {
            return new RemovableDiskDeviceItem
            {
                DriveLetter = "F:"
            };
        }
    }
}
