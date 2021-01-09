using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Core
{
    public interface ICallInfo
    {
         int ClientNumberOfTelephone { get; set; }
         int OutgoingNumber { get; set; }      
    }
}
