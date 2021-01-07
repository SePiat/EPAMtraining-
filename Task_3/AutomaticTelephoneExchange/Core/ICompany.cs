using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Core
{
    public interface ICompany
    {
        public string Name { get; set; }
        public IStation Station { get; set; }
    }
}
