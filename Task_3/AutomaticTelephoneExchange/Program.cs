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
            ITariffPlan plan = new TariffPlan();
           
            IPort port1 = _Station.GetFreePort();
            IClientTerminal terminal1 = _Station.GetClientTerminal(111111);

            IClient Client1 = new Billing.Client("Вася", "Пупкин", "10.10.1990");
            Company.Contracts.Add(new Contract(Company, Client1, DateTime.Now, plan));
            Client1.AcceptClientTerminalAndPort(terminal1, port1);
            Client1.PlugClientTerminalInPort();            

            IPort port2 = _Station.GetFreePort();
            IClientTerminal terminal2 = _Station.GetClientTerminal(222222);

            IClient Client2 = new Billing.Client("Федя", "Тапкин", "11.11.1995");
            Company.Contracts.Add(new Contract(Company, Client2, DateTime.Now, plan));
            Client2.AcceptClientTerminalAndPort(terminal2, port2);
            Client2.PlugClientTerminalInPort();

            IPort port3 = _Station.GetFreePort();
            IClientTerminal terminal3 = _Station.GetClientTerminal(333333);

            IClient Client3 = new Billing.Client("Афоня", "Сковородкин", "11.11.2000");
            Company.Contracts.Add(new Contract(Company, Client3, DateTime.Now, plan));
            Client3.AcceptClientTerminalAndPort(terminal3, port3);
            Client3.PlugClientTerminalInPort();





            Client1.ClientTerminal.OutgoingCall(222222);
            Thread.Sleep(5000);
            Client1.ClientTerminal.FinishConversation();

            Client1.ClientTerminal.OutgoingCall(333333);
            Thread.Sleep(7000);
            Client3.ClientTerminal.FinishConversation();


            Client2.ClientTerminal.OutgoingCall(111111);
            Thread.Sleep(10000);
            Client2.ClientTerminal.FinishConversation();


            Company.CalculateForReportPeriod();
            //Company.GetDetailedСallReportForPreviosMonth(Client1);
            Company.GetDetailedСallReport(Client1, "Январь 2021");

            DateTime timeForSerch = new DateTime(2021,01,13);
            Company.GetDetailedСallReportByCallDate(timeForSerch);



            


            Console.ReadKey();


        }

    }
}
