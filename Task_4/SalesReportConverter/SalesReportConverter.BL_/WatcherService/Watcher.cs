using SalesReportConverter.BL.Abstractions;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace SalesReportConverter.BL.WatcherService
{
    public class Watcher: IWatcher
    {
        public event EventHandler<string> ThereIsFileToHandlingEvent;        
        public event EventHandler<string> MessageHandlerEvent;
        public Watcher()
        {            
            watcher = new FileSystemWatcher();           
            watcher.Path = ConfigurationManager.AppSettings.Get("WatcherFolderPath");
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.csv";
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;           
        }       
        
        private FileSystemWatcher watcher; 
        
        
        public void Watch()
        {            
            watcher.EnableRaisingEvents = true;
            CheckFolderByExistFiles();
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            MessageHandlerEvent?.Invoke(this, $"File: {e.FullPath} {e.ChangeType}");            
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            MessageHandlerEvent?.Invoke(this, $"File: {e.FullPath} {e.ChangeType}");
            ThereIsFileToHandlingEvent?.Invoke(this, e.Name);
        }

        public void StopWatch()
        {
            watcher.EnableRaisingEvents = false;
        }

        private void CheckFolderByExistFiles()
        {
            if (new DirectoryInfo(ConfigurationManager.AppSettings.Get("WatcherFolderPath")).GetFiles("*.csv").Any(x => x.Extension == ".csv"))
            {
                FileInfo[] files = new DirectoryInfo(ConfigurationManager.AppSettings.Get("WatcherFolderPath")).GetFiles("*.csv");
                foreach (var file in files)
                {
                    ThereIsFileToHandlingEvent?.Invoke(this, file.Name);
                }
            }
        }
        public void Dispose()
        {
            if (watcher != null)
            {
                watcher.Created -= OnCreated;
                watcher.Deleted -= OnDeleted;
                watcher.Dispose();
                GC.SuppressFinalize(this);
                watcher = null;
            }
        }
    }
}
