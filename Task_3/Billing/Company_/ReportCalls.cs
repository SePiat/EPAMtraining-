using Core;
using System.Collections.Generic;

namespace Billing.Company_
{
    public class ReportCalls : IReportCalls
    {
        public ReportCalls(IClient client, string reportPeriod, ITariffPlan tariffPlan, decimal durationOfConversations, decimal currentMoney, decimal totalSummCollect, IList<IClientLog> clientLogs)
        {
            Client_ = client;
            ReportPeriod = reportPeriod;
            TariffPlan_ = tariffPlan;
            DurationOfConversations = durationOfConversations;
            CurrentMoney = currentMoney;
            TotalSummCollect = totalSummCollect;
            Logs.AddRange(clientLogs);
        }

        public IClient Client_ { get; set; }
        public string ReportPeriod { get; set; }
        public ITariffPlan TariffPlan_ { get; set; }
        public decimal DurationOfConversations { get; set; }
        public decimal CurrentMoney { get; set; }
        public decimal TotalSummCollect { get; set; }
        public List<IClientLog> Logs { get; set; } = new List<IClientLog>();



    }
}
