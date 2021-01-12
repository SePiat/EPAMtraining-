using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface ITariffPlan
    {
         decimal SubscriptionFeeMonthly { get; set; }
         decimal TariffForSecond { get; set; }
    }
}
