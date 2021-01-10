﻿namespace Core
{
    public interface IСlient
    {
        string Name { get; set; }
        string LastName { get; set; }
        string Birthday { get; set; }
        public decimal Money { get; set; }
        IClientTerminal ClientTerminal { get; set; }
        IPort Port { get; set; }
        void AcceptClientTerminalAndPort(IClientTerminal terminal, IPort port);
        void ReturnClientTerminalAndPort();
        void PlugClientTerminalInPort();
        void UnPlugClientTerminalInPort();


    }
}
