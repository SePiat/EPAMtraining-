
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using SalesReportConverter.BL_;
using System.IO;
using SalesReportConverter.BL_.WatcherService;
using SalesReportConverter.BL_.CSVHandler;
using SalesReportConverter.BL_.Abstractions;
using SalesReportConverter.DAL_.Context;
using SalesReportConverter.DAL_.Repositories;
using System.Linq;

namespace SalesReportConverter.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            /* ApplicationDbContext context = new ApplicationDbContext();
             UnitOfWork unitOfWork = new UnitOfWork(context);
             var ustr = unitOfWork.Managers.FirstOrDefault(x => x.Name == "Vasiliy");
             unitOfWork.Managers.Delete(ustr);
             unitOfWork.Save();*/






            IWatcher watcher = new Watcher();
            watcher.MessageHandlerEvent += ConsoleMessagePrinter.WriteMessageInConsole;
            ITaskManager taskManager = new TaskManager(watcher);
            watcher.Watch();

            Console.WriteLine("Console Client working");

            Console.ReadLine();
            Task.WaitAll();
            watcher.MessageHandlerEvent -= ConsoleMessagePrinter.WriteMessageInConsole;
            watcher.StopWatch();
            watcher.Dispose();
        }

    }
}
