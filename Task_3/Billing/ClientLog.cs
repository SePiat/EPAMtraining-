using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class ClientLog: IClientLog
    {
        public ClientLog(IClient client, IConnection connections)
        {
            Client = client;
            Connections = connections;            
        }
        public IClient Client { get; set; }
        public IConnection Connections { get; set; }        
    }
}
