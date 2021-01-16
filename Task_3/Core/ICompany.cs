using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface ICompany
    {
        string Name { get;}
        IStation Station { get; set; }
        ICollection<IContract> Contracts { get; set; }
        ICollection<IReportCalls> Reports { get; set; }
        void CalculateForReportPeriod();
        void GetDetailedСallReport(IClient client, string reportPeriod);
        void GetDetailedСallReportForPreviosMonth(IClient client);
        void GetDetailedСallReportByCallDate();
        void GetDetailedСallReportByCallCost();
        void GetDetailedСallReportByClient(IClient client);
    }
}
