using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class Company : ICompany
    {
        public Company(string name, IStation station)
        {
            Name = name;
            Station = station;
        }

        public string Name { get; set; }
        public IStation Station { get; set; }

        ICollection<Contract> Contracts { get; set; } = new List<Contract>();


    }
}
