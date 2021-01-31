using SalesReportConverter.BL.CSVHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesReportConverter.BL.Abstractions
{
    public interface IDataModelsManager<T> where T : class
    {
        void HandleDataModels(ICollection<T> models);
    }
}
