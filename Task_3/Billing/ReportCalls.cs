using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class ReportCalls: IReportCalls
    {
        public ReportCalls(IClient client, string reportPeriod, ITariffPlan tariffPlan, decimal durationOfConversations, decimal currentMoney, decimal totalSummCollect, IList<IReportItem> reportItems)
        {
            Client_ = client;
            ReportPeriod = reportPeriod;
            TariffPlan_ = tariffPlan;
            DurationOfConversations = durationOfConversations;
            CurrentMoney = currentMoney;
            TotalSummCollect = totalSummCollect;
            Logs.AddRange(reportItems);            
        }

        public IClient Client_ { get; set; }
        public string ReportPeriod { get; set; }   
        public ITariffPlan TariffPlan_ { get; set; }
        public decimal DurationOfConversations { get; set; }
        public decimal CurrentMoney { get; set; }
        public decimal TotalSummCollect { get; set; }
        public List<IReportItem> Logs { get; set; } = new List<IReportItem>();



    }
}
