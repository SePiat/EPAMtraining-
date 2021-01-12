using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IReportItem
    {
         int OutgoingNumber { get; set; }
         decimal DurationOfConversations { get; set; }
         decimal Cost { get; set; }
    }
}
