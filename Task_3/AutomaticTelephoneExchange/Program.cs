using AutomaticTelephoneExchange.Client;
using AutomaticTelephoneExchange.Company;
using AutomaticTelephoneExchange.Company.CallController_;
using AutomaticTelephoneExchange.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static AutomaticTelephoneExchange.Client.Сlient;

namespace AutomaticTelephoneExchange
{    
    class Program
    {
        static void Main(string[] args)
        {           

            Station station = new Station();
           

            IPort port1 =station.GeFreePort();
            IClientTerminal terminal1 = station.GetClientTerminal(691375); 
            port1.PlugTerminal(terminal1);
            IPort port2 = station.GeFreePort();
            IClientTerminal terminal2 = station.GetClientTerminal(677220);
            port2.PlugTerminal(terminal2);
            IPort port3 = station.GeFreePort();
            IClientTerminal terminal3 = station.GetClientTerminal(398829);
            port3.PlugTerminal(terminal3);

            terminal1.OutgoingCall(677220);
            terminal3.OutgoingCall(677220);
            Thread.Sleep(10000);

            terminal1.FinishConversation();


            Console.ReadKey();


        }
      
    }
}
