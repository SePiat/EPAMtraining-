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

namespace SalesReportConverter.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = ConfigurationManager.AppSettings.Get("WatcherFolderPath");
            
            
            
             
            Watcher watcher = new Watcher(filePath);

              watcher.AsyncWatch();

         /*   using (StreamWriter sr = new StreamWriter(ConfigurationManager.AppSettings.Get("Test")))
            {
                sr.Write("TestLine");
            } */          
           
            Console.WriteLine("Hello World!");
            Console.ReadLine();
            watcher.StopWatch();
            watcher.Dispose();
        }

    }
}
