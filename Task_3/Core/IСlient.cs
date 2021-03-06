﻿namespace Core
{
    public interface IClient
    {
        string Name { get; set; }
        string LastName { get; set; }
        string Birthday { get; set; }
        decimal Money { get; set; }
        IClientTerminal ClientTerminal { get; set; }
        IPort Port { get; set; }
        ITariffPlan TariffPlan { get; set; }
        void AcceptClientTerminalAndPort(IClientTerminal terminal, IPort port, ITariffPlan tariffPlan);
        void ReturnClientTerminalAndPort();
        void PlugClientTerminalInPort();
        void UnPlugClientTerminalInPort();


    }
}
