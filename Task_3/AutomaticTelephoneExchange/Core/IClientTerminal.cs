using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Core
{
    public interface IClientTerminal
    {
        
        public int ClientNumberOfTelephone { get; set; }
        public event EventHandler<int> EventCall;
        public void Call(int callNumber);
    }
}
