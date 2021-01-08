using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Core
{
    public interface IConnection
    {
        public int ClientNumberOfTelephone { get; set; }
        public int OutgoingNumber { get; set; }
        public DateTime StartConnection { get; set; }
        public DateTime FinishConnection { get; set; }
        public TimeSpan DurationConnection { get; set; }
    }
}
