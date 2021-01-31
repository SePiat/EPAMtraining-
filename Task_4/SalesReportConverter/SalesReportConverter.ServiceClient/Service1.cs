using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SalesReportConverter.ServiceClient
{
    public partial class ReportConverterService : ServiceBase
    {
        public ReportConverterService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            /*IWatcher watcher = new Watcher();
            watcher.MessageHandlerEvent += ConsoleMessagePrinter.WriteMessageInConsole;
            watcher.Watch();
            TaskManager taskManager = new TaskManager(watcher);*/
        }

        protected override void OnStop()
        {
        }
    }
}
