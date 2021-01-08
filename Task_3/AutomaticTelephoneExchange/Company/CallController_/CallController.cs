using AutomaticTelephoneExchange.Client;
using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Company.CallController_
{
    public class CallController
    {
       
        public ICollection<IConnection> OnlineConnections { get; set; } = new List<IConnection>();
        public ICollection<IConnection> СompletedConnections { get; set; } = new List<IConnection>();
        public CallController()
        {
            ClientTerminal.EventConnection += ConnectionHandler;
        }
        
        private void ConnectionHandler(object sender, ICallInfo callInfo)
        {            
            OnlineConnections.Add(new Connection(callInfo.ClientNumberOfTelephone, callInfo.OutgoingNumber, DateTime.Now));
        }
    }
}
