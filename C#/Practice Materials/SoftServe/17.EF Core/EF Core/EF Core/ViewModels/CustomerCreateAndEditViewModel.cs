using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EF_Core.ViewModels
{
    public class CustomerCreateAndEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        [MaxLength(50, ErrorMessage = "First Name cannot be more than 50 characters!")]
        public string? FName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [MaxLength(50, ErrorMessage ="Last Name cannot be more than 50 characters!")]
        public string? LName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Address cannot be more than 50 characters!")]
        public string? Address { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Discount { get; set; }
    }
}
