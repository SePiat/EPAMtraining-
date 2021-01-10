using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IClientLog
    {
        IClient Client { get; set; }
        IConnection Connections { get; set; }
        ITariffPlan TariffPlan { get; set; }
    }
}
