using System;
using System.Linq;
using System.Management;
using LightroomImporter.Core.Configuration;
using LightroomImporter.Core.Device.ConnectivityManager;

namespace LightroomImporter.Core.Device
{
    public class DeviceListManager
    {
        private ConfigurationManager ConfigurationManager { get; set; }
        private const string DeviceChangeEventQuery = "SELECT * FROM Win32_DeviceChangeEvent";
        private ManagementEventWatcher ManagementEventWatcher { get; set; }
        private bool IsKeepRunning { get; set; }

        public DeviceListManager(ConfigurationManager configurationManager)
        {
            ConfigurationManager = configurationManager;

            ManagementEventWatcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery(DeviceChangeEventQuery);
            ManagementEventWatcher.EventArrived += Watcher_EventArrived;
            ManagementEventWatcher.Query = query;
            IsKeepRunning = false;
        }

        /// <summary>
        /// This method sets the management event watch to continually wait for the next event.
        /// </summary>
        public void Start()
        {
            IsKeepRunning = true;
            ManagementEventWatcher.Start();
            while (IsKeepRunning)
            {
                ManagementEventWatcher.WaitForNextEvent();
            }
        }

        public void Stop()
        {
            IsKeepRunning = false;
            ManagementEventWatcher.Stop();
        }

        private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            PortableDeviceConnectivityManager.Instance().GetConnectedDevices();
            foreach (var item in PortableDeviceConnectivityManager.Instance().CurrentConnectedDevices.Where(x => !x.IsTransferedData))
            {
                item.TransferData(
                    ConfigurationManager.ImageDestinationPath,
                    ConfigurationManager.IsKeepFolderStructure);
                Console.WriteLine("Debug: {0}", item);
            }
        }
    }
}
