using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Core
{
    public interface IConnection
    {
         int ClientNumberOfTelephone { get; set; }
         int OutgoingNumber { get; set; }
         DateTime StartConnection { get; set; }
         DateTime FinishConnection { get; set; }
         TimeSpan DurationConnection { get; set; }
    }
}
