using System.ComponentModel.DataAnnotations;

namespace Forum1.Models.Mappers
{
    public class CommentDto
    {
        [StringLength(8192, MinimumLength = 32, ErrorMessage = "Value for {0} must be {1} to {2}")]
        public string Content { get; set; }
    }
}
