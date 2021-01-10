
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IPort
    {
        Guid PortNumber { get; set; }
        bool On { get; set; }
        bool Busy { get; set; }
        bool Rent { get; set; }
        void OnPort();
        void OffPort();
        void BusyPort();
        void RidPort();
        void PlugTerminal(IClientTerminal terminal);
        void UnPlugTerminal(IClientTerminal terminal);
        IClientTerminal Terminal { get; set; }
        event EventHandler<ICallInfo> PortOutgoingCallEvent;
        event EventHandler<ICallInfo> PortIncomingCallEvent;
        event EventHandler<IClientTerminal> PlugTerminalEvent;
        event EventHandler<IClientTerminal> UnPlugTerminalEvent;
    }
}
