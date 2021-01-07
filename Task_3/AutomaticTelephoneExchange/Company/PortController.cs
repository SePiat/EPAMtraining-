using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticTelephoneExchange.Company
{
    public class PortController
    {
        public ICollection<IPort> Ports { get; set; }
        
        public static event EventHandler<ICallInfo> IncomingCall;

        public PortController()
        {
            Ports = new List<IPort>();           
            Port.PortEventOutgoingCall += CallHandler;
        }

        private void CallHandler(object sender, ICallInfo callInfo)
        {
            IPort port = GetPortByOutgoingNumber(callInfo.OutgoingNumber);
            if (!port.Busy&&port.On)
            {
               IncomingCall?.Invoke(port, callInfo);
            }
            
        }

        private IPort GetPortByOutgoingNumber(int OutgoingNumber)
        {
            IPort port = Ports.FirstOrDefault(x => x.Terminal.ClientNumberOfTelephone == OutgoingNumber);
            return port;
        }

       


        


        


    }
}
