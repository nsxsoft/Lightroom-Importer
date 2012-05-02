using System.Collections.Generic;
using LightroomImporter.Core.Device.Item;

namespace LightroomImporter.Core.Device.ConnectivityManager
{
    public interface IConnectivityManager
    {
        List<IDevice> GetConnectedDevices();
    }
}
