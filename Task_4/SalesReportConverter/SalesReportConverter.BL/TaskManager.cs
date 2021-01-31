using SalesReportConverter.BL.Abstractions;
using SalesReportConverter.BL.CSVHandler;
using SalesReportConverter.BL.WatcherService;
using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories;
using SalesReportConverter.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SalesReportConverter.BL
{
    public class TaskManager: ITaskManager
    {        
        private IWatcher _watcher;
        public TaskManager(IWatcher watcher)
        {            
            _watcher = watcher;
            watcher.OnCreatedReportEvent += CreateTask;
        }    

        public void CreateTask(object sender, FileSystemEventArgs e)
        {
            var task1 =Task.Factory.StartNew(() =>
            {
                ParserCSV parserCSV = new ParserCSV();
                ICollection<CSVModel> modelsCSV = parserCSV.GetModels(e);
                IDataModelsManager<CSVModel> dataModelsManager = new DataModelsManagerCSV();
                dataModelsManager.HandleDataModels(modelsCSV);                
            });            
        }

        public void Dispose()
        {
            if (_watcher != null)
            {
                _watcher.OnCreatedReportEvent += CreateTask;
                GC.SuppressFinalize(this);
                _watcher = null;
            }
        }
    }
}
