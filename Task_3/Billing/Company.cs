using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing
{
    public class Company : ICompany
    {
        public event EventHandler<string> MessageHandlerEvent;
        public Company(string name, IStation station)
        {
            Name = name;
            Station = station;
            Station.CallController.SaveConnection += ConnectionHandler;
            MessageHandlerEvent += ConsoleMessagePrinter.WriteMessageInConsole;
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

        public void GetDetailedСallReportByCallDate(DateTime dateTime) 
        {
            try
            {
                var raports = Reports.Where(x => x.ReportPeriod == dateTime.ToString("y"));                
                if (raports != null)
                {
                    foreach (var raport in raports)
                    {                        
                        MessageHandlerEvent(this, $"Клиент {raport.Client_.Name} {raport.Client_.LastName}");
                        MessageHandlerEvent(this, $"Дата поиска {dateTime.ToString("dd.MM.yyyy")}");
                        var calls = raport.Logs.Where(x => x.DateConnection.ToString("dd.MM.yyyy") == dateTime.ToString("dd.MM.yyyy"));
                        if (calls!=null)
                        {
                            foreach (var log in calls)
                            {
                                MessageHandlerEvent(this, $"Исходящий номер {log.OutgoingNumber}, дата звонка {log.DateConnection.ToString("dd.MM.yyyy HH:mm")}, продолжительность соединения {log.DurationOfConversations}с, стоимость {log.Cost}руб.");                                
                            }
                            MessageHandlerEvent(this, "");
                        }                       
                    }                    
                }
                else
                {
                    MessageHandlerEvent(this, $"На данную дату отчетов не обнаружено");
                }
            }
            catch
            {
                throw new Exception("Ошибка в методе GetDetailedСallReportForPreviosMonth");
            }
        }

        public void GetDetailedСallReportForPreviosMonth(IClient client)
        {
            try
            {
                string previosMonth = DateTime.Now.AddMonths(-1).ToString("y");
                var raport = Reports.Where(x => x.Client_ == client).FirstOrDefault(x => x.ReportPeriod == previosMonth);
                MessageHandlerEvent(this, $"Клиент {client.Name} {client.LastName}");
                MessageHandlerEvent(this, $"Расчетный период  {previosMonth}");
                if (raport!=null)
                {
                    foreach (var log in raport.Logs)
                    {
                        MessageHandlerEvent(this, $"Исходящий номер {log.OutgoingNumber}, дата звонка {log.DateConnection.ToString("MM.dd.yyyy HH:mm")}, продолжительность соединения {log.DurationOfConversations}с, стоимость {log.Cost}руб.");
                    }
                    MessageHandlerEvent(this, "");
                }
                else
                {
                    MessageHandlerEvent(this, $"Для клиента {client.Name} {client.LastName} на данный расчетный период отчетов не обнаружено"); 
                }
               
            }
            catch
            {
                throw new Exception("Ошибка в методе GetDetailedСallReportForPreviosMonth");
            }
        }
        public void GetDetailedСallReport(IClient client, string reportPeriod)
        {
            try
            {
                var raport = Reports.Where(x => x.Client_ == client).FirstOrDefault(x => x.ReportPeriod == reportPeriod);
                MessageHandlerEvent(this, $"Клиент {client.Name} {client.LastName}");
                MessageHandlerEvent(this, $"Расчетный период  {reportPeriod}");
                if (raport != null)
                {
                    foreach (var log in raport.Logs)
                    {
                        MessageHandlerEvent(this, $"Исходящий номер {log.OutgoingNumber}, дата звонка {log.DateConnection.ToString("MM.dd.yyyy HH:mm")}, продолжительность соединения {log.DurationOfConversations}с, стоимость {log.Cost}руб.");
                    }
                    MessageHandlerEvent(this, "");
                }
                else
                {
                    MessageHandlerEvent(this, $"Для клиента {client.Name} {client.LastName} на данный расчетный период отчетов не обнаруженолибо периодн задан некорректно(Пример:'Сентябрь 2025')");
                }
                
            }
            catch
            {
                throw new Exception("Ошибка в методе GetDetailedСallReport");
            }           
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
                        .Select(x => x.Client).Distinct().ToList();

                    ClientsToCalculte.ToList().ForEach(x => CalculateClientForReportPeriod(x, сurrentDate));
                    ReportPeriods.Add(previosMonthYear);
                }
            }
            catch
            {
                throw new Exception("Ошибка в методе CalculateForReportPeriod");
            }

        }


        private void CalculateClientForReportPeriod(IClient client, DateTime reportPeriod)
        {
            try
            {
                var ReportPeriodClientLogs = ClientLogs.Where(x => x.Client == client).Where(x => x.Connections.FinishConnection.Month == reportPeriod.Month);
                ITariffPlan tariffPlan = Contracts.FirstOrDefault(x => x.Client == client).TariffPlan;
                var reportItems = GetReportItems(ReportPeriodClientLogs, client);
                decimal totalSummCollect = reportItems.ToList().Sum(x => x.Cost) + tariffPlan.SubscriptionFeeMonthly;
                decimal DurationOfConversations = reportItems.Sum(x => x.DurationOfConversations);
                client.Money = client.Money - totalSummCollect;
                Reports.Add(new ReportCalls(
                    client,
                    reportPeriod.ToString("y"),
                    tariffPlan,
                    DurationOfConversations,
                    client.Money, totalSummCollect, reportItems));
            }
            catch
            {
                throw new Exception("Ошибка в методе CalculateClientForReportPeriod");
            }
           
        }
        private IList<IReportItem> GetReportItems(IEnumerable<IClientLog> ClientLogs, IClient client)
        {
            IList<IReportItem> reportItems = new List<IReportItem>();
            try
            {                
                ITariffPlan tariffPlan = Contracts.FirstOrDefault(x => x.Client == client).TariffPlan;

                ClientLogs.ToList().ForEach(x => reportItems.
                Add(new ReportItem(x.Connections.OutgoingNumber,
                x.Connections.FinishConnection,
                x.Connections.DurationConnection.Seconds,
                x.Connections.DurationConnection.Seconds * tariffPlan.TariffForSecond)));               
            }
            catch
            {
                throw new Exception("Ошибка в методе GetReportItems");
            }
            return reportItems;
        }




        

      
        
       






    }
}
