using SalesReportConverter.BL.Abstractions;
using SalesReportConverter.BL.CSVHandler;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesReportConverter.BL
{
    public class TaskManager : ITaskManager
    {
        private IWatcher _watcher;
        public TaskManager(IWatcher watcher)
        {
            _watcher = watcher;
            watcher.ThereIsFileToHandlingEvent += CreateTask;
        }

        public void CreateTask(object sender, string fileName)
        {
            var task1 = Task.Factory.StartNew(() =>
             {
                 ParserCSV parserCSV = new ParserCSV();
                 ICollection<CSVModel> modelsCSV = parserCSV.GetModels(fileName);
                 IDataModelsManager<CSVModel> dataModelsManager = new DataModelsManagerCSV();
                 dataModelsManager.HandleDataModels(modelsCSV);                
             });
        }

        public void Dispose()
        {
            if (_watcher != null)
            {
                _watcher.ThereIsFileToHandlingEvent -= CreateTask;
                GC.SuppressFinalize(this);//!!!!!!!!!!!!!!!!
                _watcher = null;
            }
        }
    }
}
