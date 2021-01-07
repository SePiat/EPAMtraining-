using AutomaticTelephoneExchange.Client;
using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Company
{
    public class Port : IPort
    {
        public event EventHandler<int> PortEventCall;
        public Guid PortNumber { get; set; }
        public bool On { get; set; } = false;
        public bool Busy { get; set; } = false;
        public Port()
        {
            PortNumber = Guid.NewGuid();           
        }

        public void PlugTerminal(IClientTerminal terminal)
        {
           terminal.EventCall += CallHandler;
        }

        private void CallHandler(object sender, int callNumber)
        {
            PortEventCall?.Invoke(this, callNumber);
            if (!Busy&&On)
            {
                PortEventCall?.Invoke(this, callNumber);
            };
        }

       

        
    }
}
