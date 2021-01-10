using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class TariffPlan: ITariffPlan
    {
        public decimal SubscriptionFeeMonthly { get; set; } = 3;
        public decimal TariffForMinute { get; set; } = 0.005M;
    }
}
