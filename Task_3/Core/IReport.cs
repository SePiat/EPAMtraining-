using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IReport
    {
         IClient Client_ { get; set; }
         DateTime ReportPeriod { get; set; }
         decimal DurationOfConversations { get; set; }
         decimal CurrentMoney { get; set; }
         decimal TotalSummCollect { get; set; }
    }
}
