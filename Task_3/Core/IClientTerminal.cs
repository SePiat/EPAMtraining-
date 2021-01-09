using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IClientTerminal
    {

        int ClientNumberOfTelephone { get; set; }
        ICallInfo CurrentCallInfo { get; set; }
        void OutgoingCall(int callNumber);
        void IncomingCall(object sender, ICallInfo callInfo);
        void FinishConversation();       

        event EventHandler<ICallInfo> ConnectionEvent;
        event EventHandler<ICallInfo> CallEvent;
        event EventHandler<string> MessageHandlerEvent;
    }
}
