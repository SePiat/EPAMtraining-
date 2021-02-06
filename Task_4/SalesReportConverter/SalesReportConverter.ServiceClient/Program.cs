using SalesReportConverter.BL_;
using SalesReportConverter.BL_.Abstractions;
using SalesReportConverter.BL_.WatcherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace SalesReportConverter.ServiceClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new SalesService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
