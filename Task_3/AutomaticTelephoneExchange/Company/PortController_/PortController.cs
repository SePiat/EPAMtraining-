﻿using AutomaticTelephoneExchange.Core;
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
        public event EventHandler<string> MessageHandler;
        
        public PortController()
        {
            Ports = new List<IPort>();
            MessageHandler += ConsoleMessagePrinter.WriteMessageInConsole;
        }

        public void CallHandler(object sender, ICallInfo callInfo)
        {
            IPort port = GetPortByOutgoingNumber(callInfo.OutgoingNumber);           
            IncomingCall?.Invoke(port, callInfo);            
        }

        public void Drop(object sender, ICallInfo callInfo)
        {            
            MessageHandler?.Invoke(sender, $"Соедиение абонента {callInfo.ClientNumberOfTelephone} c абоненстом {callInfo.OutgoingNumber} сброшено, порт надоступен");           
            callInfo = null;            
        }
        public IPort GetPortByOutgoingNumber(int OutgoingNumber)
        {
            IPort port = Ports.FirstOrDefault(x => x.Terminal.ClientNumberOfTelephone == OutgoingNumber);
            return port;
        }

        

       


        


        


    }
}
