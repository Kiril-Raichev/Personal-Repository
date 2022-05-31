using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [StringLength(8192, MinimumLength = 32, ErrorMessage = "Value for {0} must be {1} to {2}")]
        public string Content { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Reaction> PostReactions { get; set; } = new List<Reaction>();
    }
}