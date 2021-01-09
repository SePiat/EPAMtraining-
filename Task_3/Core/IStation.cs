using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Core
{
    public interface IStation
    {
        ICollection<IClientTerminal> ClientTerminals { get; set; }
        public IPort GetFreePort();
        IClientTerminal GetClientTerminal(int ClientNumberOfTelephone);

    }
}
