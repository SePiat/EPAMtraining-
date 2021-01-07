using AutomaticTelephoneExchange.Client;
using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Company
{
    public class Port : IPort
    {
        
        public static event EventHandler<ICallInfo> PortEventOutgoingCall;
        public event EventHandler<ICallInfo> PortEventIncomingCall;
        public Guid PortNumber { get;  set; }
        public bool On { get; set; } = true;
        public bool Busy { get; set; } = false;
        public IClientTerminal Terminal { get; set; }
        public Port()
        {
            PortNumber = Guid.NewGuid();
            PortController.IncomingCall += IncomingCall;
        }

        private void IncomingCall(object sender, ICallInfo callInfo)
        {
            if (sender is Port port&&port.PortNumber == PortNumber)
            {
                PortEventIncomingCall?.Invoke(sender, callInfo);
            }
        }

       
        private void OutgoingCallHandler(object sender, ICallInfo callInfo)
        {            
            if (On)
            {
                PortEventOutgoingCall?.Invoke(sender, callInfo);
            };
        }
        public void PlugTerminal(IClientTerminal terminal)
        {
            Terminal = terminal;
            terminal.EventCall += OutgoingCallHandler;
            PortEventIncomingCall += terminal.IncomingCall;
        }

       

        public void UnPlugTerminal(IClientTerminal terminal)
        {            
            terminal.EventCall -= OutgoingCallHandler;
            PortEventIncomingCall -= terminal.IncomingCall;
            Terminal = null;
        }



    }
}
