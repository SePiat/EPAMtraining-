using System;

namespace Core
{
    public interface IContract
    {
        ICompany Company { get; set; }
        IClient Client { get; set; }
        DateTime DateCreate { get; set; }

        ITariffPlan TariffPlan { get; set; }
    }
}
