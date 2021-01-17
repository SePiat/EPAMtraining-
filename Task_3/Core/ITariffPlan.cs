namespace Core
{
    public interface ITariffPlan
    {
        decimal SubscriptionFeeMonthly { get; set; }
        decimal TariffForSecond { get; set; }
    }
}
