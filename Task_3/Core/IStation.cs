using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IStation
    {
        IPortController PortController { get; set; }
        ICallController CallController { get; set; }
        ICollection<IClientTerminal> ClientTerminals { get; set; }
        public IPort GetFreePort();
        IClientTerminal GetClientTerminal(int ClientNumberOfTelephone);

    }
}
