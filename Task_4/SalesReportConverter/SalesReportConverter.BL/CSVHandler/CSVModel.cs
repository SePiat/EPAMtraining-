using System;
using System.Collections.Generic;
using System.Text;

namespace SalesReportConverter.BL.CSVHandler
{
    public class CSVModel
    {
        public CSVModel(string manager, DateTime reportDate, DateTime purchaseDate, string client, string product, decimal cost)
        {
            Manager = manager;
            ReportDate = reportDate;
            PurchaseDate = purchaseDate;
            Client = client;
            Product = product;
            Cost = cost;
        }

        public string Manager { get;}
        public DateTime ReportDate { get;}
        public DateTime PurchaseDate { get;}
        public string Client { get;}
        public string Product { get;}
        public decimal Cost { get;}

        
    }
}
