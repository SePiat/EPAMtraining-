using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class TariffPlan: ITariffPlan
    {
        public decimal SubscriptionFeeMonthly = 3;
        public decimal TariffForMinute = 0.005M;
    }
}
