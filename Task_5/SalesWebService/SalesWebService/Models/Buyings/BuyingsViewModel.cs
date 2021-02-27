using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesReportConverter.Model_.Models;

namespace SalesWebService.Models.Buyings
{
    public class BuyingsViewModel
    {
        public Buying Buying { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSecondName { get; set; }
        public string Buyer { get; set; }
        public string Product { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Cost { get; set; }
    }
}
