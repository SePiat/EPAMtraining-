using AutomaticTelephoneExchange.Client;
using AutomaticTelephoneExchange.Company;
using AutomaticTelephoneExchange.Company.CallController_;
using AutomaticTelephoneExchange.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static AutomaticTelephoneExchange.Client.Сlient;

namespace AutomaticTelephoneExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            Station station = new Station();
            station.ClientTerminals.Add(new ClientTerminal(691375));
            station.ClientTerminals.Add(new ClientTerminal(677220));
            station.PortController.Ports.Add(new Port(station.PortController));
            station.PortController.Ports.Add(new Port(station.PortController));
            IPort port1 =station.PortController.Ports.FirstOrDefault(x => x.Terminal == null);
            IClientTerminal terminal1 = station.ClientTerminals.FirstOrDefault(x => x.ClientNumberOfTelephone == 691375);
            port1.PlugTerminal(terminal1);
            IPort port2 = station.PortController.Ports.FirstOrDefault(x => x.Terminal == null);
            IClientTerminal terminal2 = station.ClientTerminals.FirstOrDefault(x => x.ClientNumberOfTelephone == 677220);
            port2.PlugTerminal(terminal2);








            terminal1.OutgoingCall(677220);





           /* IClientTerminal terminal1 = new ClientTerminal(777);
            IPort port = new Port();
            port.PlugTerminal(terminal1);

            Station station = new Station(port);

            
            terminal1.OutgoingCall(555);*/


            Console.ReadKey();


        }
      
    }
}
