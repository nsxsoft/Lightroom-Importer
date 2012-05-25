using System.ServiceProcess;
using LightroomImporter.Core.Configuration;
using LightroomImporter.Core.Device;
using LightroomImporter.Core.Device.ConnectivityManager;

namespace LightroomImporter.Service
{
    public partial class LightroomImporterService : ServiceBase
    {
        private ConfigurationManager ConfigurationManager { get; set; }
        private DeviceListManager DeviceListManager { get; set; }
        public LightroomImporterService()
        {
            InitializeComponent();
            ConfigurationManager = new ConfigurationManager();
            PortableDeviceConnectivityManager.Instance();
            DeviceListManager = new DeviceListManager(ConfigurationManager);
        }

        protected override void OnStart(string[] args)
        {
            DeviceListManager.Start();
        }

        protected override void OnStop()
        {
            DeviceListManager.Stop();
        }
    }
}
