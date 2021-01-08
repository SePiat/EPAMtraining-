using AutomaticTelephoneExchange.Client;
using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Company.CallController_
{
    public class Port : IPort
    {        
        public event EventHandler<ICallInfo> PortEventOutgoingCall;
        public event EventHandler<ICallInfo> PortEventIncomingCall;
        public event EventHandler<ICallInfo> DropIncomingCall;
        public Guid PortNumber { get;  set; }
        public bool On { get; set; } = true;
        public bool Busy { get; set; } = false;
        public IClientTerminal Terminal { get; set; }
        public Port(IPortController portController)
        {
            PortNumber = Guid.NewGuid();
            portController.IncomingCall += IncomingCall;
            DropIncomingCall += portController.Drop;
            PortEventOutgoingCall += portController.CallHandler;
        }

        private void IncomingCall(object sender, ICallInfo callInfo)
        {
            if (sender is IPort port&&port.PortNumber == PortNumber)
            {
                if (On&&!Busy)
                {
                    Busy = true;
                    PortEventIncomingCall?.Invoke(sender, callInfo);
                }
                else
                {
                    DropIncomingCall?.Invoke(sender, callInfo);
                }
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
            if (terminal!=null)
            {
                Terminal = terminal;
                terminal.EventCall += OutgoingCallHandler;
                PortEventIncomingCall += terminal.IncomingCall;
            }
            else
            {
                throw new Exception("In Method PlugTerminal terminal is null");
            }
           
        }

       

        public void UnPlugTerminal(IClientTerminal terminal)
        {
            if (terminal != null)
            {
                terminal.EventCall -= OutgoingCallHandler;
                PortEventIncomingCall -= terminal.IncomingCall;
                Terminal = null;
            }
            else
            {
                throw new Exception("In Method UnPlugTerminal terminal is null");
            }

        }



    }
}
