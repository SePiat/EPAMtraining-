using System;

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
