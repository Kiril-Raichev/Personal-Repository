using Forum1.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Forum1.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(16), MaxLength(64)]
        public string Title { get; set; }
        [Required, MinLength(32), MaxLength(8192)]
        public string Content { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Reaction> PostReactions { get; set; } = new List<Reaction>();

        public override string ToString() => JsonSerializer.Serialize<Post>(this);
    }
}
