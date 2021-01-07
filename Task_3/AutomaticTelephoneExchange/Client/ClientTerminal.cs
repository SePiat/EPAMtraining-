using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Client
{
    public class ClientTerminal: IClientTerminal
    {
        public event EventHandler<int> EventCall;
        public ClientTerminal(int numberOfTelephone)
        {
            ClientNumberOfTelephone = numberOfTelephone;
        }
        
        public int ClientNumberOfTelephone { get;  set; }       
        
        public void Call(int callNumber)
        {
            EventCall?.Invoke(this, callNumber);
        }
    }
}
