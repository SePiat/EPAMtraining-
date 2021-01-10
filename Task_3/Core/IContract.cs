using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IContract
    {
         ICompany Company { get; set; }
         IСlient Client { get; set; }
         DateTime DateCreate { get; set; }

         ITariffPlan TariffPlan { get; set; }
    }
}
