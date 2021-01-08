using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Core
{
    public interface IClientTerminal
    {
        
        public int ClientNumberOfTelephone { get; set; }
        public ICallInfo CurrentCallInfo { get; set; }
        public void OutgoingCall(int callNumber);
        public void IncomingCall(object sender, ICallInfo callInfo);
        public void FinishConversation();

        public event EventHandler<ICallInfo> EventConnection;
        public event EventHandler<ICallInfo> EventCall;
        public event EventHandler<string> MessageHandler;
    }
}
