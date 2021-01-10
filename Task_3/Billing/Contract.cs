﻿using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class Contract: IContract
    {
        public Contract(ICompany company, IClient client, DateTime dateCreate, ITariffPlan tariffPlan)
        {
            Company = company;
            Client = client;
            DateCreate = dateCreate;
            TariffPlan = tariffPlan;
        }

        public ICompany Company { get; set; }
        public IClient Client { get; set; }
        public DateTime DateCreate { get; set; }       
        public ITariffPlan TariffPlan {get;set;}

    }
}
