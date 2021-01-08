using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Core
{
    public interface ICallController
    {
        public ICollection<IConnection> OnlineConnections { get; set; } 
        public ICollection<IConnection> СompletedConnections { get; set; }
        public void ConnectionCreator(object sender, ICallInfo callInfo);
        public void ConnectionCompletion(object sender, ICallInfo callInfo);
    }
}
