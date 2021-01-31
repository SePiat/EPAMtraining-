using SalesReportConverter.BL.CSVHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalesReportConverter.BL.Abstractions
{
    public interface IParser<T> where T : class
    {
        ICollection<T> GetModels(FileSystemEventArgs e);        
    }
}
