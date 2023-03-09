using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EF_Core.ViewModels
{
    public class SupermarketCreateAndEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be more than 50 characters!")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Address cannot be more than 50 characters!")]
        public string? Address { get; set; }
    }
}
