using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing
{
    public class Company : ICompany
    {
        public Company(string name, IStation station)
        {
            Name = name;
            Station = station;
            Station.CallController.CreateConnection += ConnectionHandler;
        }

        public string Name { get; set; }
        public IStation Station { get; set; }
        public ICollection<IContract> Contracts { get; set; } = new List<IContract>();
        public ICollection<IClientLog> ClientLogs { get; set; } = new List<IClientLog>();
        public ICollection<string> EstimatedPeriods { get; set; } = new List<string>();
        public void ConnectionHandler(object sender, IConnection connection)
        {
            IContract contract = Contracts.FirstOrDefault(x => x.Client.ClientTerminal.ClientNumberOfTelephone == connection.ClientNumberOfTelephone);
            if (contract!=null)
            {
                ClientLogs.Add(new ClientLog(contract.Client, connection, contract.TariffPlan));
            }
            else
            {
                throw new Exception("С абонентом не заключен контракт");
            }
        }

        public void CalculateForEstimatedPeriod()
        {
            var CurrentDate = DateTime.Now; 
            if (EstimatedPeriods.Contains(DateTime.Now.ToString("y")))
            {
                throw new Exception("Расчет за данный период уже было произведен");
            }
            else
            {                
                var previosMonth = CurrentDate.AddMonths(-1).Month;
                var EstimatedPeriodClientLogs = ClientLogs.Where(x => x.Connections.FinishConnection.Month == CurrentDate.Month /*previosMonth*/);
                foreach (var ClientLog in EstimatedPeriodClientLogs)
                {

                }
            }  
        }







    }
}
