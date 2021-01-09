using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface ICallInfo
    {
         int ClientNumberOfTelephone { get; set; }
         int OutgoingNumber { get; set; }      
    }
}
