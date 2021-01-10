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

            IStation _Station = new Station();
            ICompany Company = new Billing.Company("Белтелеком", _Station);
           
            IPort port1 = _Station.GetFreePort();
            IClientTerminal terminal1 = _Station.GetClientTerminal(691375);

            IСlient Client1 = new Billing.Client("Вася", "Пупкин", "10.10.1990");
            Company.Contracts.Add(new Contract(Company, Client1, DateTime.Now));
            Client1.AcceptClientTerminalAndPort(terminal1, port1);
            Client1.PlugClientTerminalInPort();            

            IPort port2 = _Station.GetFreePort();
            IClientTerminal terminal2 = _Station.GetClientTerminal(677220);

            IСlient Client2 = new Billing.Client("Федя", "Тапкин", "11.11.1995");
            Company.Contracts.Add(new Contract(Company, Client2, DateTime.Now));
            Client2.AcceptClientTerminalAndPort(terminal2, port2);
            Client2.PlugClientTerminalInPort();


            Client1.ClientTerminal.OutgoingCall(677220);

            Thread.Sleep(5000);

            Client1.ClientTerminal.FinishConversation();

            Client2.ClientTerminal.OutgoingCall(691375);
            Thread.Sleep(10000);
            Client2.ClientTerminal.FinishConversation();








            Company.CalculateForEstimatedPeriod();


            Console.ReadKey();


        }

    }
}
