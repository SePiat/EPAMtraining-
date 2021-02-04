using System;
using System.Collections.Generic;
using System.Text;

namespace SalesReportConverter.Model_.Models
{
    public class Buying
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public virtual Manager Manager {get;set;}
        public int BuyerId { get; set; }
        public virtual Buyer Buyer { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Cost { get; set; }
    }
}
