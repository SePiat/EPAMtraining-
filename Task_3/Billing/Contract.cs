using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class Contract
    {
        public Contract(ICompany company, IСlient client, DateTime dateCreate, IClientTerminal clientTerminal, IPort port)
        {
            Company = company;
            Client = client;
            DateCreate = dateCreate;
            ClientTerminal = clientTerminal;
            Port = port;
        }

        public ICompany Company { get; set; }
        public IСlient Client { get; set; }
        public DateTime DateCreate { get; set; }
        public IClientTerminal ClientTerminal { get; set; }
        public IPort Port { get; set; }

        public ITariffPlan TariffPlan {get;set;}

    }
}
