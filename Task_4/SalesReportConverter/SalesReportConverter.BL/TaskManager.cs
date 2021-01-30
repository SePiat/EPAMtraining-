using SalesReportConverter.BL.CSVHandler;
using SalesReportConverter.BL.WatcherService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SalesReportConverter.BL
{
    public class TaskManager
    {
        /*public TaskManager(Watcher watcher)
        {
            watcher.OnCreatedReportEvent += CSVTaskHandler;
        }

        private void CSVTaskHandler(object sender, FileSystemEventArgs e)
        {
            Reader reader = new Reader();
            ICollection<string> CSVReport = reader.ReadStrings(e.Name);
            foreach (var item in CSVReport)
            {
                Console.WriteLine(item);
            }

            // var SCVTasck = Task.Factory.StartNew(() => Console.WriteLine("Hello Task!"));
        }*/
    }
}
