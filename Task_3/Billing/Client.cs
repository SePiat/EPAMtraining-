using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing
{
    public class Client : IClient
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
        public decimal Money { get; set; } = 100;
        public IClientTerminal ClientTerminal { get; set; }
        public IPort Port { get; set; }        

        public void AcceptClientTerminalAndPort(IClientTerminal terminal, IPort port)
        {           
            if (terminal.Rent!=true)
            {
                terminal.Rent = true;
                ClientTerminal = terminal;
            }
            else
            {
                throw new Exception("Данный терминал уже выдан другому клиенту");
            }

            if (port.Rent != true)
            {
                port.Rent = true;
                Port = port;
            }
            else
            {
                throw new Exception("Данный порт уже предоставлен другому клиенту");
            }
        }
        public void ReturnClientTerminalAndPort()
        {
            if (Port!=null)
            {
                Port.Rent = false;
                Port = null;
            }
            if (ClientTerminal != null)
            {
                ClientTerminal.Rent = false;
                ClientTerminal = null;
            }
        }

        public void PlugClientTerminalInPort()
        {
            if (ClientTerminal!=null&&Port!=null)
            {
                Port.PlugTerminal(ClientTerminal);
            }
            else
            {
                throw new Exception("У абонента не имеется необходимого для подлкючения оборудования");
            }
        }
        public void UnPlugClientTerminalInPort()
        {
            if (ClientTerminal != null && Port != null)
            {               
                Port.UnPlugTerminal(ClientTerminal);
            }
            else
            {
                throw new Exception("У абонента не имеется необходимого для подлкючения оборудования");
            }
        }
       
        public void PutMoney(decimal money)
        {
            Money += money;
        }
       
        public void TakeMoney(decimal money)
        {            
            Money -= money;
        }
    }
}
