using Core;

namespace Billing.Company_
{
    public class ClientLog : IClientLog
    {
        public ClientLog(IClient client, IConnection connections)
        {
            Client = client;
            Connections = connections;
            DurationOfConversations = connections.DurationConnection.Seconds;
            Cost = DurationOfConversations * client.TariffPlan.TariffForSecond;
            client.Money -= Cost;
        }
        public IClient Client { get; }
        public IConnection Connections { get; }
        public decimal DurationOfConversations { get; }
        public decimal Cost { get; }
    }
}
