using System;
using System.Collections.Generic;
//using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SalesReportConverter.BL
{
    public class Watcher
    {
        public Watcher(string path)
        {
            Path = path;
        }
        FileSystemWatcher watcher = new FileSystemWatcher();
        private bool IsWatch = true;
        private string Path { get; set; }

        public async Task AsyncWatch()
        {
            await Task.Run(() => Watch());
        }
        public void Watch()
        {            
            watcher.Path = Path;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.txt";
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.EnableRaisingEvents = true;
            while (IsWatch) ;
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
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
