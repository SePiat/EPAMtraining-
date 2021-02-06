using SalesReportConverter.BL_;
using SalesReportConverter.BL_.Abstractions;
using SalesReportConverter.BL_.WatcherService;
using System;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace SalesReportConverter.ServiceClient
{
    public partial class SalesService : ServiceBase
    {
        IWatcher watcher;
        ITaskManager taskManager;
        public SalesService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                watcher = new Watcher();
                taskManager = new TaskManager(watcher);
                watcher.Watch();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка в методе OnStart, {ex}");
            }
            
        }

        protected override void OnStop()
        {
            try
            {                
                watcher.StopWatch();
                watcher.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка в методе OnStop, {ex}");
            }

        }
    }
}
