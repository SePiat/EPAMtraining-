using AutomaticTelephoneExchange.Company;
using AutomaticTelephoneExchange.Company.CallController_;
using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Client
{
    public class ClientTerminal: IClientTerminal
    {
        public event EventHandler<ICallInfo> EventConnection;
        public event EventHandler<ICallInfo> EventCall;
        public event EventHandler<ICallInfo> EventFinishConversation;
        public event EventHandler<string> MessageHandler;
        public ICallInfo CurrentCallInfo { get; set; }
        public ClientTerminal(int numberOfTelephone, ICallController callController)
        {
            EventConnection += callController.ConnectionCreator;
            EventFinishConversation += callController.ConnectionCompletion;
            ClientNumberOfTelephone = numberOfTelephone;
            MessageHandler += ConsoleMessagePrinter.WriteMessageInConsole;
        }
        
        public int ClientNumberOfTelephone { get;  set; }       
        
        public void OutgoingCall(int outgoingNumber)
        {
            ICallInfo callInfo = new CallInfo() {ClientNumberOfTelephone= ClientNumberOfTelephone , OutgoingNumber= outgoingNumber };
            EventCall?.Invoke(this, callInfo);
            CurrentCallInfo = callInfo;
        }

        public void IncomingCall(object sender, ICallInfo callInfo)
        {
            CurrentCallInfo = callInfo;
            EventConnection?.Invoke(sender, callInfo);
            MessageHandler(sender, $"Установлено ConnectionCompletion соединение между абоненсом с номером {callInfo.ClientNumberOfTelephone} с абонентом {callInfo.OutgoingNumber}");            
        }

        public void FinishConversation()
        {
            EventFinishConversation?.Invoke(this, CurrentCallInfo);
            MessageHandler(this, $"Завершено соединение абонента {CurrentCallInfo.ClientNumberOfTelephone} с абонентом {CurrentCallInfo.OutgoingNumber}");
            CurrentCallInfo = null;
        }

    }
}
