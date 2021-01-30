/*using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model.Models;*/
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using SalesReportConverter.BL;
using System.IO;
using SalesReportConverter.BL.WatcherService;
using SalesReportConverter.BL.CSVHandler;
using SalesReportConverter.BL.Abstractions;
using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories;

namespace SalesReportConverter.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = ConfigurationManager.AppSettings.Get("WatcherFolderPath");

            ApplicationDbContext context = new ApplicationDbContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            var ustr=unitOfWork.Managers.FirstOrDefault(x=>x.Name== "Vasiliy");
            unitOfWork.Managers.Delete(ustr.Id);
            unitOfWork.Save();


            /*IWatcher watcher = new Watcher();
            watcher.Watch();
            TaskManager taskManager = new TaskManager(watcher);

            */

            Console.WriteLine("Hello World!");

           
            Console.ReadLine();
           /* Task.WaitAll();
            var result = taskManager.CSVModels;
            watcher.StopWatch();
            watcher.Dispose();*/
        }

    }
}
