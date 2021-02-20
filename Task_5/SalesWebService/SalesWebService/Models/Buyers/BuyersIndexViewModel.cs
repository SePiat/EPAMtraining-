using SalesReportConverter.Model_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebService.Models.Buyers
{
    public class BuyersIndexViewModel
    {        
        public Buyer Buyer { get; set; }
        public int CountBuyings { get; set; }
    }
}
