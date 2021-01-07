using AutomaticTelephoneExchange.Client;
using AutomaticTelephoneExchange.Company;
using AutomaticTelephoneExchange.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using static AutomaticTelephoneExchange.Client.Сlient;

namespace AutomaticTelephoneExchange
{
    class Program
    {
        static void Main(string[] args)
        {


            
            IClientTerminal terminal1 = new ClientTerminal(777);
            IPort port = new Port();
            port.PlugTerminal(terminal1);

            Station station = new Station(port);

            //station.ClientTerminals.Add(terminal1);
            terminal1.Call(555);


            Console.ReadKey();


        }
      
    }
}
