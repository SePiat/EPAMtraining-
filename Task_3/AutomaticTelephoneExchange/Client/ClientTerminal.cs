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

        public int ClientNumberOfTelephone { get; set; }

        public void OutgoingCall(int outgoingNumber)
        {
            ICallInfo callInfo = new CallInfo() { ClientNumberOfTelephone = ClientNumberOfTelephone, OutgoingNumber = outgoingNumber };
            MessageHandlerEvent(this, $"Попытка вызова абонентом  {callInfo.ClientNumberOfTelephone} абонента {callInfo.OutgoingNumber}");
            CallEvent?.Invoke(this, callInfo);
            CurrentCallInfo = callInfo;

        }

        public void IncomingCall(object sender, ICallInfo callInfo)
        {
            MessageHandlerEvent(sender, $"Запрос входящего соединения на терминале {callInfo.OutgoingNumber} от абонента {callInfo.ClientNumberOfTelephone}");
            MessageHandlerEvent(sender, $"Принять звонок Y/N");
            string answer = null;
            while (answer != "Y" && answer != "y" && answer != "N" && answer != "n")
            {
                answer = Console.ReadLine().ToString();


                if (answer == "Y" || answer == "y")
                {
                    Answer(sender, callInfo);
                }
                else if (answer == "N" || answer == "n")
                {
                    Drop(sender, callInfo);
                }
                else
                {
                    MessageHandlerEvent(sender, "Некорректный ввод");
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
            ConnectionEvent?.Invoke(sender, callInfo);
            MessageHandlerEvent(sender, $"Установлено соединение между абонентом {callInfo.ClientNumberOfTelephone} с абонентом {callInfo.OutgoingNumber}");
        }
        private void Drop(object sender, ICallInfo callInfo)
        {
            DropCallEvent?.Invoke(this, callInfo);
            CurrentCallInfo = null;
        }

    }
}
