using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebService.Models.Buyers
{
    public class BuyersCreateEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Za-zА-Я\s]+",ErrorMessage = "Error, enter only letters")]
        [StringLength(20, MinimumLength = 3)]
        public string FullName { get; set; }
    }
}
