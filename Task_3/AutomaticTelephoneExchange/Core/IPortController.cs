using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Core
{
    public interface IPortController
    {
        public ICollection<IPort> Ports { get; set; }
        public void CallHandler(object sender, ICallInfo callInfo);
        public IPort GetPortByOutgoingNumber(int OutgoingNumber);
        public event EventHandler<ICallInfo> IncomingCall;
    }
}
