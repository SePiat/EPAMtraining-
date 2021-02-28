using System.ComponentModel.DataAnnotations;

namespace SalesWebService.Models.Products
{
    public class ProductsCreateEditViewModel
    {
        public int Id { get; set; }
        [Required]      
        public string Name { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }
}
