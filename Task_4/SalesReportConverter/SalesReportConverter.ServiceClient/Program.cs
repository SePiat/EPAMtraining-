using System.ServiceProcess;


namespace SalesReportConverter.ServiceClient
{
    static class Program
    {
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
