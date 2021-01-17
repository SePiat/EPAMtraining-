using AutomaticTelephoneExchange.Company;
using Core;
using System;

namespace AutomaticTelephoneExchange.Client
{
    public class ClientTerminal : IClientTerminal
    {
        public event EventHandler<ICallInfo> ConnectionEvent;
        public event EventHandler<ICallInfo> CallEvent;
        public event EventHandler<ICallInfo> FinishConversationEvent;
        public event EventHandler<ICallInfo> DropCallEvent;
        public event EventHandler<string> MessageHandlerEvent;
        public ICallInfo CurrentCallInfo { get; set; }
        public ClientTerminal(int numberOfTelephone, ICallController callController)
        {
            ConnectionEvent += callController.ConnectionCreator;
            FinishConversationEvent += callController.ConnectionCompletion;
            DropCallEvent += callController.DropCall;
            ClientNumberOfTelephone = numberOfTelephone;
            MessageHandlerEvent += ConsoleMessagePrinter.WriteMessageInConsole;
        }

        public int ClientNumberOfTelephone { get;}
        public bool Rent { get; set; } = false;


        public void OutgoingCall(int outgoingNumber)
        {
            ICallInfo callInfo = new CallInfo() { ClientNumberOfTelephone = ClientNumberOfTelephone, OutgoingNumber = outgoingNumber };
            MessageHandlerEvent(this, $"Попытка вызова абонентом  {callInfo.ClientNumberOfTelephone} абонента {callInfo.OutgoingNumber}");
            CallEvent?.Invoke(this, callInfo);
            CurrentCallInfo = callInfo;

        }

        public void IncomingCall(object sender, ICallInfo callInfo)
        {
            MessageHandlerEvent(this, $"Запрос входящего соединения на терминале {callInfo.OutgoingNumber} от абонента {callInfo.ClientNumberOfTelephone}");
            MessageHandlerEvent(this, $"Принять звонок Y/N");
            string answer = null;
            while (answer != "Y" && answer != "y" && answer != "N" && answer != "n")
            {
                answer = Console.ReadLine().ToString();


                if (answer == "Y" || answer == "y")
                {
                    Answer(this, callInfo);
                }
                else if (answer == "N" || answer == "n")
                {
                    Drop(this, callInfo);
                }
                else
                {
                    MessageHandlerEvent(this, "Некорректный ввод");
                }
            }
        }

        public void FinishConversation()
        {
            FinishConversationEvent?.Invoke(this, CurrentCallInfo);
            CurrentCallInfo = null;
        }

        private void Answer(object sender, ICallInfo callInfo)
        {
            CurrentCallInfo = callInfo;
            ConnectionEvent?.Invoke(this, callInfo);
            MessageHandlerEvent(this, $"Установлено соединение между абонентом {callInfo.ClientNumberOfTelephone} с абонентом {callInfo.OutgoingNumber}");
        }
        private void Drop(object sender, ICallInfo callInfo)
        {
            DropCallEvent?.Invoke(this, callInfo);
            CurrentCallInfo = null;
        }

        public void ClearEvents()
        {
            ConnectionEvent = null;
            FinishConversationEvent = null;
            DropCallEvent = null;
            MessageHandlerEvent = null;
        }

    }
}
