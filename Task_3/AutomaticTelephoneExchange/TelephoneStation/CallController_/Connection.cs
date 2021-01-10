using Core;
using System;

namespace AutomaticTelephoneExchange.TelephoneStation.CallController_
{
    public class Connection : IConnection
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
