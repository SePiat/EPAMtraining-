using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class Contract: IContract
    {
        public Contract(ICompany company, IСlient client, DateTime dateCreate)
        {
            Company = company;
            Client = client;
            DateCreate = dateCreate;
            
        }

        public ICompany Company { get; set; }
        public IСlient Client { get; set; }
        public DateTime DateCreate { get; set; }
       
        public ITariffPlan TariffPlan {get;set;}

    }
}
