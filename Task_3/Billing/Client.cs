using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class Client: IСlient
    {
        public Client(string name, string lastName, string birthday)
        {
            Name = name;
            LastName = lastName;
            Birthday = birthday;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
       
    }
}
