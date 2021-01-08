using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticTelephoneExchange.Company.CallController_
{
    public class PortController: IPortController
    {
        public ICollection<IPort> Ports { get; set; }
        
        public event EventHandler<ICallInfo> IncomingCall;

        public PortController()
        {
            Ports = new List<IPort>();           
            //Port.PortEventOutgoingCall += CallHandler;
        }

        public void CallHandler(object sender, ICallInfo callInfo)
        {
            IPort port = GetPortByOutgoingNumber(callInfo.OutgoingNumber);
            if (!port.Busy&&port.On)
            {
               IncomingCall?.Invoke(port, callInfo);
            }
            
        }

        public IPort GetPortByOutgoingNumber(int OutgoingNumber)
        {
            IPort port = Ports.FirstOrDefault(x => x.Terminal.ClientNumberOfTelephone == OutgoingNumber);
            return port;
        }

       


        


        


    }
}
