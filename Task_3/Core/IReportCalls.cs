using System.Collections.Generic;

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
        List<IClientLog> Logs { get; set; }
    }
}
