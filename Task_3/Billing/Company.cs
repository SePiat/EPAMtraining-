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
            Station.CallController.SaveConnection += ConnectionHandler;
        }

        public string Name { get;}
        public IStation Station { get; set; }
        public ICollection<IContract> Contracts { get; set; } = new List<IContract>();
        public ICollection<IClientLog> ClientLogs { get; set; } = new List<IClientLog>();
        public ICollection<string> ReportPeriods { get; set; } = new List<string>();
        public ICollection<IReportCalls> Reports { get; set; } = new List<IReportCalls>();
        private void ConnectionHandler(object sender, IConnection connection)
        {
            IContract contract = Contracts.FirstOrDefault(x => x.Client.ClientTerminal.ClientNumberOfTelephone == connection.ClientNumberOfTelephone);
            if (contract!=null)
            {
                ClientLogs.Add(new ClientLog(contract.Client, connection));
            }
            else
            {
                throw new Exception("С абонентом не заключен контракт");
            }
        }

        private void CalculateClientForReportPeriod(IClient client, DateTime reportPeriod)
        {
            var ReportPeriodClientLogs = ClientLogs.Where(x => x.Client == client).Where(x => x.Connections.FinishConnection.Month == reportPeriod.Month);
            ITariffPlan tariffPlan = Contracts.FirstOrDefault(x => x.Client == client).TariffPlan;
            var reportItems = GetReportItems(ReportPeriodClientLogs, client);
            decimal totalSummCollect = reportItems.ToList().Sum(x=>x.Cost)+ tariffPlan.SubscriptionFeeMonthly;
            decimal DurationOfConversations = reportItems.Sum(x=>x.DurationOfConversations);
            client.Money = client.Money - totalSummCollect;
            Reports.Add(new ReportCalls(
                client, 
                reportPeriod.ToString("y"),
                tariffPlan,
                DurationOfConversations,
                client.Money, totalSummCollect, reportItems));
        }
        private IList<IReportItem> GetReportItems(IEnumerable<IClientLog> ClientLogs, IClient client)
        {
            IList<IReportItem> reportItems = new List<IReportItem>();
            ITariffPlan tariffPlan = Contracts.FirstOrDefault(x => x.Client == client).TariffPlan;          

            ClientLogs.ToList().ForEach(x => reportItems.
            Add(new ReportItem(x.Connections.OutgoingNumber, 
            x.Connections.DurationConnection.Seconds,
             x.Connections.DurationConnection.Seconds * tariffPlan.TariffForSecond)));
            return reportItems;
        }




        public void CalculateForReportPeriod()
        {
            try
            {
                var сurrentDate = DateTime.Now;
                var previosMonthDate = сurrentDate.AddMonths(-1);
                var previosMonthYear = previosMonthDate.ToString("y");
                if (ReportPeriods.Contains(previosMonthYear))
                {
                    throw new Exception("Расчет за данный период уже был произведен");
                }
                else
                {
                    //var previosMonth = CurrentDate.AddMonths(-1).Month; //Расчетный период-прошлый месяц
                   
                    IList<IClient> ClientsToCalculte = ClientLogs.
                        Where(x => x.Connections.FinishConnection.Month == сurrentDate.Month/* previosMonthDate.Month*/)
                        .Select(x => x.Client).ToList();

                    ClientsToCalculte.ToList().ForEach(x => CalculateClientForReportPeriod(x, сurrentDate));                   
                    ReportPeriods.Add(previosMonthYear);
                }
            }
            catch
            {
                throw new Exception("Ошибка в методе CalculateForReportPeriod");
            }
           
        }

      
        
       






    }
}
