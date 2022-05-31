using System.ComponentModel.DataAnnotations;

namespace Forum1.Models
{
    public class UserDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Value for {0} must be {1} to {2}")]
        public string FirstName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Value for {0} must be {1} to {2}")]
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }    
        [EmailAddress]
        public string Email { get; set; }
    }
}
