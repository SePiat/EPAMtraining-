using Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomaticTelephoneExchange.TelephoneStation.CallController_
{
    public class PortController : IPortController
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
            if (port!=null)
            {
                IncomingCall?.Invoke(port, callInfo);
            }
            else
            {
                Drop(sender, callInfo);
            }
        }

        public void Drop(object sender, ICallInfo callInfo)
        {
            MessageHandler?.Invoke(sender, $"Соединение абонента {callInfo.ClientNumberOfTelephone} c абонентом {callInfo.OutgoingNumber} сброшено, абонент надоступен");
            IPort port = Ports.FirstOrDefault(x => x.Terminal.ClientNumberOfTelephone == callInfo.ClientNumberOfTelephone);
            if (port != null)
            {
                port.RidPort();
            }
            callInfo = null;
        }
        public IPort GetPortByOutgoingNumber(int OutgoingNumber)
        {
            IPort port = Ports.FirstOrDefault(x => x.Terminal.ClientNumberOfTelephone == OutgoingNumber);
            if (port!=null)
            {
                return port;
            }
            else
            {
                return null;
            }
           
        }

        public void OnOfPortEventHandler(object sender, bool on)
        {
            if (sender is Port port)
            {
                string state = on ? "ВКЛЮЧЕН" : "ВЫКЛЮЧЕН";
                MessageHandler?.Invoke(sender, $"Порт {port.PortNumber} изменил состояние на {state}");
            }

        }
        public void BusyPortEventHandler(object sender, bool busy)
        {
            if (sender is Port port)
            {
                string state = busy ? "ЗАНЯТ" : "СВОБОДЕН";
                MessageHandler?.Invoke(sender, $"Порт {port.PortNumber} изменил состояние на {state}");
            }
        }
        public void PlugTerminalEventHandler(object sender, IClientTerminal terminal)
        {
            if (sender is Port port)
            {
                MessageHandler?.Invoke(sender, $"Терминал {terminal.ClientNumberOfTelephone} подключен к порту {port.PortNumber}");
            }
        }
        public void UnPlugTerminalEventHandler(object sender, IClientTerminal terminal)
        {
            if (sender is Port port)
            {
                MessageHandler?.Invoke(sender, $"Терминал {terminal.ClientNumberOfTelephone} отключен от порта {port.PortNumber}");
            }
        }

        public void ClearEvents()
        {
            IncomingCall = null;
            MessageHandler = null;           
        }
    }
}
