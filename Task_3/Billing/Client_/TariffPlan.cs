using Core;

namespace Billing.Client_
{
    public class TariffPlan : ITariffPlan
    {
        public decimal SubscriptionFeeMonthly { get; set; } = 3;
        public decimal TariffForSecond { get; set; } = 0.005M;
    }
}
