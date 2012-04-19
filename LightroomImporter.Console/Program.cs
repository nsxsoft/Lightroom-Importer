using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LightroomImporter.Core;

namespace LightroomImporter.Console
{
    class Program
    {
        //static DeviceListManager Detector = new DeviceListManager();
        static void Main(string[] args)
        {
            //AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            //Detector.TrackDevices();

            //while (true)
            //{
            //};
        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            //Detector.Stop();
        }

    }
}
