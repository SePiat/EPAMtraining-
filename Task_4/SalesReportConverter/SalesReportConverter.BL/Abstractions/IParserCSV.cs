using SalesReportConverter.BL.CSVHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalesReportConverter.BL.Abstractions
{
    public interface IParserCSV
    {
        ICollection<CSVModel> GetCSVModels(FileSystemEventArgs e);        
    }
}
