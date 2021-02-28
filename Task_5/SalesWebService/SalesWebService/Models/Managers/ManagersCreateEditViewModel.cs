using System.ComponentModel.DataAnnotations;

namespace SalesWebService.Models.Managers
{
    public class ManagersCreateEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Za-zА-Я\s]+", ErrorMessage = "Error, enter only letters")]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Za-zА-Я\s]+", ErrorMessage = "Error, enter only letters")]
        [StringLength(20, MinimumLength = 3)]
        public string SecondName { get; set; }

    }
}
