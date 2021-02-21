using SalesReportConverter.Model_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebService.Models.Managers
{
    public class ManagersIndexViewModel
    {
        public Manager Manager { get; set; }
        public int CountBuyers { get; set; }       
    }
}
