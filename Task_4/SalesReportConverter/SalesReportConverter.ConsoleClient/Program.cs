using SalesReportConverter.BL;
using SalesReportConverter.BL.Abstractions;
using SalesReportConverter.BL.WatcherService;
using System;

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
            watcher.MessageHandlerEvent -= ConsoleMessagePrinter.WriteMessageInConsole;
            watcher.StopWatch();
            watcher.Dispose();
        }
    }
}
