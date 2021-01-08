using AutomaticTelephoneExchange.Client;
using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticTelephoneExchange.Company.CallController_
{
    public class CallController:ICallController
    {       
        public ICollection<IConnection> OnlineConnections { get; set; } = new List<IConnection>();
        public ICollection<IConnection> СompletedConnections { get; set; } = new List<IConnection>();        

        public void ConnectionCreator(object sender, ICallInfo callInfo)
        {            
            OnlineConnections.Add(new Connection(callInfo.ClientNumberOfTelephone, callInfo.OutgoingNumber, DateTime.Now));
        }

        public void ConnectionCompletion(object sender, ICallInfo callInfo)
        {
            try
            {
                IConnection connection = OnlineConnections.FirstOrDefault(x => x.ClientNumberOfTelephone == callInfo.ClientNumberOfTelephone && x.OutgoingNumber == callInfo.OutgoingNumber);
                connection.FinishConnection = DateTime.Now;
                connection.DurationConnection = connection.FinishConnection - connection.StartConnection;
                OnlineConnections.Remove(connection);
                СompletedConnections.Add(connection);
            }
            catch 
            {
                throw new Exception("Exception on method ConnectionCompletion");
            }
        }

    }
}
