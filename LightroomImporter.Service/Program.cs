using System.ServiceProcess;

namespace LightroomImporter.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new LightroomImporterService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
