using System;
using System.Collections.Generic;

namespace Core
{
    public interface ICallController
    {
        ICollection<IConnection> OnlineConnections { get; set; }
        ICollection<IConnection> СompletedConnections { get; set; }
        void ConnectionCreator(object sender, ICallInfo callInfo);
        void ConnectionCompletion(object sender, ICallInfo callInfo);
        void DropCall(object sender, ICallInfo callInfo);
        event EventHandler<string> MessageHandler;
        event EventHandler<IConnection> SaveConnection;
        void ClearEvents();
    }
}
