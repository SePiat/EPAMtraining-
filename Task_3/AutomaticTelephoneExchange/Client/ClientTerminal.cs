using AutomaticTelephoneExchange.Company;
using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Client
{
    public class ClientTerminal: IClientTerminal
    {
        public event EventHandler<ICallInfo> EventCall;
        public ClientTerminal(int numberOfTelephone)
        {
            ClientNumberOfTelephone = numberOfTelephone;
          
        }
        
        public int ClientNumberOfTelephone { get;  set; }       
        
        public void OutgoingCall(int outgoingNumber)
        {
            ICallInfo callInfo = new CallInfo() {ClientNumberOfTelephone= ClientNumberOfTelephone , OutgoingNumber= outgoingNumber };
            EventCall?.Invoke(this, callInfo);
        }

        public void IncomingCall(object sender, ICallInfo callInfo)
        {
            Console.WriteLine($"Установлено соединение между абоненсом с номером {callInfo.ClientNumberOfTelephone} с абонентом {callInfo.OutgoingNumber}");
        }
    }
}
