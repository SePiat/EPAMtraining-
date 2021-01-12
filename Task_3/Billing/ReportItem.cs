using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class ReportItem : IReportItem
    {
        public ReportItem(int outgoingNumber, decimal durationOfConversations, decimal cost)
        {
            OutgoingNumber = outgoingNumber;
            DurationOfConversations = durationOfConversations;
            Cost = cost;
        }

        public int OutgoingNumber { get; set; }
        public decimal DurationOfConversations { get; set; }
        public decimal Cost { get; set; }
    }
}
