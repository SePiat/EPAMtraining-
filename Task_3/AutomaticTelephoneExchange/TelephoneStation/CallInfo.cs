using Core;

namespace AutomaticTelephoneExchange.Company
{
    public class CallInfo : ICallInfo
    {
        public int ClientNumberOfTelephone { get; set; }
        public int OutgoingNumber { get; set; }

    }
}
