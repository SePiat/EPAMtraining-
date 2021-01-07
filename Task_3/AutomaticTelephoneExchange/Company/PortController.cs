using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Company
{
    public class PortController
    {
        public PortController()
        {
            Ports = new List<IPort>();
            ClientTerminals = new List<IClientTerminal>();
        }

        public ICollection<IPort> Ports { get; set; }
        public ICollection<IClientTerminal> ClientTerminals { get;  set; }
    }
}
