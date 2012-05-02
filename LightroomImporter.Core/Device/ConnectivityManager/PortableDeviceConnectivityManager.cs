using System.Collections.Generic;
using LightroomImporter.Core.Device.Item;
using WindowsPortableDeviceNet;

namespace LightroomImporter.Core.Device.ConnectivityManager
{
    public class PortableDeviceConnectivityManager : IConnectivityManager
    {
        public List<IDevice> GetConnectedDevices()
        {
            List<IDevice> connectedDevices = new List<IDevice>();
            Utility utility = new Utility();
            foreach (WindowsPortableDeviceNet.Model.Device device in utility.Get())
            {
                connectedDevices.Add(new PortableDeviceItem(device));
            }

            return connectedDevices;
        }
    }
}
