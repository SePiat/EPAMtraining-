using AutomaticTelephoneExchange.Company;
using Core;
using System;
using System.Threading;
using Billing;

namespace AutomaticTelephoneExchange
{
    class Program
    {
        static void Main(string[] args)
        {

            IStation Station = new Station();
            ICompany Company = new Billing.Company("Белтелеком", Station);

            IPort port1 = Station.GetFreePort();
            IClientTerminal terminal1 = Station.GetClientTerminal(691375);

            IСlient Client1 = new Billing.Client("Вася", "Пупкин", "10.10.1990");
            Company.Contracts.Add(new Contract(Company, Client1, DateTime.Now));
            Client1.AcceptClientTerminalAndPort(terminal1, port1);
            Client1.PlugClientTerminalInPort();

            IPort port2 = Station.GetFreePort();
            IClientTerminal terminal2 = Station.GetClientTerminal(677220);

            IСlient Client2 = new Billing.Client("Федя", "Тапкин", "11.11.1995");
            Company.Contracts.Add(new Contract(Company, Client2, DateTime.Now));
            Client2.AcceptClientTerminalAndPort(terminal2, port2);
            Client2.PlugClientTerminalInPort();


            Client1.ClientTerminal.OutgoingCall(677220);

            Thread.Sleep(5000);

            Client1.ClientTerminal.FinishConversation();










            // IPort port3 = station.GetFreePort();
            // IClientTerminal terminal3 = station.GetClientTerminal(398829);
            // port3.PlugTerminal(terminal3);

            // terminal1.OutgoingCall(677220);
            // terminal3.OutgoingCall(677220);



            Console.ReadKey();


        }

    }
}
