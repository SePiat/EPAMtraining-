using SalesReportConverter.BL_;
using SalesReportConverter.BL_.Abstractions;
using SalesReportConverter.BL_.WatcherService;
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
            watcher = new Watcher();
            taskManager = new TaskManager(watcher);
            watcher.Watch();
        }

        protected override void OnStop()
        {
            Task.WaitAll();
            watcher.StopWatch();
            watcher.Dispose();
        }
    }
}
