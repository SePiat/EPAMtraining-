using AutomaticTelephoneExchange.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Core
{
    public interface IPort
    {
        public Guid PortNumber { get; set; }     
        public bool On { get; set; }
        public bool Busy { get; set; }
        public event EventHandler<int> PortEventCall;
        public void PlugTerminal(IClientTerminal terminal);
    }
}
