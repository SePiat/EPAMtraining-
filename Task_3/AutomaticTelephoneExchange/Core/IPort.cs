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
        public void OnPort();
        public void OfPort();
        public void BusyPort();
        public void RidPort();
        public void PlugTerminal(IClientTerminal terminal);
        public IClientTerminal Terminal { get; set; }
        public event EventHandler<ICallInfo> PortOutgoingCallEvent;
        public event EventHandler<ICallInfo> PortIncomingCallEvent;
        public event EventHandler<IClientTerminal> PlugTerminalEvent;
        public event EventHandler<IClientTerminal> UnPlugTerminalEvent;
    }
}
