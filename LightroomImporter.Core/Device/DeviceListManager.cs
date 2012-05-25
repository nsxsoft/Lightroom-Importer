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

            Console.WriteLine(
                "{0}: {1} devices detected.",
                DateTime.Now.ToString("d MMM yyyy HH:mm:ss"),
                PortableDeviceConnectivityManager.Instance().CurrentConnectedDevices.Count);

            foreach (var item in PortableDeviceConnectivityManager.Instance().CurrentConnectedDevices.Where(x => !x.IsTransferedData))
            {
                Console.WriteLine(
                    "{0}: Data is being transferred from {1}. Please wait for this to complete.",
                    DateTime.Now.ToString("d MMM yyyy HH:mm:ss"),
                    item.Name);
                item.TransferData(
                    ConfigurationManager.ImageDestinationPath,
                    ConfigurationManager.IsKeepFolderStructure);
                Console.WriteLine("{0}: Data from {1} TRANSFERRED.", DateTime.Now.ToString("d MMM yyyy HH:mm:ss"), item.Name);
            }
        }
    }
}
