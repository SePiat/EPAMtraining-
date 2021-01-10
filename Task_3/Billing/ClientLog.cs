using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class ClientLog: IClientLog
    {
        public ClientLog(IClient client, IConnection connections, ITariffPlan tariffPlan)
        {
            Client = client;
            Connections = connections;
            TariffPlan = tariffPlan;
        }

        public IClient Client { get; set; }
        public IConnection Connections { get; set; }
        public ITariffPlan TariffPlan { get; set; }
    }
}
