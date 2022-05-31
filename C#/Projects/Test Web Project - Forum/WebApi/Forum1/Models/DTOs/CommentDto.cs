using System.ComponentModel.DataAnnotations;

namespace Forum1.Models
{
    public class CommentDto
    {
        [StringLength(8192, MinimumLength = 3, ErrorMessage = "Value for {0} must be {1} to {2}")]
        public string Content { get; set; }
        
        [Required]
        public string PostTitle { get; set; }
    }
}
