using System.Collections.Generic;

namespace SalesReportConverter.BL.Abstractions
{
    public interface IReader
    {
        ICollection<string> ReadStrings(string nameFile);
    }
}
