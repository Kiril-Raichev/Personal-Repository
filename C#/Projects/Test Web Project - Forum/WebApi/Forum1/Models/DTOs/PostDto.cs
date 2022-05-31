using System.ComponentModel.DataAnnotations;

namespace Forum1.Models
{
    public class PostDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]

        [StringLength(64, MinimumLength = 4, ErrorMessage = "Value for {0} must be {1} to {2}")]
        public string Title { get; set; }
        [StringLength(8192, MinimumLength = 4, ErrorMessage = "Value for {0} must be {1} to {2}")]
        public string Content { get; set; }
    }
}
