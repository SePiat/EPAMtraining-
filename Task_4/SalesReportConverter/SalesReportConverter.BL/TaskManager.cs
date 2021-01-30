using SalesReportConverter.BL.Abstractions;
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
        private IWatcher _watcher;
        public TaskManager(IWatcher watcher)
        {
            _watcher = watcher;
            watcher.OnCreatedReportEvent += CSVTaskHandler;
        }
       public List<CSVModel> CSVModels { get; set; } = new List<CSVModel>();

        private void CSVTaskHandler(object sender, FileSystemEventArgs e)
        {
            var task1 =Task.Factory.StartNew(() =>
            {
                ParserCSV parserCSV = new ParserCSV();
                ICollection<CSVModel> models = parserCSV.GetCSVModels(e);
                lock (this)
                {
                    CSVModels.AddRange(models);
                }
               
                Console.WriteLine(CSVModels.Count);
            });            
        }

        public void Dispose()
        {
            if (_watcher != null)
            {
                _watcher.OnCreatedReportEvent += CSVTaskHandler;
                GC.SuppressFinalize(this);
                _watcher = null;
            }
        }
    }
}
