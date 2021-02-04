using SalesReportConverter.BL_.Abstractions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace SalesReportConverter.BL_.CSVHandler
{
    public class ParserCSV : IParser<CSVModel>
    {
        public ICollection<CSVModel> GetModels(string fileName)
        {
            ICollection<CSVModel> CSVmodels = new List<CSVModel>();
            try
            {
                IReader reader = new Reader();
                ICollection<string> CSVItems = reader.ReadStrings(fileName);
                string nameManager = GetNameFromFileName(fileName);
                DateTime reportDate = GetDateTimeFromFileName(fileName);

                foreach (var item in CSVItems)
                {
                    var splitSting = item.Split(new char[] { ';', ',' }); ;
                    DateTime purchaseDate = GetPurchaseDateTimeFromString(splitSting[0]);
                    string client = splitSting[1];
                    string product = splitSting[2];
                    decimal cost = GetCostFromString(splitSting[3]);
                    CSVmodels.Add(new CSVModel(nameManager, reportDate, purchaseDate, client, product, cost));
                }
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException("Ошибка в методе GetModels", ex);
            }
            BackUp(fileName);
            return CSVmodels;
        }

        private DateTime GetPurchaseDateTimeFromString(string date)
        {
            var stringPurchaseDate = date.Split('.');
            string dateDD = stringPurchaseDate[0];
            string dateMM = stringPurchaseDate[1];
            string dateYYY = stringPurchaseDate[2];
            string date_hh = stringPurchaseDate[3];
            string date_mm = stringPurchaseDate[4];
            string date_ss = stringPurchaseDate[5];

            bool dateDDConvertSuccess = int.TryParse(dateDD, out int day);
            bool dateMMConvertSuccess = int.TryParse(dateMM, out int month);
            bool dateYYYConvertSuccess = int.TryParse(dateYYY, out int year);
            bool date_hhConvertSuccess = int.TryParse(date_hh, out int hour);
            bool date_mmConvertSuccess = int.TryParse(date_mm, out int minute);
            bool date_ssConvertSuccess = int.TryParse(date_ss, out int second);

            if (dateDDConvertSuccess && dateMMConvertSuccess && dateYYYConvertSuccess && date_hhConvertSuccess && date_mmConvertSuccess && date_ssConvertSuccess)
            {
                DateTime purchaseDate = new DateTime(year, month, day, hour, minute, second);
                return purchaseDate;
            }
            else
            {
                throw new Exception("Ошибка в файле отчета:неверный формат даты (пример:30.01.2021.18.42.36)");
            }
        }
        private decimal GetCostFromString(string stringCost)
        {
            bool costToDecimal = Decimal.TryParse(stringCost, NumberStyles.Currency, new CultureInfo("en-US"), out decimal cost);
            if (costToDecimal)
            {
                return cost;
            }
            else
            {
                throw new Exception("Ошибка в файле отчета:неверный формат стоимости товара (пример:30.5)");
            }

        }

        private string GetNameFromFileName(string fileName)
        {
            var splitFileName = fileName.Split(new char[] { '_', '.' });
            return splitFileName[0];
        }
        private DateTime GetDateTimeFromFileName(string fileName)
        {
            var splitFileName = fileName.Split(new char[] { '_', '.' });
            if (splitFileName[1].Length == 8)
            {
                string dateDD = splitFileName[1].Substring(0, 2);
                string dateMM = splitFileName[1].Substring(2, 2);
                string dateYYY = splitFileName[1].Substring(4);
                bool dateDDConvertSuccess = int.TryParse(dateDD, out int day);
                bool dateMMConvertSuccess = int.TryParse(dateMM, out int month);
                bool dateYYYConvertSuccess = int.TryParse(dateYYY, out int year);

                if (dateDDConvertSuccess && dateMMConvertSuccess && dateYYYConvertSuccess)
                {
                    DateTime reportDate = new DateTime(year, month, day);
                    return reportDate;
                }
                else
                {
                    throw new Exception("Неверный формат названия файла отёта (пример:Ivanov_19112012.csv ) ");
                }
            }
            else
            {
                throw new Exception("Неверный формат названия файла отёта (пример:Ivanov_19112012.csv ) ");
            }

        }

        private void BackUp(string fileName)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("WatcherFolderPath");
                string filePuth = ConfigurationManager.AppSettings.Get("WatcherFolderPath") + "\\" + fileName;
                FileInfo fileInfo = new FileInfo(ConfigurationManager.AppSettings.Get("WatcherFolderPath") + "\\" + fileName);
                fileInfo.MoveTo(ConfigurationManager.AppSettings.Get("HandledFilesPath") + fileName);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException("Ошибка в методе BackUp", ex);
            }
        }

    }
}
