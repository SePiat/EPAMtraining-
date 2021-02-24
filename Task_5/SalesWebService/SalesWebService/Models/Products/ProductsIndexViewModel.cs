using SalesReportConverter.Model_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebService.Models.Products
{
    public class ProductsIndexViewModel
    {
        public Product Product { get; set; }
        public int CountBuyers { get; set; }
    }
}
