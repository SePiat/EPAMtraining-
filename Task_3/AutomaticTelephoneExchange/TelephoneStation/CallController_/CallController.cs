using Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomaticTelephoneExchange.TelephoneStation.CallController_
{
    public class CallController : ICallController
    {
        public event EventHandler<string> MessageHandler;
        public event EventHandler<IConnection> SaveConnection;
        public CallController(IPortController portController)
        {
            PortController_ = portController;
            MessageHandler += ConsoleMessagePrinter.WriteMessageInConsole;
        }

        public IPortController PortController_ { get; set; }
        public ICollection<IConnection> OnlineConnections { get; set; } = new List<IConnection>();
        public ICollection<IConnection> СompletedConnections { get; set; } = new List<IConnection>();

        public void ConnectionCreator(object sender, ICallInfo callInfo)
        {
            OnlineConnections.Add(new Connection(callInfo.ClientNumberOfTelephone, callInfo.OutgoingNumber, DateTime.Now));
        }

        public void ConnectionCompletion(object sender, ICallInfo callInfo)
        {
            try
            {
                IConnection connection = OnlineConnections.FirstOrDefault(x => x.ClientNumberOfTelephone == callInfo.ClientNumberOfTelephone && x.OutgoingNumber == callInfo.OutgoingNumber);                          
                if (connection != null)
                {                    
                    connection.FinishConnection = DateTime.Now;
                    connection.DurationConnection = connection.FinishConnection - connection.StartConnection;
                    OnlineConnections.Remove(connection);
                    СompletedConnections.Add(connection);
                    SaveConnection?.Invoke(sender, connection);
                    IPort port1 = PortController_.Ports.FirstOrDefault(x => x.Terminal.ClientNumberOfTelephone == callInfo.ClientNumberOfTelephone);
                    IPort port2 = PortController_.Ports.FirstOrDefault(x => x.Terminal.ClientNumberOfTelephone == callInfo.OutgoingNumber);
                    port1.RidPort();
                    port2.RidPort();
                    MessageHandler(this, $"Завершено соединение абонента {callInfo.ClientNumberOfTelephone} с абонентом {callInfo.OutgoingNumber}");
                }
            }
            catch
            {
                throw new Exception("Exception on method ConnectionCompletion");
            }
        }

        public void DropCall(object sender, ICallInfo callInfo)
        {
            try
            {
                IPort port1 = PortController_.Ports.FirstOrDefault(x => x.Terminal.ClientNumberOfTelephone == callInfo.ClientNumberOfTelephone);
                IPort port2 = PortController_.Ports.FirstOrDefault(x => x.Terminal.ClientNumberOfTelephone == callInfo.OutgoingNumber);
                port1.RidPort();
                port2.RidPort();
                MessageHandler(this, $"Абонент {callInfo.OutgoingNumber} отклонил вызов от абонента {callInfo.ClientNumberOfTelephone}");
            }
            catch
            {
                throw new Exception("Exception on method DropCall");
            }
        }

        public void ClearEvents()
        {
            SaveConnection = null;
            MessageHandler = null;
        }

    }
}
