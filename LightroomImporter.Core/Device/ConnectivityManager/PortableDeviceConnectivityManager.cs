using System;
using System.Collections.Generic;
using System.Linq;
using LightroomImporter.Core.Device.Item;
using WindowsPortableDeviceNet;

namespace LightroomImporter.Core.Device.ConnectivityManager
{
    public class PortableDeviceConnectivityManager
    {
        private static volatile PortableDeviceConnectivityManager instance = new PortableDeviceConnectivityManager();
        public List<PortableDeviceItem> CurrentConnectedDevices { get; set; }
        private Utility WpdUtility { get; set; }
        private static object syncRoot = new Object();

        private PortableDeviceConnectivityManager()
        {
            CurrentConnectedDevices = new List<PortableDeviceItem>();
            WpdUtility = new Utility();
        }

        public static PortableDeviceConnectivityManager Instance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new PortableDeviceConnectivityManager();
                }
            }

            return instance;
        }

        public void GetConnectedDevices()
        {
            AddConnectedDevices(WpdUtility.Get().Select(device => new PortableDeviceItem(device)).ToList());
        }

        private void AddConnectedDevices(IEnumerable<PortableDeviceItem> actualConnectedDevices)
        {
            // Reset the IscurrentlyConnected flag to false for the stored currently connected devices.

            CurrentConnectedDevices.ForEach(x => x.IsCurrentlyConnected = false);

            // Cycle through each of the actually connected devices and add any that are not already on the
            // stored currently connected device list.

            foreach (var actualConnectedDevice in actualConnectedDevices)
            {
                PortableDeviceItem device = CurrentConnectedDevices.Find(x => x.Id == actualConnectedDevice.Id);
                if (device != null)
                {
                    device.IsCurrentlyConnected = true;
                }
                else
                {
                    CurrentConnectedDevices.Add(actualConnectedDevice);
                }
            }

            // Remove all disconnected devices.

            CurrentConnectedDevices.RemoveAll(x => !x.IsCurrentlyConnected);
        }
    }
}
