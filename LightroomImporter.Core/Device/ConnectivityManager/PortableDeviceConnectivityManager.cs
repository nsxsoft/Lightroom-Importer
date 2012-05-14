using System.Collections.Generic;
using LightroomImporter.Core.Device.Item;
using WindowsPortableDeviceNet;

namespace LightroomImporter.Core.Device.ConnectivityManager
{
    public class PortableDeviceConnectivityManager : IConnectivityManager
    {
        public List<BaseDevice> GetConnectedDevices()
        {
            List<BaseDevice> connectedDevices = new List<BaseDevice>();
            Utility utility = new Utility();
            foreach (WindowsPortableDeviceNet.Model.Device device in utility.Get())
            {
                connectedDevices.Add(new PortableDeviceItem(device));
            }

            return connectedDevices;
        }
    }
}
