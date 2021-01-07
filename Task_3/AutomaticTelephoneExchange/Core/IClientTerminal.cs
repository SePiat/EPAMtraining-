using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Core
{
    public interface IClientTerminal
    {
        
        public int ClientNumberOfTelephone { get; set; }
        public event EventHandler<ICallInfo> EventCall;
        public void OutgoingCall(int callNumber);
        public void IncomingCall(object sender, ICallInfo e);
    }
}
