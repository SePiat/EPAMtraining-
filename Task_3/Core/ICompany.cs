using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface ICompany
    {
        string Name { get; set; }
        IStation Station { get; set; }
        ICollection<IContract> Contracts { get; set; }
        ICollection<IReport> Reports { get; set; }
        void CalculateForEstimatedPeriod();
    }
}
