using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Core
{
    public interface ICompany
    {
         string Name { get; set; }
         IStation Station { get; set; }
    }
}
