using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class Report: IReport
    {
        public Report(IClient client, DateTime reportPeriod, decimal durationOfConversations, decimal currentMoney, decimal totalSummCollect)
        {
            Client_ = client;
            ReportPeriod = reportPeriod;
            DurationOfConversations = durationOfConversations;
            CurrentMoney = currentMoney;
            TotalSummCollect = totalSummCollect;
        }

        public IClient Client_ { get; set; }
        public DateTime ReportPeriod { get; set; }
        public decimal DurationOfConversations { get; set; }
        public decimal CurrentMoney { get; set; }
        public decimal TotalSummCollect { get; set; }

       
    }
}
