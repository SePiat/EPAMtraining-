using System.Collections.Generic;

namespace SalesReportConverter.BL.Abstractions
{
    public interface IParser<T> where T : class
    {
        ICollection<T> GetModels(string fileName);
    }
}
