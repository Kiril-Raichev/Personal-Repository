using System.ComponentModel.DataAnnotations;

namespace Forum1.Models
{
    public class PostDto
    {
        [StringLength(64, MinimumLength = 16, ErrorMessage = "Value for {0} must be {1} to {2}")]
        public string Title { get; set; }
        [StringLength(8192, MinimumLength = 32, ErrorMessage = "Value for {0} must be {1} to {2}")]
        public string Content { get; set; }
    }
}
