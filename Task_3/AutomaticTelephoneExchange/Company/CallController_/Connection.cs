using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Company.CallController_
{
    public class Connection: IConnection
    {
        public Connection(int clientNumberOfTelephone, int outgoingNumber, DateTime startConnection)
        {
            ClientNumberOfTelephone = clientNumberOfTelephone;
            OutgoingNumber = outgoingNumber;
            StartConnection = startConnection;
        }

        public int ClientNumberOfTelephone { get; set; }
        public int OutgoingNumber { get; set; }
        public DateTime StartConnection { get; set; }
        public DateTime FinishConnection { get; set; }
        public TimeSpan DurationConnection { get; set; }
    }
}
