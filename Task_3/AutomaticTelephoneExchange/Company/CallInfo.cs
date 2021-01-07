using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Company
{
    public class CallInfo: ICallInfo
    {
        public int ClientNumberOfTelephone { get; set; }
        public int OutgoingNumber { get; set; }
        public DateTime StartConnection { get; set; }
        public TimeSpan DurationConnection { get; set; }
    }
}
