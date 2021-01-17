﻿using System.Collections.Generic;

namespace Core
{
    public interface IClientHandler
    {
        ICollection<IContract> Contracts { get; set; }
        ICollection<IReportCalls> Reports { get; set; }
        void CalculateSubscriptionFeeMonthlyForReportPeriod();
        void GetDetailedСallReportByCallDate();
        void GetDetailedСallReportByCallCost();
        void GetDetailedСallReportByClient(IClient client);
        void GetDetailedСallReportForReportPeriod(IClient client);
    }
}
