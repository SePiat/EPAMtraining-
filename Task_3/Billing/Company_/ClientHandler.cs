using Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Billing.Company_
{
    public class ClientHandler : IClientHandler
    {
        public ICompany Company { get; }
        public event EventHandler<string> MessageHandlerEvent;
        public ClientHandler(ICompany company)
        {
            Company = company;
            Company.Station.CallController.SaveConnection += ConnectionHandler;
            MessageHandlerEvent += ConsoleMessagePrinter.WriteMessageInConsole;
        }

        public ICollection<IContract> Contracts { get; set; } = new List<IContract>();
        public ICollection<IClientLog> ClientLogs { get; set; } = new List<IClientLog>();
        public ICollection<string> ReportPeriods { get; set; } = new List<string>();
        public ICollection<IReportCalls> Reports { get; set; } = new List<IReportCalls>();
        private void ConnectionHandler(object sender, IConnection connection)
        {
            IContract contract = Contracts.FirstOrDefault(x => x.Client.ClientTerminal.ClientNumberOfTelephone == connection.ClientNumberOfTelephone);
            if (contract != null)
            {
                ClientLogs.Add(new ClientLog(contract.Client, connection));
            }
            else
            {
                throw new Exception("С абонентом не заключен контракт");
            }
        }

        public void GetDetailedСallReportForReportPeriod(IClient client)
        {
            {
                bool isPeriod = false;
                while (isPeriod == false)
                {
                    MessageHandlerEvent(this, "Введите отчетный период (пример 01.2021)");
                    var inputStringh = "01." + Console.ReadLine();
                    isPeriod = DateTime.TryParse(inputStringh, out DateTime reportPeriod);
                    if (isPeriod)
                    {
                        try
                        {
                            var reportByPeriod = Reports.FirstOrDefault(x => x.ReportPeriod == reportPeriod.ToString("y"));
                            if (reportByPeriod == null)
                            {
                                var logsByReportPeriod = ClientLogs.Where(x => x.Client == client).
                               Where(x => x.Connections.FinishConnection.ToString("y") == reportPeriod.ToString("y")).ToList();
                                var DurationOfConversations = logsByReportPeriod.Sum(x => x.Connections.DurationConnection.Seconds);
                                decimal totalSummCollect = logsByReportPeriod.Sum(x => x.Cost);
                                if (logsByReportPeriod.Count != 0)
                                {
                                    reportByPeriod = new ReportCalls(client, reportPeriod.ToString("y"), client.TariffPlan, DurationOfConversations, client.Money, totalSummCollect, logsByReportPeriod);
                                    Reports.Add(reportByPeriod);
                                }
                                else
                                {
                                    MessageHandlerEvent(this, $"В данном отчетном периоде звонков не обнаружено");
                                }
                            }
                            PrintReportByPeriod(reportByPeriod, reportPeriod);
                        }
                        catch
                        {
                            throw new Exception("Ошибка в методе GetDetailedСallReportForReportPeriod");
                        }
                    }
                    else
                    {
                        MessageHandlerEvent(this, $"Не корректный ввод, введите дату в предложенном формате (пример 01.2021)");
                    }
                }
            }
        }
        private void PrintReportByPeriod(IReportCalls reportByPeriod, DateTime reportPeriod)
        {
            if (reportByPeriod != null)
            {
                MessageHandlerEvent(this, $"Клиент {reportByPeriod.Client_.Name} {reportByPeriod.Client_.LastName}");
                MessageHandlerEvent(this, $"Отчетный период {reportPeriod.ToString("y")}");
                var calls = reportByPeriod.Logs;
                if (calls != null)
                {
                    foreach (var log in calls)
                    {
                        MessageHandlerEvent(this, $"Исходящий номер {log.Connections.OutgoingNumber}, дата звонка {log.Connections.FinishConnection.ToString("dd.MM.yyyy HH:mm")}, продолжительность соединения {log.Connections.DurationConnection.Seconds}с, стоимость {log.Cost}руб.");
                    }
                    MessageHandlerEvent(this, $"Итого продолжительность звонков {reportByPeriod.DurationOfConversations}c, стоимость звонков {reportByPeriod.TotalSummCollect}руб., остаток на счете {reportByPeriod.Client_.Money}руб.");
                    MessageHandlerEvent(this, "");
                }
                else
                {
                    MessageHandlerEvent(this, $"В данном отчетном периоде звонков не обнаружено");
                }
            }
        }

        public void GetDetailedСallReportByClient(IClient client)
        {
            MessageHandlerEvent(this, $"Поиск по клиенту {client.Name} {client.LastName}");
            var clientLogs = ClientLogs.Where(x => x.Client == client).ToList();

            try
            {
                MessageHandlerEvent(this, $"Клиент {client.Name} {client.LastName}");
                if (clientLogs.Count != 0)
                {
                    foreach (var log in clientLogs)
                    {
                        MessageHandlerEvent(this, $"Исходящий номер {log.Connections.OutgoingNumber}, дата звонка {log.Connections.FinishConnection.ToString("dd.MM.yyyy HH:mm")}, продолжительность соединения {log.Connections.DurationConnection.Seconds}с, стоимость {log.Cost}руб.");
                    }
                    MessageHandlerEvent(this, "");
                }
                else
                {
                    MessageHandlerEvent(this, $"Для клиента {client.Name} {client.LastName} отчетов не обнаружено");
                }
            }
            catch
            {
                throw new Exception("GetDetailedСallReportByClient");
            }
        }

        public void GetDetailedСallReportByCallCost()
        {
            Console.WriteLine("Введите стоимость для поиска звонков (пример 0,05)");
            bool isCost = false;
            while (isCost == false)
            {
                isCost = Decimal.TryParse(Console.ReadLine(), out decimal costCall);
                if (isCost)
                {
                    try
                    {

                        var calls = ClientLogs.Where(x => x.Cost == costCall).ToList();
                        if (calls.Count() != 0)
                        {
                            MessageHandlerEvent(this, $"Поиск по стоимости звонка {costCall}");


                            foreach (var call in calls)
                            {
                                MessageHandlerEvent(this, $"Клиент {call.Client.Name} {call.Client.LastName}");
                                MessageHandlerEvent(this, $"Исходящий номер {call.Connections.OutgoingNumber}, дата звонка {call.Connections.FinishConnection.ToString("dd.MM.yyyy HH:mm")}, продолжительность соединения {call.Connections.DurationConnection.Seconds}с, стоимость {call.Cost}руб.");
                            }
                            MessageHandlerEvent(this, "");
                        }
                    }
                    catch
                    {
                        throw new Exception("GetDetailedСallReportByCallCost");
                    }
                }
                else
                {
                    MessageHandlerEvent(this, $"Не корректный ввод, введите стоимость звонка в предложенном формате (пример 0,05)");
                }
            }
        }

        public void GetDetailedСallReportByCallDate()
        {
            Console.WriteLine("Введите дату для поиска звонков (пример 15.01.2021)");
            bool isTime = false;
            while (isTime == false)
            {
                isTime = DateTime.TryParse(Console.ReadLine(), out DateTime dateTime);
                if (isTime)
                {
                    try
                    {
                        var calls = ClientLogs.Where(x => x.Connections.FinishConnection.ToString("dd.MM.yyyy") == dateTime.ToString("dd.MM.yyyy"));
                        if (calls.Count() > 0)
                        {
                            MessageHandlerEvent(this, $"Дата поиска {dateTime.ToString("dd.MM.yyyy")}");
                            foreach (var call in calls)
                            {
                                MessageHandlerEvent(this, $"Клиент {call.Client.Name} {call.Client.LastName}");
                                MessageHandlerEvent(this, $"Исходящий номер {call.Connections.OutgoingNumber}, дата звонка {call.Connections.FinishConnection.ToString("dd.MM.yyyy HH:mm")}, продолжительность соединения {call.Connections.DurationConnection.Seconds}с, стоимость {call.Cost}руб.");
                                MessageHandlerEvent(this, "");
                            }
                        }
                        else
                        {
                            MessageHandlerEvent(this, $"На данную дату отчетов не обнаружено");
                        }
                    }
                    catch
                    {
                        throw new Exception("Ошибка в методе GetDetailedСallReportByCallDate");
                    }
                }
                else
                {
                    MessageHandlerEvent(this, $"Не корректный ввод, введите дату в предложенном формате (пример 15.01.2021)");
                }
            }
        }
        public void CalculateSubscriptionFeeMonthlyForReportPeriod()
        {
            try
            {
                var сurrentDate = DateTime.Now;
                var previosMonthDate = сurrentDate.AddMonths(-1);
                var previosMonthYear = previosMonthDate.ToString("y");
                if (ReportPeriods.Contains(previosMonthYear))
                {
                    throw new Exception("Расчет абонентской платы за данный период уже был произведен");
                }
                else
                {
                    IList<IClient> ClientsToCalculte = Contracts.Where(x => x.DateCreate.Month == сurrentDate/*previosMonthDate*/.Month).Select(x => x.Client).ToList();
                    ClientsToCalculte.ToList().ForEach(x => x.Money -= x.TariffPlan.SubscriptionFeeMonthly);
                    ReportPeriods.Add(previosMonthYear);
                }
            }
            catch
            {
                throw new Exception("Ошибка в методе CalculateSubscriptionFeeMonthlyForReportPeriod");
            }
        }
        public void ClearEvents() 
        {
            MessageHandlerEvent = null;
            Company.Station.CallController.SaveConnection-= ConnectionHandler;
        }
    }
}