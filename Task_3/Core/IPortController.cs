﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IPortController
    {
        ICollection<IPort> Ports { get; set; }
        void CallHandler(object sender, ICallInfo callInfo);
        IPort GetPortByOutgoingNumber(int OutgoingNumber);
        void OnOfPortEventHandler(object sender, bool on);
        void BusyPortEventHandler(object sender, bool busy);
        void PlugTerminalEventHandler(object sender, IClientTerminal terminal);
        void UnPlugTerminalEventHandler(object sender, IClientTerminal terminal);
        void Drop(object sender, ICallInfo callInfo);
        void ClearEvents();        
        event EventHandler<string> MessageHandler;
    }
}
