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
        public ICollection<string> ReportPeriods { get; set; } = new List<string>();
        public ICollection<IReport> Reports { get; set; } = new List<IReport>();
        private void ConnectionHandler(object sender, IConnection connection)
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
            try
            {
                var сurrentDate = DateTime.Now;
                var previosMonthDate = сurrentDate.AddMonths(-1);
                var previosMonthYear = previosMonthDate.ToString("y");
                if (ReportPeriods.Contains(previosMonthYear))
                {
                    throw new Exception("Расчет за данный период уже было произведен");
                }
                else
                {
                    //var previosMonth = CurrentDate.AddMonths(-1).Month; //Расчетный период-прошлый месяц
                    var ReportPeriodClientLogs = ClientLogs.Where(x => x.Connections.FinishConnection.Month == сurrentDate.Month/* previosMonthDate.Month*/);

                    ICollection<IClient> ClientsToCalculte = ReportPeriodClientLogs.Select(x => x.Client).ToList();

                    foreach (var client in ClientsToCalculte)
                    {
                        ICollection<TimeSpan> ListDurationOfConversations = ReportPeriodClientLogs.Where(x => x.Client == client).Select(x => x.Connections.DurationConnection).ToList();
                        var DurationOfConversations = Convert.ToDecimal(ListDurationOfConversations.Sum(x => x.TotalMinutes));
                        ITariffPlan tariffPlan = Contracts.FirstOrDefault(x => x.Client == client).TariffPlan;
                        decimal totalSummCollect = tariffPlan.SubscriptionFeeMonthly + (DurationOfConversations * tariffPlan.TariffForMinute);
                        client.Money = client.Money - totalSummCollect;
                        Reports.Add(new Report(client, previosMonthDate, DurationOfConversations, client.Money, totalSummCollect));
                    }
                    ReportPeriods.Add(previosMonthYear);
                }
            }
            catch
            {
                throw new Exception("Ошибка в методе CalculateForEstimatedPeriod");
            }
           
        }







    }
}
