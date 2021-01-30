using System;
using System.Collections.Generic;
using System.Text;

namespace SalesReportConverter.BL.Abstractions
{
    public interface IReader
    {
        ICollection<string> ReadStrings(string nameFile);
    }
}
