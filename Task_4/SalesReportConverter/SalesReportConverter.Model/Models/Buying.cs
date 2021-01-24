using System;
using System.Collections.Generic;
using System.Text;

namespace SalesReportConverter.Model.Models
{
    public class Buying
    {
        public int Id { get; set; }
        public virtual Manager Manager {get;set;}
        public virtual Buyer Buyer { get; set; }
        public virtual Product Product { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Cost { get; set; }
    }
}
