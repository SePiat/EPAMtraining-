using SalesReportConverter.Model_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebService.Models.Buyings
{
    public class BuyingsCreateViewModel
    {        
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string ManagerName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string ManagerSecondName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Buyer { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Product { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }
}
