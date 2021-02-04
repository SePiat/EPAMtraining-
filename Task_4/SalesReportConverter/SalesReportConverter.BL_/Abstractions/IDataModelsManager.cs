using System.Collections.Generic;

namespace SalesReportConverter.BL_.Abstractions
{
    public interface IDataModelsManager<T> where T : class
    {
        void HandleDataModels(ICollection<T> models);
    }
}
