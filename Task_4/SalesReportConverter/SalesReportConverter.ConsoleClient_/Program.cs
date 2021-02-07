using SalesReportConverter.BL_;
using SalesReportConverter.BL_.Abstractions;
using SalesReportConverter.BL_.WatcherService;
using System;
using System.Threading.Tasks;

namespace SalesReportConverter.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
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
