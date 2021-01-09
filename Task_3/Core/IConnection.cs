using System;
using System.Collections.Generic;
using System.Text;

namespace Core
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
