using AutomaticTelephoneExchange.Client;
using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Company
{
    public class Station : IStation
    {
        public Station(IPort port)
        {
            port.PortEventCall += CallHandler;
        }



        private void CallHandler(object sender, int e)
        {
            if (sender is Port)
            {
                Console.WriteLine($"Port number {((Port)sender).PortNumber}+ IncominNuber{e}");
            }

        }
    }
}
