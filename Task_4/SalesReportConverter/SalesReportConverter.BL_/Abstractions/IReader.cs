using System.Collections.Generic;

namespace SalesReportConverter.BL_.Abstractions
{
    public interface IReader
    {
        ICollection<string> ReadStrings(string nameFile);
    }
}
