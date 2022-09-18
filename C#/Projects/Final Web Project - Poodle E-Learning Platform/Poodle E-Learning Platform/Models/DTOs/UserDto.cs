using System.ComponentModel.DataAnnotations;

namespace Poodle_E_Learning_Platform.Models.DTOs
{
    public class UserDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage ="The {0} field is required and must not be empty!")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Value for {0} must be between {2} and {1} characters!")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty!")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Value for {0} must be between {2} and {1} characters!")]
        public string LastName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

    }
}
