using AutomaticTelephoneExchange.Client;
using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Company
{
    public class Station : IStation
    {
        public PortController PortController;
        public CallController CallController;
        public Station()
        {
            PortController = new PortController();
            CallController = new CallController();

        }        
        public ICollection<IClientTerminal> ClientTerminals { get; set; } = new List<IClientTerminal>();





       /* public Station(IPort port)
        {
            
            Port.PortEventOutgoingCall += CallHandler;
        }       

        private void CallHandler(object sender, ICallInfo callInfo)
        {
            if (sender is ClientTerminal)
            {
                Console.WriteLine($"ClientNumber {((ClientTerminal)sender).ClientNumberOfTelephone} IncominNuber ClientTerminal");
            }
            
            if (sender is Port)
            {
                Console.WriteLine($"Port number {((Port)sender).PortNumber}+ OutgoingNumber{callInfo.OutgoingNumber}, ClientNumberOfTelephone {callInfo.ClientNumberOfTelephone}  ");
            }

        }*/
    }
}
