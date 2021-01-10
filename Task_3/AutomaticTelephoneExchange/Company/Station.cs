using AutomaticTelephoneExchange.Client;
using AutomaticTelephoneExchange.Company.CallController_;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticTelephoneExchange.Company
{
    public class Station : IStation
    {
        public PortController PortController;
        public CallController CallController;
        public Station()
        {
            PortController = new PortController();
            CallController = new CallController(PortController);            
        }        
        public ICollection<IClientTerminal> ClientTerminals { get; set; } = new List<IClientTerminal>();

        public IPort GetFreePort()
        {            
            try
            {
                IPort port = PortController.Ports.FirstOrDefault(x => x.Terminal == null&&x.Rent==false);
                if (port!=null)
                {
                    return port;
                }
                else
                {
                    IPort port1 = new Port(PortController);
                    PortController.Ports.Add(port1);                   
                    return port1;
                }                
            }
            catch 
            {
                throw new Exception("Exception on method GetFreePort");
            }           
        }
        public IClientTerminal GetClientTerminal(int ClientNumberOfTelephone)
        {
            IClientTerminal terminal = ClientTerminals.FirstOrDefault(x => x.ClientNumberOfTelephone == ClientNumberOfTelephone);
            if (terminal != null)
            {
                if (terminal.Rent == false)
                {
                    return terminal;
                }
                else
                {
                    throw new Exception("Терминал с таким номером уже существует");
                }
            }
            else
            {
                IClientTerminal terminal1 = new ClientTerminal(ClientNumberOfTelephone, CallController);
                ClientTerminals.Add(terminal1);
                return terminal1;
            }
        }
    }
}
