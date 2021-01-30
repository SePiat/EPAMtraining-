using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalesReportConverter.BL.Abstractions
{
    public interface IWatcher
    {
        EventHandler<FileSystemEventArgs> OnCreatedReportEvent { get; set; }
        void Watch();
        void StopWatch();
        void Dispose();
    }
}
