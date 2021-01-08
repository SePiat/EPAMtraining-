using AutomaticTelephoneExchange.Client;
using AutomaticTelephoneExchange.Company.CallController_;
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





      
    }
}
