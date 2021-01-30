using SalesReportConverter.BL.Abstractions;
using System;
using System.Configuration;
using System.IO;


namespace SalesReportConverter.BL.WatcherService
{
    public class Watcher: IWatcher
    {
        public EventHandler<FileSystemEventArgs> OnCreatedReportEvent { get; set; }
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
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            OnCreatedReportEvent?.Invoke(this, e);
        }

        public void StopWatch()
        {
            watcher.EnableRaisingEvents = false;
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
