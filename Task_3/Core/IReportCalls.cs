using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IReportCalls
    {
         IClient Client_ { get; set; }
         string ReportPeriod { get; set; }
         ITariffPlan TariffPlan_ { get; set; }
         decimal DurationOfConversations { get; set; }
         decimal CurrentMoney { get; set; }
         decimal TotalSummCollect { get; set; }
         List<IReportItem> Logs { get; set; }
    }
}
