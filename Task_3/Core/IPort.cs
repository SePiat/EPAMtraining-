
using System;

namespace Core
{
    public interface IPort
    {
        Guid PortNumber { get;}
        bool On { get; set; }
        bool Busy { get; set; }
        bool Rent { get; set; }
        void OnPort();
        void OffPort();
        void BusyPort();
        void RidPort();
        void PlugTerminal(IClientTerminal terminal);
        void UnPlugTerminal(IClientTerminal terminal);
        void ClearEvents();
        IClientTerminal Terminal { get; set; }
        event EventHandler<ICallInfo> PortOutgoingCallEvent;
        event EventHandler<ICallInfo> PortIncomingCallEvent;
        event EventHandler<IClientTerminal> PlugTerminalEvent;
        event EventHandler<IClientTerminal> UnPlugTerminalEvent;
    }
}
