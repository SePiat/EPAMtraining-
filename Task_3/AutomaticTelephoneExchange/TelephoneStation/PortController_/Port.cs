﻿using Core;
using System;

namespace AutomaticTelephoneExchange.TelephoneStation.CallController_
{
    public class Port : IPort
    {
        public event EventHandler<ICallInfo> PortOutgoingCallEvent;
        public event EventHandler<ICallInfo> PortIncomingCallEvent;
        public event EventHandler<ICallInfo> DropIncomingCallEvent;
        public event EventHandler<bool> OnOfPortEvent;
        public event EventHandler<bool> BusyPortEvent;
        public event EventHandler<IClientTerminal> PlugTerminalEvent;
        public event EventHandler<IClientTerminal> UnPlugTerminalEvent;
        public Guid PortNumber { get;}
        public bool On { get; set; } = true;
        public bool Busy { get; set; } = false;
        public bool Rent { get; set; } = false;
        public IClientTerminal Terminal { get; set; }
        public Port(IPortController portController)
        {
            PortNumber = Guid.NewGuid();            
            DropIncomingCallEvent += portController.Drop;
            OnOfPortEvent += portController.OnOfPortEventHandler;
            BusyPortEvent += portController.BusyPortEventHandler;
            PortOutgoingCallEvent += portController.CallHandler;
            PlugTerminalEvent += portController.PlugTerminalEventHandler;
            UnPlugTerminalEvent += portController.UnPlugTerminalEventHandler;
        }

        public void IncomingCall(ICallInfo callInfo)
        {
            if (On && !Busy)
            {
                BusyPort();
                PortIncomingCallEvent?.Invoke(this, callInfo);
            }
            else
            {
                DropIncomingCallEvent?.Invoke(this, callInfo);
            }
        }

        private void OutgoingCallHandler(object sender, ICallInfo callInfo)
        {
            if (On)
            {
                BusyPort();
                PortOutgoingCallEvent?.Invoke(this, callInfo);
            };
        }

        public void PlugTerminal(IClientTerminal terminal)
        {
            if (terminal != null && Terminal == null)
            {
                Terminal = terminal;
                terminal.CallEvent += OutgoingCallHandler;
                PortIncomingCallEvent += terminal.IncomingCall;
                PlugTerminalEvent?.Invoke(this, terminal);
            }
            else
            {
                throw new Exception("In Method PlugTerminal terminal is null");
            }

        }

        public void UnPlugTerminal(IClientTerminal terminal)
        {
            if (terminal != null)
            {
                terminal.CallEvent -= OutgoingCallHandler;
                PortIncomingCallEvent -= terminal.IncomingCall;
                UnPlugTerminalEvent?.Invoke(this, terminal);
                Terminal = null;
            }
            else
            {
                throw new Exception("In Method UnPlugTerminal terminal is null");
            }

        }

        public void OnPort()
        {
            On = true;
            OnOfPortEvent?.Invoke(this, On);
        }
        public void OffPort()
        {
            On = false;
            OnOfPortEvent?.Invoke(this, On);
        }
        public void BusyPort()
        {
            Busy = true;
            BusyPortEvent?.Invoke(this, Busy);
        }
        public void RidPort()
        {
            Busy = false;
            BusyPortEvent?.Invoke(this, Busy);
        }

        public void ClearEvents()
        {
            PortOutgoingCallEvent = null;
            PortIncomingCallEvent = null;
            DropIncomingCallEvent = null;
            OnOfPortEvent = null;
            BusyPortEvent = null;
            PlugTerminalEvent = null;
            UnPlugTerminalEvent = null;
        }



    }
}
