﻿/*using SalesReportConverter.DAL.Context;
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

           /* ApplicationDbContext context = new ApplicationDbContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            var ustr = unitOfWork.Managers.FirstOrDefault(x => x.Name == "Vasiliy");
            unitOfWork.Managers.Delete(ustr);
            unitOfWork.Save();*/


            IWatcher watcher = new Watcher();
            watcher.MessageHandlerEvent += ConsoleMessagePrinter.WriteMessageInConsole;
            watcher.Watch();
            TaskManager taskManager = new TaskManager(watcher);

            Console.WriteLine("Console Client working");
           
            Console.ReadLine();
            Task.WaitAll();
            watcher.MessageHandlerEvent -= ConsoleMessagePrinter.WriteMessageInConsole;
            watcher.StopWatch();
            watcher.Dispose();
        }

    }
}
