using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class Client: IСlient
    {
                 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public IClientTerminal ClientTerminal { get; set; }
        public IPort Port { get; set; }
    }
}
