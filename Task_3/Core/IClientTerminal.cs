using System;

namespace Core
{
    public interface IClientTerminal
    {

        int ClientNumberOfTelephone { get;}
        ICallInfo CurrentCallInfo { get; set; }
        public bool Rent { get; set; }
        void OutgoingCall(int callNumber);
        void IncomingCall(object sender, ICallInfo callInfo);
        void FinishConversation();
        void ClearEvents();

        event EventHandler<ICallInfo> ConnectionEvent;
        event EventHandler<ICallInfo> CallEvent;
        event EventHandler<string> MessageHandlerEvent;
    }
}
